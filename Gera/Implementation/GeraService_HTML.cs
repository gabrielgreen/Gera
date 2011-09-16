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
using System.Text;
using System.Linq;

using de.ahzf.Hermod.HTTP;

#endregion

namespace de.ahzf.Gera
{

    /// <summary>
    /// A Gera HTML service implementation.
    /// </summary>
    public class GeraService_HTML : AGeraService, IGeraService
    {

        #region Constructor(s)

        #region GeraService_HTML()

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        public GeraService_HTML()
            : base(HTTPContentType.HTML_UTF8)
        { }

        #endregion

        #region GeraService_HTML(IHTTPConnection)

        /// <summary>
        /// Creates a new GeraService.
        /// </summary>
        /// <param name="IHTTPConnection">The http connection for this request.</param>
        public GeraService_HTML(IHTTPConnection IHTTPConnection)
            : base(IHTTPConnection, HTTPContentType.HTML_UTF8, "Gera.resources.")
        { }

        #endregion

        #endregion


        #region (private) HTMLBuilder(myHeadline, myFunc)

        /// <summary>
        /// A little HTML genereator...
        /// </summary>
        /// <param name="myHeadline"></param>
        /// <param name="AddHTMLAction"></param>
        /// <returns></returns>
        private String HTMLBuilder(String myHeadline, Action<StringBuilder> AddHTMLAction = null)
        {

            var _StringBuilder = new StringBuilder();

            _StringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _StringBuilder.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">");
            _StringBuilder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            _StringBuilder.AppendLine("<head>");
            _StringBuilder.AppendLine("<title>Gera</title>");
            _StringBuilder.AppendLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"/resources/style.css\" />");
            _StringBuilder.AppendLine("</head>");
            _StringBuilder.AppendLine("<body>");
            _StringBuilder.Append("<h1>").Append(myHeadline).AppendLine("</h1>");
            _StringBuilder.AppendLine("<table>");
            _StringBuilder.AppendLine("<tr>");
            _StringBuilder.AppendLine("<td style=\"width: 100px\">&nbsp;</td>");
            _StringBuilder.AppendLine("<td>");

            if (AddHTMLAction != null)
                AddHTMLAction(_StringBuilder);

            _StringBuilder.AppendLine("</td>");
            _StringBuilder.AppendLine("</tr>");
            _StringBuilder.AppendLine("</table>");
            _StringBuilder.AppendLine("</body>");
            _StringBuilder.AppendLine("</html>").AppendLine();

