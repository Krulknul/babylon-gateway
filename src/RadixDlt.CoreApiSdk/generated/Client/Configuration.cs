/* Copyright 2021 Radix Publishing Ltd incorporated in Jersey (Channel Islands).
 *
 * Licensed under the Radix License, Version 1.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at:
 *
 * radixfoundation.org/licenses/LICENSE-v1
 *
 * The Licensor hereby grants permission for the Canonical version of the Work to be
 * published, distributed and used under or by reference to the Licensor’s trademark
 * Radix ® and use of any unregistered trade names, logos or get-up.
 *
 * The Licensor provides the Work (and each Contributor provides its Contributions) on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied,
 * including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT,
 * MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE.
 *
 * Whilst the Work is capable of being deployed, used and adopted (instantiated) to create
 * a distributed ledger it is your responsibility to test and validate the code, together
 * with all logic and performance of that code under all foreseeable scenarios.
 *
 * The Licensor does not make or purport to make and hereby excludes liability for all
 * and any representation, warranty or undertaking in any form whatsoever, whether express
 * or implied, to any entity or person, including any representation, warranty or
 * undertaking, as to the functionality security use, value or other characteristics of
 * any distributed ledger nor in respect the functioning or value of any tokens which may
 * be created stored or transferred using the Work. The Licensor does not warrant that the
 * Work or any use of the Work complies with any law or regulation in any territory where
 * it may be implemented or used or that it will be appropriate for any specific purpose.
 *
 * Neither the licensor nor any current or former employees, officers, directors, partners,
 * trustees, representatives, agents, advisors, contractors, or volunteers of the Licensor
 * shall be liable for any direct or indirect, special, incidental, consequential or other
 * losses of any kind, in tort, contract or otherwise (including but not limited to loss
 * of revenue, income or profits, or loss of use or data, or loss of reputation, or loss
 * of any economic or other opportunity of whatsoever nature or howsoever arising), arising
 * out of or in connection with (without limitation of any use, misuse, of any ledger system
 * or use made or its functionality or any performance or operation of any code or protocol
 * caused by bugs or programming or logic errors or otherwise);
 *
 * A. any offer, purchase, holding, use, sale, exchange or transmission of any
 * cryptographic keys, tokens or assets created, exchanged, stored or arising from any
 * interaction with the Work;
 *
 * B. any failure in a transmission or loss of any token or assets keys or other digital
 * artefacts due to errors in transmission;
 *
 * C. bugs, hacks, logic errors or faults in the Work or any communication;
 *
 * D. system software or apparatus including but not limited to losses caused by errors
 * in holding or transmitting tokens by any third-party;
 *
 * E. breaches or failure of security including hacker attacks, loss or disclosure of
 * password, loss of private key, unauthorised use or misuse of such passwords or keys;
 *
 * F. any losses including loss of anticipated savings or other benefits resulting from
 * use of the Work or any changes to the Work (however implemented).
 *
 * You are solely responsible for; testing, validating and evaluation of all operation
 * logic, functionality, security and appropriateness of using the Work for any commercial
 * or non-commercial purpose and for any reproduction or redistribution by You of the
 * Work. You assume all risks associated with Your use of the Work and the exercise of
 * permissions under this License.
 */

