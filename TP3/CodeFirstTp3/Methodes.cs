using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public sealed class Methodes
    {
        public int InscrireParticipants(string prenom, string nom, string email, string affiliation, DateTime DateInscription, decimal frais)
        {
            using (var context = new ConferenceContext())
            {
                try
                {
                    var p = new Participant()
                    {
                        Prenom = prenom,
                        Nom = nom,
                        Email = email,
                        Affiliation = affiliation,
                        DateInscription = DateInscription,
                        Dette = frais,
                    };

                    context.Add(p);
                    context.SaveChanges();

                    return context.Participant.Find(p).Id;
                }
                catch { return -1; }
            }
        }

        public int InscrireMembreCO(int id, string codeUtilisateur, string mdp, Role role)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    if (mdp.Count() < 8 || mdp.Any(char.IsDigit)) { throw new Exception("Le mot de passe doit être au moins huit caractères incluant au moins un chiffre."); }
                    if (context.MembreComite.Where(x => x.Role == role).SingleOrDefault() != null) { throw new Exception("Ce role est déjà comblé."); }
                    if (context.MembreComite.Where(x => x.CodeUtilisateur == codeUtilisateur).SingleOrDefault() != null) { throw new Exception("Ce code d'utilisateur est déjà utilisé."); }

                    var p = context.Participant.Find(id);
                    if (p == null) { throw new Exception("L'Id du participant n'existe pas."); }

                    var m = new MembreComite()
                    {
                        CodeUtilisateur = codeUtilisateur,
                        MotDePasse = mdp,
                        Role = role,
                        Participant = p,
                    };

                    context.Add(m);
                    context.SaveChanges();

                    return context.MembreComite.Find(m).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }
    }
}
