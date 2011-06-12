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
using System.Collections;
using System.Collections.Generic;

using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.Datastructures;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A tcp/http based GeraServer.
    /// </summary>
    public class GeraServer : HTTPServer<IGeraService>, IGeraServer
    {

        #region Data

        private IDictionary<AccountId, IAccount>       _Accounts;
        private IDictionary<RepositoryId, IRepository> _Repositories;

        #endregion
        
        #region Properties

        /// <summary>
        /// The GeraServerId.
        /// </summary>
        public Blueprints.VertexId Id
        {
            get { throw new NotImplementedException(); }
        }


        /// <summary>
        /// The default server name.
        /// </summary>
        public override String DefaultServerName
        {
            get
            {
                return "Gera HTTP/REST Server v0.1";
            }
        }

        #endregion

        #region Constructor(s)

        #region GeraServer()

        /// <summary>
        /// Initialize the GeraServer using IPAddress.Any, http port 8182 and start the server.
        /// </summary>
        public GeraServer()
            : base(IPv4Address.Any, new IPPort(8182), Autostart: true)
        {

            ServerName    = DefaultServerName;
            _Accounts     = new Dictionary<AccountId, IAccount>();
            _Repositories = new Dictionary<RepositoryId, IRepository>();

            base.OnNewHTTPService += GeraService => { GeraService.GeraServer = this; };

        }

        #endregion

        #region GeraServer(Port, AutoStart = false)

        /// <summary>
        /// Initialize the GeraServer using IPAddress.Any and the given parameters.
        /// </summary>
        /// <param name="Port">The listening port</param>
        /// <param name="Autostart"></param>
        public GeraServer(IPPort Port, Boolean Autostart = false)
            : base(IPv4Address.Any, Port, Autostart: true)
        {

            ServerName  = DefaultServerName;
            _Accounts   = new Dictionary<AccountId, IAccount>();

            base.OnNewHTTPService += GeraService => { GeraService.GeraServer = this; };

        }

        #endregion

        #region GeraServer(IIPAddress, Port, AutoStart = false)

        /// <summary>
        /// Initialize the HTTPServer using the given parameters.
        /// </summary>
        /// <param name="IIPAddress">The listening IP address(es)</param>
        /// <param name="Port">The listening port</param>
        /// <param name="Autostart"></param>
        public GeraServer(IIPAddress IIPAddress, IPPort Port, Boolean Autostart = false)
            : base(IIPAddress, Port, Autostart: true)
        {

            ServerName  = DefaultServerName;
            _Accounts   = new Dictionary<AccountId, IAccount>();

            base.OnNewHTTPService += GeraService => { GeraService.GeraServer = this; };

        }

        #endregion

        #region GeraServer(IPSocket, Autostart = false)

        /// <summary>
        /// Initialize the HTTPServer using the given parameters.
        /// </summary>
        /// <param name="IPSocket">The listening IPSocket.</param>
        /// <param name="Autostart"></param>
        public GeraServer(IPSocket IPSocket, Boolean Autostart = false)
            : base(IPSocket.IPAddress, IPSocket.Port, Autostart: true)
        {

            ServerName  = DefaultServerName;
            _Accounts   = new Dictionary<AccountId, IAccount>();

            base.OnNewHTTPService += GeraService => { GeraService.GeraServer = this; };

        }

        #endregion

        #endregion


        #region Accounts

        #region CreateAccount(AccountId = null, Account = null)

        /// <summary>
        /// Create a new Account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">An optional AccountId.</param>
        /// <param name="Account">A optional Account.</param>
        public IAccount CreateAccount(AccountId AccountId = null, IAccount Account = null)
        {

            if (AccountId == null)
                AccountId = AccountId.NewAccountId;

            if (Account   == null)
                Account   = new Account(AccountId);

            _Accounts.Add(AccountId, Account);

            return Account;

        }

        #endregion

        #region TryGetAccount(AccountId, out Account)

        /// <summary>
        /// Return a specific account.
        /// </summary>
        /// <param name="AccountId">The AccountId.</param>
        /// <param name="Account">The Account.</param>
        public Boolean TryGetAccount(AccountId AccountId, out IAccount Account)
        {

            if (AccountId != null)
                return _Accounts.TryGetValue(AccountId, out Account);

            Account = null;
            return false;

        }

        #endregion

        #region HasAccount(AccountId)

        /// <summary>
        /// Checks if an Account having the given AccountId already exists.
        /// </summary>
        /// <param name="AccountId">An AccountId.</param>
        public Boolean HasAccount(AccountId AccountId)
        {

            if (AccountId != null)
                return _Accounts.ContainsKey(AccountId);

            return false;

        }

        #endregion

        #region RemoveAccount(AccountId)

        /// <summary>
        /// Removes the Account having the given AccountId.
        /// </summary>
        /// <param name="AccountId">An AccountId.</param>
        public Boolean DeleteAccount(AccountId AccountId)
        {

            if (AccountId != null)
                return _Accounts.Remove(AccountId);

            return false;

        }

        #endregion

        #region NumberOfAccounts

        /// <summary>
        /// Number of known accounts.
        /// </summary>
        public UInt64 NumberOfAccounts
        {
            get
            {
                return (UInt64) _Accounts.Count;
            }
        }
        
        #endregion

        #region AccountIds

        /// <summary>
        /// An enumeration of all AccountIds.
        /// </summary>
        public IEnumerable<AccountId> AccountIds
        {
            get
            {
                return _Accounts.Keys;
            }
        }

        #endregion

        #endregion

        #region Repositories

        #region CreateRepository(RepositoryId = null, Repository = null)

        /// <summary>
        /// Create a new repository using the given RepositoryId.
        /// </summary>
        /// <param name="RepositoryId">An optional RepositoryId.</param>
        /// <param name="Repository">A optional Repository.</param>
        public IRepository CreateRepository(RepositoryId RepositoryId = null, IRepository Repository = null)
        {

            if (RepositoryId == null)
                RepositoryId = RepositoryId.NewRepositoryId;

            if (Repository == null)
                Repository = new Repository(RepositoryId: RepositoryId);

            _Repositories.Add(RepositoryId, Repository);

            return Repository;

        }

        #endregion

        #region TryGetRepository(RepositoryId, out Repository)

        /// <summary>
        /// Return a specific repository.
        /// </summary>
        /// <param name="RepositoryId">The RepositoryId.</param>
        /// <param name="Repository">The Repository.</param>
        public Boolean TryGetRepository(RepositoryId RepositoryId, out IRepository Repository)
        {

            if (RepositoryId != null)
                return _Repositories.TryGetValue(RepositoryId, out Repository);

            Repository = null;
            return false;

        }

        #endregion

        #region HasRepository(RepositoryId)

        /// <summary>
        /// Checks if a Repository having the given RepositoryId already exists.
        /// </summary>
        /// <param name="RepositoryId">An RepositoryId.</param>
        public Boolean HasRepository(RepositoryId RepositoryId)
        {

            if (RepositoryId != null)
                return _Repositories.ContainsKey(RepositoryId);

            return false;

        }

        #endregion

        #region RemoveRepository(RepositoryId)

        /// <summary>
        /// Removes the Repository having the given RepositoryId.
        /// </summary>
        /// <param name="RepositoryId">An RepositoryId.</param>
        public Boolean RemoveRepository(RepositoryId RepositoryId)
        {

            if (RepositoryId != null)
                return _Repositories.Remove(RepositoryId);

            return false;

        }

        #endregion

        #region NumberOfRepositories

        /// <summary>
        /// The number of known repositories.
        /// </summary>
        public UInt64 NumberOfRepositories
        {
            get
            {
                return (UInt64)_Repositories.Count;
            }
        }

        #endregion

        #region RepositoryIds

        /// <summary>
        /// An enumeration of all RepositoryIds.
        /// </summary>
        public IEnumerable<RepositoryId> RepositoryIds
        {
            get
            {
                return _Repositories.Keys;
            }
        }

        #endregion

        #endregion


        #region ToString()

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        public override string ToString()
        {
            return "GeraServerId : " + Id.ToString();
        }

        #endregion

    }

}
