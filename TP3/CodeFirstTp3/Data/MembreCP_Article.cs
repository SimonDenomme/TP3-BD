using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public class MembreCP_Article
    {
        public int Id { get; set; }

        public int MembreCPId { get; set; }
        public MembreCP MembreCP { get; set; }

        public Nullable<int> ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
