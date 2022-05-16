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
                    if (context.MembreCO.Where(x => x.Role == role).SingleOrDefault() != null) { throw new Exception("Ce role est déjà comblé."); }
                    if (context.MembreCO.Where(x => x.CodeUtilisateur == codeUtilisateur).SingleOrDefault() != null) { throw new Exception("Ce code d'utilisateur est déjà utilisé."); }

                    var p = context.Participant.Find(id);
                    if (p == null) { throw new Exception("L'Id du participant n'existe pas."); }

                    var m = new MembreCO()
                    {
                        CodeUtilisateur = codeUtilisateur,
                        MotDePasse = mdp,
                        Role = role,
                        Participant = p,
                    };

                    context.Add(m);
                    context.SaveChanges();

                    return context.MembreCO.Find(m).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public bool InscrirePaiement(int id, DateTime DatePaiement)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var p = context.Participant.Find(id);
                    if (p == null) { throw new Exception("L'Id du participant n'existe pas."); }

                    if (p.DateInscription > DatePaiement) { throw new Exception("La date de réception du paiement ne peut précéder la date d'inscription."); }
                    if (p.Dette == 0) { throw new Exception("Le paiement a déjà été enregisté."); }

                    p.Dette = 0;

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }

        public int InscrireMembreCP(int id, params string[] Aptitudes)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var p = context.Participant.Find(id);
                    if (p == null) { throw new Exception("L'Id du participant n'existe pas."); }

                    if (Aptitudes == null) { throw new Exception("L'ensemble des aptitudes ne peut êter vide."); }
                    if (Aptitudes.Length < 2) { throw new Exception("L'ensemble des aptitudes doit être d'au moins 2."); }

                    var m = new MembreCP()
                    {
                        Participant = p,
                    };

                    foreach (string s in Aptitudes)
                    {
                        m.Aptitudes.Add(new Aptitude
                        {
                            MembreCP = m,
                            Name = s,
                        });
                    }

                    context.Add(m);
                    context.SaveChanges();

                    return context.MembreCP.Find(m).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public int InscrireArticleSoumis(string Titre, DateTime DateSoumission, string URL, params int[] auteurs)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    if (auteurs == null) { throw new Exception("Il faut un auteur à l'ouvrage."); }
                    if (auteurs.Length < 1) { throw new Exception("Il faut un auteur à l'ouvrage."); }

                    var a = new Article()
                    {
                        Titre = Titre,
                        DateSoumis = DateSoumission,
                        URL = URL,
                    };

                    foreach (int i in auteurs)
                    {
                        var p = context.Participant.Find(i);
                        if (p == null) { throw new Exception("L'auteur" + i + " n'existe pas."); }

                        a.Auteurs.Add(new Participant_Article
                        {
                            Article = a,
                            Participant = p,
                        });
                    }

                    context.Add(a);
                    context.SaveChanges();

                    return context.Article.Find(a).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public int AssignerArticles(int id, params int[] voteurs)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var a = context.Article.Find(id);
                    if (a == null) { throw new Exception("Cet ouvrage n'existe pas."); }

                    if (voteurs == null) { throw new Exception("Il faut au moins un membre votant l'ouvrage."); }
                    if (voteurs.Length < 1) { throw new Exception("Il faut au moins un membre votant l'ouvrage."); }

                    foreach (int i in voteurs)
                    {
                        var m = context.MembreCP.Find(i);
                        if (m == null) { throw new Exception("Le membre du comité programme #" + i + " n'existe pas."); }

                        a.MembreCPs.Add(new MembreCP_Article
                        {
                            Article = a,
                            MembreCP = m,
                        });
                    }

                    context.Add(a);
                    context.SaveChanges();

                    return context.Article.Find(a).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }
    }
}
