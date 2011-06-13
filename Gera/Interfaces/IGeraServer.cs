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
using System.Collections.Generic;

using de.ahzf.Blueprints;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera Server.
    /// </summary>
    public interface IGeraServer
    {

        /// <summary>
        /// The GeraServerId.
        /// </summary>
        VertexId Id { get; }

        
        /// <summary>
        /// The default server name.
        /// </summary>
        String DefaultServerName { get; }


        #region Accounts

        /// <summary>
        /// Create a new Account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">An optional AccountId.</param>
        /// <param name="Account">A optional Account.</param>
        /// <param name="Metadata">Optional metadata.</param>
        IAccount CreateAccount(AccountId AccountId = null, IAccount Account = null, IDictionary<String, Object> Metadata = null);


        /// <summary>
        /// Return a specific account.
        /// </summary>
        /// <param name="AccountId">The AccountId.</param>
        /// <param name="Account">The Account.</param>
        Boolean TryGetAccount(AccountId AccountId, out IAccount Account);


        /// <summary>
        /// Checks if an Account having the given AccountId already exists.
        /// </summary>
        /// <param name="AccountId">An AccountId.</param>
        Boolean HasAccount(AccountId AccountId);


        /// <summary>
        /// Removes the Account having the given AccountId.
        /// </summary>
        /// <param name="AccountId">An AccountId.</param>
        Boolean DeleteAccount(AccountId AccountId);


        /// <summary>
        /// Number of known accounts.
        /// </summary>
        UInt64 NumberOfAccounts { get; }


        /// <summary>
        /// An enumeration of all AccountIds.
        /// </summary>
        IEnumerable<AccountId> AccountIds { get; }

        #endregion

        #region Repositories

        /// <summary>
        /// Create a new repository using the given RepositoryId.
        /// </summary>
        /// <param name="RepositoryId">An optional RepositoryId.</param>
        /// <param name="Repository">A optional Repository.</param>
        IRepository CreateRepository(RepositoryId RepositoryId = null, IRepository Repository = null);


        /// <summary>
        /// Return a specific repository.
        /// </summary>
        /// <param name="RepositoryId">The RepositoryId.</param>
        /// <param name="Repository">The Repository.</param>
        Boolean TryGetRepository(RepositoryId RepositoryId, out IRepository Repository);


        /// <summary>
        /// Checks if a Repository having the given RepositoryId already exists.
        /// </summary>
        /// <param name="RepositoryId">An RepositoryId.</param>
        Boolean HasRepository(RepositoryId RepositoryId);


        /// <summary>
        /// Removes the Repository having the given RepositoryId.
        /// </summary>
        /// <param name="RepositoryId">An RepositoryId.</param>
        Boolean RemoveRepository(RepositoryId RepositoryId);


        /// <summary>
        /// The number of known repositories.
        /// </summary>
        UInt64 NumberOfRepositories { get; }


        /// <summary>
        /// An enumeration of all RepositoryIds.
        /// </summary>
        IEnumerable<RepositoryId> RepositoryIds { get; }

        #endregion

    }

}
