using System;
using System.Collections.Generic;
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

        // one-to-many
        public List<Article> Articles { get; set; }
        // one-to-many
        public List<Participant> Participants { get; set; }
    }
}
