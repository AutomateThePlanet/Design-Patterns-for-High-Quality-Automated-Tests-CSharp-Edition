using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace TestDataPreparationDemos.DataStubs
{
    [TestClass]
    public class UsingDataStubsTests
    {
        private static IWebDriver _driver;
        private static ProxyServer _proxyServer;
        private static ConcurrentDictionary<string, string> _redirectUrls;

        [ClassInitialize]
        public static void OnClassInitialize(TestContext context)
        {
            _proxyServer = new ProxyServer();
            var explicitEndPoint = new ExplicitProxyEndPoint(System.Net.IPAddress.Any, 18882, true);
            _redirectUrls = new ConcurrentDictionary<string, string>();
            _proxyServer.AddEndPoint(explicitEndPoint);
            _proxyServer.Start();
            _proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            _proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
            _proxyServer.BeforeRequest += OnRequestRedirectTrafficEventHandler;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _proxyServer.Stop();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var proxy = new OpenQA.Selenium.Proxy
            {
                HttpProxy = "http://localhost:18882",
                SslProxy = "http://localhost:18882",
                FtpProxy = "http://localhost:18882"
            };
            var options = new ChromeOptions
            {
                Proxy = proxy
            };
            _driver = new ChromeDriver(Environment.CurrentDirectory, options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ClearAllRedirectUrlPairs();
            _driver.Dispose();
        }

        [TestMethod]
        public void RequestRedirected_When_UsingProxyRedirect()
        {
            SetUrlToBeRedirectedTo("https://secure.gravatar.com/js/gprofiles.js?ver=2019Junaa", "https://stub.gravatar.com/js/gprofiles.js?ver=2019Junaa");

            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");
        }

        private void SetUrlToBeRedirectedTo(string originalUrl, string redirectUrl)
        {
            _redirectUrls.GetOrAdd(originalUrl, redirectUrl);
        }

        private void ClearAllRedirectUrlPairs()
        {
            _redirectUrls.Clear();
        }

        private static async Task OnRequestRedirectTrafficEventHandler(object sender, SessionEventArgs e) => await Task.Run(
            () =>
            {
                if (_redirectUrls.Keys.Count > 0)
                {
                    foreach (var redirectUrlPair in _redirectUrls)
                    {
                        if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains(redirectUrlPair.Key))
                        {
                            e.Redirect(redirectUrlPair.Value);
                        }
                    }
                }
            });
    }
}
