﻿using Spotify.NetStandard.Client.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Spotify.NetStandard.Client.Authentication.Internal
{
    /// <summary>
    /// Authentication Client
    /// </summary>
    internal class AuthenticationClient : SimpleServiceClient
    {
        // Endpoint
        private readonly Uri host_name = new Uri("https://accounts.spotify.com");
        // Token Auth
        private const string auth_header = "Authorization";
        private const string auth_basic = "Basic";
        private const string grant_type = "grant_type";
        private const string client_credentials = "client_credentials";
        private const string token_uri = "/api/token";
        // Get Auth
        private const string response_type = "response_type";
        private const string code_value = "code";
        private const string client_id = "client_id";
        private const string scope_value = "scope";
        private const string state_value = "state";
        private const string token_value = "token";
        private const string redirect_uri = "redirect_uri";
        private const string auth_uri = "/authorize";
        // Url Auth
        private const string authorization_code = "authorization_code";
        private const string refresh_token = "refresh_token";
        private const string show_dialog = "show_dialog";
        #region Private Methods
        /// <summary>
        /// Get Headers
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <returns>Dictionary Of String, String</returns>
        private Dictionary<string, string> GetHeaders(
            string clientId,
            string clientSecret)
        {
            string auth = Convert.ToBase64String(
            Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { auth_header, $"{auth_basic} {auth}"}
            };
            return headers;
        }
        #endregion Private Methods

        #region Public Methods
        /// <summary>
        /// Authenticate - Client Credentials Flow - Client Credentials Request
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Authentication Response</returns>
        public Task<AuthenticationResponse> ClientCredentialsAuthAsync(
            string clientId, 
            string clientSecret, 
            CancellationToken cancellationToken)
        {
            var headers = GetHeaders(clientId, clientSecret);
            var request = new Dictionary<string, string>()
            {
                { grant_type, client_credentials }
            };
            return PostRequestAsync<Dictionary<string, string>, AuthenticationResponse>(host_name,
                token_uri, null, cancellationToken, request, null, headers, true);
        }

        /// <summary>
        /// Authenticate - Authorisation Code Flow - Authorisation Code Request
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <param name="accessCode">Access Code</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Authentication Response</returns>
        public Task<AuthenticationResponse> AuthorisationCodeAuthAsync(
            string clientId, 
            string clientSecret, 
            AccessCode accessCode, 
            CancellationToken cancellationToken)
        {
            var headers = GetHeaders(clientId, clientSecret);
            var request = new Dictionary<string, string>()
            {
                { grant_type, authorization_code },
                { code_value, accessCode.Code },
                { redirect_uri, accessCode.RedirectUri.ToString() }
            };
            return PostRequestAsync<Dictionary<string, string>, AuthenticationResponse>(host_name,
                token_uri, null, cancellationToken, request, null, headers, true);
        }

        /// <summary>
        /// Authenticate - Authorization Code Flow - Refresh Token Request
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <param name="refreshToken">Refresh Token</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Authentication Response</returns>
        public Task<AuthenticationResponse> RefreshTokenAuthAsync(
            string clientId,
            string clientSecret,
            string refreshToken,
            CancellationToken cancellationToken)
        {
            var headers = GetHeaders(clientId, clientSecret);
            var request = new Dictionary<string, string>()
            {
                { grant_type, refresh_token },
                { refresh_token, refreshToken },
            };
            return PostRequestAsync<Dictionary<string, string>, AuthenticationResponse>(host_name,
                token_uri, null, cancellationToken, request, null, headers, true);
        }

        /// <summary>
        /// Authenticate - Authorization Code Flow - Access Code Request
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="scopes">Comma delimited scopes</param>
        /// <param name="state">State</param>
        /// <param name="redirectUrl">Redirect Url</param>
        /// <param name="showDialog">Show Dialog</param>
        /// <returns>Url</returns>
        public Uri AccessTokenAuth(
            string clientId, 
            string scopes, 
            string state, 
            string redirectUrl,
            bool showDialog)
        {
            var request = new Dictionary<string, string>()
            {
                { response_type, code_value },
                { client_id, clientId },
                { scope_value, scopes },
                { state_value, HttpUtility.UrlEncode(state) },
                { redirect_uri, HttpUtility.UrlEncode(redirectUrl) },
                { show_dialog, showDialog.ToString().ToLower() }
            };
            return GetUri(host_name, auth_uri, request);
        }

        /// <summary>
        /// Authenticate - Implicit Grant Flow
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="scopes">Comma delimited scopes</param>
        /// <param name="state">State</param>
        /// <param name="redirectUrl">Redirect Url</param>
        /// <param name="showDialog">Show Dialog</param>
        /// <returns>Url</returns>
        public Uri ImplicitGrantAuth(
            string clientId,
            string scopes,
            string state,
            string redirectUrl,
            bool showDialog)
        {
            var request = new Dictionary<string, string>()
            {
                { response_type, token_value },
                { client_id, clientId },
                { scope_value, scopes },
                { state_value, HttpUtility.UrlEncode(state) },
                { redirect_uri, HttpUtility.UrlEncode(redirectUrl) },
                { show_dialog, showDialog.ToString().ToLower() }
            };
            return GetUri(host_name, auth_uri, request);
        }
        #endregion Public Methods
    }
}
