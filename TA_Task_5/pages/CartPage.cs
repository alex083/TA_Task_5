using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Task_5.pages
{
    class CartPage : BasePage
    {
        private readonly By proceedToCheckoutButton = By.XPath("//input[@name='proceedToRetailCheckout']");
        public CartPage(IWebDriver webdriver) : base(webdriver)
        {

        }
        public CartPage clickToCheckoutButton()
        {
            _webdriver.FindElement(proceedToCheckoutButton).Click();
            return this;
        }

    }
}
