using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TA_Task_5.pages
{
    class BasePage
    {
        protected IWebDriver _webdriver;
        private readonly By searchTextField = By.XPath("//input[@id='twotabsearchtextbox']");
        private readonly By seacrhButton = By.XPath("//input[@id='nav-search-submit-button']");
        private readonly By logoButton = By.XPath("//a[@id='nav-logo-sprites']");
        private readonly By sandwichMenuButton = By.XPath("//span[@class='hm-icon-label']");
        private readonly By iconCartButton = By.XPath("//span[normalize-space()='Cart']");
        private readonly By linkInNearTheMenu = By.XPath("//a[contains(@href,'/gp/goldbox?ref_=nav_cs_gb')]");
        
        public BasePage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
        public BasePage Search(string searchQuery)
        {
            _webdriver.FindElement(searchTextField).SendKeys(searchQuery);
            _webdriver.FindElement(seacrhButton).Click();
            return new BasePage(_webdriver);
        }
        public BasePage ClickToLogo()
        {
            _webdriver.FindElement(logoButton).Click();
            return this;
        }
        public BasePage ClikcToMenu()
        {
            _webdriver.FindElement(sandwichMenuButton).Click();
            return this;
        }
        public BasePage ClickToCart()
        {
            _webdriver.FindElement(iconCartButton).Click();
            return this;
        }
        public BasePage ClickToLink()
        {
            _webdriver.FindElement(linkInNearTheMenu).Click();
            return this;
        }
    }
}
