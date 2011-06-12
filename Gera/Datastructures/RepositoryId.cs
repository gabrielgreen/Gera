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
    /// A RepositoryId is unique identificator for an repository vertex.
    /// </summary>    
    public class RepositoryId : VertexId, IEquatable<RepositoryId>, IComparable<RepositoryId>, IComparable
    {

        #region Constructor(s)

        #region RepositoryId()

        /// <summary>
        /// Generates a new RepositoryId
        /// </summary>
        public RepositoryId()
            : base()
        {
        }

        #endregion

        #region RepositoryId(myInt32)

        /// <summary>
        /// Generates a RepositoryId based on the content of an Int32
        /// </summary>
        public RepositoryId(Int32 myInt32)
            : base(myInt32)
        {
        }

        #endregion

        #region RepositoryId(myUInt32)

        /// <summary>
        /// Generates a RepositoryId based on the content of an UInt32
        /// </summary>
        public RepositoryId(UInt32 myUInt32)
            : base(myUInt32)
        {
        }

        #endregion

        #region RepositoryId(myInt64)

        /// <summary>
        /// Generates a RepositoryId based on the content of an Int64
        /// </summary>
        public RepositoryId(Int64 myInt64)
            : base(myInt64)
        {
        }

        #endregion

        #region RepositoryId(myUInt64)

        /// <summary>
        /// Generates a RepositoryId based on the content of an UInt64
        /// </summary>
        public RepositoryId(UInt64 myUInt64)
            : base(myUInt64)
        {
        }

        #endregion

        #region RepositoryId(myString)

        /// <summary>
        /// Generates a RepositoryId based on the content of myString.
        /// </summary>
        public RepositoryId(String myString)
            : base(myString)
        {
        }

        #endregion

        #region RepositoryId(myUri)

        /// <summary>
        /// Generates a RepositoryId based on the content of myUri.
        /// </summary>
        public RepositoryId(Uri myUri)
            : base(myUri)
        {
        }

        #endregion

        #region RepositoryId(myRepositoryId)

        /// <summary>
        /// Generates a RepositoryId based on the content of myRepositoryId
        /// </summary>
        /// <param name="myRepositoryId">A RepositoryId</param>
        public RepositoryId(RepositoryId myRepositoryId)
            : base(myRepositoryId)
        {
        }

        #endregion

        #endregion

        #region NewRepositoryId

        /// <summary>
        /// Generate a new RepositoryId.
        /// </summary>
        public static RepositoryId NewRepositoryId
        {
            get
            {
                return new RepositoryId(Guid.NewGuid().ToString());
            }
        }

        #endregion


        #region Operator overloading

        #region Operator == (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(myRepositoryId1, myRepositoryId2))
                return true;

            // If one is null, but not both, return false.
            if (((Object) myRepositoryId1 == null) || ((Object) myRepositoryId2 == null))
                return false;

            return myRepositoryId1.Equals(myRepositoryId2);

        }

        #endregion

        #region Operator != (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {
            return !(myRepositoryId1 == myRepositoryId2);
        }

        #endregion

        #region Operator <  (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {

            // Check if myRepositoryId1 is null
            if ((Object) myRepositoryId1 == null)
                throw new ArgumentNullException("Parameter myRepositoryId1 must not be null!");

            // Check if myRepositoryId2 is null
            if ((Object) myRepositoryId2 == null)
                throw new ArgumentNullException("Parameter myRepositoryId2 must not be null!");


            // Check the length of the RepositoryIds
            if (myRepositoryId1.Length < myRepositoryId2.Length)
                return true;

            if (myRepositoryId1.Length > myRepositoryId2.Length)
                return false;

            return myRepositoryId1.CompareTo(myRepositoryId2) < 0;

        }

        #endregion

        #region Operator >  (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {

            // Check if myRepositoryId1 is null
            if ((Object) myRepositoryId1 == null)
                throw new ArgumentNullException("Parameter myRepositoryId1 must not be null!");

            // Check if myRepositoryId2 is null
            if ((Object) myRepositoryId2 == null)
                throw new ArgumentNullException("Parameter myRepositoryId2 must not be null!");


            // Check the length of the RepositoryIds
            if (myRepositoryId1.Length > myRepositoryId2.Length)
                return true;

            if (myRepositoryId1.Length < myRepositoryId2.Length)
                return false;

            return myRepositoryId1.CompareTo(myRepositoryId2) > 0;

        }

        #endregion

        #region Operator <= (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {
            return !(myRepositoryId1 > myRepositoryId2);
        }

        #endregion

        #region Operator >= (myRepositoryId1, myRepositoryId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId1">A RepositoryId.</param>
        /// <param name="myRepositoryId2">Another RepositoryId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (RepositoryId myRepositoryId1, RepositoryId myRepositoryId2)
        {
            return !(myRepositoryId1 < myRepositoryId2);
        }

        #endregion

        #endregion

        #region IComparable<RepositoryId> Members

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

            // Check if myObject can be casted to an RepositoryId object
            var myRepositoryId = myObject as RepositoryId;
            if ((Object) myRepositoryId == null)
                throw new ArgumentException("myObject is not of type RepositoryId!");

            return CompareTo(myRepositoryId);

        }

        #endregion

        #region CompareTo(myRepositoryId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(RepositoryId myRepositoryId)
        {

            // Check if myRepositoryId is null
            if (myRepositoryId == null)
                throw new ArgumentNullException("myRepositoryId must not be null!");

            return _ElementId.CompareTo(myRepositoryId._ElementId);

        }

        #endregion

        #endregion

        #region IEquatable<RepositoryId> Members

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

            // Check if myObject can be cast to RepositoryId
            var myRepositoryId = myObject as RepositoryId;
            if ((Object) myRepositoryId == null)
                throw new ArgumentException("Parameter myObject could not be casted to type RepositoryId!");

            return this.Equals(myRepositoryId);

        }

        #endregion

        #region Equals(myRepositoryId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myRepositoryId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Boolean Equals(RepositoryId myRepositoryId)
        {

            // Check if myRepositoryId is null
            if (myRepositoryId == null)
                throw new ArgumentNullException("Parameter myRepositoryId must not be null!");

            return _ElementId.Equals(myRepositoryId._ElementId);

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
