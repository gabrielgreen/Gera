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

using de.ahzf.Gera;
using de.ahzf.blueprints.Datastructures;

#endregion

namespace GeraTest
{

    public class GeraTest
    {
        
        public static void Main(String[] myArgs)
        {

            var SemanticGraph = new GeraGraph();

            // Vertex properties
            var FirstName = FOAF.FirstName("FirstName");
            var Nick      = FOAF.Nick     ("Nick");
            var LastName  = FOAF.LastName ("LastName");

            // Edges
            var Knows     = FOAF.Knows    ("knows");


            // Vertices
            var alice = SemanticGraph.AddVertex(new VertexId(1), v => v.SetProperty(FirstName, "Alice"));
            var bob   = SemanticGraph.AddVertex(new VertexId(2), v => v.SetProperty(FirstName, "Bob"));

            //Edges
            var alice_bob = SemanticGraph.AddEdge(alice, bob, new EdgeId(1), "knows");

        }

    }

}
