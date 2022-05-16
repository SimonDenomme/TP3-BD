using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class MembreCP
    {
        public int Id { get; set; }

        // one-to-one
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        // one-to-many
        public List<Aptitude> Aptitudes { get; set; }
        // many-to-many
        public List<MembreCP_Article> Articles { get; set; }
    }
}
