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
    /// Logique d'interaction pour Combat.xaml
    /// </summary>
    public partial class Combat : Window
    {
        public Combat()
        {
            InitializeComponent();
            fenetre_difficulty.Visibility = System.Windows.Visibility.Visible;
        }


        // Bouton temporaire servant a retourner a la map
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Map newWin = new Map();
            newWin.Show();
            this.Close();
        }

        // Choix de la difficulté
        private void pick_difficulte(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
        }
     }
}
