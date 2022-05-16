using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03ClientDonne;

namespace WcfServiceConference
{
    public sealed partial class ConferenceService : IParticipantService
    {
        public int InscrireParticipants(string prenom, string nom, string email, string affiliation, DateTime DateInscription, decimal frais)
        {
            using (var context = new Tp03BDEntities1())
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
                        ConferenceId = context.Conference.Find(1).Id,
                    };

                    context.Participant.Add(p);
                    context.SaveChanges();

                    return context.Participant.Find(p.Id).Id;
                }
                catch { return -1; }
            }
        }
    }
}
