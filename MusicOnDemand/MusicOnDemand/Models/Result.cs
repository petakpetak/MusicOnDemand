using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicOnDemand.Models
{
    public class Result
    {
      // public string name {get; set;}
       //public string type { get; set; }
       //public string id { get; set; }
        public List<izvođač> izvodjaci { get; set; }
        public List<album> albumi { get; set; }
        public List<pjesma> pjesme { get; set; }
        public List<država> drzave { get; set; }
        public List<žanr> zanrovi { get; set; }
    }
}