//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wpf_GUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conference
    {
        public Conference()
        {
            this.Article = new HashSet<Article>();
            this.Participant = new HashSet<Participant>();
        }
    
        public int Id { get; set; }
        public string Titre { get; set; }
        public System.DateTime DateSession { get; set; }
        public Nullable<int> PrésidentDeSessionId { get; set; }
    
        public virtual ICollection<Article> Article { get; set; }
        public virtual MembreCP MembreCP { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
    }
}