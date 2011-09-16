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
using System.Reflection;
using System.Collections.Generic;

using de.ahzf.Blueprints;

using de.ahzf.Hermod.HTTP;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera HTML service implementation.
    /// </summary>
    public abstract class AGeraService : AHTTPService
    {

        #region Properties

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

        #region AGeraService(HTTPContentType)

        /// <summary>
        /// Creates a new abstract GeraService.
        /// </summary>
        /// <param name="HTTPContentType">A content type.</param>
        public AGeraService(HTTPContentType HTTPContentType)
            : base(HTTPContentType)
        { }

        #endregion

        #region AGeraService(HTTPContentTypes)

        /// <summary>
        /// Creates a new abstract GeraService.
        /// </summary>
        public AGeraService(IEnumerable<HTTPContentType> HTTPContentTypes)
        { }

        #endregion

        #region AGeraService(IHTTPConnection, HTTPContentType, ResourcePath)

        /// <summary>
        /// Creates a new abstract AGeraService.
        /// </summary>
        public AGeraService(IHTTPConnection IHTTPConnection, HTTPContentType HTTPContentType, String ResourcePath)
            : base(IHTTPConnection, HTTPContentType, ResourcePath)
        {
            this.CallingAssembly = Assembly.GetExecutingAssembly();
        }

        #endregion

        #region AGeraService(IHTTPConnection, HTTPContentTypes, ResourcePath)

        /// <summary>
        /// Creates a new abstract AGeraService.
        /// </summary>
        public AGeraService(IHTTPConnection IHTTPConnection, IEnumerable<HTTPContentType> HTTPContentTypes, String ResourcePath)
            : base(IHTTPConnection, HTTPContentTypes, ResourcePath)
        {
            this.CallingAssembly = Assembly.GetExecutingAssembly();
        }

        #endregion

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

