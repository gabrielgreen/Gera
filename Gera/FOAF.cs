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
    /// Friend-of-a-Friend Ontology
    /// </summary>
    public static class FOAF
    {

        /// <summary>
        /// The base Uri of the FOAF ontology.
        /// </summary>
        public static readonly Uri Prefix = new Uri("http://xmlns.com/foaf/0.1");

        /// <summary>
        /// A homepage for something.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Homepage(String myAlias)
        {
            return new SemanticProperty(Prefix, "homepage", myAlias);
        }

        /// <summary>
        /// A person known by this person (indicating some level of reciprocated
        /// interaction between the parties).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Knows(String myAlias)
        {
            return new SemanticProperty(Prefix, "knows", myAlias);
        }

        /// <summary>
        /// Something that was made by this agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Made(String myAlias)
        {
            return new SemanticProperty(Prefix, "made", myAlias);
        }

        /// <summary>
        /// An agent that made this thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Maker(String myAlias)
        {
            return new SemanticProperty(Prefix, "maker", myAlias);
        }

        /// <summary>
        /// A personal mailbox, ie. an Internet mailbox associated with exactly
        /// one owner, the first owner of this mailbox. This is a 'static inverse
        /// functional property', in that there is (across time and change) at most
        /// one individual that ever has any particular value for foaf:mbox.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty MBox(String myAlias)
        {
            return new SemanticProperty(Prefix, "mbox", myAlias);
        }

        /// <summary>
        /// Indicates a member of a Group.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Member(String myAlias)
        {
            return new SemanticProperty(Prefix, "member", myAlias);
        }

        /// <summary>
        /// The primary topic of some page or document.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty PrimaryTopic(String myAlias)
        {
            return new SemanticProperty(Prefix, "primaryTopic", myAlias);
        }

        /// <summary>
        /// Indicates an account held by this agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Account(String myAlias)
        {
            return new SemanticProperty(Prefix, "account", myAlias);
        }

        /// <summary>
        /// Indicates the name (identifier) associated with this online account.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty AccountName(String myAlias)
        {
            return new SemanticProperty(Prefix, "accountName", myAlias);
        }

        /// <summary>
        /// Indicates a homepage of the service provide for this online account.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty AccountServiceHomepage(String myAlias)
        {
            return new SemanticProperty(Prefix, "accountServiceHomepage", myAlias);
        }

        /// <summary>
        /// A depiction of smething.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Depiction(String myAlias)
        {
            return new SemanticProperty(Prefix, "depiction", myAlias);
        }

        /// <summary>
        /// A thing depicted in this representation.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Depicts(String myAlias)
        {
            return new SemanticProperty(Prefix, "depicts", myAlias);
        }

        /// <summary>
        /// The family name of some person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty FamilyName(String myAlias)
        {
            return new SemanticProperty(Prefix, "familyName", myAlias);
        }

        /// <summary>
        /// The first name of a person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty FirstName(String myAlias)
        {
            return new SemanticProperty(Prefix, "firstName", myAlias);
        }

        /// <summary>
        /// The gender of this Agent (typically but not necessarily 'male' or 'female').
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Gender(String myAlias)
        {
            return new SemanticProperty(Prefix, "gender", myAlias);
        }

        /// <summary>
        /// The given name of some person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty GivenName(String myAlias)
        {
            return new SemanticProperty(Prefix, "givenName", myAlias);
        }

        /// <summary>
        /// An ICQ chat ID.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty ICQChatID(String myAlias)
        {
            return new SemanticProperty(Prefix, "icqChatID", myAlias);
        }

        /// <summary>
        /// An image that can be used to represent some thing (ie. those depictions
        /// which are particularly representative of something, eg. one's photo on
        /// a homepage).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Img(String myAlias)
        {
            return new SemanticProperty(Prefix, "img", myAlias);
        }

        /// <summary>
        /// A page about a topic of interest to this person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Interest(String myAlias)
        {
            return new SemanticProperty(Prefix, "interest", myAlias);
        }

        /// <summary>
        /// A jabber ID for something.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty JabberID(String myAlias)
        {
            return new SemanticProperty(Prefix, "jabberID", myAlias);
        }

        /// <summary>
        /// The last name of a person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty LastName(String myAlias)
        {
            return new SemanticProperty(Prefix, "lastName", myAlias);
        }

        /// <summary>
        /// A logo representing some thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Logo(String myAlias)
        {
            return new SemanticProperty(Prefix, "logo", myAlias);
        }

        /// <summary>
        /// A name for some thing.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Name(String myAlias)
        {
            return new SemanticProperty(Prefix, "name", myAlias);
        }

        /// <summary>
        /// A short informal nickname characterising an agent (includes login
        /// identifiers, IRC and other chat nicknames). 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Nick(String myAlias)
        {
            return new SemanticProperty(Prefix, "nick", myAlias);
        }

        /// <summary>
        /// A phone, specified using fully qualified tel: URI scheme
        /// (refs: http://www.w3.org/Addressing/schemes.html#tel).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Phone(String myAlias)
        {
            return new SemanticProperty(Prefix, "phone", myAlias);
        }

        /// <summary>
        /// A derived thumbnail image.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Thumbnail(String myAlias)
        {
            return new SemanticProperty(Prefix, "thumbnail", myAlias);
        }

        /// <summary>
        /// Title (Mr, Mrs, Ms, Dr. etc).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Title(String myAlias)
        {
            return new SemanticProperty(Prefix, "title", myAlias);
        }

        /// <summary>
        /// A topic of some page or document.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Topic(String myAlias)
        {
            return new SemanticProperty(Prefix, "topic", myAlias);
        }

        /// <summary>
        /// A thing of interest to this person.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty TopicInterest(String myAlias)
        {
            return new SemanticProperty(Prefix, "topic_interest", myAlias);
        }

        /// <summary>
        /// A weblog of some thing (whether person, group, company etc.).
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Weblog(String myAlias)
        {
            return new SemanticProperty(Prefix, "weblog", myAlias);
        }

        /// <summary>
        /// A work info homepage of some person; a page about their work
        /// for some organization. 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty WorkInfoHomepage(String myAlias)
        {
            return new SemanticProperty(Prefix, "workInfoHomepage", myAlias);
        }

        /// <summary>
        /// A workplace homepage of some person; the homepage of an
        /// organization they work for. 
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty WorkPlaceHomepage(String myAlias)
        {
            return new SemanticProperty(Prefix, "workPlaceHomepage", myAlias);
        }

        /// <summary>
        /// The age in years of some agent.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Age(String myAlias)
        {
            return new SemanticProperty(Prefix, "age", myAlias);
        }

        /// <summary>
        /// The birthday of this Agent, represented in mm-dd string form,
        /// eg. '12-31'.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty Birthday(String myAlias)
        {
            return new SemanticProperty(Prefix, "birthday", myAlias);
        }

        /// <summary>
        /// ndicates the class of individuals that are a member of a Group.
        /// </summary>
        /// <param name="myAlias">An alias for this key within your domain.</param>
        /// <returns>A semantic property key to be used within property graphs.</returns>
        public static SemanticProperty MembershipClass(String myAlias)
        {
            return new SemanticProperty(Prefix, "membershipClass", myAlias);
        }

    }

}
