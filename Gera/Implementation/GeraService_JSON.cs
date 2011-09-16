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
using System.Text;
using System.Linq;
using System.Collections.Generic;

using de.ahzf.Pipes.ExtensionMethods;
using de.ahzf.Hermod;
using de.ahzf.Hermod.HTTP;

using Newtonsoft.Json.Linq;

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
        
        private const String __AccountId = "AccountId";
        private const String __Metadata  = "Metadata";

        #endregion

        #region Constructor(s)

        #region GeraService_JSON()

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        public GeraService_JSON()
            : base(HTTPContentType.JSON_UTF8)
        { }

        #endregion

        #region GeraService_JSON(IHTTPConnection)

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        /// <param name="IHTTPConnection">The http connection for this request.</param>
        public GeraService_JSON(IHTTPConnection IHTTPConnection)
            : base(IHTTPConnection, HTTPContentType.JSON_UTF8, "Gera.resources.")
        {
            JSON_Success      = new JObject(new JProperty("result", "success")).ToString().ToUTF8Bytes();
        }

        #endregion

        #endregion


        #region (private) ParseMetadata()

        /// <summary>
        /// Parse the JSON metadata from the http request body.
        /// </summary>
        /// <returns>A metadata dictionary.</returns>
        private IDictionary<String, Object> ParseMetadata()
        {

            var _Metadata = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);

            #region Decode RequestBody

            if (IHTTPConnection.RequestBody == null)
                return _Metadata;

            var _RequestBody = Encoding.UTF8.GetString(IHTTPConnection.RequestBody);
            if (_RequestBody == null)
                return _Metadata;

            #endregion

            #region Parse JSON

            JObject _JSONRequest = null;

            try
            {
                _JSONRequest = JObject.Parse(_RequestBody);
            }
            catch (Exception)
            { }

            if (_JSONRequest == null)
                return _Metadata;

            #endregion

            #region Get JSON metadata

            var _JSONMetadata = _JSONRequest[__Metadata] as JObject;
            if (_JSONMetadata == null) _JSONMetadata = _JSONRequest[__Metadata.ToLower()] as JObject;
            if (_JSONMetadata == null)
                return _Metadata;

            #endregion

            #region Add valid KeyValuePairs

            foreach (var _KeyValuePair in _JSONMetadata)
            {
                
                var _Value = _KeyValuePair.Value.ToString().Trim();

                if (!_Value.StartsWith("{") && !_Value.StartsWith("["))
                {

                    // Add as string...
                    if (_Value.StartsWith("\"") && _Value.EndsWith("\""))
                        _Metadata.Add(_KeyValuePair.Key.ToString(), _Value.Substring(1, _Value.Length - 2));

                    // ...or try to parse as Int64!
                    else
                    {
                        Int64 _Int64;
                        if (Int64.TryParse(_Value, out _Int64))
                            _Metadata.Add(_KeyValuePair.Key.ToString(), _Int64);
                    }

                }

            }

            #endregion

            return _Metadata;

        }

        #endregion


        #region GetRoot()

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
        public HTTPResponseHeader GetRoot()
        {

            var _Content = Encoding.UTF8.GetBytes(new JObject(
                               new JProperty("AccountIds", GeraServer.AccountIds.MapEach(_AccountId => _AccountId.ToString()))
                           ).ToString());

            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.JSON_UTF8,
                    Content        = _Content
            };

        }

        #endregion

        #region Accounts

        #region ListAccountIds()

        /// <summary>
        /// Return a list of valid accounts.
        /// </summary>
        /// <example>
        /// $ curl -X GET  -H "Accept: application/json" http://127.0.0.1:8182/Accounts
        /// {
        ///   "AccountIds": [
        ///     "Account1"
        ///   ]
        /// }
        /// </example>
        public HTTPResponseHeader ListValidAccounts()
        {

            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentType    = HTTPContentType.JSON_UTF8,
                    Content        = new JObject(
                                        new JProperty("AccountIds", GeraServer.AccountIds.MapEach(_AccountId => _AccountId.ToString()))
                                     ).ToString().ToUTF8Bytes()
            };

        }

        #endregion

        #region CreateNewRandomAccount()

        /// <summary>
        /// Create a new account using a random AccountId.
        /// </summary>
        /// <example>
        /// $ curl -X POST -H "Accept: application/json" http://127.0.0.1:8182/Accounts
        /// ~ HTTP/1.1 201 Created
        /// ~ Location: http://127.0.0.1:8182/Account/5b0afa1a-99ac-4727-bfe6-ef77803e1d81
        /// {
        ///   "AccountId": "5b0afa1a-99ac-4727-bfe6-ef77803e1d81"
        /// }
        /// 
        /// $ curl -X POST -H "Content-Type: application/json" -H "Accept: application/json" -d "{"metadata" :{\"name\":\"Alice\", \"age\":18, \"password\":\"secure\"}" http://127.0.0.1:8182/Accounts
        /// ~ HTTP/1.1 201 Created
        /// ~ Location: http://127.0.0.1:8182/Account/cf0f5a72-ef01-4eb7-ae76-50f7540cf890
        /// {
        ///   "AccountId": "cf0f5a72-ef01-4eb7-ae76-50f7540cf890",
        ///   "Metadata": {
        ///     "name": "Alice",
        ///     "age": 18,
        ///     "password": "secure"
        ///   }
        /// }
        /// </example>
        public HTTPResponseHeader CreateNewRandomAccount()
        {

            IAccount _Account = null;
            Byte[]   _Content = null;

            // ADD HTTP-HEADERFIELD CONTENT-LENGTH!
            // ADD HTTP-HEADERFIELD CONTENT-TYPE!
            if (IHTTPConnection.RequestBody.Length > 0)
            {
                _Account = GeraServer.CreateAccount(Metadata: ParseMetadata());
                _Content = new JObject(
                               new JProperty(__AccountId, _Account.Id.ToString()),
                               new JProperty(__Metadata, new JObject(from _Metadatum in _Account.Metadata select new JProperty(_Metadatum.Key, _Metadatum.Value)))
                           ).ToString().ToUTF8Bytes();
            }
            else
            {
                _Account = GeraServer.CreateAccount();
                _Content = new JObject(
                               new JProperty(__AccountId, _Account.Id.ToString())
                           ).ToString().ToUTF8Bytes();
            }


            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.Created,
                    Location       = "http://" + IHTTPConnection.RequestHeader.Host + "/Account/" + _Account.Id.ToString(),
                    CacheControl   = "no-cache",
                    ContentType    = HTTPContentType.JSON_UTF8,
                    Content        = _Content
            };

        }

        #endregion

        #region CreateNewAccount()

        /// <summary>
        /// Create a new account using the given AccountId.
        /// </summary>
        /// <param name=__AccountId>A valid AccountId.</param>
        /// <example>
        /// $ curl -X PUT -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// ~ HTTP/1.1 201 Created
        /// ~ Location: http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "AccountId": "ABC"
        /// }
        /// 
        /// $ curl -X PUT -H "Content-Type: application/json" -H "Accept: application/json" -d "{"metadata" :{\"name\":\"Alice\", \"age\":18, \"password\":\"secure\"}" http://127.0.0.1:8182/Account/ABC
        /// ~ HTTP/1.1 201 Created
        /// ~ Location: http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "AccountId": "ABC",
        ///   "Metadata": {
        ///     "name": "Alice",
        ///     "age": 18,
        ///     "password": "secure"
        ///   }
        /// }
        /// </example>
        public HTTPResponseHeader CreateNewAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
                return Error400_BadRequest();

            #endregion

            var _NewAccountId = new AccountId(AccountId);

            if (!GeraServer.HasAccount(_NewAccountId))
            {

                IAccount _Account = null;
                Byte[]   _Content = null;

                // ADD HTTP-HEADERFIELD CONTENT-LENGTH!
                // ADD HTTP-HEADERFIELD CONTENT-TYPE!
                if (IHTTPConnection.RequestBody.Length > 0)
                {
                    _Account = GeraServer.CreateAccount(AccountId: _NewAccountId, Metadata: ParseMetadata());
                    _Content = new JObject(
                                   new JProperty(__AccountId, _Account.Id.ToString()),
                                   new JProperty(__Metadata, new JObject(from _Metadatum in _Account.Metadata select new JProperty(_Metadatum.Key, _Metadatum.Value)))
                               ).ToString().ToUTF8Bytes();
                }
                else
                {
                    _Account = GeraServer.CreateAccount(AccountId: _NewAccountId);
                    _Content = new JObject(
                                   new JProperty(__AccountId, _Account.Id.ToString())
                               ).ToString().ToUTF8Bytes();
                }

                return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.Created,
                    Location       = "http://" + IHTTPConnection.RequestHeader.Host + "/Account/" + _Account.Id.ToString(),
                    CacheControl   = "no-cache",
                    ContentType    = HTTPContentType.JSON_UTF8,
                    Content        = _Content
                };

            }


            #region ...or conflict!

            else
                return Error409_Conflict();

            #endregion

        }

        #endregion

        #region GetAccountInformation(AccountId)

        /// <summary>
        ///  Get information on the given account.
        /// </summary>
        /// <param name=__AccountId>A valid AccountId.</param>
        /// <example>
        /// $ curl -X GET -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// {
        ///   "AccountId": "ABC",
        ///   "Repositories": []
        /// }
        /// </example>
        public HTTPResponseHeader GetAccountInformation(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
                return Error400_BadRequest();

            #endregion

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
            {

                var _Content = new JObject(
                                   new JProperty(__AccountId, AccountId),
                                   new JProperty("Repositories", new JArray(
                                       from   _RepositoryId
                                       in     _Account.RepositoryIds
                                       select _RepositoryId.ToString()))
                               ).ToString().ToUTF8Bytes();

                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentType    = HTTPContentType.JSON_UTF8,
                        Content        = _Content
                };

            }


            #region ...invalid AccountId!

            else
                return Error404_NotFound();

            #endregion

        }

        #endregion

        #region DeleteAccount()

        /// <summary>
        /// Delete an account using the given AccountId.
        /// </summary>
        /// <param name=__AccountId>A valid AccountId.</param>
        /// <example>
        /// $ curl -X DELETE -H "Accept: application/json" http://127.0.0.1:8182/Account/ABC
        /// </example>
        public HTTPResponseHeader DeleteAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
                return Error400_BadRequest();

            #endregion

            var _AccountId = new AccountId(AccountId);

            if (GeraServer.HasAccount(_AccountId))
            {

                if (GeraServer.DeleteAccount(_AccountId))
                {
                    return new HTTPResponseBuilder() {
                            HTTPStatusCode = HTTPStatusCode.OK,
                            CacheControl   = "no-cache",
                        };
                }

                else return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.InternalServerError,
                        CacheControl   = "no-cache"
                    };

            }


            #region ...or not found!

            else
                return Error404_NotFound();

            #endregion

        }

        #endregion

        #endregion


        #region ListRepositories()

        public HTTPResponseHeader ListRepositories(String AccountId)
        {

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentType    = HTTPContentType.JSON_UTF8,
                        Content        = new JArray(from   _RepositoryId
                                                    in     _Account.RepositoryIds
                                                    select _RepositoryId.ToString()).ToString().ToUTF8Bytes()
                };


            #region ...invalid AccountId!

            else
                return Error404_NotFound();

            #endregion

        }

        #endregion

    }

}

