using System;

namespace CodeFirstTp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(  Methodes.AjouterConference(DateTime.Now,"Test1"));
            Console.WriteLine("InscrireParticipants: " + Methodes.InscrireParticipants("testCodeFisrt", "testDette", "test@test.com", "aucune", DateTime.Now, 100));
            Console.WriteLine("InscrireParticipants: " + Methodes.InscrireParticipants("testCodeFisrt2", "testDette", "test@test.com", "aucune", DateTime.Now, 100));
            Console.WriteLine("InscrireParticipants: " + Methodes.InscrireParticipants("testCodeFisrt3", "testDette", "test@test.com", "aucune", DateTime.Now, 100));
            Console.WriteLine("InscrireMembreCO: " + Methodes.InscrireMembreCO(1,"TestUser2", "Test123!",Role.PCO));
            Console.WriteLine("InscrirePaiement: " + Methodes.InscrirePaiement(1,DateTime.Now));
            Console.WriteLine("InscrireMembreCP: " + Methodes.InscrireMembreCP(1,new string[] {"Beau bonhome", "Inteligent", "Un bon jack"}));
            Console.WriteLine("InscrireArticleSoumis: " + Methodes.InscrireArticleSoumis("TestCodeFirst2",DateTime.Now, "https://www.google.ca",3,2,1));
            Console.WriteLine("AssignerArticles: " + Methodes.AssignerArticles(1,1));
            Console.WriteLine("EnregistrerNotesEvaluation: " + Methodes.EnregistrerNotesEvaluation(1,1,30));
            Methodes.RapportArticleEnOrdreDeNote();
            Console.WriteLine("ProduireProgramme: " + Methodes.ProduireProgramme("TESTProduireProgramme",DateTime.Now, 1,1));
            Console.WriteLine("InscrireVersionRévisée: " + Methodes.InscrireVersionRévisée(1,DateTime.Now, "https://www.google.ca"));
        }
    }
}
