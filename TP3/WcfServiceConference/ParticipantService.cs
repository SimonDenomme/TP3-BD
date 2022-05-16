using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03ClientDonne;

namespace WcfServiceConference
{
    internal class ParticipantService : IParticipantService
    {
        public int InscrireParticipants(string prenom, string nom, string email, string affiliation, DateTime DateInscription, decimal frais)
        {
            using (var context = new Tp03BDEntities())
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

                    context.Participants.Add(p);
                    context.SaveChanges();

                    return context.Participants.Find(p).Id;
                }
                catch { return -1; }
            }
        }
    }
}
