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

        private void icone_quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //########################################################################
        //#                     Contenu des icônes de la map                     #
        //########################################################################

        private void button_stade_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat();
            newWin.Show();
            this.Close();
        }
    }
}
