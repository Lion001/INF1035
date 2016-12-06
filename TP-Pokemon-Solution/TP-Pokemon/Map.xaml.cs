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
                afficher_team();
                afficher_stat(parti.joueur.equipe[0]);
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
            //Choix 1
            string pokemon = parti.joueur.equipe[0].nomMonstre;
            image_pokemon_choix_1.Source = Monstre.portrait(pokemon);

            //Choix 2
            if (parti.joueur.equipe[1] != null)
            {
                pokemon = parti.joueur.equipe[1].nomMonstre;
                image_pokemon_choix_2.Source = Monstre.portrait(pokemon);
            }

            //Choix 3
            if (parti.joueur.equipe[2] != null)
            {
                pokemon = parti.joueur.equipe[2].nomMonstre;
                image_pokemon_choix_3.Source = Monstre.portrait(pokemon);
            }

            //Choix 4
            if (parti.joueur.equipe[3] != null)
            {
                pokemon = parti.joueur.equipe[3].nomMonstre;
                image_pokemon_choix_4.Source = Monstre.portrait(pokemon);
            }

            //Choix 5
            if (parti.joueur.equipe[4] != null)
            {
                pokemon = parti.joueur.equipe[4].nomMonstre;
                image_pokemon_choix_5.Source = Monstre.portrait(pokemon);
            }
        }

        private void afficher_stat(Monstre monstre)
        {
            image_pokemon_afficher.Source = Monstre.portrait(monstre.nomMonstre);
            label_nom.Content = monstre.nomMonstre;
            label_level.Content = "Level " + monstre.niveauExp;
            label_id.Content ="ID : "+ monstre.id;
            label_element.Content = monstre.typeMonstre;
            label_xp.Content = "XP : " + monstre.pointExp;
            label_vie.Content = "Vie : " + monstre.total[0];
            label_mana.Content = "Mana : " + monstre.total[1];
            label_mana_Copy.Content = "Regen : +" + monstre.total[2];
            label_attaque.Content = "Attaque : " + monstre.total[3];
            label_défense.Content = "Défense : " + monstre.total[4];

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
