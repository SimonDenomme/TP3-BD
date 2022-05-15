using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public sealed class Conference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConferenceID { get; set; }
    }
}