            return _StringBuilder.ToString();

        }

        #endregion


        #region GetRoot()

        /// <summary>
        /// The HTML landing page.
        /// </summary>
        public HTTPResponseHeader GetRoot()
        {

            var _RequestHeader = IHTTPConnection.RequestHeader;
            var _Content       = Encoding.UTF8.GetBytes(HTMLBuilder("Hello world!",
                    str => str.AppendLine("<a href=\"/Accounts\">List AccountIds</a><br />").
                               AppendLine("<script type=\"text/javascript\" src=\"resources/jQuery/jquery-1.6.1.min.js\"></script>").
                               AppendLine("<script type=\"text/javascript\">").
                               AppendLine("  function CreateNewAccount() {").
                               AppendLine("    jQuery.ajax({").
                               AppendLine("        type:     \"put\",").
                               AppendLine("        url:      \"/Account/\" + $(\"#NewAccountForm input[name=NewAccountId]\").val(),").
                               AppendLine("        dataType: \"json\",").
                               AppendLine("        async:    false,").
                               AppendLine("        success:  function(msg) { $(\"#infoarea\").html(\" <a href=\\\"/Account/\" + msg.AccountId + \" \\\">\" + msg.AccountId + \"</a>\");},").
                               AppendLine("        error:    function(msg) { alert(\"error: \" + msg); },").
                               AppendLine("        });").
                               AppendLine("  }").
                               AppendLine("</script>").
                               AppendLine("<form action=\"/Accounts\" method=\"post\">").
                               AppendLine(  "<input id=\"Senden\" type=\"submit\" name=\"senden\" value=\"Create random account\" />").
                               AppendLine("</form><br />").
                               AppendLine("<form id=\"NewAccountForm\" action=\"javascript:CreateNewAccount()\">").
                               AppendLine(  "<input id=\"NewAccountId\" type=\"text\" name=\"NewAccountId\" />").
                               AppendLine(  "<input id=\"Senden\" type=\"submit\" name=\"senden\" value=\"Create new account\" />").
                               AppendLine("</form><br />").
                               AppendLine("<div id=\"infoarea\"></div>")
                ));

            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64)_Content.Length,
                    ContentType    = HTTPContentType.HTML_UTF8,
                    Content        = _Content
            };

        }

        #endregion

        #region Accounts

        #region ListAccountIds()

        /// <summary>
        /// Return a list of valid accounts.
        /// </summary>
        public HTTPResponseHeader ListValidAccounts()
        {

            var _RequestHeader = IHTTPConnection.RequestHeader;
            var _Content       = Encoding.UTF8.GetBytes(HTMLBuilder("List Account Ids...",
                                     _StringBuilder => {

                                         foreach (var _AccountId in GeraServer.AccountIds)
                                             _StringBuilder.AppendLine("<a href=\"/Account/" + _AccountId + "\">" + _AccountId + "</a><br />");

                                         _StringBuilder.AppendLine("<br /><a href=\"/\">back</a><br />");

                                     }
                                 ));

            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.HTML_UTF8,
                    Content        = _Content
            };

        }

        #endregion

        #region CreateNewRandomAccount()

        /// <summary>
        /// Create a new account using a random AccountId.
        /// </summary>
        public HTTPResponseHeader CreateNewRandomAccount()
        {

            var _Account       = GeraServer.CreateAccount();
            var _RequestHeader = IHTTPConnection.RequestHeader;
            var _Content       = Encoding.UTF8.GetBytes(HTMLBuilder("Account Created!",
                                     _StringBuilder => _StringBuilder.AppendLine("<a href=\"/Account/" + _Account.Id.ToString() + "\">" + _Account.Id.ToString() + "</a><br />").
                                                                      AppendLine("<br /><a href=\"/\">back</a><br />")
                                 ));

            return new HTTPResponseBuilder() {
                    HTTPStatusCode = HTTPStatusCode.OK,
                    CacheControl   = "no-cache",
                    ContentLength  = (UInt64) _Content.Length,
                    ContentType    = HTTPContentType.HTML_UTF8,
                    Content        = _Content
            };

        }

        #endregion

        #region CreateNewAccount()

        /// <summary>
        /// Create a new account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader CreateNewAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.BadRequest,
                        CacheControl   = "no-cache",
                    };
            }

            #endregion

            var _NewAccountId = new AccountId(AccountId);

            if (!GeraServer.HasAccount(_NewAccountId))
            {

                var _Account       = GeraServer.CreateAccount(AccountId: _NewAccountId);
                var _RequestHeader = IHTTPConnection.RequestHeader;
                var _Content       = Encoding.UTF8.GetBytes(HTMLBuilder("Account Created!",
                                            _StringBuilder => _StringBuilder.AppendLine("<a href=\"/Account/" + _Account.Id.ToString() + "\">" + _Account.Id.ToString() + "</a><br />").
                                                                             AppendLine("<br /><a href=\"/\">back</a><br />")
                                        ));

                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.HTML_UTF8,
                        Content        = _Content
                };

            }


            #region ...or conflict!

            else
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.Conflict,
                        CacheControl   = "no-cache",
                    };
            }

            #endregion

        }

        #endregion

        #region GetAccountInformation(AccountId)

        /// <summary>
        ///  Get information on the given account.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader GetAccountInformation(String AccountId)
        {

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
            {

                var _RequestHeader = IHTTPConnection.RequestHeader;
                
                var _Content = Encoding.UTF8.GetBytes(HTMLBuilder("Account Information...",
                                   _StringBuilder => {

                                       _StringBuilder.AppendLine("<table>").
                                                      AppendLine("<tr><td>AccountId:</td><td>" + AccountId.ToString() + "</td></tr>");

                                       var _RepositoryArray = _Account.RepositoryIds.ToArray();
                                       var _RepositoryCount = _RepositoryArray.Length;

                                       if (_RepositoryCount > 0)
                                           _StringBuilder.AppendLine("<tr><td rowspan=" + GeraServer.NumberOfAccounts + ">Repositories</td><td><a href=\"/Account/" + AccountId.ToString() + "/" + _RepositoryArray[0] + "\">" + _RepositoryArray[0] + "</a></td></tr>");

                                       if (_RepositoryCount > 1)
                                           for(var _Repo = 1; _Repo<_RepositoryCount; _Repo++)
                                               _StringBuilder.AppendLine("<tr><td><a href=\"/Account/" + AccountId + "/" + _RepositoryArray[_Repo] + "\">" + _RepositoryArray[_Repo] + "</a></td></tr>");

                                   }
                               ));

                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.HTML_UTF8,
                        Content        = _Content
                };

            }


            #region ...invalid AccountId!

            else
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                        ContentLength  = 0,
                    };
            }

            #endregion

        }

        #endregion

        #region DeleteAccount()

        /// <summary>
        /// Delete an account using the given AccountId.
        /// </summary>
        /// <param name="AccountId">A valid AccountId.</param>
        public HTTPResponseHeader DeleteAccount(String AccountId)
        {

            #region Not a valid AccountId

            if (!IsValidAccountId(AccountId))
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.BadRequest,
                        CacheControl   = "no-cache",
                    };
            }

            #endregion

            var _AccountId = new AccountId(AccountId);

            if (GeraServer.HasAccount(_AccountId))
            {

                if (GeraServer.DeleteAccount(_AccountId))
                {

                    var _Content = Encoding.UTF8.GetBytes(HTMLBuilder("Account deleted!",
                                          _StringBuilder => _StringBuilder.AppendLine("<br /><a href=\"/\">back</a><br />")
                                      ));

                    return new HTTPResponseBuilder() {
                            HTTPStatusCode = HTTPStatusCode.OK,
                            CacheControl   = "no-cache",
                            ContentLength  = (UInt64) _Content.Length,
                            ContentType    = HTTPContentType.HTML_UTF8,
                            Content        = _Content
                    };


                }

                else return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.InternalServerError,
                        CacheControl   = "no-cache"
                    };

            }


            #region ...or not found!

            else
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                };
            }

            #endregion

        }

        #endregion

        #endregion


        #region ListRepositories()

        public HTTPResponseHeader ListRepositories(String AccountId)
        {

            IAccount _Account;
            var      _AccountId = new AccountId(AccountId);

            if (GeraServer.TryGetAccount(_AccountId, out _Account))
            {

                var _Content = Encoding.UTF8.GetBytes(HTMLBuilder("List Repositories...",
                                   _StringBuilder => {

                                       _StringBuilder.AppendLine("<table>").
                                                      AppendLine("<tr><td>AccountId:</td><td>" + AccountId.ToString() + "</td></tr>");

                                       var _RepositoryArray = _Account.RepositoryIds.ToArray();
                                       var _RepositoryCount = _RepositoryArray.Length;

                                       if (_RepositoryCount > 0)
                                           _StringBuilder.AppendLine("<tr><td rowspan=" + GeraServer.NumberOfAccounts + ">Repositories</td><td><a href=\"/Account/" + AccountId.ToString() + "/" + _RepositoryArray[0] + "\">" + _RepositoryArray[0] + "</a></td></tr>");

                                       if (_RepositoryCount > 1)
                                           for(var _Repo = 1; _Repo<_RepositoryCount; _Repo++)
                                               _StringBuilder.AppendLine("<tr><td><a href=\"/Account/" + AccountId + "/" + _RepositoryArray[_Repo] + "\">" + _RepositoryArray[_Repo] + "</a></td></tr>");

                                   }
                               ));

                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.OK,
                        CacheControl   = "no-cache",
                        ContentLength  = (UInt64) _Content.Length,
                        ContentType    = HTTPContentType.HTML_UTF8,
                        Content        = _Content
                };

            }


            #region ...invalid AccountId!

            else
            {
                return new HTTPResponseBuilder() {
                        HTTPStatusCode = HTTPStatusCode.NotFound,
                        CacheControl   = "no-cache",
                        ContentLength  = 0,
                };
            }

            #endregion

        }

        #endregion

    }

}

