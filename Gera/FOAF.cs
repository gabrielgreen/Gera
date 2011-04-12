﻿/*
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

using de.ahzf.blueprints.Datastructures;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// Friend-of-a-Friend Ontology
    /// </summary>
    public static class FOAF
    {

        /// <summary>
        /// The base Uri of the FOAF ontology.
        /// </summary>
        public static readonly Uri Namespace = new Uri("http://xmlns.com/foaf/0.1");

        /// <summary>
        /// A homepage for something.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Homepage(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "homepage", myAlias);
        }

        /// <summary>
        /// A person known by this person (indicating some level of reciprocated
        /// interaction between the parties).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Knows(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "knows", myAlias);
        }

        /// <summary>
        /// Something that was made by this agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Made(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "made", myAlias);
        }

        /// <summary>
        /// An agent that made this thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Maker(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "maker", myAlias);
        }

        /// <summary>
        /// A personal mailbox, ie. an Internet mailbox associated with exactly
        /// one owner, the first owner of this mailbox. This is a 'static inverse
        /// functional property', in that there is (across time and change) at most
        /// one individual that ever has any particular value for foaf:mbox.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey MBox(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "mbox", myAlias);
        }

        /// <summary>
        /// Indicates a member of a Group.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Member(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "member", myAlias);
        }

        /// <summary>
        /// The primary topic of some page or document.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey PrimaryTopic(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "primaryTopic", myAlias);
        }

        /// <summary>
        /// Indicates an account held by this agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Account(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "account", myAlias);
        }

        /// <summary>
        /// Indicates the name (identifier) associated with this online account.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey AccountName(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "accountName", myAlias);
        }

        /// <summary>
        /// Indicates a homepage of the service provide for this online account.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey AccountServiceHomepage(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "accountServiceHomepage", myAlias);
        }

        /// <summary>
        /// A depiction of smething.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Depiction(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "depiction", myAlias);
        }

        /// <summary>
        /// A thing depicted in this representation.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Depicts(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "depicts", myAlias);
        }

        /// <summary>
        /// The family name of some person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey FamilyName(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "familyName", myAlias);
        }

        /// <summary>
        /// The first name of a person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey FirstName(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "firstName", myAlias);
        }

        /// <summary>
        /// The gender of this Agent (typically but not necessarily 'male' or 'female').
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Gender(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "gender", myAlias);
        }

        /// <summary>
        /// The given name of some person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey GivenName(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "givenName", myAlias);
        }

        /// <summary>
        /// An ICQ chat ID.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey ICQChatID(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "icqChatID", myAlias);
        }

        /// <summary>
        /// An image that can be used to represent some thing (ie. those depictions
        /// which are particularly representative of something, eg. one's photo on
        /// a homepage).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Img(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "img", myAlias);
        }

        /// <summary>
        /// A page about a topic of interest to this person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Interest(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "interest", myAlias);
        }

        /// <summary>
        /// A jabber ID for something.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey JabberID(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "jabberID", myAlias);
        }

        /// <summary>
        /// The last name of a person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey LastName(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "lastName", myAlias);
        }

        /// <summary>
        /// A logo representing some thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Logo(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "logo", myAlias);
        }

        /// <summary>
        /// A name for some thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Name(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "name", myAlias);
        }

        /// <summary>
        /// A short informal nickname characterising an agent (includes login
        /// identifiers, IRC and other chat nicknames). 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Nick(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "nick", myAlias);
        }

        /// <summary>
        /// A phone, specified using fully qualified tel: URI scheme
        /// (refs: http://www.w3.org/Addressing/schemes.html#tel).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Phone(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "phone", myAlias);
        }

        /// <summary>
        /// A derived thumbnail image.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Thumbnail(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "thumbnail", myAlias);
        }

        /// <summary>
        /// Title (Mr, Mrs, Ms, Dr. etc).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Title(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "title", myAlias);
        }

        /// <summary>
        /// A topic of some page or document.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Topic(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "topic", myAlias);
        }

        /// <summary>
        /// A thing of interest to this person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey TopicInterest(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "topic_interest", myAlias);
        }

        /// <summary>
        /// A weblog of some thing (whether person, group, company etc.).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Weblog(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "weblog", myAlias);
        }

        /// <summary>
        /// A work info homepage of some person; a page about their work
        /// for some organization. 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey WorkInfoHomepage(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "workInfoHomepage", myAlias);
        }

        /// <summary>
        /// A workplace homepage of some person; the homepage of an
        /// organization they work for. 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey WorkPlaceHomepage(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "workPlaceHomepage", myAlias);
        }

        /// <summary>
        /// The age in years of some agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Age(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "age", myAlias);
        }

        /// <summary>
        /// The birthday of this Agent, represented in mm-dd string form,
        /// eg. '12-31'.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey Birthday(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "birthday", myAlias);
        }

        /// <summary>
        /// ndicates the class of individuals that are a member of a Group.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticPropertyKey MembershipClass(String myAlias)
        {
            return new SemanticPropertyKey(Namespace, "membershipClass", myAlias);
        }

    }

}