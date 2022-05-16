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
    
    public partial class Participant
    {
        public Participant()
        {
            this.MembreCO = new HashSet<MembreCO>();
            this.MembreCP = new HashSet<MembreCP>();
            this.Participant_Article = new HashSet<Participant_Article>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Affiliation { get; set; }
        public System.DateTime DateInscription { get; set; }
        public decimal Dette { get; set; }
        public int ConferenceId { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual ICollection<MembreCO> MembreCO { get; set; }
        public virtual ICollection<MembreCP> MembreCP { get; set; }
        public virtual ICollection<Participant_Article> Participant_Article { get; set; }
    }
}