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
using System.Windows.Shapes;

namespace TP_Pokemon
{
    /// <summary>
    /// Logique d'interaction pour Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
             // Fonction en charge d'afficher/cacher le menu déroulant (en haut a gauche)

            if (menu_deroulant.Visibility != System.Windows.Visibility.Visible)
            {
                menu_deroulant.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                menu_deroulant.Visibility = System.Windows.Visibility.Hidden;
            }
         }

        //########################################################################
        //#                     Contenu du menu déroulant                        #
        //########################################################################
        private void bouton_profil_Click(object sender, RoutedEventArgs e)
        {
            panel_utilisateur.Visibility = System.Windows.Visibility.Visible;
        }

        private void icone_quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //########################################################################
        //#                     Contenu des icônes de la map                     #
        //########################################################################

        //Bouton Stade
        private void button_stade_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat();
            newWin.Show();
            this.Close();
        }

        //Bouton Port
        private void button_port_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat();
            newWin.Background = new ImageBrush( new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/port.jpg")));
            newWin.Show();
            this.Close();
        }

        //Bouton Parc
        private void button_parc_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat();
            newWin.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/parc-bg.jpg")));
            newWin.Show();
            this.Close();
        }

        //Bouton Central électrique
        private void button_central_h_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat();
            newWin.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/electrique.jpg")));
            newWin.Show();
            this.Close();
        }

    }
}
