using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    // https://www.youtube.com/watch?v=Qh2hgIc90y0&t=333s&ab_channel=ErvisTrupja
    public class Participant_Article
    {
        public int Id { get; set; }

        public Nullable<int> ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
