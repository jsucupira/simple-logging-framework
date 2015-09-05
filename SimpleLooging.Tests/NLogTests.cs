using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLogging;

namespace SimpleLooging.Tests
{
    [TestClass]
    public class NLogTests
    {
        private readonly ISimpleLogger _simpleLogger = SimpleLoggerFactory.Create();

        [TestMethod]
        public void test_logging_error_message()
        {
            _simpleLogger.LogError(string.Format("test_logging_error_message at: {0}", DateTime.Now));
        }

        [TestMethod]
        public void test_logging_error_with_exception()
        {
            _simpleLogger.LogError(new NotImplementedException("Not Implemented"), "test_logging_error_with_exception");
        }

        [TestMethod]
        public void test_logging_error_with_request_url()
        {
            _simpleLogger.LogError(string.Format("test_logging_error_with_exception_request_url at: {0}", DateTime.Now), "https://www.outback.com");
        }

        [TestMethod]
        public void test_logging_error_with_exception_request_url()
        {
            _simpleLogger.LogError(new ApplicationException("Error"), string.Format("test_logging_error_with_exception_request_url at: {0}", DateTime.Now), "https://www.outback.com");
        }

        [TestMethod]
        public void test_logging_error_with_exception_ip_urls()
        {
            _simpleLogger.LogError(new ApplicationException("Error"), string.Format("test_logging_error_with_ip_urls at: {0}", DateTime.Now), "https://www.outback.com", "127.0.0.1", "http://www.google.com");
        }

        [TestMethod]
        public void test_logging_error_with_ip_urls()
        {
            _simpleLogger.LogError(string.Format("test_logging_error_with_ip_urls at: {0}", DateTime.Now), "https://www.outback.com", "127.0.0.1", "http://www.google.com");
        }

        [TestMethod]
        public void test_logging_error_with_real_exception()
        {
            const string WRONG_URL = "www.test.com";
            try
            {
                Uri uri = new Uri(WRONG_URL);
            }
            catch (Exception ex)
            {
                _simpleLogger.LogError(ex, "There was an error on: test_logging_error_with_real_exception");
            }
        }

        [TestMethod]
        public void test_logging_trace_message()
        {
            _simpleLogger.LogTrace(string.Format("test_logging_trace_message at: {0}", DateTime.Now));
        }
        
        [TestMethod]
        public void test_logging_trace_with_exception_request_url()
        {
            _simpleLogger.LogTrace(string.Format("test_logging_trace_with_exception_request_url at: {0}", DateTime.Now), "https://www.outback.com");
        }

        [TestMethod]
        public void test_logging_trace_with_ip_urls()
        {
            _simpleLogger.LogTrace(string.Format("test_logging_trace_with_ip_urls at: {0}", DateTime.Now), "https://www.outback.com", "127.0.0.1", "http://www.google.com");
        }

        [TestMethod]
        public void test_logging_warning_message()
        {
            _simpleLogger.LogWarning(string.Format("test_logging_warning_message at: {0}", DateTime.Now));
        }
        
        [TestMethod]
        public void test_logging_warning_with_exception_request_url()
        {
            _simpleLogger.LogWarning(string.Format("test_logging_warning_with_exception_request_url at: {0}", DateTime.Now), "https://www.outback.com");
        }

        [TestMethod]
        public void test_logging_warning_with_ip_urls()
        {
            _simpleLogger.LogWarning(string.Format("test_logging_warning_with_ip_urls at: {0}", DateTime.Now), "https://www.outback.com", "127.0.0.1", "http://www.google.com");
        }

        [TestMethod]
        public void test_logging_information_message()
        {
            _simpleLogger.LogInfo(string.Format("test_logging_information_message at: {0}", DateTime.Now));
        }
        
        [TestMethod]
        public void test_logging_information_with_exception_request_url()
        {
            _simpleLogger.LogInfo(string.Format("test_logging_information_with_exception_request_url at: {0}", DateTime.Now), "https://www.outback.com");
        }

        [TestMethod]
        public void test_logging_information_with_ip_urls()
        {
            _simpleLogger.LogInfo(string.Format("test_logging_information_with_ip_urls at: {0}", DateTime.Now), "https://www.outback.com", "127.0.0.1", "http://www.google.com");
        }
    }
}