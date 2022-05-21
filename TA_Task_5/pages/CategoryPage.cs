using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_Task_5.pages
{
    internal class CategoryPage : BasePage
    {
        private readonly By productCard = By.XPath("//a[@title='JSLEAP Mens Running Shoes Walking Non Slip Blade Type Sneakers']//div[@class='a-section octopus-pc-item-hue-shield octopus-pc-item-image-background-v3']");
        private readonly By brandCard = By.XPath("//a[@aria-label='adidas']//img[@alt='adidas']");
        public CategoryPage(IWebDriver webdriver) : base(webdriver)
        {

        }
        public CategoryPage clickToProductCard()
        {
            _webdriver.FindElement(productCard).Click();
            return this;
        }
        public CategoryPage clickToBrandCard()
        {
            _webdriver.FindElement(brandCard).Click();
            return this;
        }
    }
}
