using HasznaltAuto.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HasznaltAuto.Handlers
{
    class HasznaltautoHandler:DbHandler
    {
        private void CheckErrors(Hasznaltauto hasznaltAuto)
        {
            string errors = "";

        }
        public void SetHasznaltautoWithCheckErrors(Hasznaltauto hasznaltAuto)
        {
            CheckErrors(hasznaltAuto);
            SetHasznaltauto(hasznaltAuto);
        }
        public string[] GetRawCarData(string carUrl, string autogyarto, string autoTipus)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(carUrl);

            //Az összes hirdetés adatot kiveszi a megadott adattipusra (Vételár:)
            var nodePrice = htmlDoc.DocumentNode.SelectNodes(@"//td[@class='bal pontos']");

            //List<string> carData = new List<string>();

            var adatlapCim = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='adatlap-cim col-xs-28 col-lg-23']/h1");
            string[] adatlapCimArr = adatlapCim.InnerText.Split(' ');

            string[] carData = new string[16];

            if (adatlapCimArr.Length >= 2)
            {
                carData[0]=adatlapCimArr[1];
            }

            for (int i = 0; i < nodePrice.Count; i++)
            {
                var elementOG = nodePrice[i];
                //var element = nodePrice[p].NextSibling;
                /*carData.Add(element.InnerText);*/                 // += $"{element.InnerText} \n";
                if (elementOG.InnerText == "Vételár:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[1] = element.InnerText;
                }
                if (elementOG.InnerText == "Vételár EUR:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[2] = element.InnerText;
                }
                if (elementOG.InnerText == "Évjárat:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[3] = element.InnerText;
                }
                if (elementOG.InnerText == "Állapot:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[4] = element.InnerText;
                }
                if (elementOG.InnerText == "Kivitel:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[5] = element.InnerText;
                }
                if (elementOG.InnerText == "Kilométeróra állása:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[6] = element.InnerText;
                }
                if (elementOG.InnerText == "Klíma fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[7] = element.InnerText;
                }
                if (elementOG.InnerText == "Tető:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[8] = element.InnerText;
                }
                if (elementOG.InnerText == "Üzemanyag::")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[9] = element.InnerText;
                }
                if (elementOG.InnerText == "Hengerűrtartalom:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[10] = element.InnerText;
                }
                if (elementOG.InnerText == "Teljesítmény:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[11] = element.InnerText;
                }
                if (elementOG.InnerText == "Sebességváltó fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[12] = element.InnerText;
                }
                if (elementOG.InnerText == "Okmányok jellege:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[13] = element.InnerText;
                }
                if (elementOG.InnerText == "Műszaki vizsga érvényes:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[14] = element.InnerText;
                }
            }
            //Leírás stringet kimentem
            var isLeirasExist = htmlDoc.DocumentNode
                                     .Descendants("div")
                                     .Any(d => d.GetAttributeValue("class", "") == "leiras");
            if (isLeirasExist)
            {
                var node2 = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='leiras']");
                var nodeLeiras = node2.Element("div");
                //carData.Add(nodeLeiras.InnerText);
                carData[15] = nodeLeiras.InnerText;
            }
            foreach (var item in carData)
            {
                Console.WriteLine(item);
            }
            return carData;
        }
        public void ConvertRawDataToHasznaltauto()
        {

        }
    }
}