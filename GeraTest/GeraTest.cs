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

using de.ahzf.Gera;
using de.ahzf.blueprints;

#endregion

namespace GeraTest
{

    public class GeraTest
    {
        
        public static void Main(String[] myArgs)
        {

            var _SemanticGraph = new GeraGraph();

            // Vertex properties
            var _FirstName = FOAF.FirstName("FirstName");
            var _Nick      = FOAF.Nick     ("Nick");
            var _LastName  = FOAF.LastName ("LastName");

            // Edges
            var _Knows     = FOAF.Knows    ("knows");


            // Vertices
            var _alice = _SemanticGraph.AddVertex(new VertexId(1), v => v.SetProperty(_FirstName, "Alice"));
            var _bob   = _SemanticGraph.AddVertex(new VertexId(2), v => v.SetProperty(_FirstName, "Bob"));

            var _Kennt = new SemanticPropertyKey(new Uri("http://xmlns.com/foaf/0.1"), "knows", "kennt");

            //Edges
            var _alice_bob = _SemanticGraph.AddEdge(_alice, _bob, new EdgeId(1), _Kennt);


            // Some very simple traversals
            foreach (var _Vertex in _SemanticGraph.Vertices)
            {

                foreach (var _Edge in _Vertex.OutEdges)
                    Console.WriteLine("V({0}) --Fwd({1})-> V({2})", _Vertex.Id, _Edge.Id, _Edge.InVertex.Id);

                foreach (var _Edge in _Vertex.InEdges)
                    Console.WriteLine("V({0}) <~Bwd({1})~~ V({2})", _Vertex.Id, _Edge.Id, _Edge.OutVertex.Id);
            
            }

            Console.WriteLine("---------");

            foreach (var _Edge in _SemanticGraph.Edges)
            {
                Console.WriteLine("V({0}) --Fwd({1})-> V({2})", _Edge.OutVertex.Id, _Edge.Id, _Edge.InVertex.Id);
            }

        }

    }

}
