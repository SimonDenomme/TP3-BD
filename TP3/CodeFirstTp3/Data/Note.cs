using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class Note
    {
        public int Id { get; set; }
        public byte Valeur { get; set; }

        // one-to-one
        public int MemberCPId { get; set; }
        public MembreCP MembreCP { get; set; }
        // one-to-many
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
