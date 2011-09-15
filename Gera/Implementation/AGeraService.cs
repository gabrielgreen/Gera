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

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera HTML service implementation.
    /// </summary>
    public abstract class AGeraService : AHTTPService
    {

        #region Data

        /// <summary>
        /// A list of supported HTTP ContentTypes.
        /// </summary>
        protected IEnumerable<HTTPContentType> _HTTPContentTypes;

        #endregion

        #region Properties

        public IHTTPConnection IHTTPConnection { get; protected set; }
        public GeraServer      GeraServer      { get; set; }

        #endregion

        #region Constructor(s)

        #region AGeraService()

        /// <summary>
        /// Creates a new abstract AGeraService.
        /// </summary>
        public AGeraService()
        { }

        #endregion

        #endregion

        
        #region HTTPContentTypes

        /// <summary>
        /// A list of supported HTTP ContentTypes.
        /// </summary>
        public IEnumerable<HTTPContentType> HTTPContentTypes
        {
            get
            {
                return _HTTPContentTypes;
            }
        }

        #endregion


        #region (protected) TryGetGraph(myGraph, out myIGraph, out myHTTPErrorResponse)

        ///// <summary>
        ///// Returns a valid IGraph object or a HTTP error.
        ///// </summary>
        ///// <param name="myGraph">The name of the graph.</param>
        ///// <param name="myIGraph">The IGraph object.</param>
        ///// <param name="myHTTPErrorResponse">The HTTP error.</param>
        ///// <returns>true|false</returns>
        //protected Boolean TryGetGraph(String myGraph, out IGraph myIGraph, out HTTPResponse myHTTPErrorResponse)
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

        #region (protected) IsValidAccountId(AccountId)

        protected Boolean IsValidAccountId(String AccountId)
        {

            if (AccountId == "Account")
                return false;

            if (AccountId == "Accounts")
                return false;

            if (AccountId == "resources")
                return false;

            return true;

        }

        #endregion

        #region (protected) IsValidAccountId(VertexId)

        protected Boolean IsValidAccountId(VertexId VertexId)
        {
            return IsValidAccountId(VertexId.ToString());
        }

        #endregion



        #region GetResources(myResource)

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        /// <param name="myResource">The path and name of the resource.</param>
        public HTTPResponseHeader GetResources(String myResource)
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
                    case "htm":  _ResponseContentType = HTTPContentType.HTML_UTF8;       break;
                    case "html": _ResponseContentType = HTTPContentType.HTML_UTF8;       break;
                    case "css":  _ResponseContentType = HTTPContentType.CSS_UTF8;        break;
                    case "gif":  _ResponseContentType = HTTPContentType.GIF;             break;
                    case "ico":  _ResponseContentType = HTTPContentType.ICO;             break;
                    case "swf":  _ResponseContentType = HTTPContentType.SWF;             break;
                    case "js":   _ResponseContentType = HTTPContentType.JAVASCRIPT_UTF8; break;
                    default:     _ResponseContentType = HTTPContentType.OCTETSTREAM;     break;
                }

                return new HTTPResponseBuilder() {
                            HTTPStatusCode = HTTPStatusCode.OK,
                            ContentType    = _ResponseContentType,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                            ContentStream  = _ResourceContent
                };

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

                return new HTTPResponseBuilder() {
                            HTTPStatusCode = HTTPStatusCode.NotFound,
                            ContentType    = HTTPContentType.HTML_UTF8,
                            ContentLength  = (UInt64) _ResourceContent.Length,
                            CacheControl   = "no-cache",
                            Connection     = "close",
                            ContentStream  = _ResourceContent
                        };

            }

            #endregion

        }

        #endregion

        #region GetFavicon()

        /// <summary>
        /// Returns the favicon.ico.
        /// </summary>
        public HTTPResponseHeader GetFavicon()
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
        public HTTPResponseHeader GetError(String myHTTPStatusCode)
        {

            IHTTPConnection.ResponseHeader.HTTPStatusCode = HTTPStatusCode.ParseString(myHTTPStatusCode);

            if (IHTTPConnection.RequestHeader.QueryString.ContainsKey("reason"))
                IHTTPConnection.ErrorReason = String.Join(", ", IHTTPConnection.RequestHeader.QueryString["reason"]);

            return new HTTPResponseBuilder() {
                HTTPStatusCode = IHTTPConnection.ResponseHeader.HTTPStatusCode,
                Connection     = "close"
            };

        }

        #endregion

    }

}

