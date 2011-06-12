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
using de.ahzf.Pipes.ExtensionMethods;
using de.ahzf.Hermod;
using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.HTTP.Common;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera JSON service implementation.
    /// </summary>
    public class GeraService_JSON : AGeraService, IGeraService
    {

        #region Data

        private readonly Byte[] JSON_Success;

        #endregion

        #region Constructor(s)

        #region GeraService_JSON()

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        public GeraService_JSON()
        {
            _HTTPContentTypes = new List<HTTPContentType>() { HTTPContentType.JSON_UTF8 };
            JSON_Success      = Encoding.UTF8.GetBytes(new JObject(new JProperty("result", "success")).ToString());
        }

        #endregion

        #region GeraService_JSON(myIHTTPConnection)

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        /// <param name="myIHTTPConnection">The http connection for this request.</param>
        public GeraService_JSON(IHTTPConnection myIHTTPConnection)
        {
            IHTTPConnection   = myIHTTPConnection;
            _HTTPContentTypes = new List<HTTPContentType>() { HTTPContentType.JSON_UTF8 };
            JSON_Success      = Encoding.UTF8.GetBytes(new JObject(new JProperty("result", "success")).ToString());
        }

        #endregion

        #endregion



        #region GetLandingpage()

        /// <summary>
        /// The HTML landing page.
        /// </summary>
        /// <example>
        /// $ curl -H "Accept: application/json" http://127.0.0.1:8182
        /// {
        ///   "AccountIds": [
        ///     "Account1"
        ///   ]
        /// }
        /// </example>
        public HTTPResponse GetLandingpage()
        {

            var _Content = Encoding.UTF8.GetBytes(new JObject(new JProperty("AccountIds", GeraServer.AccountIds.MapEach(_AccountId => _AccountId.ToString()))).ToString());

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.JSON_UTF8
                },

                _Content

            );

        }

        #endregion

        #region Accounts

        #region ListAccountIds()

        /// <summary>
        /// Return a list of valid accounts.
        /// </summary>
        /// <example>
        /// $ curl _X GET  -H "Accept: application/json" http://127.0.0.1:8182/Accounts
        /// {
        ///   "AccountIds": [
        ///     "Account1"
        ///   ]
        /// }
        /// </example>
        public HTTPResponse ListValidAccounts()
        {

            var _Content = Encoding.UTF8.GetBytes(new JObject(new JProperty("AccountIds", GeraServer.AccountIds.MapEach(_AccountId => _AccountId.ToString()))).ToString());

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.JSON_UTF8
                },

                _Content

            );

        }

        #endregion

        #region CreateNewRandomAccount()

        /// <summary>
        /// Create a new account using a random AccountId.
        /// </summary>
        /// <example>
        /// $ curl -X POST -H "Accept: application/json" http://127.0.0.1:8182/Accounts
        /// {
        ///   "AccountId": "9b659ee8-1521-4d55-a24a-9c03814bdb4e"
        /// }
        /// </example>
        public HTTPResponse CreateNewRandomAccount()
        {

            var _Content = Encoding.UTF8.GetBytes(new JObject(new JProperty("AccountId", GeraServer.CreateAccount().Id.ToString())).ToString());

            return new HTTPResponse(

                new HTTPResponseHeader()
                {
                    HttpStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.JSON_UTF8
                },

                _Content

            );

        }

        #endregion

        #region CreateNewAccount()

        /// <summary>
        /// Create a new account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        /// <example>
        /// $ curl -X PUT -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "AccountId": "ABC"
        /// }
        /// </example>
        public HTTPResponse CreateNewAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.BadRequest,
                        CacheControl   = "no-cache",
                    }
                );
            }

            #endregion

            var _NewAccountId = new AccountId(AccountId);

            if (!GeraServer.HasAccount(_NewAccountId))
            {

                var _Content = Encoding.UTF8.GetBytes(new JObject(new JProperty("AccountId", GeraServer.CreateAccount(AccountId: _NewAccountId).Id.ToString())).ToString());

                return new HTTPResponse(

                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.JSON_UTF8
                    },

                    _Content

                );

            }


            #region ...or conflict!

            else
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.Conflict,
                        CacheControl   = "no-cache",
                    }
                );
            }

            #endregion

        }

        #endregion

        #region GetAccountInformation(AccountId)

        /// <summary>
        ///  Get information on the given account.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        /// <example>
        /// $ curl -X GET -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "AccountId": "ABC",
        ///   "Repositories": []
        /// }
        /// </example>
        public HTTPResponse GetAccountInformation(String AccountId)
        {

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
            {

                var _Content = Encoding.UTF8.GetBytes(
                                   new JObject(new JProperty("AccountId", AccountId),
                                               new JProperty("Repositories", new JArray(
                                                   from   _RepositoryId
                                                   in     _Account.RepositoryIds
                                                   select _RepositoryId.ToString()))).
                                   ToString());

                return new HTTPResponse(

                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.JSON_UTF8
                    },

                    _Content

                );

            }


            #region ...invalid AccountId!

            else
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                        ContentLength  = 0,
                    }
                );
            }

            #endregion

        }

        #endregion

        #region DeleteAccount()

        /// <summary>
        /// Delete an account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        /// <example>
        /// $ curl -X DELETE -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "result": "success"
        /// }
        /// </example>
        public HTTPResponse DeleteAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.BadRequest,
                        CacheControl   = "no-cache",
                    }
                );
            }

            #endregion

            var _AccountId = new AccountId(AccountId);

            if (GeraServer.HasAccount(_AccountId))
            {

                if (GeraServer.DeleteAccount(_AccountId))
                {

                    return new HTTPResponse(

                        new HTTPResponseHeader()
                        {
                            HttpStatusCode = HTTPStatusCode.OK,
                            CacheControl   = "no-cache",
                            ContentLength  = (UInt64) JSON_Success.Length,
                            ContentType    = HTTPContentType.JSON_UTF8
                        },

                        JSON_Success

                    );


                }

                else return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.InternalServerError,
                        CacheControl   = "no-cache"
                    }
                );

            }


            #region ...or not found!

            else
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                    }
                );
            }

            #endregion

        }

        #endregion

        #endregion


        #region ListRepositories()

        public HTTPResponse ListRepositories(String AccountId)
        {

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
            {

                var _Content = Encoding.UTF8.GetBytes(
                                   new JArray(from   _RepositoryId
                                              in     _Account.RepositoryIds
                                              select _RepositoryId.ToString()).
                                   ToString());

                return new HTTPResponse(

                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.JSON_UTF8
                    },

                    _Content

                );

            }


            #region ...invalid AccountId!

            else
            {
                return new HTTPResponse(
                    new HTTPResponseHeader()
                    {
                        HttpStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                        ContentLength  = 0,
                    }
                );
            }

            #endregion

        }

        #endregion


    }

}

