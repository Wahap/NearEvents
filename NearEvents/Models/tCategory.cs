//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NearEvents.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCategory
    {
        public tCategory()
        {
            this.tAnnouncement = new HashSet<tAnnouncement>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> count { get; set; }
    
        public virtual ICollection<tAnnouncement> tAnnouncement { get; set; }
    }
}