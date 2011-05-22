/*
 * Copyright (c) 2010-2011 Achim 'ahzf' Friedland <achim.friedland@aperis.com>
 * This file is part of Gera <http://www.github.com/ahzf/Gera>
 *
 * Licensed under the Affero GPL license, Version 3.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.gnu.org/licenses/agpl.html
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using de.ahzf.Blueprints;

using de.ahzf.Hermod;
using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.HTTP.Common;

using Newtonsoft.Json.Linq;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// The Gera service implementation.
    /// </summary>
    public class GeraService : IGeraService
    {

        
        #region Data

        #endregion

        #region Properties

        #region IHTTPConnection

        public IHTTPConnection IHTTPConnection { get; private set; }

        #endregion

        #region Graphs

        #endregion

        #endregion

        #region Constructor(s)

        #region GeraService()

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        public GeraService()
        { }

        #endregion

        #region GeraService(myIHTTPConnection)

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        /// <param name="myIHTTPConnection">The http connection for this request.</param>
        public GeraService(IHTTPConnection myIHTTPConnection)
        {
            IHTTPConnection = myIHTTPConnection;
        }

        #endregion

        #endregion



        #region (private) HTMLBuilder(myHeadline, myFunc)

        /// <summary>
        /// A little HTML genereator...
        /// </summary>
        /// <param name="myHeadline"></param>
        /// <param name="myFunc"></param>
        /// <returns></returns>
        private String HTMLBuilder(String myHeadline, Action<StringBuilder> myFunc)
        {

            var _StringBuilder = new StringBuilder();

            _StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _StringBuilder.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">");
            _StringBuilder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            _StringBuilder.AppendLine("<head>");
            _StringBuilder.AppendLine("<title>Gera</title>");
            _StringBuilder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"/resources/style.css\" />");
            _StringBuilder.AppendLine("</head>");
            _StringBuilder.AppendLine("<body>");
            _StringBuilder.Append("<h1>").Append(myHeadline).AppendLine("</h1>");
            _StringBuilder.AppendLine("<table>");
            _StringBuilder.AppendLine("<tr>");
            _StringBuilder.AppendLine("<td style=\"width: 100px\">&nbsp;</td>");
            _StringBuilder.AppendLine("<td>");

            myFunc(_StringBuilder);

            _StringBuilder.AppendLine("</td>");
            _StringBuilder.AppendLine("</tr>");
            _StringBuilder.AppendLine("</table>");
            _StringBuilder.AppendLine("</body>");
            _StringBuilder.AppendLine("</html>").AppendLine();

            return _StringBuilder.ToString();

        }

        #endregion

        #region (private) TryGetGraph(myGraph, out myIGraph, out myHTTPErrorResponse)

        ///// <summary>
        ///// Returns a valid IGraph object or a HTTP error.
        ///// </summary>
        ///// <param name="myGraph">The name of the graph.</param>
        ///// <param name="myIGraph">The IGraph object.</param>
        ///// <param name="myHTTPErrorResponse">The HTTP error.</param>
        ///// <returns>true|false</returns>
        //private Boolean TryGetGraph(String myGraph, out IGraph myIGraph, out HTTPResponse myHTTPErrorResponse)
        //{

        //    myHTTPErrorResponse = null;

        //    if (myGraph  == null ||
        //        myGraph  == ""   ||
        //        !Graphs.TryGetValue(myGraph, out myIGraph) ||
        //        myIGraph == null)
        //    {

        //        myHTTPErrorResponse = new HTTPResponse(

        //            new HTTPResponseHeader()
        //            {
        //                HttpStatusCode = HTTPStatusCode.NotFound,
        //                CacheControl   = "no-cache",
        //                ContentType    = HTTPContentType.TEXT_UTF8
        //            },

        //            "Invalid graph name!".ToUTF8Bytes()

        //        );

        //        myIGraph = null;

        //        return false;

        //    }

        //    return true;

        //}

        #endregion



        #region GetResources(myResource)

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        /// <param name="myResource">The path and name of the resource.</param>
        public HTTPResponse GetResources(String myResource)
        {

            #region Data

            var _Assembly     = Assembly.GetExecutingAssembly();
            var _AllResources = _Assembly.GetManifestResourceNames();

            myResource = myResource.Replace('/', '.');

            #endregion

            #region Return internal assembly resources...

            if (_AllResources.Contains("Gera.resources." + myResource))
            {

                var _ResourceContent = _Assembly.GetManifestResourceStream("Gera.resources." + myResource);

                HTTPContentType _ResponseContentType = null;

                // Get the apropriate content type based on the suffix of the requested resource
                switch (myResource.Remove(0, myResource.LastIndexOf(".") + 1))
                {
                    case "htm":  _ResponseContentType = HTTPContentType.XHTML_UTF8;      break;
                    case "html": _ResponseContentType = HTTPContentType.XHTML_UTF8;      break;
                    case "css":  _ResponseContentType = HTTPContentType.CSS_UTF8;        break;
                    case "gif":  _ResponseContentType = HTTPContentType.GIF;             break;
                    case "ico":  _ResponseContentType = HTTPContentType.ICO;             break;
                    case "swf":  _ResponseContentType = HTTPContentType.SWF;             break;
                    case "js":   _ResponseContentType = HTTPContentType.JAVASCRIPT_UTF8; break;
                    default:     _ResponseContentType = HTTPContentType.OCTETSTREAM;     break;
                }

                return new HTTPResponse(

                    new HTTPResponseHeader()
                        {
                            HttpStatusCode = HTTPStatusCode.OK,
                            ContentType    = _ResponseContentType,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                        },

                    _ResourceContent

                );

            }

            #endregion

            #region ...or send an (custom) error 404!

            else
            {
                
                Stream _ResourceContent = null;

                if (_AllResources.Contains("Gera.resources.errorpages.Error404.html"))
                    _ResourceContent = _Assembly.GetManifestResourceStream("Gera.resources.errorpages.Error404.html");
                else
                    _ResourceContent = new MemoryStream(UTF8Encoding.UTF8.GetBytes("Error 404 - File not found!"));

                return new HTTPResponse(

                    new HTTPResponseHeader()
                        {
                            HttpStatusCode = HTTPStatusCode.NotFound,
                            ContentType    = HTTPContentType.XHTML_UTF8,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                        },

                    _ResourceContent

                );

            }

            #endregion

        }

        #endregion

        #region GetFavicon()

        /// <summary>
        /// Returns the favicon.ico.
        /// </summary>
        public HTTPResponse GetFavicon()
        {
            return GetResources("favicon.ico");
        }

        #endregion

        #region GetError(myHTTPStatusCode)

        /// <summary>
        /// Get a http error for debugging purposes.
        /// An additional error reason may be given via the
        /// QueryString (e.g. "/error/204&reason=unknown")
        /// </summary>
        /// <param name="myHTTPStatusCode">The http status code.</param>
        public HTTPResponse GetError(String myHTTPStatusCode)
        {

            IHTTPConnection.ResponseHeader.HttpStatusCode = HTTPStatusCode.ParseString(myHTTPStatusCode);

            if (IHTTPConnection.RequestHeader.QueryString.ContainsKey("reason"))
                IHTTPConnection.ErrorReason = IHTTPConnection.RequestHeader.QueryString["reason"];

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = IHTTPConnection.ResponseHeader.HttpStatusCode,
                    Connection     = "close"
                }

            );

        }

        #endregion

        
    }

}

