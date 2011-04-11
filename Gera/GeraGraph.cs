/*
 * Copyright (c) 2010-2011, Achim 'ahzf' Friedland <code@ahzf.de>
 * This file is part of Gera
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
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
using de.ahzf.blueprints.Datastructures;
using de.ahzf.blueprints.InMemory.PropertyGraph.Generic;

#endregion

namespace de.ahzf.Gera
{

    public class GeraGraph : InMemoryGenericPropertyGraph<// Vertex definition
                                                          VertexId,    RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                                          IGenericVertex<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                         EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                         HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>,
                                                          ICollection<IGenericEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                                   EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                                   HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>,
                                                          
                                                          // Edge definition
                                                          EdgeId,      RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                                          IGenericEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                       EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                       HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>,
                                                          
                                                          // Hyperedge definition
                                                          HyperEdgeId, RevisionId,
                                                          SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                                          IGenericHyperEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                            EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                            HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>,
                                                          
                                                          Object>
    {

        public GeraGraph()
            : base(// Create a new Vertex
                    (myVertexId, myVertexPropertyInitializer) =>
                        new PropertyVertex<VertexId,    RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                           EdgeId,      RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                           HyperEdgeId, RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                           ICollection<IGenericEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                    EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                    HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>>
                            (myVertexId, new SemanticPropertyKey("Id"), new SemanticPropertyKey("RevisionId"),
                             () => new Dictionary<SemanticPropertyKey, Object>(),
                             () => new HashSet<IGenericEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                            EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                            HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>(),
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
                   (myOutVertex, myInVertices, myHyperEdgeId, myLabel, myHyperEdgePropertyInitializer) =>
                       new PropertyHyperEdge<VertexId,    RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                             EdgeId,      RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                             HyperEdgeId, RevisionId, SemanticPropertyKey, Object, IDictionary<SemanticPropertyKey, Object>,
                                             ICollection<IGenericVertex<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                        EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                        HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>>
                            (myOutVertex, myInVertices, myHyperEdgeId, myLabel, new SemanticPropertyKey("Id"), new SemanticPropertyKey("RevisionId"),
                             () => new Dictionary<SemanticPropertyKey, Object>(),
                             () => new HashSet<IGenericVertex<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                              EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                              HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>(),
                             myHyperEdgePropertyInitializer
                            ),

                   // The vertices collection
                   new ConcurrentDictionary<VertexId,    IGenericVertex   <VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>(),

                   // The edges collection
                   new ConcurrentDictionary<EdgeId,      IGenericEdge     <VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>(),

                   // The hyperedges collection
                   new ConcurrentDictionary<HyperEdgeId, IGenericHyperEdge<VertexId,    RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           EdgeId,      RevisionId, IProperties<SemanticPropertyKey, Object>,
                                                                           HyperEdgeId, RevisionId, IProperties<SemanticPropertyKey, Object>>>()

              )


        { }

    }

}
