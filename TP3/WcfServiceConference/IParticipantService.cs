using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceConference
{
    [ServiceContract]
    public interface IParticipantService
    {
        [OperationContract]
        int InscrireParticipants(string prenom, string nom, string email, string affiliation, DateTime DateInscription, decimal frais);
    }

    [DataContract]
    public class ParticipantInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Affiliation { get; set; }
        [DataMember]
        public DateTime? DateInscription { get; set; }
        [DataMember]
        public decimal? Dette { get; set; }
        [DataMember]
        public int? ConferenceId { get; set; }
    }
}
