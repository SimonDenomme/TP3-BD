using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public DateTime DateSoumis { get; set; }
        [Required]
        public string URL { get; set; }
        public int Version { get; set; }

        // one-to-many
        public Nullable<int> ConferenceId { get; set; }
        public Conference Conference { get; set; }
        // many-to-many
        public List<Participant_Article> Auteurs { get; set; }
        // many-to-many
        public List<MembreCP_Article> MembreCPs { get; set; }
        // one-to-many
        public List<Note> Notes { get; set; }
    }
}
