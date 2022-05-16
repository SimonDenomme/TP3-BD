using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class Aptitude
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // one-to-many
        public int MemberCPId { get; set; }
        public MembreCP MembreCP { get; set; }
    }
}
