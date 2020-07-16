using System;
using System.Collections.Generic;
using System.Text;

namespace HasznaltAuto.Models
{
    class Hasznaltauto
    {
        public int Id { get; set; }
        public string AutoGyarto { get; set; }
        public string AutoTipus { get; set; }
        public string Hirdeteskod { get; set; }
        public DateTime Regdate { get; set; }
        public int VetelarHUF { get; set; }
        public int VetelarEUR { get; set; }
        public int EvjaratEv { get; set; }
        public int EvjaratHonap { get; set; }
        public string Allapot { get; set; }
        public string Kivitel { get; set; }
        public int KmAllas { get; set; }
        public int SzemelyekSzama { get; set; }
        public int AjtokSzama { get; set; }
        public string Szin { get; set; }
        public int Tomeg { get; set; }
        public int TeljesTomeg { get; set; }
        public int CsomagtartoMeret { get; set; }
        public string KlimaFajta { get; set; }
        public string Uzemanyag { get; set; }
        public int Hengerurtartalom { get; set; }
        public int TeljesitmenyKW { get; set; }
        public int TeljesitmenyLE { get; set; }
        public string Hajtas { get; set; }
        public string Sebessegvalto { get; set; }
        public string Okmanyok { get; set; }
        public int MuszakiVizsgaEv { get; set; }
        public int MuszakiVizsgaHonap { get; set; }
        public string AbroncsMeret { get; set; }
        public string Link { get; set; }
        public string  Leiras { get; set; }
        public bool IsKereskedo { get; set; }

        public Hasznaltauto(int id, string autoGyarto, string autoTipus,  string hirdetesKod, int vetelarHUF, int vetelarEUR, int evjaratEv, int evjaratHonap, string allapot, string kivitel,
            int kmAllas, int szemelyekSzama, int ajtokSzama, string szin, int tomeg, int teljesTomeg, int csomagtartoMeret, string klimaFajta, string uzemanyag,
            int hengerurtartalom, int teljesitmenyKW, int teljesitmenyLE, string hajtas, string sebessegvalto, string okmanyok, int muszakivizsgaEv,
            int muszakivizsgaHonap, string abroncsMeret, string link, string leiras, bool isKereskedo)
        {
            Id = id;
            AutoGyarto = autoGyarto;
            AutoTipus = autoTipus;
            Hirdeteskod = hirdetesKod;
            VetelarHUF = vetelarHUF;
            VetelarEUR = vetelarEUR;
            EvjaratEv = evjaratEv;
            EvjaratHonap = evjaratHonap;
            Allapot = allapot;
            Kivitel = kivitel;
            KmAllas = kmAllas;
            SzemelyekSzama = szemelyekSzama;
            AjtokSzama = ajtokSzama;
            Szin = szin;
            Tomeg = tomeg;
            TeljesTomeg = teljesTomeg;
            CsomagtartoMeret = csomagtartoMeret;
            KlimaFajta = klimaFajta;
            Uzemanyag = uzemanyag;
            Hengerurtartalom = hengerurtartalom;
            TeljesitmenyKW = teljesitmenyKW;
            TeljesitmenyLE = teljesitmenyLE;
            Hajtas = hajtas;
            Sebessegvalto = sebessegvalto;
            Okmanyok = okmanyok;
            MuszakiVizsgaEv = muszakivizsgaEv;
            MuszakiVizsgaHonap = muszakivizsgaHonap;
            AbroncsMeret = abroncsMeret;
            Link = link;
            Leiras = leiras;
            IsKereskedo = isKereskedo;
        }

        public Hasznaltauto(string autoGyarto, string autoTipus, string hirdetesKod,  int vetelarHUF, int vetelarEUR, int evjaratEv, int evjaratHonap, string allapot, string kivitel,
            int kmAllas, int szemelyekSzama, int ajtokSzama, string szin, int tomeg, int teljesTomeg, int csomagtartoMeret, string klimaFajta, string uzemanyag,
            int hengerurtartalom, int teljesitmenyKW, int teljesitmenyLE, string hajtas, string sebessegvalto, string okmanyok, int muszakivizsgaEv,
            int muszakivizsgaHonap, string abroncsMeret, string link, string leiras, bool isKereskedo)
        {
            AutoGyarto = autoGyarto;
            AutoTipus = autoTipus;
            Hirdeteskod = hirdetesKod;
            VetelarHUF = vetelarHUF;
            VetelarEUR = vetelarEUR;
            EvjaratEv = evjaratEv;
            EvjaratHonap = evjaratHonap;
            Allapot = allapot;
            Kivitel = kivitel;
            KmAllas = kmAllas;
            SzemelyekSzama = szemelyekSzama;
            AjtokSzama = ajtokSzama;
            Szin = szin;
            Tomeg = tomeg;
            TeljesTomeg = teljesTomeg;
            CsomagtartoMeret = csomagtartoMeret;
            KlimaFajta = klimaFajta;
            Uzemanyag = uzemanyag;
            Hengerurtartalom = hengerurtartalom;
            TeljesitmenyKW = teljesitmenyKW;
            TeljesitmenyLE = teljesitmenyLE;
            Hajtas = hajtas;
            Sebessegvalto = sebessegvalto;
            Okmanyok = okmanyok;
            MuszakiVizsgaEv = muszakivizsgaEv;
            MuszakiVizsgaHonap = muszakivizsgaHonap;
            AbroncsMeret = abroncsMeret;
            Link = link;
            Leiras = leiras;
            IsKereskedo = isKereskedo;
        }
    }
}
