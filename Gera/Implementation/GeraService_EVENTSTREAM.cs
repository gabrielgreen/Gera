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

using de.ahzf.Hermod.HTTP;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera */* service implementation.
    /// </summary>
    public class GeraService_EVENTSTREAM : AGeraService, IGeraService
    {

        #region Constructor(s)

        #region GeraService_EVENTSTREAM()

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        public GeraService_EVENTSTREAM()
            : base(HTTPContentType.EVENTSTREAM)
        { }

        #endregion

        #region GeraService_EVENTSTREAM(IHTTPConnection)

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        /// <param name="IHTTPConnection">The http connection for this request.</param>
        public GeraService_EVENTSTREAM(IHTTPConnection IHTTPConnection)
            : base(IHTTPConnection, HTTPContentType.EVENTSTREAM, "Gera.resources.")
        { }

        #endregion

        #endregion


        #region GetRoot()

        /// <summary>
        /// The HTML landing page.
        /// </summary>
        public HTTPResponseHeader GetRoot()
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #region Accounts

        #region ListAccountIds()

        /// <summary>
        /// Return a list of valid accounts.
        /// </summary>
        public HTTPResponseHeader ListValidAccounts()
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #region CreateNewRandomAccount()

        /// <summary>
        /// Create a new account using a random AccountId.
        /// </summary>
        public HTTPResponseHeader CreateNewRandomAccount()
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #region CreateNewAccount()

        /// <summary>
        /// Create a new account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader CreateNewAccount(String AccountId)
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #region GetAccountInformation(AccountId)

        /// <summary>
        ///  Get information on the given account.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader GetAccountInformation(String AccountId)
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #region DeleteAccount()

        /// <summary>
        /// Delete an account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader DeleteAccount(String AccountId)
        {
            return Error406_NotAcceptable();
        }

        #endregion

        #endregion


        #region ListRepositories()

        public HTTPResponseHeader ListRepositories(String AccountId)
        {
            return Error406_NotAcceptable();
        }

        #endregion

    }

}

