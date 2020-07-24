using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HasznaltAuto.Models
{
    public partial class Kepek
    {
        [Key]
        [Column("ImagesID")]
        public int ImagesId { get; set; }
        [Column("HasznaltautoID")]
        public int? HasznaltautoId { get; set; }
        public string Hirdeteskod { get; set; }
        public byte[] Img { get; set; }
        public string Hash { get; set; }

        [ForeignKey(nameof(HasznaltautoId))]
        [InverseProperty("Kepek")]
        public virtual Hasznaltauto Hasznaltauto { get; set; }

        public Kepek()
        {

        }
    }
}
