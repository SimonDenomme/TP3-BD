using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Affiliation { get; set; }
        [Required]
        public DateTime DateInscription { get; set; }
        [Required]
        public decimal Dette { get; set; }

        // one-to-many
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
        // many-to-many
        public List<Participant_Article> Articles { get; set; }
        // one-to-one
        public MembreCO MembreCO { get; set; }
        // one-to-one
        public MembreCP MembreCP { get; set; }
    }
}
