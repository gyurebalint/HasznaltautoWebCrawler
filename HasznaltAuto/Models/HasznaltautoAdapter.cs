using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HasznaltAuto.Models
{
    class HasznaltautoAdapter
    {
        public string rawAutoGyarto;
        public string rawAutoTipus;
        public string rawHirdeteskod;
        public string rawVetelAr;
        public string rawVetelArEUR;
        public string rawEvjarat;
        public string rawAllapot;
        public string rawKivitel;
        public string rawKmAllas;
        public string rawSzemelyekSzama;
        public string rawAjtokSzama;
        public string rawSzin;
        public string rawTomeg;
        public string rawTeljesTomeg;
        public string rawCsomagtartoMeret;
        public string rawKlima;
        public string rawTeto;
        public string rawUzemanyag;
        public string rawHengerurtartalom;
        public string rawTeljesitmeny;
        public string rawHajtas;
        public string rawSebValtofajta;
        public string rawOkmanyokJellege;
        public string rawMuszakiVizsgaErvenyes;
        public string rawAbroncsMeret;
        public string rawLink;
        public string rawLeiras;

        public HasznaltautoAdapter(string carUrl, string autoGyarto, string autoTipus)
        {
            this.rawAutoGyarto = autoGyarto;
            this.rawAutoTipus = autoTipus;
            this.rawLink = carUrl;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(carUrl);

            //Az összes hirdetés adatot kiveszi a megadott adattipusra (Vételár:)
            var nodePrice = htmlDoc.DocumentNode.SelectNodes(@"//td[@class='bal pontos']");

            //List<string> carData = new List<string>();

            var adatlapCim = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='adatlap-cim col-xs-28 col-lg-23']/h1");
            string[] adatlapCimArr = adatlapCim.InnerText.Split(' ');

            var hirdetesKodSzoveggel = htmlDoc.DocumentNode.SelectSingleNode(@"//span[@class='contact-button-text']");
            string[] hirdetesKod = hirdetesKodSzoveggel.InnerText.Split(' ');
            this.rawHirdeteskod = hirdetesKod[1];

            string[] carData = new string[16];

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
                    rawVetelAr = element.InnerText;
                }
                else
                {
                    rawVetelAr = "0";
                }
                if (elementOG.InnerText == "Vételár EUR:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[2] = element.InnerText;
                    rawVetelArEUR = element.InnerText;
                }
                else
                {
                    rawVetelArEUR = "0";
                }
                if (elementOG.InnerText == "Évjárat:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[3] = element.InnerText;
                    rawEvjarat = element.InnerText;
                }
                else
                {
                    rawEvjarat = "1900";
                }
                if (elementOG.InnerText == "Állapot:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[4] = element.InnerText;
                    rawAllapot = element.InnerText;
                }
                else
                {
                    rawAllapot = "-";
                }
                if (elementOG.InnerText == "Kivitel:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[5] = element.InnerText;
                    rawKivitel = element.InnerText;
                }
                else
                {
                    rawKivitel = "-";
                }
                if (elementOG.InnerText == "Kilóméteróra állása:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[6] = element.InnerText;
                    rawKmAllas = element.InnerText;
                }
                else
                {
                    rawKmAllas = "0";
                }
                if (elementOG.InnerText == "Szállítható szem. száma:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawSzemelyekSzama = element.InnerText;
                }
                else
                {
                    rawSzemelyekSzama = "";
                }
                if (elementOG.InnerText == "Ajtók száma:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawAjtokSzama = element.InnerText;
                }
                else
                {
                    rawAjtokSzama = "";
                }
                if (elementOG.InnerText == "Szín:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawSzin = element.InnerText;
                }
                else
                {
                    rawSzin = "";
                }
                if (elementOG.InnerText == "Saját tömeg:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawTomeg = element.InnerText;
                }
                else
                {
                    rawTomeg = "";
                }
                if (elementOG.InnerText == "Teljes tömeg:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawTeljesTomeg = element.InnerText;
                }
                else
                {
                    rawTeljesTomeg = "";
                }
                if (elementOG.InnerText == "Csomagtartó:")
                {
                    var element = nodePrice[i].NextSibling;
                    rawCsomagtartoMeret = element.InnerText;
                }
                else
                {
                    rawCsomagtartoMeret = "";
                }
                if (elementOG.InnerText == "Klíma fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[7] = element.InnerText;
                    rawKlima = element.InnerText;
                }
                else
                {
                    rawKlima = "-";
                }
                if (elementOG.InnerText == "Tető:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[8] = element.InnerText;
                    rawTeto = element.InnerText;
                }
                else
                {
                    rawTeto = "-";
                }
                if (elementOG.InnerText == "Üzemanyag:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[9] = element.InnerText;
                    rawUzemanyag = element.InnerText;
                }
                else
                {
                    rawUzemanyag = "-";
                }
                if (elementOG.InnerText == "Hengerűrtartalom:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[10] = element.InnerText;
                    rawHengerurtartalom = element.InnerText;
                }
                else
                {
                    rawHengerurtartalom = "0";
                }
                if (elementOG.InnerText == "Teljesítmény:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[11] = element.InnerText;
                    rawTeljesitmeny = element.InnerText;
                }
                else
                {
                    rawTeljesitmeny = "-";
                }
                if (elementOG.InnerText == "Hajtás:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[11] = element.InnerText;
                    rawHajtas = element.InnerText;
                }
                else
                {
                    rawHajtas = "-";
                }
                if (elementOG.InnerText == "Sebességváltó fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[12] = element.InnerText;
                    rawSebValtofajta = element.InnerText;
                }
                else
                {
                    rawSebValtofajta = "-";
                }
                if (elementOG.InnerText == "Okmányok jellege:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[13] = element.InnerText;
                    rawOkmanyokJellege = element.InnerText;
                }
                else
                {
                    rawOkmanyokJellege = "-";
                }
                if (elementOG.InnerText == "Műszaki vizsga érvényes:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    carData[14] = element.InnerText;
                    rawMuszakiVizsgaErvenyes = element.InnerText;
                }
                else
                {
                    rawMuszakiVizsgaErvenyes = "-";
                }
                if (elementOG.InnerText == "Nyári gumi méret:")
                {
                    var element = nodePrice[i].NextSibling;
                    //carData.Add(element.InnerText);                 // += $"{element.InnerText} \n";
                    rawAbroncsMeret = element.InnerText;
                }
                else
                {
                    rawAbroncsMeret = "-";
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
                rawLeiras = nodeLeiras.InnerText;
            }
            foreach (var item in carData)
            {
                Console.WriteLine(item);
            }
        }
        public Hasznaltauto CreateHasznaltauto()
        {
            string autoGyarto = this.rawAutoGyarto;
            string autoTipus = this.rawAutoTipus;
            string hirdeteskod = this.rawHirdeteskod;

            string tempVetelAr = this.rawVetelAr.Substring(0, this.rawVetelAr.Length - 3);
            int vetelAr = Convert.ToInt32(Regex.Replace(tempVetelAr, @"\s+", "").Trim());

            string tempVetelArEUR = this.rawVetelArEUR.Substring(2);
            int vetelArEUR = Convert.ToInt32(Regex.Replace(tempVetelArEUR, @"\s+", "").Trim());

            int evjaratEv = 0;
            int evjaratHonap = 0;
            if (this.rawEvjarat.Contains("/"))
            {
                string[] evjaratHonapArr = this.rawEvjarat.Split('/');
                evjaratEv = Convert.ToInt32(evjaratHonapArr[0]);
                evjaratHonap = Convert.ToInt32(evjaratHonapArr[1]);
            }
            else
            {
                evjaratEv = Convert.ToInt32(this.rawEvjarat);
                evjaratHonap = 1;
            }

            string allapot = this.rawAllapot;
            string kivitel = this.rawKivitel;

            string tempKmOraAllasa = this.rawKmAllas.Substring(0, this.rawKmAllas.Length - 3);
            int KmOraAllasa = Convert.ToInt32(Regex.Replace(tempKmOraAllasa, @"\s+", "").Trim());

            string tempSzemelyekSzama = this.rawSzemelyekSzama.Substring(0, this.rawKmAllas.Length - 3);
            int szemelyekSzama = Convert.ToInt32(Regex.Replace(tempSzemelyekSzama, @"\s+", "").Trim());

            int ajtokSzama = Convert.ToInt32(this.rawAjtokSzama.Trim());
            string szin = this.rawSzin;

            string tempTomeg = this.rawTomeg.Substring(0, this.rawTomeg.Length - 3);
            int tomeg = Convert.ToInt32(Regex.Replace(tempTomeg, @"\s+", "").Trim());

            string tempTeljesTomeg = this.rawTeljesTomeg.Substring(0, this.rawTomeg.Length - 3);
            int teljesTomeg = Convert.ToInt32(Regex.Replace(tempTeljesTomeg, @"\s+", "").Trim());

            string tempCsomagtartoMeret = this.rawCsomagtartoMeret.Substring(0, this.rawTomeg.Length - 6);
            int csomagtartoMeret = Convert.ToInt32(Regex.Replace(tempCsomagtartoMeret, @"\s+", "").Trim());

            string klimaFajta = this.rawKlima;
            string uzemanyag = this.rawUzemanyag;

            string tempHengerUrtartalom = this.rawHengerurtartalom.Substring(0, this.rawTomeg.Length - 4);
            int hengerurtartalom = Convert.ToInt32(Regex.Replace(tempHengerUrtartalom, @"\s+", "").Trim());

            string[] teljestimeny = this.rawTeljesitmeny.Split(',');
            string tempTeljkW = teljestimeny[0].Substring(0, this.rawTomeg.Length - 3);
            int TeljkW = Convert.ToInt32(Regex.Replace(tempTeljkW, @"\s+", "").Trim());

            string tempTeljLe = teljestimeny[1].Substring(0, this.rawTomeg.Length - 3);
            int TeljLe = Convert.ToInt32(Regex.Replace(tempTeljLe, @"\s+", "").Trim());

            string hajtas = this.rawHajtas;
            string sebValtofajta = this.rawSebValtofajta;
            string okmanyok = this.rawOkmanyokJellege;

            int muszakiVizsgaEv  = 0;
            int muszakiVizsgaHonap = 0;
            if (this.rawMuszakiVizsgaErvenyes.Contains("/"))
            {
                string[] muszakiVizsgaArr = this.rawMuszakiVizsgaErvenyes.Split('/');
                muszakiVizsgaEv = Convert.ToInt32(muszakiVizsgaArr[0]);
                muszakiVizsgaHonap = Convert.ToInt32(muszakiVizsgaArr[1]);
            }
            else
            {
                muszakiVizsgaEv = Convert.ToInt32(this.rawMuszakiVizsgaErvenyes);
                muszakiVizsgaHonap = 1;
            }

            string abroncsMeret = this.rawAbroncsMeret;
            string link = this.rawLink;
            string leiras = this.rawLeiras;


            Hasznaltauto hasznaltAuto = new Hasznaltauto(autoGyarto, autoTipus, hirdeteskod, vetelAr, vetelArEUR, evjaratEv, 
                evjaratHonap,allapot,kivitel, KmOraAllasa, szemelyekSzama, ajtokSzama, szin, tomeg, teljesTomeg, csomagtartoMeret,
                klimaFajta, uzemanyag, hengerurtartalom,TeljkW, TeljLe, hajtas, sebValtofajta,okmanyok, muszakiVizsgaEv,
                muszakiVizsgaHonap, abroncsMeret, link, leiras);

            return hasznaltAuto;
        }
    }
}