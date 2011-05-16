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
using System.Collections.Concurrent;

using de.ahzf.blueprints;
using de.ahzf.blueprints.PropertyGraph;
using de.ahzf.blueprints.PropertyGraph.InMemory;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A semantic property graph.
    /// </summary>
    public class GeraGraph : InMemoryGenericPropertyGraph<// Vertex definition
                                                          VertexId,    RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,

                                                          ICollection<IPropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                                    EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                                    HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>,
                                                          
                                                          // Edge definition
                                                          EdgeId,      RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                                          
                                                          // Hyperedge definition
                                                          HyperEdgeId, RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>>
    {

        /// <summary>
        /// Creates a new semantic property graph.
        /// </summary>
        public GeraGraph()
            : base(// Create a new Vertex
                    (myVertexId, myVertexPropertyInitializer) =>
                        new PropertyVertex<VertexId,    RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                           EdgeId,      RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                           HyperEdgeId, RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,

                                           ICollection<IPropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                     EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                     HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>>

                            (myVertexId, new SemanticPropertyKey("Id"), new SemanticPropertyKey("RevisionId"),
                             () => new Dictionary<SemanticPropertyKey, Object>(),
                             () => new HashSet<IPropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                             EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                             HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>(),
                             myVertexPropertyInitializer
                            ),

                   
                   // Create a new Edge
                   (myOutVertex, myInVertex, myEdgeId, myLabel, myEdgePropertyInitializer) =>
                        new PropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                         EdgeId,      RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                         HyperEdgeId, RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>>

                            (myOutVertex, myInVertex, myEdgeId, myLabel, new SemanticPropertyKey("Id"), new SemanticPropertyKey("RevisionId"),
                             () => new Dictionary<SemanticPropertyKey, Object>(),
                             myEdgePropertyInitializer
                            ),

                   // Create a new HyperEdge
                   (myEdges, myHyperEdgeId, myLabel, myHyperEdgePropertyInitializer) =>
                       new PropertyHyperEdge<VertexId,    RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                             EdgeId,      RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                             HyperEdgeId, RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,

                                             ICollection<IPropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                       EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                       HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>>

                            (myEdges, myHyperEdgeId, myLabel, new SemanticPropertyKey("Id"), new SemanticPropertyKey("RevisionId"),
                             () => new Dictionary<SemanticPropertyKey, Object>(),
                             () => new HashSet<IPropertyEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                             EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                             HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>(),
                             myHyperEdgePropertyInitializer
                            ),

                   // The vertices collection
                   new ConcurrentDictionary<VertexId,    IPropertyVertex    <VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                             EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                             HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>(),

                   // The edges collection
                   new ConcurrentDictionary<EdgeId,      IPropertyEdge     <VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                            EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                            HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>(),

                   // The hyperedges collection
                   new ConcurrentDictionary<HyperEdgeId, IPropertyHyperEdge<VertexId,    RevisionId, SemanticPropertyKey, Object,
                                                                            EdgeId,      RevisionId, SemanticPropertyKey, Object,
                                                                            HyperEdgeId, RevisionId, SemanticPropertyKey, Object>>()

              )


        { }

    }

}
