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
using System.Linq;
using System.Net;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Internal;

namespace HasznaltAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(0));
            WebClient wc = new WebClient();
            HtmlWeb web = new HtmlWeb();
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



            driver.Url = "https://www.hasznaltauto.hu/";

            #region Maximize & Click Cookie
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement cookieOK = driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));
            cookieOK.Click();
            #endregion

            Thread.Sleep(250);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            #region Main page, select a car brand
            IWebElement carBrand = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
            SelectElement carBrandSelector = new SelectElement(carBrand);
            int numberOfCarBrands = carBrandSelector.Options.Count;
            #endregion

            #region Going through each brand 1 by 1
            for (int i = 1; i < 7; i++) //numberOfCarBrands
            {
                Thread.Sleep(250);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                IWebElement carBrandNOTstale = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
                SelectElement carBrandSelectorNOTstale = new SelectElement(carBrandNOTstale);
                carBrandSelectorNOTstale.SelectByIndex(i);
                autoGyarto = carBrandSelectorNOTstale.SelectedOption.Text;

                IWebElement carType = driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
                SelectElement carTypeSelector = new SelectElement(carType);
                int numberOfCarTypes = carTypeSelector.Options.Count;

                for (int l = 1; l < numberOfCarTypes; l++)
                {
                    Thread.Sleep(250);
                    IWebElement carBrandNOTstaleagain = driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
                    SelectElement carBrandSelectorNOTstaleagain = new SelectElement(carBrandNOTstaleagain);
                    carBrandSelectorNOTstaleagain.SelectByIndex(i);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                    Thread.Sleep(750);

                    IWebElement carTypeNOTstale = driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
                    SelectElement carTypeSelectorNOTstale = new SelectElement(carTypeNOTstale);
                    wait.Until(driver => carTypeSelectorNOTstale.Options.Count > 1);

                    carTypeSelectorNOTstale.SelectByIndex(l);
                    autoTipus = carTypeSelectorNOTstale.SelectedOption.Text;

                    Thread.Sleep(450);

                    IWebElement btnKereses = driver.FindElement(By.Name("submitKereses"));
                    btnKereses.SendKeys(Keys.Control + "t");
                    btnKereses.Click();

                    int maximumNumberOfPages = 1;
                    bool pagination = IsPaginationPresent(driver, By.ClassName("pagination"));
                    if (pagination)
                    {
                        maximumNumberOfPages = Convert.ToInt32(driver.FindElement(By.XPath(@"//li[@class='last']/a")).Text);
                    }
                    int k = 0;
                    do
                    {
                        wait.Until(driver => driver.FindElement(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener")).Displayed);
                        int numberOfCarsInOnePage = driver.FindElements(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener")).Count;
                        #region Car page
                        for (int j = 0; j < numberOfCarsInOnePage; j++)
                        {
                            Thread.Sleep(250);
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                            wait.Until(driver => driver.FindElement(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener")).Displayed);
                            ReadOnlyCollection<IWebElement> listOfCarsInOnePageNOTstale = driver.FindElements(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener"));
                            //.col-sm-19.cim-kontener

                            IWebElement onecarFromList = listOfCarsInOnePageNOTstale[j].FindElement(By.TagName("h3"));
                            //(@"//div[@class='row talalati-sor swipe-watch kiemelt']//h3"));
                            IWebElement carCardLink = onecarFromList.FindElement(By.TagName("a"));
                            var carLink = carCardLink.GetAttribute("href");

                            string[] hirdetesLink = carLink.Split('-');
                            string hirdetesKod = hirdetesLink[hirdetesLink.Length - 1];

                            /*
                             * I have the text of the link of a specific car
                             * If the 'hirdeteskod' on the car card doesn't exist in my database, navigate to the above said link
                             */

                            using (HasznaltautoContext hnc = new HasznaltautoContext())
                            {
                                var doesAutoAlreadyExistInDataBase = hnc.Hasznaltauto.Where<Hasznaltauto>(p => p.Hirdeteskod == hirdetesKod).Any();
                                if (!doesAutoAlreadyExistInDataBase)
                                {
                                    Console.WriteLine($"Uj autot találtam: Ezzel a hirdetéskoddal: {hirdetesKod}");
                                    carCardLink.Click();
                                    #region Instantiating HasznaltAuto
                                    HasznaltautoAdapter hasznaltautoAdapter = new HasznaltautoAdapter(carLink, autoGyarto, autoTipus);
                                    try
                                    {
                                        Hasznaltauto hasznaltAuto = hasznaltautoAdapter.CreateHasznaltauto();
                                        hnc.Hasznaltauto.Add(hasznaltAuto);

                                        int numberOfImages = Int32.Parse(driver.FindElement(By.ClassName("hirdetes-kepek")).Text);
                                        Console.WriteLine(numberOfImages);
                                        if (numberOfImages != 0)
                                        {
                                            var links = from b in driver.FindElements(By.TagName("a"))       //driver.FindElements(By.XPath(@"//div[@class='slide']"))
                                                        where b.GetAttribute("data-size") == "640x480"  //("data-index") == z.ToString()
                                                        select (string)b.GetAttribute("href");

                                            //Console.WriteLine(firstImagesURIString);
                                            for (int z = 0; z < numberOfImages; z++)
                                            {
                                                List<string> listOfImageURI = links.ToList();
                                                if (listOfImageURI.Any())
                                                {
                                                    string imageURI = listOfImageURI[z];
                                                    Console.WriteLine(imageURI);
                                                    Kepek kep = new Kepek();
                                                    kep.Hasznaltauto = hasznaltAuto;
                                                    kep.HasznaltautoId = hasznaltAuto.HasznaltautoId;
                                                    kep.Hirdeteskod = hasznaltAuto.Hirdeteskod;
                                                    kep.Img = wc.DownloadData(imageURI);

                                                    hnc.Kepek.Add(kep);
                                                    hnc.SaveChanges();
                                                }
                                            }
                                        }
                                        hnc.SaveChanges();
                                        driver.Navigate().Back();
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                #endregion
                            }
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
        }
        static private bool IsPaginationPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        static private HtmlNode NodeFromPage(string url, string nodeString)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            //List<string> carData = new List<string>();
            var nodeFromPage = htmlDoc.DocumentNode.SelectSingleNode(nodeString);

            return nodeFromPage;
        }
    }
}

