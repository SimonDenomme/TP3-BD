//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_GUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class MembreCO
    {
        public int Id { get; set; }
        public string CodeUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public int Role { get; set; }
        public int ParticipantId { get; set; }
    
        public virtual Participant Participant { get; set; }
    }
}
