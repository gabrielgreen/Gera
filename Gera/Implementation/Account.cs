﻿/*
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

using de.ahzf.Blueprints;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera Account.
    /// </summary>
    public class Account : IAccount
    {

        #region Data

        private IDictionary<RepositoryId, IRepository> _Repositories;
        private IDictionary<String, Object>            _Metadata;

        #endregion

        #region Properties

        /// <summary>
        /// The AccountId.
        /// </summary>
        public AccountId Id { get; private set; }

        #endregion

        #region Constructor(s)

        #region Account(AccountId, Metadata = null)

        /// <summary>
        /// Create a new Gera Account.
        /// </summary>
        /// <param name="AccountId">The AccountId.</param>
        /// <param name="Metadata">Optional metadata.</param>
        public Account(AccountId AccountId, IDictionary<String, Object> Metadata = null)
        {

            Id            = AccountId;
            _Repositories = new Dictionary<RepositoryId, IRepository>();
            _Metadata     = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);;
            
            if (Metadata != null)
                AddMetadata(Metadata);

        }

        #endregion

        #endregion


        #region Metadata

        #region AddMetadata(Metadata)

        /// <summary>
        /// Add metadata.
        /// </summary>
        /// <param name="Metadata">Some metadata.</param>
        public void AddMetadata(IDictionary<String, Object> Metadata)
        {
            foreach (var _KeyValuePair in Metadata)
                _Metadata.Add(_KeyValuePair.Key, _KeyValuePair.Value);
        }

        #endregion

        #region Metadata

        /// <summary>
        /// Return all account metadata.
        /// </summary>
        public IEnumerable<KeyValuePair<String, Object>> Metadata
        {
            get
            {
                return _Metadata;
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

            if (Repository   == null)
                Repository   = new Repository(RepositoryId: RepositoryId);

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
                return (UInt64) _Repositories.Count;
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
            return "AccountId : " + Id.ToString();
        }

        #endregion

    }

}
