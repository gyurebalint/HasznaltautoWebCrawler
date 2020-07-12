using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HasznaltAuto.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using HtmlAgilityPack;
using System.Threading;
using HasznaltAuto.Handlers;

namespace HasznaltAuto
{
    //PAGINATION NEEDED
    class Program
    {
        static void Main(string[] args)
        {
            string autoGyarto = "";
            string autoTipus = "";
            /*
             * 
             * 1. Re-Do  the algorhythm to traverse the website with the Models at hand.
             * 2. Add the created használtauto-s to the database
             *      - Create a NrOfdays column to our database, representing the number of days this particular car is online
             *      - Check if a record already exists, if so update that record -> NrOfDays += 1
             *      - Make the proper checks before adding them
             * 3. Get a propert virtual machine and set up an sql database so you can handle the data online.
             */

            HasznaltautoHandler hh = new HasznaltautoHandler();


            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.hasznaltauto.hu/";

            #region Maximize & Click Cookie
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement cookieOK = driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));
            cookieOK.Click();
            #endregion

            #region Main page, select a car brand
            IWebElement carBrand = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
            SelectElement carBrandSelector = new SelectElement(carBrand);
            int numberOfCarBrands = carBrandSelector.Options.Count;
            #endregion

            #region Going through each brand 1 by 1
            for (int i = 1; i < 7; i++) //numberOfCarBrands
            {
                Thread.Sleep(500);
                IWebElement carBrandNOTstale = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
                SelectElement carBrandSelectorNOTstale = new SelectElement(carBrandNOTstale);
                carBrandSelectorNOTstale.SelectByIndex(i);
                autoGyarto = carBrandSelectorNOTstale.SelectedOption.Text;

                IWebElement carType = driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
                SelectElement carTypeSelector = new SelectElement(carType);
                int numberOfCarTypes = carTypeSelector.Options.Count;

                for (int l = 1; l < numberOfCarTypes; l++)
                {
                    Thread.Sleep(500);

                    IWebElement carBrandNOTstaleagain = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
                    SelectElement carBrandSelectorNOTstaleagain = new SelectElement(carBrandNOTstaleagain);
                    carBrandSelectorNOTstaleagain.SelectByIndex(i);

                    IWebElement carTypeNOTstale = driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
                    SelectElement carTypeSelectorNOTstale = new SelectElement(carTypeNOTstale);
                    carTypeSelectorNOTstale.SelectByIndex(l);
                    autoTipus = carTypeSelectorNOTstale.SelectedOption.Text;

                    IWebElement btnKereses = driver.FindElement(By.Name("submitKereses"));
                    btnKereses.SendKeys(Keys.Control + "t");
                    btnKereses.Click();

                    int maximumNumberOfPages = 1;

                    int k = 0;
                    do
                    {
                        Thread.Sleep(500);

                        ReadOnlyCollection<IWebElement> listOfCarsInOnePage = driver.FindElements(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener"));
                        int numberOfCarsInOnePage = listOfCarsInOnePage.Count;

                        if (numberOfCarsInOnePage >= 20)
                        {
                            //var maximumNumberOfPageselement = driver.FindElement(By.XPath(@"//li[@class='last']/a")).Text;
                            maximumNumberOfPages = Convert.ToInt32(driver.FindElement(By.XPath(@"//li[@class='last']/a")).Text);
                        }

                        #region Car page
                        for (int j = 1; j < numberOfCarsInOnePage - 1; j++)
                        {
                            Thread.Sleep(500);

                            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                            ReadOnlyCollection<IWebElement> listOfCarsInOnePageNOTstale = driver.FindElements(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener"));

                            IWebElement onecarFromList = listOfCarsInOnePageNOTstale[j].FindElement(By.XPath(".//h3"));
                            var linkText = onecarFromList.Text;
                            var carCardLink = onecarFromList.FindElement(By.LinkText(linkText));
                            carCardLink.Click();
                            #region Instantiating HasznaltAuto

                            hh.GetRawCarData(driver.Url, autoGyarto ,autoTipus);

                            #endregion

                            driver.Navigate().Back();
                        }
                        k++;
                        //Click on the next page button
                        var pages = driver.FindElements(By.XPath(@"//ul['pagination']/li"));
                        if (maximumNumberOfPages != 1)
                        {
                            var page = driver.FindElement(By.CssSelector(@".lapozoNyilJobb.haicon-uj-jnyil-kicsi"));
                            page.Click();
                        }

                        #endregion
                    } while (k < maximumNumberOfPages);

                    driver.FindElement(By.CssSelector(".navbar-brand.navbar-brand-hza")).Click();

                }
            }
            #endregion

            //Crawler crawler = new Crawler("https://www.hasznaltauto.hu/");
            //crawler.AutoGyarto = crawler.Driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
            //for (int i = 1; i < crawler.AutoGyartoSelector.Options.Count; i++)
            //{

            //    crawler.AutoGyartoSelector.SelectByIndex(i);
            //    crawler.AutoTipus = crawler.Driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));

            //    for (int j = 1; j < crawler.AutoTipusSelector.Options.Count; j++)
            //    {
            //        crawler.AutoTipus = crawler.Driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
            //        crawler.AutoTipusSelector.SelectByIndex(j);
            //        crawler.BtnKereses.Click();

            //        crawler.Driver.Navigate().Back();

            //    }
        }

    }
}

