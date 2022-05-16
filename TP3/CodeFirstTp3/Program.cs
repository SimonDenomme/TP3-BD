using System;

namespace CodeFirstTp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(  Methodes.AjouterConference(DateTime.Now,"Test1"));
            Methodes.InscrireParticipants("testService", "test", "test@test.com", "aucune", DateTime.Now, 0);
        }
    }
}
