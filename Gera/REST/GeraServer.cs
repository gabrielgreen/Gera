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
using de.ahzf.Hermod.HTTP;
using de.ahzf.Hermod.Datastructures;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A tcp/http based rexster server.
    /// </summary>
    public class GeraServer : HTTPServer<GeraService>
    {

        #region Data

        #endregion

        #region Properties

        #region DefaultServerName

        private const String _DefaultServerName = "Gera HTTP/REST Server v0.1";

        /// <summary>
        /// The default server name.
        /// </summary>
        public override String DefaultServerName
        {
            get
            {
                return _DefaultServerName;
            }
        }

        #endregion

        #region Accounts

        private IDictionary<VertexId, Account> _Accounts;

        #endregion

        #endregion

        #region Constructor(s)

        #region GeraServer()

        /// <summary>
        /// Initialize the GeraServer using IPAddress.Any, http port 8182 and start the server.
        /// </summary>
        public GeraServer()
            : base(IPv4Address.Any, new IPPort(8182), Autostart: true)
        {

            ServerName            = _DefaultServerName;
            //_Graphs               = new ConcurrentDictionary<String, IGraph>();
            //_AutoDiscoveryIGraphs = new AutoDiscoveryIGraphs();

            base.OnNewHTTPService += GeraService => { GeraService.Accounts = this._Accounts; };
            _Accounts = new Dictionary<VertexId, Account>();

        }

        #endregion

        #region GeraServer(myPort, myAutoStart = false)

        /// <summary>
        /// Initialize the GeraServer using IPAddress.Any and the given parameters.
        /// </summary>
        /// <param name="myPort">The listening port</param>
        /// <param name="Autostart"></param>
        public GeraServer(IPPort myPort, Boolean Autostart = false)
            : base(IPv4Address.Any, myPort, Autostart: true)
        {

            ServerName            = _DefaultServerName;
            //_Graphs               = new ConcurrentDictionary<String, IGraph>();
            //_AutoDiscoveryIGraphs = new AutoDiscoveryIGraphs();

            base.OnNewHTTPService += GeraService => { GeraService.Accounts = this._Accounts; };

        }

        #endregion

        #region GeraServer(myIIPAddress, myPort, myAutoStart = false)

        /// <summary>
        /// Initialize the HTTPServer using the given parameters.
        /// </summary>
        /// <param name="myIIPAddress">The listening IP address(es)</param>
        /// <param name="myPort">The listening port</param>
        /// <param name="Autostart"></param>
        public GeraServer(IIPAddress myIIPAddress, IPPort myPort, Boolean Autostart = false)
            : base(myIIPAddress, myPort, Autostart: true)
        {

            ServerName            = _DefaultServerName;
            //_Graphs               = new ConcurrentDictionary<String, IGraph>();
            //_AutoDiscoveryIGraphs = new AutoDiscoveryIGraphs();

            base.OnNewHTTPService += GeraService => { GeraService.Accounts = this._Accounts; };

        }

        #endregion

        #region GeraServer(myIPSocket, Autostart = false)

        /// <summary>
        /// Initialize the HTTPServer using the given parameters.
        /// </summary>
        /// <param name="myIPSocket">The listening IPSocket.</param>
        /// <param name="Autostart"></param>
        public GeraServer(IPSocket myIPSocket, Boolean Autostart = false)
            : base(myIPSocket.IPAddress, myIPSocket.Port, Autostart: true)
        {

            ServerName            = _DefaultServerName;
            //_Graphs               = new ConcurrentDictionary<String, IGraph>();
            //_AutoDiscoveryIGraphs = new AutoDiscoveryIGraphs();

            base.OnNewHTTPService += GeraService => { GeraService.Accounts = this._Accounts; };

        }

        #endregion

        #endregion


        public Account CreateAccount(VertexId AccountId)
        {
            var _Account = new Account(AccountId);
            this._Accounts.Add(_Account.Id, _Account);
            return _Account;
        }


        //#region this[myGraphname]

        ///// <summary>
        ///// Return a specific graph.
        ///// </summary>
        ///// <param name="myGraphname">The name of the graph.</param>
        //public IGraph this[String myGraphname]
        //{
        //    get
        //    {

        //        if (myGraphname == null)
        //            throw new ArgumentNullException("The myGraphname must not be null!");

        //        IGraph _IGraph = null;

        //        if (_Graphs.TryGetValue(myGraphname, out _IGraph))
        //            return _IGraph;

        //        return null;

        //    }
        //}

        //#endregion


    }

}
