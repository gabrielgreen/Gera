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

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera Repository.
    /// </summary>
    public class Repository : IRepository
    {

        #region Data

        private IDictionary<GraphId, GeraGraph> _Graphs;

        #endregion

        #region Properties

        /// <summary>
        /// The GraphId.
        /// </summary>
        public RepositoryId Id { get; private set; }

        #endregion

        #region Constructor(s)

        #region Repository(RepositoryId)

        /// <summary>
        /// Create a new Gera repository.
        /// </summary>
        /// <param name="RepositoryId">The RepositoryId.</param>
        public Repository(RepositoryId RepositoryId)
        {
            Id      = RepositoryId;
            _Graphs = new Dictionary<GraphId, GeraGraph>();
        }

        #endregion

        #endregion


        #region CreateGraph(GraphId = null, Graph = null)

        /// <summary>
        /// Create a new graph using the given GraphId.
        /// </summary>
        /// <param name="GraphId">An optional GraphId.</param>
        /// <param name="Graph">A optional Graph.</param>
        public GeraGraph CreateGraph(GraphId GraphId = null, GeraGraph Graph = null)
        {

            if (GraphId == null)
                GraphId = GraphId.NewGraphId;

            if (Graph   == null)
                Graph   = new GeraGraph(GraphId);

            _Graphs.Add(GraphId, Graph);

            return Graph;

        }

        #endregion

        #region TryGetGraph(GraphId, out Graph)

        /// <summary>
        /// Return a specific graph.
        /// </summary>
        /// <param name="GraphId">The GraphId.</param>
        /// <param name="Graph">The Graph.</param>
        public Boolean TryGetGraph(GraphId GraphId, out GeraGraph Graph)
        {

            if (GraphId != null)
                return _Graphs.TryGetValue(GraphId, out Graph);

            Graph = null;
            return false;

        }

        #endregion

        #region HasGraph(GraphId)

        /// <summary>
        /// Checks if a Graph having the given GraphId already exists.
        /// </summary>
        /// <param name="GraphId">An GraphId.</param>
        public Boolean HasGraph(GraphId GraphId)
        {

            if (GraphId != null)
                return _Graphs.ContainsKey(GraphId);

            return false;

        }

        #endregion

        #region RemoveGraph(GraphId)

        /// <summary>
        /// Removes the Graph having the given GraphId.
        /// </summary>
        /// <param name="GraphId">An GraphId.</param>
        public Boolean RemoveGraph(GraphId GraphId)
        {

            if (GraphId != null)
                return _Graphs.Remove(GraphId);

            return false;

        }

        #endregion

        #region NumberOfGraphs

        /// <summary>
        /// The number of known graphs.
        /// </summary>
        public UInt64 NumberOfGraphs
        {
            get
            {
                return (UInt64) _Graphs.Count;
            }
        }

        #endregion


        #region IEnumerator<KeyValuePair<GraphId, IGraph>> Members

        /// <summary>
        /// Get an Enumerator.
        /// </summary>
        public IEnumerator<KeyValuePair<GraphId, GeraGraph>> GetEnumerator()
        {
            return _Graphs.GetEnumerator();
        }

        /// <summary>
        /// Get an Enumerator.
        /// </summary>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Graphs.GetEnumerator();
        }

        #endregion


        #region ToString()

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        public override string ToString()
        {
            return "RepositoryId : " + Id.ToString();
        }

        #endregion

    }

}
