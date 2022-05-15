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
        public Article()
        {
            this.Participants = new List<Participant>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public DateTime DateSoumis { get; set; }
        [Required]
        public string URL { get; set; }
        public int Version { get; set; }

        // https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
        public virtual ICollection<Participant> Participants { get; set; }
        // https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public Conference Conference { get; set; }
    }
}
