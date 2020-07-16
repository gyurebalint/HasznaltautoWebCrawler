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
        public string rawAutoGyarto = "";
        public string rawAutoTipus = "";
        public string rawHirdeteskod = "";
        public string rawVetelAr = "";
        public string rawVetelArEUR = "";
        public string rawEvjarat = "";
        public string rawAllapot = "";
        public string rawKivitel = "";
        public string rawKmAllas = "";
        public string rawSzemelyekSzama = "";
        public string rawAjtokSzama = "";
        public string rawSzin = "";
        public string rawTomeg = "";
        public string rawTeljesTomeg = "";
        public string rawCsomagtartoMeret = "";
        public string rawKlima = "";
        public string rawTeto = "";
        public string rawUzemanyag = "";
        public string rawHengerurtartalom = "";
        public string rawTeljesitmeny = "";
        public string rawHajtas = "";
        public string rawSebValtofajta = "";
        public string rawOkmanyokJellege = "";
        public string rawMuszakiVizsgaErvenyes = "";
        public string rawAbroncsMeret = "";
        public string rawLink = "";
        public string rawLeiras = "";
        public bool rawIsKereskedo = false;

        public HasznaltautoAdapter(string carUrl, string autoGyarto, string autoTipus)
        {
            string[] carData = new string[27];
            Regex myRegex = new Regex(@"\(([^\)]+)\)");
            autoGyarto = myRegex.Replace(autoGyarto, "");
            autoGyarto = Regex.Replace(autoGyarto, @"\s+", "");

            autoTipus = myRegex.Replace(autoTipus, "");
            autoTipus = Regex.Replace(autoTipus, @"\s+", "");

            carData[0] = autoGyarto;
            carData[1] = autoTipus;
            carData[25] = carUrl;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(carUrl);

            //Az összes hirdetés adatot kiveszi a megadott adattipusra (Vételár:)
            var nodePrice = htmlDoc.DocumentNode.SelectNodes(@"//td[@class='bal pontos']");

            //List<string> carData = new List<string>();
            var adatlapCim = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='adatlap-cim col-xs-28 col-lg-23']/h1");
            string[] adatlapCimArr = adatlapCim.InnerText.Split(' ');

            var kapcsolatMezok = htmlDoc.DocumentNode.SelectNodes(@"//span[@class='contact-button-text']");

            foreach (var item in kapcsolatMezok)
            {
                if (item.InnerText.Contains("Hirdetéskód:"))
                {
                    string hirdeteskod = Regex.Replace(item.InnerText, "[^0-9]", "");
                    //Console.WriteLine(hirdeteskod);
                    carData[2] = hirdeteskod;
                    rawHirdeteskod = carData[2];
                }
            }


            for (int i = 0; i < nodePrice.Count; i++)
            {
                var elementOG = nodePrice[i];
                if (elementOG.InnerText == "Vételár:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[3] = element.InnerText;
                    rawVetelAr = carData[3];
                }
                if (elementOG.InnerText == "Vételár EUR:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[4] = element.InnerText;
                }
                if (elementOG.InnerText == "Évjárat:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[5] = element.InnerText;
                }
                if (elementOG.InnerText == "Állapot:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[6] = element.InnerText;
                }
                if (elementOG.InnerText == "Kivitel:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[7] = element.InnerText;
                }
                if (elementOG.InnerText == "Kilométeróra állása:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[8] = element.InnerText;
                }
                if (elementOG.InnerText == "Szállítható szem. száma:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[9] = element.InnerText;
                }
                if (elementOG.InnerText == "Ajtók száma:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[10] = element.InnerText;

                }
                if (elementOG.InnerText == "Szín:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[11] = element.InnerText;
                }
                if (elementOG.InnerText == "Saját tömeg:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[12] = element.InnerText;
                }
                if (elementOG.InnerText == "Teljes tömeg:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[13] = element.InnerText;
                }
                if (elementOG.InnerText == "Csomagtartó:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[14] = element.InnerText;
                }
                if (elementOG.InnerText == "Klíma fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[15] = element.InnerText;
                }
                if (elementOG.InnerText == "Tető:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[16] = element.InnerText;
                }
                if (elementOG.InnerText == "Üzemanyag:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[17] = element.InnerText;
                }
                if (elementOG.InnerText == "Hengerűrtartalom:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[18] = element.InnerText;
                }
                if (elementOG.InnerText == "Teljesítmény:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[19] = element.InnerText;
                }
                if (elementOG.InnerText == "Hajtás:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[20] = element.InnerText;
                }
                if (elementOG.InnerText == "Sebességváltó fajtája:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[21] = element.InnerText;
                }
                if (elementOG.InnerText == "Okmányok jellege:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[22] = element.InnerText;
                }
                if (elementOG.InnerText == "Műszaki vizsga érvényes:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[23] = element.InnerText;
                }
                if (elementOG.InnerText == "Nyári gumi méret:")
                {
                    var element = nodePrice[i].NextSibling;
                    carData[24] = element.InnerText;
                }
            }

            //Leírás stringet kimentem
            var isLeirasExist = htmlDoc.DocumentNode
                                     .Descendants("div")
                                     .Any(d => d.GetAttributeValue("class", "") == "leiras");

            var jarmuvekUgyanitt = htmlDoc.DocumentNode.SelectNodes(@"//div[@class='hagomb-belso']");

            foreach (var item in jarmuvekUgyanitt)
            {
                if (item.InnerText.Contains("Járművek ugyanitt"))
                {
                    rawIsKereskedo = true;
                }
            }

            if (isLeirasExist)
            {
                var node2 = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='leiras']");
                var nodeLeiras = node2.Element("div");
                carData[26] = nodeLeiras.InnerText;
            }

            //foreach (var item in carData)
            //{
            //    Console.WriteLine(item);
            //}

            rawAutoGyarto = carData[0];
            rawAutoTipus = carData[1];
            rawHirdeteskod = carData[2];
            rawVetelArEUR = carData[4];
            rawEvjarat = carData[5];
            rawAllapot = carData[6];
            rawKivitel = carData[7];
            rawKmAllas = carData[8];
            rawSzemelyekSzama = carData[9];
            rawAjtokSzama = carData[10];
            rawSzin = carData[11];
            rawTomeg = carData[12];
            rawTeljesTomeg = carData[13];
            rawCsomagtartoMeret = carData[14];
            rawKlima = carData[15];
            rawTeto = carData[16];
            rawUzemanyag = carData[17];
            rawHengerurtartalom = carData[18];
            rawTeljesitmeny = carData[19];
            rawHajtas = carData[20];
            rawSebValtofajta = carData[21];
            rawOkmanyokJellege = carData[22];
            rawMuszakiVizsgaErvenyes = carData[23];
            rawAbroncsMeret = carData[24];
            rawLink = carData[25];
            rawLeiras = carData[26];

            //foreach (var item in carData)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(this.rawVetelAr);
            //Console.WriteLine(this.rawVetelArEUR);
            //Console.WriteLine(rawEvjarat);
            //Console.WriteLine(rawAllapot);
            //Console.WriteLine(rawKivitel);
            //Console.WriteLine(rawKmAllas);
            //Console.WriteLine(rawSzemelyekSzama);
            //Console.WriteLine(rawAjtokSzama);
            //Console.WriteLine(rawSzin);
            //Console.WriteLine(rawTomeg);
            //Console.WriteLine(rawTeljesTomeg);
            //Console.WriteLine(rawCsomagtartoMeret);
            //Console.WriteLine(rawKlima);
            //Console.WriteLine(rawTeto);
            //Console.WriteLine(rawUzemanyag);
            //Console.WriteLine(rawHengerurtartalom);
            //Console.WriteLine(rawTeljesitmeny);
            //Console.WriteLine(rawHajtas);
            //Console.WriteLine(rawSebValtofajta);
            //Console.WriteLine(rawOkmanyokJellege);
            //Console.WriteLine(rawMuszakiVizsgaErvenyes);
        }
        public Hasznaltauto CreateHasznaltauto()
        {
            string autoGyarto = this.rawAutoGyarto;
            string autoTipus = this.rawAutoTipus;
            string hirdeteskod = this.rawHirdeteskod;

            int vetelAr = 0;
            if (!string.IsNullOrEmpty(this.rawVetelAr))
            {
                vetelAr = Int32.Parse(Regex.Replace(this.rawVetelAr, "[^0-9]", ""));
            }

            int vetelArEUR = 0;
            if (!string.IsNullOrEmpty(this.rawVetelArEUR))
            {
                vetelArEUR = Int32.Parse(Regex.Replace(this.rawVetelArEUR, "[^0-9]", ""));
            }

            Regex myRegex = new Regex(@"\(([^\)]+)\)");
            this.rawEvjarat = myRegex.Replace(this.rawEvjarat, "");
            this.rawEvjarat = Regex.Replace(this.rawEvjarat, @"\s+", "");

            int evjaratEv = 1900;
            int evjaratHonap = 0;
            if (!string.IsNullOrEmpty(this.rawEvjarat))
            {
                if (this.rawEvjarat.Contains("/"))
                {
                    string[] evjaratHonapArr = this.rawEvjarat.Split('/');
                    evjaratEv = Int32.Parse(evjaratHonapArr[0]);
                    evjaratHonap = Int32.Parse(evjaratHonapArr[1]);
                }

            }

            string allapot = this.rawAllapot;
            string kivitel = this.rawKivitel;

            int KmOraAllasa = 0;
            if (!string.IsNullOrEmpty(this.rawKmAllas))
            {
                KmOraAllasa = Int32.Parse(Regex.Replace(this.rawKmAllas, "[^0-9]", ""));
            }

            int szemelyekSzama = 0;
            if (!string.IsNullOrEmpty(this.rawSzemelyekSzama))
            {
                szemelyekSzama = Int32.Parse(Regex.Replace(this.rawSzemelyekSzama, "[^0-9]", ""));

            }
            int ajtokSzama = 0;
            if (!string.IsNullOrEmpty(this.rawAjtokSzama))
            {
                ajtokSzama = Int32.Parse(Regex.Replace(this.rawAjtokSzama, "[^0-9]", ""));
            }

            string szin = this.rawSzin;

            int tomeg = 0;
            if (!string.IsNullOrEmpty(this.rawTomeg))
            {
                tomeg = Int32.Parse(Regex.Replace(this.rawTomeg, "[^0-9]", ""));
            }
            int teljesTomeg = 0;
            if (!string.IsNullOrEmpty(this.rawTeljesTomeg))
            {
                teljesTomeg = Int32.Parse(Regex.Replace(this.rawTeljesTomeg, "[^0-9]", ""));
            }

            int csomagtartoMeret = 0;
            if (!string.IsNullOrEmpty(this.rawCsomagtartoMeret))
            {
                csomagtartoMeret = Int32.Parse(Regex.Replace(this.rawCsomagtartoMeret, "[^0-9]", ""));

            }

            string klimaFajta = this.rawKlima;
            string uzemanyag = this.rawUzemanyag;

            int hengerurtartalom = 0;
            if (!string.IsNullOrEmpty(this.rawHengerurtartalom))
            {
                hengerurtartalom = Int32.Parse(Regex.Replace(this.rawHengerurtartalom, "[^0-9]", ""));
            }

            int TeljkW = 0;
            int TeljLe = 0;
            if (!string.IsNullOrEmpty(this.rawTeljesitmeny))
            {
                string[] teljesitmeny = this.rawTeljesitmeny.Split(',');
                TeljkW = Int32.Parse(Regex.Replace(teljesitmeny[0], "[^0-9]", ""));
                TeljLe = Int32.Parse(Regex.Replace(teljesitmeny[1], "[^0-9]", ""));
            }

            string hajtas = this.rawHajtas;
            string sebValtofajta = this.rawSebValtofajta;
            string okmanyok = this.rawOkmanyokJellege;

            int muszakiVizsgaEv = 1900;
            int muszakiVizsgaHonap = 0;
            if (!string.IsNullOrEmpty(this.rawMuszakiVizsgaErvenyes))
            {
                if (this.rawMuszakiVizsgaErvenyes.Contains('/'))
                {
                    string[] muszakiVizsgaArr = this.rawMuszakiVizsgaErvenyes.Split('/');
                    muszakiVizsgaEv = Int32.Parse(muszakiVizsgaArr[0]);
                    muszakiVizsgaHonap = Int32.Parse(muszakiVizsgaArr[1]);
                }
            }


            string abroncsMeret = this.rawAbroncsMeret;
            string link = this.rawLink;
            string leiras = this.rawLeiras;
            bool isKereskedo = rawIsKereskedo;

            Hasznaltauto hasznaltAuto = new Hasznaltauto(autoGyarto, autoTipus, hirdeteskod, vetelAr, vetelArEUR, evjaratEv,
                evjaratHonap, allapot, kivitel, KmOraAllasa, szemelyekSzama, ajtokSzama, szin, tomeg, teljesTomeg, csomagtartoMeret,
                klimaFajta, uzemanyag, hengerurtartalom, TeljkW, TeljLe, hajtas, sebValtofajta, okmanyok, muszakiVizsgaEv,
                muszakiVizsgaHonap, abroncsMeret, link, leiras, isKereskedo);

            return hasznaltAuto;
        }
    }
}