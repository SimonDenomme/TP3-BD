using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_GUI.ServiceReference1;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tp03BD _context = null;
        private CollectionViewSource _participantViewSource;
        private ObservableCollection<Participant> _participants;
        private ObservableCollection<MembreCO> _membreCOs;
        ParticipantServiceClient _psc;

        public MainWindow()
        {
            _context = new Tp03BD();
             _psc = new ParticipantServiceClient();
            InitializeComponent();
        }

        private void btnParticipant_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (var context = _context)
            //    {
            //        int confId = context.Conference.Find(1).Id;
            //        var p = new Participant()
            //        {
            //            Prenom = txtPrenom.Text,
            //            Nom = txtNom.Text,
            //            Email = txtEmail.Text,
            //            Affiliation = txtAffiliation.Text,
            //            DateInscription = DateTime.Parse(dtpDate.Text),
            //            Dette = decimal.Parse(txtDette.Text),
            //            ConferenceId = confId,
            //        };

            //        context.Participant.Add(p);
            //        context.SaveChanges();

            //        IEnumerable<Participant> ps = context.Participant.ToList();
            //        _participantViewSource.View.Refresh();
            //    }
            //}
            //catch(Exception ex) { }

            _psc.InscrireParticipants(txtPrenom.Text, txtNom.Text, txtEmail.Text, txtAffiliation.Text, DateTime.Parse(dtpDate.Text), decimal.Parse(txtDette.Text));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _participantViewSource = (System.Windows.Data.CollectionViewSource)this.FindResource("participantViewSource");
            _participants = new ObservableCollection<Participant>(_context.Participant);
            _participantViewSource.Source = _participants;
            _participantViewSource.View.MoveCurrentToLast();
        }
    }
}
