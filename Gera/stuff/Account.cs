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

    public class Account : IEnumerable<KeyValuePair<VertexId, Repository>>
    {

        public VertexId Id { get; private set; }
        private IDictionary<VertexId, Repository> _Repositories;

        public Account(VertexId Id)
        {
            this.Id = Id;
            this._Repositories = new Dictionary<VertexId, Repository>();
        }

        public Repository CreateRepository(VertexId RepositoryId)
        {
            var _Repository = new Repository(RepositoryId);
            this._Repositories.Add(_Repository.Id, _Repository);
            return _Repository;
        }


        public IEnumerator<KeyValuePair<VertexId, Repository>> GetEnumerator()
        {
            return _Repositories.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Repositories.GetEnumerator();
        }
    }

}
