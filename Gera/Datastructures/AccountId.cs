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
    /// A AccountId is unique identificator for an account vertex.
    /// </summary>    
    public class AccountId : VertexId, IEquatable<AccountId>, IComparable<AccountId>, IComparable
    {

        #region Constructor(s)

        #region AccountId()

        /// <summary>
        /// Generates a new AccountId
        /// </summary>
        public AccountId()
            : base()
        { }

        #endregion

        #region AccountId(myInt32)

        /// <summary>
        /// Generates a AccountId based on the content of an Int32
        /// </summary>
        public AccountId(Int32 myInt32)
            : base(myInt32)
        {
        }

        #endregion

        #region AccountId(myUInt32)

        /// <summary>
        /// Generates a AccountId based on the content of an UInt32
        /// </summary>
        public AccountId(UInt32 myUInt32)
            : base(myUInt32)
        {
        }

        #endregion

        #region AccountId(myInt64)

        /// <summary>
        /// Generates a AccountId based on the content of an Int64
        /// </summary>
        public AccountId(Int64 myInt64)
            : base(myInt64)
        {
        }

        #endregion

        #region AccountId(myUInt64)

        /// <summary>
        /// Generates a AccountId based on the content of an UInt64
        /// </summary>
        public AccountId(UInt64 myUInt64)
            : base(myUInt64)
        {
        }

        #endregion

        #region AccountId(myString)

        /// <summary>
        /// Generates a AccountId based on the content of myString.
        /// </summary>
        public AccountId(String myString)
            : base(myString)
        {
        }

        #endregion

        #region AccountId(myUri)

        /// <summary>
        /// Generates a AccountId based on the content of myUri.
        /// </summary>
        public AccountId(Uri myUri)
            : base(myUri)
        {
        }

        #endregion

        #region AccountId(myAccountId)

        /// <summary>
        /// Generates a AccountId based on the content of myAccountId
        /// </summary>
        /// <param name="myAccountId">A AccountId</param>
        public AccountId(AccountId myAccountId)
            : base(myAccountId)
        {
        }

        #endregion

        #endregion

        #region NewAccountId

        /// <summary>
        /// Generate a new AccountId.
        /// </summary>
        public static AccountId NewAccountId
        {
            get
            {
                return new AccountId(Guid.NewGuid().ToString());
            }
        }

        #endregion


        #region Operator overloading

        #region Operator == (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator == (AccountId myAccountId1, AccountId myAccountId2)
        {

            // If both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(myAccountId1, myAccountId2))
                return true;

            // If one is null, but not both, return false.
            if (((Object) myAccountId1 == null) || ((Object) myAccountId2 == null))
                return false;

            return myAccountId1.Equals(myAccountId2);

        }

        #endregion

        #region Operator != (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator != (AccountId myAccountId1, AccountId myAccountId2)
        {
            return !(myAccountId1 == myAccountId2);
        }

        #endregion

        #region Operator <  (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator < (AccountId myAccountId1, AccountId myAccountId2)
        {

            // Check if myAccountId1 is null
            if ((Object) myAccountId1 == null)
                throw new ArgumentNullException("Parameter myAccountId1 must not be null!");

            // Check if myAccountId2 is null
            if ((Object) myAccountId2 == null)
                throw new ArgumentNullException("Parameter myAccountId2 must not be null!");


            // Check the length of the AccountIds
            if (myAccountId1.Length < myAccountId2.Length)
                return true;

            if (myAccountId1.Length > myAccountId2.Length)
                return false;

            return myAccountId1.CompareTo(myAccountId2) < 0;

        }

        #endregion

        #region Operator >  (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator > (AccountId myAccountId1, AccountId myAccountId2)
        {

            // Check if myAccountId1 is null
            if ((Object) myAccountId1 == null)
                throw new ArgumentNullException("Parameter myAccountId1 must not be null!");

            // Check if myAccountId2 is null
            if ((Object) myAccountId2 == null)
                throw new ArgumentNullException("Parameter myAccountId2 must not be null!");


            // Check the length of the AccountIds
            if (myAccountId1.Length > myAccountId2.Length)
                return true;

            if (myAccountId1.Length < myAccountId2.Length)
                return false;

            return myAccountId1.CompareTo(myAccountId2) > 0;

        }

        #endregion

        #region Operator <= (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator <= (AccountId myAccountId1, AccountId myAccountId2)
        {
            return !(myAccountId1 > myAccountId2);
        }

        #endregion

        #region Operator >= (myAccountId1, myAccountId2)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId1">A AccountId.</param>
        /// <param name="myAccountId2">Another AccountId.</param>
        /// <returns>true|false</returns>
        public static Boolean operator >= (AccountId myAccountId1, AccountId myAccountId2)
        {
            return !(myAccountId1 < myAccountId2);
        }

        #endregion

        #endregion

        #region IComparable<AccountId> Members

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

            // Check if myObject can be casted to an AccountId object
            var myAccountId = myObject as AccountId;
            if ((Object) myAccountId == null)
                throw new ArgumentException("myObject is not of type AccountId!");

            return CompareTo(myAccountId);

        }

        #endregion

        #region CompareTo(myAccountId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Int32 CompareTo(AccountId myAccountId)
        {

            // Check if myAccountId is null
            if (myAccountId == null)
                throw new ArgumentNullException("myAccountId must not be null!");

            return _Id.CompareTo(myAccountId._Id);

        }

        #endregion

        #endregion

        #region IEquatable<AccountId> Members

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

            // Check if myObject can be cast to AccountId
            var myAccountId = myObject as AccountId;
            if ((Object) myAccountId == null)
                throw new ArgumentException("Parameter myObject could not be casted to type AccountId!");

            return this.Equals(myAccountId);

        }

        #endregion

        #region Equals(myAccountId)

        /// <summary>
        /// Compares two instances of this object.
        /// </summary>
        /// <param name="myAccountId">An object to compare with.</param>
        /// <returns>true|false</returns>
        public Boolean Equals(AccountId myAccountId)
        {

            // Check if myAccountId is null
            if (myAccountId == null)
                throw new ArgumentNullException("Parameter myAccountId must not be null!");

            return _Id.Equals(myAccountId._Id);

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
