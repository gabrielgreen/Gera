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

using de.ahzf.blueprints.Datastructures;

#endregion

namespace de.ahzf.Gera
{

    public class Gera2
    {

        public Uri FOAF;

        public Gera2()
        {
            
            FOAF = new Uri("http://xmlns.com/foaf/0.1");

            var a1 = new SemanticPropertyKey(FOAF, "Person", "Freunde");
            var a2 = new SemanticPropertyKey(FOAF, "knows", "kennt");

        }

    }

}
