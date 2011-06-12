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

using de.ahzf.Blueprints;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// The Graph-Database Ontology.
    /// </summary>
    public static class GDB
    {

        /// <summary>
        /// The base Uri of the graph-database ontology.
        /// </summary>
        public static readonly Uri Prefix = new Uri("http://graph-database.org/gdb/0.1");

        /// <summary>
        /// The Id of swomething.
        /// </summary>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Id()
        {
            return new SemanticProperty(Prefix, "Id", "Id");
        }

        /// <summary>
        /// The RevId of swomething.
        /// </summary>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty RevId()
        {
            return new SemanticProperty(Prefix, "RevId", "RevId");
        }

    }

}
