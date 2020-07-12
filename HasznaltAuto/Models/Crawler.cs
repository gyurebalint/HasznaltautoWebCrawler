using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HasznaltAuto.Models
{
    class Crawler
    {
        public string Url { get; set; }
        public IWebDriver Driver { get; set; }
        public IWebElement AutoGyarto { get; set; }
        public IWebElement AutoTipus { get; set; }
        public SelectElement AutoGyartoSelector { get; set; }
        public SelectElement AutoTipusSelector { get; set; }
        public int NrOfAutoGyarto { get; set; }
        public int NrOfAutoTipus { get; set; }
        public IWebElement BtnKereses { get; set; }
        public ReadOnlyCollection<IWebElement> AutokEgyLaponLista { get; set; }
        public int MaximumOldalszam { get; set; }
        public Hasznaltauto Hasznaltauto { get; set; }
        public Crawler(string url)
        {
            #region Setup
            Url = url;
            Driver = new ChromeDriver();

            Driver.Url = "https://www.hasznaltauto.hu/";
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement cookieOK = Driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));
            cookieOK.Click();
            #endregion
            AutoGyarto = Driver.FindElement(By.Id("hirdetesszemelyautosearch-marka_id"));
            AutoTipus = Driver.FindElement(By.Id("hirdetesszemelyautosearch-modell_id"));
            AutoGyartoSelector = new SelectElement(AutoGyarto);
            AutoTipusSelector = new SelectElement(AutoTipus);
            NrOfAutoGyarto = AutoGyartoSelector.Options.Count;
            NrOfAutoTipus= AutoTipusSelector.Options.Count;
            BtnKereses = Driver.FindElement(By.Name("submitKereses"));
            AutokEgyLaponLista = Driver.FindElements(By.CssSelector(@".col-xs-28.col-sm-19.cim-kontener"));

            //MaximumOldalszam = Driver.FindElement(By.XPath(@"//li[@class='last']/a")).Size == null ? Convert.ToInt32(Driver.FindElement(By.XPath(@"//li[@class='last']/a")).Text) : 1;
        }
    }

}
