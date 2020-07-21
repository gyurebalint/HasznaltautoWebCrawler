using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HasznaltAuto.Models
{
    public partial class Hasznaltauto
    {
        [Key]
        [Column("HasznaltautoID")]
        public int HasznaltautoId { get; set; }
        public string AutoGyarto { get; set; }
        public string AutoTipus { get; set; }
        public string Hirdeteskod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Regdate { get; set; }
        [Column("VetelarHUF")]
        public int? VetelarHuf { get; set; }
        [Column("VetelarEUR")]
        public int? VetelarEur { get; set; }
        public int? EvjaratEv { get; set; }
        public int? EvjaratHonap { get; set; }
        public string Allapot { get; set; }
        public string Kivitel { get; set; }
        public int? KmAllas { get; set; }
        public int? SzemelyekSzama { get; set; }
        public int? AjtokSzama { get; set; }
        public string Szin { get; set; }
        public int? Tomeg { get; set; }
        public int? TeljesTomeg { get; set; }
        public int? CsomagtartoMeret { get; set; }
        public string KlimaFajta { get; set; }
        public string Uzemanyag { get; set; }
        public int? Hengerurtartalom { get; set; }
        [Column("TeljesitmenyKW")]
        public int? TeljesitmenyKw { get; set; }
        [Column("TeljesitmenyLE")]
        public int? TeljesitmenyLe { get; set; }
        public string Hajtas { get; set; }
        public string Sebessegvalto { get; set; }
        public string Okmanyok { get; set; }
        public int? MuszakiVizsgaEv { get; set; }
        public int? MuszakivizsgaHonap { get; set; }
        public string AbroncsMeret { get; set; }
        public string Link { get; set; }
        public string Leiras { get; set; }
        [Column("isKereskedo")]
        public bool? IsKereskedo { get; set; }
        public Hasznaltauto()
        {

        }
    }
}
