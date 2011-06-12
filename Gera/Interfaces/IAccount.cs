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

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera Account.
    /// </summary>
    public interface IAccount : IEnumerable<KeyValuePair<RepositoryId, IRepository>>
    {

        /// <summary>
        /// The AccountId.
        /// </summary>
        AccountId Id { get; }

        
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

    }

}