/*
 * Radix Core API
 *
 * This API provides endpoints from a node for integration with the Radix ledger.  # Overview  > WARNING > > The Core API is __NOT__ intended to be available on the public web. It is > designed to be accessed in a private network.  The Core API is separated into three: * The **Data API** is a read-only api which allows you to view and sync to the state of the ledger. * The **Construction API** allows you to construct and submit a transaction to the network. * The **Key API** allows you to use the keys managed by the node to sign transactions.  The Core API is a low level API primarily designed for network integrations such as exchanges, ledger analytics providers, or hosted ledger data dashboards where detailed ledger data is required and the integrator can be expected to run their node to provide the Core API for their own consumption.  For a higher level API, see the [Gateway API](https://redocly.github.io/redoc/?url=https://raw.githubusercontent.com/radixdlt/radixdlt-network-gateway/main/generation/gateway-api-spec.yaml).  For node monitoring, see the [System API](https://redocly.github.io/redoc/?url=https://raw.githubusercontent.com/radixdlt/radixdlt/main/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/system/api.yaml).  ## Rosetta  The Data API and Construction API is inspired from [Rosetta API](https://www.rosetta-api.org/) most notably:   * Use of a JSON-Based RPC protocol on top of HTTP Post requests   * Use of Operations, Amounts, and Identifiers as universal language to   express asset movement for reading and writing  There are a few notable exceptions to note:   * Fetching of ledger data is through a Transaction stream rather than a   Block stream   * Use of `EntityIdentifier` rather than `AccountIdentifier`   * Use of `OperationGroup` rather than `related_operations` to express related   operations   * Construction endpoints perform coin selection on behalf of the caller.   This has the unfortunate effect of not being able to support high frequency   transactions from a single account. This will be addressed in future updates.   * Construction endpoints are online rather than offline as required by Rosetta  Future versions of the api will aim towards a fully-compliant Rosetta API.  ## Enabling Endpoints  All endpoints are enabled when running a node with the exception of two endpoints, each of which need to be manually configured to access: * `/transactions` endpoint must be enabled with configuration `api.transaction.enable=true`. This is because the transactions endpoint requires additional database storage which may not be needed for users who aren't using this endpoint * `/key/sign` endpoint must be enable with configuration `api.sign.enable=true`. This is a potentially dangerous endpoint if accessible publicly so it must be enabled manually.  ## Client Code Generation  We have found success with generating clients against the [api.yaml specification](https://raw.githubusercontent.com/radixdlt/radixdlt/main/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/api.yaml). See https://openapi-generator.tech/ for more details.  The OpenAPI generator only supports openapi version 3.0.0 at present, but you can change 3.1.0 to 3.0.0 in the first line of the spec without affecting generation.  # Data API Flow  The Data API can be used to synchronize a full or partial view of the ledger, transaction by transaction.  ![Data API Flow](https://raw.githubusercontent.com/radixdlt/radixdlt/feature/update-documentation/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/documentation/data_sequence_flow.png)  # Construction API Flow  The Construction API can be used to construct and submit transactions to the network.  ![Construction API Flow](https://raw.githubusercontent.com/radixdlt/radixdlt/feature/open-api/radixdlt-core/radixdlt/src/main/java/com/radixdlt/api/core/documentation/construction_sequence_flow.png)  Unlike the Rosetta Construction API [specification](https://www.rosetta-api.org/docs/construction_api_introduction.html), this Construction API selects UTXOs on behalf of the caller. This has the unfortunate side effect of not being able to support high frequency transactions from a single account due to UTXO conflicts. This will be addressed in a future release. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net.Http;

namespace RadixDlt.CoreApiSdk.Client
{
    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public class Configuration : IReadableConfiguration
    {
        #region Constants

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <value>Version of the package.</value>
        public const string Version = "1.0.0";

        /// <summary>
        /// Identifier for ISO 8601 DateTime Format
        /// </summary>
        /// <remarks>See https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8 for more information.</remarks>
        // ReSharper disable once InconsistentNaming
        public const string ISO8601_DATETIME_FORMAT = "o";

        #endregion Constants

        #region Static Members

        /// <summary>
        /// Default creation of exceptions for a given method name and response object
        /// </summary>
        public static readonly ExceptionFactory DefaultExceptionFactory = (methodName, response) =>
        {
            var status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.RawContent),
                    response.RawContent, response.Headers);
            }
            if (status == 0)
            {
                return new ApiException(status,
                    string.Format("Error calling {0}: {1}", methodName, response.ErrorText), response.ErrorText);
            }
            return null;
        };

        #endregion Static Members

        #region Private Members

        /// <summary>
        /// Defines the base path of the target API server.
        /// Example: http://localhost:3000/v1/
        /// </summary>
        private string _basePath;

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// This is the key and value comprising the "secret" for accessing an API.
        /// </summary>
        /// <value>The API key.</value>
        private IDictionary<string, string> _apiKey;

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        /// </summary>
        /// <value>The prefix of the API key.</value>
        private IDictionary<string, string> _apiKeyPrefix;

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;
        private string _tempFolderPath = Path.GetTempPath();

        /// <summary>
        /// Gets or sets the servers defined in the OpenAPI spec.
        /// </summary>
        /// <value>The servers</value>
        private IList<IReadOnlyDictionary<string, object>> _servers;

        /// <summary>
        /// Gets or sets the operation servers defined in the OpenAPI spec.
        /// </summary>
        /// <value>The operation servers</value>
        private IReadOnlyDictionary<string, List<IReadOnlyDictionary<string, object>>> _operationServers;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Configuration()
        {
            Proxy = null;
            UserAgent = WebUtility.UrlEncode("OpenAPI-Generator/1.0.0/csharp");
            BasePath = "http://localhost:3333";
            DefaultHeaders = new ConcurrentDictionary<string, string>();
            ApiKey = new ConcurrentDictionary<string, string>();
            ApiKeyPrefix = new ConcurrentDictionary<string, string>();
            Servers = new List<IReadOnlyDictionary<string, object>>()
            {
                {
                    new Dictionary<string, object> {
                        {"url", "localhost:3333"},
                        {"description", "No description provided"},
                    }
                }
            };
            OperationServers = new Dictionary<string, List<IReadOnlyDictionary<string, object>>>()
            {
            };

            // Setting Timeout has side effects (forces ApiClient creation).
            Timeout = 100000;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Configuration(
            IDictionary<string, string> defaultHeaders,
            IDictionary<string, string> apiKey,
            IDictionary<string, string> apiKeyPrefix,
            string basePath = "http://localhost:3333") : this()
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("The provided basePath is invalid.", "basePath");
            if (defaultHeaders == null)
                throw new ArgumentNullException("defaultHeaders");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (apiKeyPrefix == null)
                throw new ArgumentNullException("apiKeyPrefix");

            BasePath = basePath;

            foreach (var keyValuePair in defaultHeaders)
            {
                DefaultHeaders.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKey)
            {
                ApiKey.Add(keyValuePair);
            }

            foreach (var keyValuePair in apiKeyPrefix)
            {
                ApiKeyPrefix.Add(keyValuePair);
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the base path for API access.
        /// </summary>
        public virtual string BasePath {
            get { return _basePath; }
            set { _basePath = value; }
        }

        /// <summary>
        /// Gets or sets the default header.
        /// </summary>
        [Obsolete("Use DefaultHeaders instead.")]
        public virtual IDictionary<string, string> DefaultHeader
        {
            get
            {
                return DefaultHeaders;
            }
            set
            {
                DefaultHeaders = value;
            }
        }

        /// <summary>
        /// Gets or sets the default headers.
        /// </summary>
        public virtual IDictionary<string, string> DefaultHeaders { get; set; }

        /// <summary>
        /// Gets or sets the HTTP timeout (milliseconds) of ApiClient. Default to 100000 milliseconds.
        /// </summary>
        public virtual int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the proxy
        /// </summary>
        /// <value>Proxy.</value>
        public virtual WebProxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the HTTP user agent.
        /// </summary>
        /// <value>Http user agent.</value>
        public virtual string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the username (HTTP basic authentication).
        /// </summary>
        /// <value>The username.</value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the password (HTTP basic authentication).
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; set; }

        /// <summary>
        /// Gets the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            string apiKeyValue;
            ApiKey.TryGetValue(apiKeyIdentifier, out apiKeyValue);
            string apiKeyPrefix;
            if (ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out apiKeyPrefix))
            {
                return apiKeyPrefix + " " + apiKeyValue;
            }

            return apiKeyValue;
        }

        /// <summary>
        /// Gets or sets certificate collection to be sent with requests.
        /// </summary>
        /// <value>X509 Certificate collection.</value>
        public X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Gets or sets the access token for OAuth2 authentication.
        ///
        /// This helper property simplifies code generation.
        /// </summary>
        /// <value>The access token.</value>
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the temporary folder path to store the files downloaded from the server.
        /// </summary>
        /// <value>Folder path.</value>
        public virtual string TempFolderPath
        {
            get { return _tempFolderPath; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _tempFolderPath = Path.GetTempPath();
                    return;
                }

                // create the directory if it does not exist
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                // check if the path contains directory separator at the end
                if (value[value.Length - 1] == Path.DirectorySeparatorChar)
                {
                    _tempFolderPath = value;
                }
                else
                {
                    _tempFolderPath = value + Path.DirectorySeparatorChar;
                }
            }
        }

        /// <summary>
        /// Gets or sets the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public virtual string DateTimeFormat
        {
            get { return _dateTimeFormat; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix (e.g. Token) of the API key based on the authentication name.
        ///
        /// Whatever you set here will be prepended to the value defined in AddApiKey.
        ///
        /// An example invocation here might be:
        /// <example>
        /// ApiKeyPrefix["Authorization"] = "Bearer";
        /// </example>
        /// … where ApiKey["Authorization"] would then be used to set the value of your bearer token.
        ///
        /// <remarks>
        /// OAuth2 workflows should set tokens via AccessToken.
        /// </remarks>
        /// </summary>
        /// <value>The prefix of the API key.</value>
        public virtual IDictionary<string, string> ApiKeyPrefix
        {
            get { return _apiKeyPrefix; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKeyPrefix collection may not be null.");
                }
                _apiKeyPrefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the API key based on the authentication name.
        /// </summary>
        /// <value>The API key.</value>
        public virtual IDictionary<string, string> ApiKey
        {
            get { return _apiKey; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("ApiKey collection may not be null.");
                }
                _apiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the servers.
        /// </summary>
        /// <value>The servers.</value>
        public virtual IList<IReadOnlyDictionary<string, object>> Servers
        {
            get { return _servers; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Servers may not be null.");
                }
                _servers = value;
            }
        }

        /// <summary>
        /// Gets or sets the operation servers.
        /// </summary>
        /// <value>The operation servers.</value>
        public virtual IReadOnlyDictionary<string, List<IReadOnlyDictionary<string, object>>> OperationServers
        {
            get { return _operationServers; }
            set
            {
                if (value == null)
                {
                    throw new InvalidOperationException("Operation servers may not be null.");
                }
                _operationServers = value;
            }
        }

        /// <summary>
        /// Returns URL based on server settings without providing values
        /// for the variables
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index)
        {
            return GetServerUrl(Servers, index, null);
        }

        /// <summary>
        /// Returns URL based on server settings.
        /// </summary>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The server URL.</return>
        public string GetServerUrl(int index, Dictionary<string, string> inputVariables)
        {
            return GetServerUrl(Servers, index, inputVariables);
        }

        /// <summary>
        /// Returns URL based on operation server settings.
        /// </summary>
        /// <param name="operation">Operation associated with the request path.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <return>The operation server URL.</return>
        public string GetOperationServerUrl(string operation, int index)
        {
            return GetOperationServerUrl(operation, index, null);
        }

        /// <summary>
        /// Returns URL based on operation server settings.
        /// </summary>
        /// <param name="operation">Operation associated with the request path.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The operation server URL.</return>
        public string GetOperationServerUrl(string operation, int index, Dictionary<string, string> inputVariables)
        {
            if (OperationServers.TryGetValue(operation, out var operationServer))
            {
                return GetServerUrl(operationServer, index, inputVariables);
            }

            return null;
        }

        /// <summary>
        /// Returns URL based on server settings.
        /// </summary>
        /// <param name="servers">Dictionary of server settings.</param>
        /// <param name="index">Array index of the server settings.</param>
        /// <param name="inputVariables">Dictionary of the variables and the corresponding values.</param>
        /// <return>The server URL.</return>
        private string GetServerUrl(IList<IReadOnlyDictionary<string, object>> servers, int index, Dictionary<string, string> inputVariables)
        {
            if (index < 0 || index >= servers.Count)
            {
                throw new InvalidOperationException($"Invalid index {index} when selecting the server. Must be less than {servers.Count}.");
            }

            if (inputVariables == null)
            {
                inputVariables = new Dictionary<string, string>();
            }

            IReadOnlyDictionary<string, object> server = servers[index];
            string url = (string)server["url"];

            if (server.ContainsKey("variables"))
            {
                // go through each variable and assign a value
                foreach (KeyValuePair<string, object> variable in (IReadOnlyDictionary<string, object>)server["variables"])
                {

                    IReadOnlyDictionary<string, object> serverVariables = (IReadOnlyDictionary<string, object>)(variable.Value);

                    if (inputVariables.ContainsKey(variable.Key))
                    {
                        if (((List<string>)serverVariables["enum_values"]).Contains(inputVariables[variable.Key]))
                        {
                            url = url.Replace("{" + variable.Key + "}", inputVariables[variable.Key]);
                        }
                        else
                        {
                            throw new InvalidOperationException($"The variable `{variable.Key}` in the server URL has invalid value #{inputVariables[variable.Key]}. Must be {(List<string>)serverVariables["enum_values"]}");
                        }
                    }
                    else
                    {
                        // use default value
                        url = url.Replace("{" + variable.Key + "}", (string)serverVariables["default_value"]);
                    }
                }
            }

            return url;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a string with essential information for debugging.
        /// </summary>
        public static string ToDebugReport()
        {
            string report = "C# SDK (RadixDlt.CoreApiSdk) Debug Report:\n";
            report += "    OS: " + System.Environment.OSVersion + "\n";
            report += "    .NET Framework Version: " + System.Environment.Version  + "\n";
            report += "    Version of the API: 1.0.0\n";
            report += "    SDK Package Version: 1.0.0\n";

            return report;
        }

        /// <summary>
        /// Add Api Key Header.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        /// <returns></returns>
        public void AddApiKey(string key, string value)
        {
            ApiKey[key] = value;
        }

        /// <summary>
        /// Sets the API key prefix.
        /// </summary>
        /// <param name="key">Api Key name.</param>
        /// <param name="value">Api Key value.</param>
        public void AddApiKeyPrefix(string key, string value)
        {
            ApiKeyPrefix[key] = value;
        }

        #endregion Methods

        #region Static Members
        /// <summary>
        /// Merge configurations.
        /// </summary>
        /// <param name="first">First configuration.</param>
        /// <param name="second">Second configuration.</param>
        /// <return>Merged configuration.</return>
        public static IReadableConfiguration MergeConfigurations(IReadableConfiguration first, IReadableConfiguration second)
        {
            if (second == null) return first ?? GlobalConfiguration.Instance;

            Dictionary<string, string> apiKey = first.ApiKey.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> apiKeyPrefix = first.ApiKeyPrefix.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Dictionary<string, string> defaultHeaders = first.DefaultHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in second.ApiKey) apiKey[kvp.Key] = kvp.Value;
            foreach (var kvp in second.ApiKeyPrefix) apiKeyPrefix[kvp.Key] = kvp.Value;
            foreach (var kvp in second.DefaultHeaders) defaultHeaders[kvp.Key] = kvp.Value;

            var config = new Configuration
            {
                ApiKey = apiKey,
                ApiKeyPrefix = apiKeyPrefix,
                DefaultHeaders = defaultHeaders,
                BasePath = second.BasePath ?? first.BasePath,
                Timeout = second.Timeout,
                Proxy = second.Proxy ?? first.Proxy,
                UserAgent = second.UserAgent ?? first.UserAgent,
                Username = second.Username ?? first.Username,
                Password = second.Password ?? first.Password,
                AccessToken = second.AccessToken ?? first.AccessToken,
                TempFolderPath = second.TempFolderPath ?? first.TempFolderPath,
                DateTimeFormat = second.DateTimeFormat ?? first.DateTimeFormat,
                ClientCertificates = second.ClientCertificates ?? first.ClientCertificates,
            };
            return config;
        }
        #endregion Static Members
    }
}
