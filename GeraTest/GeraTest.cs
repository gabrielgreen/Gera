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
using System.Linq;

using de.ahzf.Blueprints;
using de.ahzf.Blueprints.PropertyGraph;
using de.ahzf.Pipes;
using de.ahzf.Pipes.ExtensionMethods;
using de.ahzf.Balder.ExtensionMethods;
using de.ahzf.Gera;
using System.Threading;

#endregion

namespace GeraTest
{

    public class GeraTest
    {
        
        public static void Main(String[] myArgs)
        {

            var _GeraServer    = new GeraServer();
            var _Account1      = _GeraServer.CreateAccount(new AccountId("Account1"));
            var _Repository1   = _GeraServer.CreateRepository(new RepositoryId("Repository1"));
            var _SemanticGraph = _Repository1.CreateGraph(new GraphId("GeraGraph"));

            // curl -H "Accept: text/html"        http://127.0.0.1:8182

            

            
            

            // Vertex properties
            var _FirstName = FOAF.FirstName("FirstName");
            var _Nick      = FOAF.Nick     ("Nick");
            var _LastName  = FOAF.LastName ("LastName");

            // Edges
            var _knows     = FOAF.Knows    ("knows");

            // Vertices
            var _Alice = _SemanticGraph.AddVertex(new VertexId(1), v => v.SetProperty(_FirstName, "Alice"));
            var _Bob   = _SemanticGraph.AddVertex(new VertexId(2), v => v.SetProperty(_FirstName, "Bob"));
            var _Carol = _SemanticGraph.AddVertex(new VertexId(3), v => v.SetProperty(_FirstName, "Carol"));

            // Edges
            var _Alice_Bob   = _SemanticGraph.AddEdge(_Alice, _Bob,   new EdgeId(1), _knows);
            var _Alice_Carol = _SemanticGraph.AddEdge(_Alice, _Carol, new EdgeId(2), _knows);
            var _Carol_Bob   = _SemanticGraph.AddEdge(_Carol, _Bob,   new EdgeId(3), _knows);


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


            var _AllFoaf1 = _SemanticGraph.V().Out(_knows).Out(_knows).Prop(_FirstName).Cast<String>().ToList();

            // ToDo: Would be nice if the result would be a n-tuple.
            var _AllFoaf2 = _SemanticGraph.V().Out(_knows).Out(_knows).Prop(GDB.Id(), _FirstName).ToList();


            var _Pipeline = new Pipeline<IPropertyVertex<VertexId,    RevisionId,                   SemanticProperty, Object,
                                                         EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                         HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>,
                                         IPropertyVertex<VertexId,    RevisionId, SemanticProperty, Object,
                                                         EdgeId,      RevisionId, SemanticProperty, SemanticProperty, Object,
                                                         HyperEdgeId, RevisionId, SemanticProperty, SemanticProperty, Object>>

                                          (v => v.Out(_knows).Out(_knows));

            var _FriendsFriends = _Pipeline.SetSource(_Alice).ToList();

            while (true)
            {
                Thread.Sleep(100);
            }

        }

    }

}
