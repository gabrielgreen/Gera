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

using de.ahzf.Blueprints;
using de.ahzf.Blueprints.PropertyGraph;
using de.ahzf.Blueprints.PropertyGraph.InMemory;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A semantic property graph.
    /// </summary>
    public class GeraGraph : InMemoryGenericPropertyGraph<
                                 VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,  // Vertex definition
                                 EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,  // Edge definition
                                 MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,  // MultiEdge definition
                                 HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>>  // Hyperedge definition
    {

        /// <summary>
        /// Creates a new semantic property graph.
        /// </summary>
        /// <param name="GraphId">The identification of this graph.</param>
        /// <param name="GraphInitializer">A delegate to initialize the newly created graph.</param>
        public GeraGraph(VertexId GraphId,
                         GraphInitializer<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                          EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                          MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                          HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object> GraphInitializer = null)

            : base (GraphId,
                    GDB.Id(),
                    GDB.RevId(),
                    () => new Dictionary<SemanticProperty, Object>(),

                    // Create a new Vertex
                    (Graph) => VertexId.NewVertexId,
                    (Graph, myVertexId, myVertexPropertyInitializer) =>
                        new PropertyVertex<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                           EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                           MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                           HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                           ICollection<IPropertyEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                     EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                     MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                     HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>,
                                           IDictionary<SemanticProperty, IPropertyHyperEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                            EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                            MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                            HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>>

                            (Graph, myVertexId, GDB.Id(), GDB.RevId(),
                             () => new Dictionary<SemanticProperty, Object>(),
                             () => new HashSet<IPropertyEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),
                             () => new Dictionary<SemanticProperty, IPropertyHyperEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                       EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                       MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                                       HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),
                             myVertexPropertyInitializer
                            ),

                   
                   // Create a new Edge
                   (Graph) => EdgeId.NewEdgeId,
                   (Graph, myOutVertex, myInVertex, myEdgeId, myLabel, myEdgePropertyInitializer) =>
                        new PropertyEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                         EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                         MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                         HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>>

                            (Graph, myOutVertex, myInVertex, myEdgeId, myLabel, GDB.Id(), GDB.RevId(),
                             () => new Dictionary<SemanticProperty, Object>(),
                             myEdgePropertyInitializer
                            ),

                   // Create a new HyperEdge
                   (Graph) => HyperEdgeId.NewHyperEdgeId,
                   (Graph, myEdges, myHyperEdgeId, myLabel, myHyperEdgePropertyInitializer) =>
                       new PropertyHyperEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                             EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                             MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,
                                             HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object, IDictionary<SemanticProperty, Object>,

                                             ICollection<IPropertyEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                       EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                       MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                       HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>>

                            (Graph, myEdges, myHyperEdgeId, myLabel, GDB.Id(), GDB.RevId(),
                             () => new Dictionary<SemanticProperty, Object>(),
                             () => new HashSet<IPropertyEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                             HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),
                             myHyperEdgePropertyInitializer
                            ),


                   // The vertices collection
                   new ConcurrentDictionary<VertexId,    IPropertyVertex   <VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),

                   // The edges collection
                   new ConcurrentDictionary<EdgeId,      IPropertyEdge     <VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),

                   // The hyperedges collection
                   new ConcurrentDictionary<HyperEdgeId, IPropertyHyperEdge<VertexId,    RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            MultiEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object,
                                                                            HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>(),

                   GraphInitializer)


        { }

    }

}
