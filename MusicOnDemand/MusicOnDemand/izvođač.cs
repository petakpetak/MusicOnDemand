//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicOnDemand
{
    using System;
    using System.Collections.Generic;
    
    public partial class izvođač
    {
        public izvođač()
        {
            this.album = new HashSet<album>();
            this.žanr = new HashSet<žanr>();
        }
    
        public int izvođačID { get; set; }
        public string nazivIzvođač { get; set; }
        public Nullable<int> državaID { get; set; }
    
        public virtual ICollection<album> album { get; set; }
        public virtual država država { get; set; }
        public virtual ICollection<žanr> žanr { get; set; }
    }
}
