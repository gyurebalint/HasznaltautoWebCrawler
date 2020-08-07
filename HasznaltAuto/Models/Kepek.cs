using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

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
        public string Img { get; set; }
        public string Hash { get; set; }

        [ForeignKey(nameof(HasznaltautoId))]
        [InverseProperty("Kepek")]
        public virtual Hasznaltauto Hasznaltauto { get; set; }

        public async 
        Task
SaveImageToDatabase(Kepek kep, Hasznaltauto hasznaltAuto, int allPicsNumber, string imageURI, HasznaltautoContext hnc)
        {

            Console.WriteLine(imageURI);
            kep.Hasznaltauto = hasznaltAuto;
            kep.HasznaltautoId = hasznaltAuto.HasznaltautoId;
            kep.Hirdeteskod = hasznaltAuto.Hirdeteskod;
            kep.Img = imageURI;
            kep.Hash = await GetHashAsync(imageURI);

            allPicsNumber++;
            hnc.Kepek.Add(kep);
            hnc.SaveChanges();
        }
        private async Task<Bitmap> GetBitmapAsync(string imageURI)
        {
            Bitmap bmpSource;
            using (WebClient wc = new WebClient())
            {
                using (Stream s = await wc.OpenReadTaskAsync(new Uri(imageURI)))
                {
                    bmpSource = (Bitmap)Image.FromStream(s);
                }
            }
            return bmpSource;
        }
        private async Task<string> GetHashAsync(string imageURI)
        {
            Bitmap bmpSource = await GetBitmapAsync(imageURI);
            string stringResult = "";
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel

            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false 
                    bool trueOrFalse = bmpMin.GetPixel(i, j).GetBrightness() < 0.5f;
                    lResult.Add(trueOrFalse);
                    if (trueOrFalse)
                    {
                        stringResult += "1";
                    }
                    else
                    {
                        stringResult += "0";
                    }
                }
            }
            return stringResult;
        }
    }
}

