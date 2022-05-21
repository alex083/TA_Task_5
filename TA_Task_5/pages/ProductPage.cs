using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Task_5.pages
{
    class ProductPage : BasePage
    {
        private readonly By addToCarButton = By.XPath("//input[@id='add-to-cart-button']");
        public ProductPage(IWebDriver webdriver) : base(webdriver)
        {

        }
        public ProductPage AddToCart()
        {
            _webdriver.FindElement(addToCarButton).Click();
            return this;
        }
    }

}
