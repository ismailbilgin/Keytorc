using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keytorc
{
    public class AddingFavorite
    {
        public IWebDriver driver;

        public AddingFavorite(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void resultForSamsung()
        {
            //Search textbox
            string xPath = "//*[@id=\"breadCrumb\"]/ul/li[2]/a/span";
            IWebElement xPathElement = driver.FindElement(By.XPath(xPath));

            //Check result for "Samsung" and Add favorite
            if (xPathElement.Text.Equals("Samsung"))
            {
                IWebElement thirdElement = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div"));

                Actions builder = new Actions(driver);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", thirdElement);
                builder.MoveToElement(driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div/div[1]/span"))).Click().Build().Perform();


            }
            else
            {
                // throw new ArgumentException("There is no search has been found for Samsung.! ");
                Console.WriteLine("There is no search has been found for Samsung.!");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


    }
}
