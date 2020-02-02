using Keytorc.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keytorc
{
    [TestClass]
   public class n11Automation
    {

        IWebDriver driver;

        [TestMethod]
        public void N11()
        {

            // Driver & URL's configuration
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.n11.com");
            Thread.Sleep(2000);

            //Login the n11
            LoginPage login = new LoginPage(driver);
            login.signInButton();
            login.typeUsername();
            login.typePassword();
            login.clickOnLoginButton();
            Thread.Sleep(2000);

            //Search activity
            Searching search = new Searching(driver);
            search.Search();
            Thread.Sleep(2000);
            search.clickSearchButton();
            Thread.Sleep(2000);
            search.pageTwo();
            Thread.Sleep(2000);

            //Result For Samsung search and adding 3 element in favorite list
            AddingFavorite checkPageAndAddFavorite = new AddingFavorite(driver);            
            checkPageAndAddFavorite.resultForSamsung();
            Thread.Sleep(2000);

            //Open Favorite Page
            FavoritePage fav = new FavoritePage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            fav.hoverMenu();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Select Favorite Item
            fav.selectFavoriteItem();
            Thread.Sleep(2000);

            //Remove From Favorites
            fav.deleteFavoriteItem();
            Thread.Sleep(2000);

            //Check watched items
            fav.checkFavItem();
            Thread.Sleep(2000);

            //Quit browser
            driver.Quit();
        }

     
   }
}