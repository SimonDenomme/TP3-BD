using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceClient1.ServiceReference1;

namespace ConferenceClient1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParticipantServiceClient psc= new ParticipantServiceClient();

            if(psc.InscrireParticipants("testServiceWCF","test","test@test.com","aucune",DateTime.Now, 0)== -1)
                Console.WriteLine("Erreur: InscrireParticipants ");
            Console.ReadLine();
        }
    }
}
