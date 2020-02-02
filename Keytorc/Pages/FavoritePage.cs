using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keytorc.Pages
{
    [TestClass]
    public class FavoritePage
    {
        IWebDriver driver;
        By favItem = By.XPath(("/html/body/div[1]/header/div/div/div[2]/div[2]/div[2]/div[2]/div/a[2]"));

        public FavoritePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void hoverMenu()
        {
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/section[1]/div[2]/ul/li[3]/div"));

            if (element.Displayed == true)
            {

                //Main Menu
                IWebElement hver = driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div[2]/div[2]/div[2]/div[1]/a[1]"));
                //Favorite Item In Menu
                

                //Create object 'action' of an Actions class
                Actions action = new Actions(driver);
                //Mousehover on menu item
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", hver);
                //moving to the main menu and then sub menu and clicking on it using object of the Actions class
                action.MoveToElement(hver).MoveToElement(driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div[2]/div[2]/div[2]/div[2]/div/a[2]"))).Click().Build().Perform();
            }

            else
            {
                Console.WriteLine("Cannot reached at the moment.! ");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public void selectFavoriteItem()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[3]/ul/li[1]/div/ul/li/a/img")).Click();

            Thread.Sleep(3000);
        }

        public void deleteFavoriteItem()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[3]/div[1]/div[2]/ul/li/div/div[3]/span")).Click();

            Thread.Sleep(3000);

            driver.FindElement(By.XPath("/html/body/div[4]/div/div/span")).Click();
        }

        public void checkFavItem()
        {
            string xPath = "/html/body/div[1]/div[2]/div/div[2]/div[3]/div/div/div";
            IWebElement xPathElement = driver.FindElement(By.XPath(xPath));

            //Check result for "Samsung" and Add favorite
            if (xPathElement.Text.Equals("İzlediğiniz bir ürün bulunmamaktadır."))
            {
                //If list empty Go MainPage
                Console.WriteLine("Correct.!");

            }
            else
            {
                // throw new ArgumentException("There is no search has been found for Samsung.! ");
                Console.WriteLine("There is watched item in your list.! s");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }    
}
