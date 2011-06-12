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
    /// A GraphId is unique identificator for an account vertex.
    /// </summary>    
    public class GraphId : VertexId, IEquatable<GraphId>, IComparable<GraphId>, IComparable
    {

        #region Constructor(s)

        #region GraphId()

        /// <summary>
        /// Generates a new GraphId
        /// </summary>
        public GraphId()
            : base()
        { }

        #endregion

        #region GraphId(myInt32)

        /// <summary>
        /// Generates a GraphId based on the content of an Int32
        /// </summary>
        public GraphId(Int32 myInt32)
            : base(myInt32)
        {
        }

        #endregion

        #region GraphId(myUInt32)

        /// <summary>
        /// Generates a GraphId based on the content of an UInt32
        /// </summary>
        public GraphId(UInt32 myUInt32)
            : base(myUInt32)
        {
        }

        #endregion

        #region GraphId(myInt64)

        /// <summary>
        /// Generates a GraphId based on the content of an Int64
        /// </summary>
        public GraphId(Int64 myInt64)
            : base(myInt64)
        {
        }

        #endregion

        #region GraphId(myUInt64)

        /// <summary>
        /// Generates a GraphId based on the content of an UInt64
        /// </summary>
        public GraphId(UInt64 myUInt64)
            : base(myUInt64)
        {
        }

        #endregion

        #region GraphId(myString)

        /// <summary>
        /// Generates a GraphId based on the content of myString.
        /// </summary>
        public GraphId(String myString)
            : base(myString)
        {
        }

        #endregion

        #region GraphId(myUri)

        /// <summary>
        /// Generates a GraphId based on the content of myUri.
        /// </summary>
        public GraphId(Uri myUri)
            : base(myUri)
        {
        }

        #endregion

        #region GraphId(myGraphId)

        /// <summary>
        /// Generates a GraphId based on the content of myGraphId
        /// </summary>
        /// <param name="myGraphId">A GraphId</param>
        public GraphId(GraphId myGraphId)
            : base(myGraphId)
        {
        }

        #endregion

        #endregion

        #region NewGraphId

        /// <summary>
        /// Generate a new GraphId.
        /// </summary>
        public static GraphId NewGraphId
        {
            get
            {
                return new GraphId(Guid.NewGuid().ToString());
            }
        }

        #endregion


        #region Operator overloading

        #region Operator == (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (GraphId myGraphId1, GraphId myGraphId2)
        {

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(myGraphId1, myGraphId2))
                return true;

            // If one is null, but not both, return false.
            if (((Object) myGraphId1 == null) || ((Object) myGraphId2 == null))
                return false;

            return myGraphId1.Equals(myGraphId2);

        }

        #endregion

        #region Operator != (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (GraphId myGraphId1, GraphId myGraphId2)
        {
            return !(myGraphId1 == myGraphId2);
        }

        #endregion

        #region Operator <  (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (GraphId myGraphId1, GraphId myGraphId2)
        {

            // Check if myGraphId1 is null
            if ((Object) myGraphId1 == null)
                throw new ArgumentNullException("Parameter myGraphId1 must not be null!");

            // Check if myGraphId2 is null
            if ((Object) myGraphId2 == null)
                throw new ArgumentNullException("Parameter myGraphId2 must not be null!");


            // Check the length of the GraphIds
            if (myGraphId1.Length < myGraphId2.Length)
                return true;

            if (myGraphId1.Length > myGraphId2.Length)
                return false;

            return myGraphId1.CompareTo(myGraphId2) < 0;

        }

        #endregion

        #region Operator >  (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (GraphId myGraphId1, GraphId myGraphId2)
        {

            // Check if myGraphId1 is null
            if ((Object) myGraphId1 == null)
                throw new ArgumentNullException("Parameter myGraphId1 must not be null!");

            // Check if myGraphId2 is null
            if ((Object) myGraphId2 == null)
                throw new ArgumentNullException("Parameter myGraphId2 must not be null!");


            // Check the length of the GraphIds
            if (myGraphId1.Length > myGraphId2.Length)
                return true;

            if (myGraphId1.Length < myGraphId2.Length)
                return false;

            return myGraphId1.CompareTo(myGraphId2) > 0;

        }

        #endregion

        #region Operator <= (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (GraphId myGraphId1, GraphId myGraphId2)
        {
            return !(myGraphId1 > myGraphId2);
        }

        #endregion

        #region Operator >= (myGraphId1, myGraphId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId1">A GraphId.</param>
        /// <param name="myGraphId2">Another GraphId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (GraphId myGraphId1, GraphId myGraphId2)
        {
            return !(myGraphId1 < myGraphId2);
        }

        #endregion

        #endregion

        #region IComparable<GraphId> Members

        #region CompareTo(myObject)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myObject">An object to compare with.</param>
        /// <returns>true|false</returns>
        public new Int32 CompareTo(Object myObject)
        {

            // Check if myObject is null
            if (myObject == null)
                throw new ArgumentNullException("myObject must not be null!");

            // Check if myObject can be casted to an GraphId object
            var myGraphId = myObject as GraphId;
            if ((Object) myGraphId == null)
                throw new ArgumentException("myObject is not of type GraphId!");

            return CompareTo(myGraphId);

        }

        #endregion

        #region CompareTo(myGraphId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(GraphId myGraphId)
        {

            // Check if myGraphId is null
            if (myGraphId == null)
                throw new ArgumentNullException("myGraphId must not be null!");

            return _ElementId.CompareTo(myGraphId._ElementId);

        }

        #endregion

        #endregion

        #region IEquatable<GraphId> Members

        #region Equals(myObject)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myObject">An object to compare with.</param>
        /// <returns>true|false</returns>
        public override Boolean Equals(Object myObject)
        {

            // Check if myObject is null
            if (myObject == null)
                throw new ArgumentNullException("Parameter myObject must not be null!");

            // Check if myObject can be cast to GraphId
            var myGraphId = myObject as GraphId;
            if ((Object) myGraphId == null)
                throw new ArgumentException("Parameter myObject could not be casted to type GraphId!");

            return this.Equals(myGraphId);

        }

        #endregion

        #region Equals(myGraphId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myGraphId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Boolean Equals(GraphId myGraphId)
        {

            // Check if myGraphId is null
            if (myGraphId == null)
                throw new ArgumentNullException("Parameter myGraphId must not be null!");

            return _ElementId.Equals(myGraphId._ElementId);

        }

        #endregion

        #endregion

        #region GetHashCode()

        /// <summary>
        /// Return the HashCode of this object.
        /// </summary>
        /// <returns>The HashCode of this object.</returns>
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }

}
