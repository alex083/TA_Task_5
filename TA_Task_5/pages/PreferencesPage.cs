using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Task_5.pages
{
    class PreferencesPage : BasePage
    {
        private readonly By langButton = By.XPath("//span[normalize-space()='- Traducción']");
        private readonly By changeCurrencyButton = By.XPath("//span[@class='a-button-text a-declarative']");
        private readonly By currencyName = By.XPath("//body/div[@id='a-popover-5']/div[@class='a-popover-wrapper']/div[@class='a-popover-inner a-lgtbox-vertical-scroll']/ul[@role='listbox']/li[@id='MYR']/a[@id='icp-currency-dropdown_8']/span[1]");
        public PreferencesPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public PreferencesPage ChangeLanguage()
        {
            _webdriver.FindElement(langButton).Click();
            return this;
        }
        public PreferencesPage ChangeCurency()
        {
            _webdriver.FindElement(changeCurrencyButton).Click();
            _webdriver.FindElement(currencyName).Click();
            return this;
        }
    }
}
