using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TA_Task_5.pages;
[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace TA_Task_5
{
    [TestFixture("Chrome","101.0", "Windows 10", "Chrome101")]
    [TestFixture("MicrosoftEdge", "101.0", "Windows 10", "MicrosoftEdge101")]
    [TestFixture("Opera","87.0", "Windows 10", "Opera87")]
    [TestFixture("FireFox", "100.0", "Windows 10", "FireFox100")]
    public class Tests
    {
        private IWebDriver _webdriver;
        private string hubUrl;
        private string _browser;
        private string _version;
        private string _os;
        private string _name;
        public Tests(string browser, string version, string os, string name)
        {
            _browser = browser;
            _version = version;
            _os = os;
            _name = name;
        }

        [SetUp]
        public void Setup()
        {
            dynamic capability = GetBrowserOptions(_browser);
            hubUrl = "http://localhost:4444/wd/hub";
            _webdriver = new RemoteWebDriver(new Uri(hubUrl), capability) ;
            _webdriver.Manage().Window.Maximize();
        }

        [Test]
        [Parallelizable]
        public void CheckSearch()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/");
            Thread.Sleep(1000);
            var homePage = new HomePage(_webdriver);
            homePage.Search("Наушники Apple AirPods with Charging Case");
        }
        [Test]
        public void CheckToClickToLogo()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/b/?ie=UTF8&node=17853230011&ref_=sv_hg_3");
            var homePage = new HomePage(_webdriver);
            homePage.ClickToLogo();
        }
        [Test]
        public void CheckMainMenu()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/b/?ie=UTF8&node=17853230011&ref_=sv_hg_3");
            var homePage = new HomePage(_webdriver);
            homePage.ClikcToMenu();
        }
        [Test]
        public void CheckToAddToCart()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/Gildan-Cotton-T-Shirt-G2000-10-Pack/dp/B096W7BTDQ");
            var homePage = new ProductPage(_webdriver);
            homePage.AddToCart();
        }
        [Test]
        public void CheckToCartPage()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/b/?ie=UTF8&node=17853230011&ref_=sv_hg_3");
            var homePage = new ProductPage(_webdriver);
            homePage.AddToCart();
            Thread.Sleep(500);
            var cartPage = new CartPage(_webdriver);
            cartPage.ClickToCart();
        }
        [Test]
        public void CheckToBrandCardClick()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/s?k=shoes&i=fashion-mens-intl-ship&pf_rd_i=23466307011&pf_rd_m=ATVPDKIKX0DER&pf_rd_p=ac44f2ea-50c6-4b75-aa64-e9fc0458792b&pf_rd_r=WVMZG09N4B7Y2ZCYY8WD&pf_rd_s=merchandised-search-5&pf_rd_t=101&ref=nb_sb_noss");
            var categoryPage = new CategoryPage(_webdriver);
            categoryPage.clickToBrandCard();
        }
        [Test]
        public void CheckLinksNearTheMenu()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com");
            var homePage = new HomePage(_webdriver);
            homePage.ClickToLink();
        }
        [Test]
        public void CheckChangeTheLanguage()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/customer-preferences/edit");
            var preferencesPage = new PreferencesPage(_webdriver);
            preferencesPage.ChangeLanguage();
        }
        public void CheckChangeCurrency()
        {
            _webdriver.Navigate().GoToUrl("https://www.amazon.com/customer-preferences/edit");
            var preferencesPage = new PreferencesPage(_webdriver);
            preferencesPage.ChangeCurency();
        }

        [TearDown]
        public void TearDown()
        {
            _webdriver.Quit();
        }
        private dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    return new ChromeOptions();
                case "MicrosoftEdge":
                    return new EdgeOptions();
                case "FireFox":
                    return new FirefoxOptions();
                case "Opera":
                    return new OperaOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}