using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class Conference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public DateTime DateSession { get; set; }

        // one-to-one
        //[Required]
        public MembreCP PrésidentDeSession { get; set; }
        // one-to-many
        public List<Article> Articles { get; set; }
        // one-to-many
        public List<Participant> Participants { get; set; }
    }
}
