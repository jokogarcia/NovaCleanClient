using System;
using System.Collections.Generic;
using System.Net;

namespace NovaCleanClient.Exceptions
{
    public class BackendServiceException : Exception
    {
        /// <summary>
        /// Creates a BackendException with default values
        /// </summary>
        public BackendServiceException()
            : base("There was an error during a backend call")
        {
            SetDefaults();
        }

        /// <summary>
        /// Creates a BackendException with default values and a personalized message
        /// </summary>
        public BackendServiceException(string message)
            : base(message)
        {
            SetDefaults();
        }

        /// <summary>
        /// Creates a BackendException with default values and a personalized message
        /// </summary>
        public BackendServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
            SetDefaults();
        }

        /// <summary>
        /// Creates a BackendException
        /// </summary>
        public BackendServiceException(HttpStatusCode statusCode, int backendResult, string errorCode, string message)
            : base(message)
        {
            _code = statusCode;
            _errorCode = errorCode;
            _backendResult = backendResult;
        }

        HttpStatusCode _code;
        /// <summary>
        /// Gets the backend's Status Code. The default value is BadRequest = 400
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get { return _code; }
        }

        int _backendResult;
        /// <summary>
        /// Gets the backend's Result code. The default value is 999999
        /// </summary>
        public int BackendResult
        {
            get { return _backendResult; }
        }

        string _errorCode;
        /// <summary>
        /// Gets the backend's Error Code. The default value is 999999
        /// </summary>
        public string ErrorCode
        {
            get { return _errorCode; }
        }

        private Dictionary<string, string> _extraData = new Dictionary<string, string>();
        public Dictionary<string, string> ExtraData
        {
            get { return _extraData; }
        }

        private void SetDefaults()
        {
            _code = HttpStatusCode.BadRequest;
            _errorCode = "999999";
            _backendResult = 999999;
        }
    }
}
