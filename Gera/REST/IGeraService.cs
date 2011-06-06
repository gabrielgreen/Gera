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

using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.HTTP.Common;
using System.Collections.Generic;
using de.ahzf.Blueprints;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// The Gera service interface mapping HTTP/REST URIs onto .NET methods.
    /// </summary>
    //[HTTPService(Host: "localhost:8080", ForceAuthentication: true)]
    public interface IGeraService : IHTTPService
    {

        IDictionary<VertexId, Account> Accounts { get; set; }


        // HTTP-Methods: LINK / UNLINK

        /// <summary>
        /// The HTML landing page.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/")]
        HTTPResponse GetLandingpage();

        #region Account

        /// <summary>
        /// Return a list of valid accounts.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/Accounts")]
        HTTPResponse ListValidAccounts();

        /// <summary>
        /// Create a new account using a random AccountId.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.POST, "/Accounts")]
        HTTPResponse CreateNewRandomAccount();
        // include metadata map!

        /// <summary>
        /// Create a new account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.PUT, "/Account/{AccountId}")]
        HTTPResponse CreateNewAccount(String AccountId);
        // include metadata map!

        /// <summary>
        /// Get information on the given account.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/Account/{AccountId}")]
        HTTPResponse GetAccountInformation(String AccountId);

        /// <summary>
        /// Delete a Account
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/Account/{AccountId}")]
        //HTTPResponse DeleteAccount(String AccountId);

        #endregion

        #region Account Metadata

        /// <summary>
        /// Get Account metadata
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/metadata")]
        //HTTPResponse GetServiceMetadata(String AccountId, String AccountId);

        /// <summary>
        /// Get Account metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/metadata/{Metakey}")]
        //HTTPResponse GetServiceMetadatum(String AccountId, String AccountId, String Metakey);

        /// <summary>
        /// Update/Set Account metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/metadata")]
        //HTTPResponse SetServiceMetadata(String AccountId, String AccountId);
        // include metadata map!

        /// <summary>
        /// Set Account metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/metadata/{Metakey}")]
        //HTTPResponse SetServiceMetadatum(String AccountId, String AccountId, String Metakey);

        /// <summary>
        /// Delete Account metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/metadata")]
        //HTTPResponse DeleteServiceMetadata(String AccountId, String AccountId);
        // include metadata map!

        /// <summary>
        /// Delete Account metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/metadata/{Metakey}")]
        //HTTPResponse DeleteServiceMetadatum(String AccountId, String AccountId, String Metakey);

        #endregion

        #region Repositories

        /// <summary>
        /// Repository list
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/{AccountId}/repositories")]
        HTTPResponse ListRepositories(String AccountId);

        /// <summary>
        /// Create a repository
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}")]
        //HTTPResponse CreateRepository(String AccountId, String RepositoryId);
        // RepositoryId == "Accounts" is invalid!
        // include metadata map!

        /// <summary>
        /// Repository Information
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}")]
        //HTTPResponse GetRepositoryInformation(String AccountId, String RepositoryId);

        /// <summary>
        /// Delete a repository
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}")]
        //HTTPResponse DeleteRepository(String AccountId, String RepositoryId);

        #endregion

        #region Repository Metadata

        /// <summary>
        /// Get repository metadata
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/metadata")]
        //HTTPResponse GetRepositoryMetadata(String AccountId, String RepositoryId);

        /// <summary>
        /// Get repository metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/metadata/{Metakey}")]
        //HTTPResponse GetRepositoryMetadatum(String AccountId, String RepositoryId, String Metakey);

        /// <summary>
        /// Update/Set repository metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}/metadata")]
        //HTTPResponse SetRepositoryMetadata(String AccountId, String RepositoryId);
        // include metadata map!

        /// <summary>
        /// Set repository metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}/metadata/{Metakey}")]
        //HTTPResponse SetRepositoryMetadatum(String AccountId, String RepositoryId, String Metakey);

        /// <summary>
        /// Delete repository metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}/metadata")]
        //HTTPResponse DeleteRepositoryMetadata(String AccountId, String RepositoryId);
        // include metadata map!

        /// <summary>
        /// Delete repository metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}/metadata/{Metakey}")]
        //HTTPResponse DeleteRepositoryMetadatum(String AccountId, String RepositoryId, String Metakey);

        #endregion

        #region Transactions

        /// <summary>
        /// Starts a transaction.
        /// Result is the transaction identifier as text/plain.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.BEGINTRANSACTION, "/{AccountId}/{RepositoryId}")]
        //HTTPResponse BeginTransaction(String AccountId, String RepositoryId);
        //...
        //Distributed
        //LongRunning
        //IsolationLevel
        //Name
        //CreationTime
        //InvalidationTime

        /// <summary>
        /// Starts a nested transaction.
        /// Result is the transaction identifier as text/plain.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.BEGINTRANSACTION, "/{AccountId}/{RepositoryId}/{TransactionId}")]
        //HTTPResponse BeginNestedTransaction(String AccountId, String RepositoryId, String TransactionId);

        /// <summary>
        /// Commit a transaction.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.COMMIT, "/{AccountId}/{RepositoryId}/{TransactionId}")]
        //HTTPResponse CommitTransaction(String AccountId, String RepositoryId, String TransactionId);
        //...
        //Comment

        /// <summary>
        /// Rollback a transaction.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}/{TransactionId}")]
        //HTTPResponse RollbackTransaction(String AccountId, String RepositoryId, String TransactionId);
        //...
        //Comment

        #endregion

        #region Transaction Metadata

        /// <summary>
        /// GetTransactionMetadata
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/{TransactionId}")]
        //HTTPResponse GetTransactionMetadata(String AccountId, String RepositoryId, String TransactionId);

        /// <summary>
        /// Get Transaction metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/{TransactionId}/metadata/{Metakey}")]
        //HTTPResponse GetTransactionMetadatum(String AccountId, String RepositoryId, String TransactionId, String Metakey);

        /// <summary>
        /// Update/Set repository metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}/{TransactionId}/metadata")]
        //HTTPResponse SetTransactionMetadata(String AccountId, String RepositoryId, String TransactionId);
        // include metadata map!

        /// <summary>
        /// Set repository metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}/{TransactionId}/metadata/{Metakey}")]
        //HTTPResponse SetTransactionMetadatum(String AccountId, String RepositoryId, String TransactionId, String Metakey);

        /// <summary>
        /// Delete repository metadata map (union with existing data!)
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}/{TransactionId}/metadata")]
        //HTTPResponse DeleteTransactionMetadata(String AccountId, String RepositoryId, String TransactionId);
        // include metadata map!

        /// <summary>
        /// Delete repository metadatum
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.DELETE, "/{AccountId}/{RepositoryId}/{TransactionId}/metadata/{Metakey}")]
        //HTTPResponse DeleteTransactionMetadatum(String AccountId, String RepositoryId, String TransactionId, String Metakey);

        #endregion


        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.PUT, "/{AccountId}/{RepositoryId}/{TransactionId}/gera/statement/subject/predicate/object/context")]
        //HTTPResponse SetStatement(String myResource);

        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/{TransactionId}/gera/statements")]
        //HTTPResponse GetResources(String myResource);
        //...
        //subject
        //predicate
        //object
        //context

        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/{TransactionId}/sparql/...")]
        //HTTPResponse GetResources(String myResource);


        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        //[NoAuthentication]
        //[HTTPMapping(HTTPMethods.GET, "/{AccountId}/{RepositoryId}/{TransactionId}/gremlin/...")]
        //HTTPResponse GetResources(String myResource);




        #region Utilities



        /// <summary>
        /// Returns internal resources embedded within the assembly.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/resources/{myResource}")]
        HTTPResponse GetResources(String myResource);


        /// <summary>
        /// Returns the favicon.ico.
        /// </summary>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/favicon.ico")]
        HTTPResponse GetFavicon();


        /// <summary>
        /// Get a http error for debugging purposes.
        /// An additional error reason may be given via the
        /// QueryString (e.g. "/error/204&reason=unknown")
        /// </summary>
        /// <param name="myHTTPStatusCode">The http status code.</param>
        [NoAuthentication]
        [HTTPMapping(HTTPMethods.GET, "/error/{myHTTPStatusCode}")]
        HTTPResponse GetError(String myHTTPStatusCode);

        #endregion


    }

}
