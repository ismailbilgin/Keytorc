using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keytorc
{
    public class Searching
    {
        IWebDriver driver;
        By search = By.Id("searchData");
        By searchButton = By.ClassName("searchBtn");
        By secondPage = By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div[4]/a[2]");


        public Searching(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Search()
        {
            //Write Search box to "Samsung"
            driver.FindElement(search).SendKeys("Samsung");
            
        }
        public void clickSearchButton()
        {
            //Click on Search button
            driver.FindElement(searchButton).Click();

        }

        public void pageTwo()
        {
            //Go to second page via paging buttin
            driver.FindElement(secondPage).Click();

            IWebElement currentPage = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/input[1]"));
          
            string page = currentPage.GetAttribute("value").ToString();
            //Check for Second page
            Assert.IsTrue(page.Equals("2"), "Could not reached page 2! ");
            
            Console.WriteLine("Paging control has been used and reached the 2 page.! ");
            
        }

    }
}
