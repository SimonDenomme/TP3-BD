using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public enum Role { PCO, PCP, RF }
    public sealed class MembreComite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembreID { get; set; }
        [Required]
        public string CodeUtilisateur { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 8)]
        [RegularExpression(@".*[0-9].*")]
        public string MotDePasse { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
