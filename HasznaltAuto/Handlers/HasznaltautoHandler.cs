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
        public void ConvertRawDataToHasznaltauto()
        {

        }
    }
}