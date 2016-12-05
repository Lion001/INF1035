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
        public Aventure parti;
        public Map(Aventure aventure)
        {
            InitializeComponent();
            parti = aventure;
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
            if(panel_utilisateur.Visibility != System.Windows.Visibility.Visible)
            {
                panel_utilisateur.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
                //Afficher le nom du joueur
                label_nom_user.Content = parti.joueur.nomJoueur;
            }
            else
            {
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void bouton_inventaire_Click(object sender, RoutedEventArgs e)
        {
            if (panel_inventaire.Visibility != System.Windows.Visibility.Visible)
            {
                panel_inventaire.Visibility = System.Windows.Visibility.Visible;
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
                //Afficher l'argent
                //Afficher nombre de pokeball
                //Afficher nombre de potion mauve
                //Afficher nombre de potion or
                //Afficher nombre de potion max
            }
            else
            {
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void bouton_pokemon_Click(object sender, RoutedEventArgs e)
        {
            if (panel_pokemons.Visibility != System.Windows.Visibility.Visible)
            {
                panel_pokemons.Visibility = System.Windows.Visibility.Visible;
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                //Afficher les 5 choix de départ
                //Afficher la listes des pokemons capturés
                afficher_team();
            }
            else
            {
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void icone_quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void afficher_team()
        {
            //string adresse = parti.joueur.monstreCapture[0].nom_Image;
            string adresse = "Images/charmander.png";
            Uri imageUri = new Uri(adresse, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            image_pokemon1 = myImage;
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

        //###############################################################################
        //#		                   Panel Utilisateur                                    #
        //###############################################################################
        private void button_change_name_Click(object sender, RoutedEventArgs e)
        {
            parti.joueur.nomJoueur = textBox_change_name.Text;
            label_nom_user.Content = parti.joueur.nomJoueur;
        }
    }
}
