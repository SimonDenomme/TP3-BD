using System;
using System.Collections.Generic;
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

namespace Wpf_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource articleViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("articleViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // articleViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource participantViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("participantViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // participantViewSource.Source = [source de données générique]
        }

        private void InscrireParticipants_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
