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
    /// A Gera Repository.
    /// </summary>
    public interface IRepository : IEnumerable<KeyValuePair<GraphId, GeraGraph>>
    {

        /// <summary>
        /// The RepositoryId.
        /// </summary>
        RepositoryId Id { get; }


        /// <summary>
        /// Create a new graph using the given GraphId.
        /// </summary>
        /// <param name="GraphId">An optional GraphId.</param>
        /// <param name="GeraGraph">A optional graph.</param>
        GeraGraph CreateGraph(GraphId GraphId = null, GeraGraph GeraGraph = null);


        /// <summary>
        /// Return a specific graph.
        /// </summary>
        /// <param name="GraphId">The GraphId.</param>
        /// <param name="GeraGraph">The graph.</param>
        Boolean TryGetGraph(GraphId GraphId, out GeraGraph GeraGraph);


        /// <summary>
        /// Checks if a graph having the given GraphId already exists.
        /// </summary>
        /// <param name="GraphId">An GraphId.</param>
        Boolean HasGraph(GraphId GraphId);


        /// <summary>
        /// Removes the graph having the given GraphId.
        /// </summary>
        /// <param name="GraphId">An GraphId.</param>
        Boolean RemoveGraph(GraphId GraphId);


        /// <summary>
        /// The number of known graphs.
        /// </summary>
        UInt64 NumberOfGraphs { get; }

        
    }

}
