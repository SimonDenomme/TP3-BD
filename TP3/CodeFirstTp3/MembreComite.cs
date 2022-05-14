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
        public int Id { get; set; }
        [Required]
        public string CodeUtilisateur { get; set; }
        [Required]
        [StringLength(64,MinimumLength = 8)]
        [RegularExpression(@".*[0-9].*")]
        public string MotDePasse { get; set; }
        [Required]
        public Role Role { get; set; }

        // https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
        public Conference Conference { get; set; }
    }
}
