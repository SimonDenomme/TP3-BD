using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public static class Methodes
    {
        private static int _conferenceId;

        public static int InscrireParticipants(string prenom, string nom, string email, string affiliation, DateTime DateInscription, decimal frais)
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
                        Conference = context.Conference.Find(_conferenceId)
                    };

                    context.Add(p);
                    context.SaveChanges();

                    return context.Participant.Find(p).Id;
                }
                catch { return -1; }
            }
        }

        public static int InscrireMembreCO(int id, string codeUtilisateur, string mdp, Role role)
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

        public static bool InscrirePaiement(int id, DateTime DatePaiement)
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

        public static int InscrireMembreCP(int id, params string[] Aptitudes)
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

                    context.MembreCP.Add(m);
                    context.SaveChanges();

                    return context.MembreCP.Find(m).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public static int InscrireArticleSoumis(string Titre, DateTime DateSoumission, string URL, params int[] auteurs)
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
                        Version = 1,
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

                    context.Article.Add(a);
                    context.SaveChanges();

                    return context.Article.Find(a).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public static bool AssignerArticles(int id, params int[] voteurs)
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

                    context.Article.Update(a);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }

        public static double EnregistrerNotesEvaluation(int id, int MembreCPId, byte note)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var a = context.Article.Find(id);
                    if (a == null) { throw new Exception("Cet ouvrage n'existe pas."); }

                    var m = context.MembreCP.Find(MembreCPId);
                    if (m == null) { throw new Exception("Ce membre du comité programme n'existe pas."); }

                    if (context.MembreCP_Article.Where(x => x.MembreCP == m && x.Article == a) == null) { throw new Exception("Ce membre du comité programme n'est pas invité au vote."); }

                    a.Notes.Add(new Note
                    {
                        Valeur = note,
                        Article = a,
                        MembreCP = m
                    });

                    context.Article.Update(a);
                    context.SaveChanges();

                    return context.Note.Where(x => x.Article == a).Average(x => x.Valeur);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public static void RapportArticleEnOrdreDeNote()
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    List<Tuple<int, double>> ar = new();

                    var articles = context.Article.ToList();

                    foreach (Article a in articles)
                        ar.Add(new Tuple<int, double>(a.Id, context.Note.Where(x => x.Article == a).Average(x => x.Valeur)));

                    // TODO: sort by note

                    Console.WriteLine("==================== Rapport des articles ====================");
                    foreach (var a in ar)
                    {
                        Console.Write(a.Item1 + " -> Note: " + a.Item2 + " (");
                        Console.WriteLine(context.Note.Count(x => x.ArticleId == a.Item2) + ")");
                    }
                    Console.WriteLine("==============================================================");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public int ProduireProgramme(string Titre, DateTime DateSession, int MembreCPId, params int[] articles)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    if (context.Conference.Where(x => x.Titre == Titre).SingleOrDefault() != null) { throw new Exception("Ce titre de session est utilisé par une autre conférence."); }

                    var p = context.MembreCP.Where(x => x.ParticipantId == MembreCPId).SingleOrDefault();
                    if (p == null) { throw new Exception("Ce participant n'est pas un membre du comité programme."); }
                    if (context.Conference.Where(x => x.PrésidentDeSession == p).SingleOrDefault() != null) { throw new Exception("Ce membre du comité programme préside une autre conférence."); }

                    var c = new Conference()
                    {
                        Titre = Titre,
                        DateSession = DateSession,
                        PrésidentDeSession = p,
                    };

                    foreach (int i in articles)
                    {
                        var a = context.Article.Find(i);
                        if (a == null) { throw new Exception("L'article #" + i + " n'existe pas."); }
                        if (context.Conference.Where(x => x.Articles.Contains(a)).SingleOrDefault() != null) { throw new Exception("Cet article a été présenté à une autre conférence."); }

                        c.Articles.Add(a);
                    }

                    context.Conference.Add(c);
                    context.SaveChanges();

                    _conferenceId = context.Conference.Find(c).Id;
                    return _conferenceId;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }

        public int InscrireVersionRévisée(int id, DateTime DateSoumission, string URL)
        {
            try
            {
                using (var context = new ConferenceContext())
                {
                    var a = context.Article.Find(id);
                    if (context.Article.Find(id) != null) { throw new Exception("Ce titre de session est utilisé par une autre conférence."); }

                    var a2 = new Article()
                    {
                        Titre = a.Titre,
                        Conference = context.Conference.Find(_conferenceId),
                        DateSoumis = DateSoumission,
                        URL = URL,
                        Version = a.Version + 1,
                        Auteurs = a.Auteurs,
                        MembreCPs = a.MembreCPs
                    };

                    context.Article.Add(a2);
                    context.SaveChanges();

                    return context.Article.Find(a2).Id;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return -1; }
        }
    }
}
