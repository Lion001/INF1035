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
        public Aventure parti;
        public Monstre selectionne;
        public Combat(Aventure parti)
        {
            InitializeComponent();
            fenetre_difficulty.Visibility = System.Windows.Visibility.Visible;
            this.parti = parti;
            init_interface();
        }

        //###############################################################################
        //#		             Buttons de l'interface graphique                           #
        //###############################################################################
        private void button_choix1_Click(object sender, RoutedEventArgs e)
        {
            panel_pokemon.Visibility = System.Windows.Visibility.Visible;
            panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
            afficher_pokemon(parti.joueur.equipe[0]);
        }
        private void button_choix2_Click(object sender, RoutedEventArgs e)
        {
            if(parti.joueur.equipe[1]!=null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[1]);
            }
        }
        private void button_choix3_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[2] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[2]);
            }
        }
        private void button_choix4_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[3] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[3]);
            }
        }
        private void button_choix5_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[4] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[4]);
            }
        }


        private void button_inventaire_Click(object sender, RoutedEventArgs e)
        {
            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
            panel_inventaire.Visibility = System.Windows.Visibility.Visible;

            label_pokeball.Content = "x " + parti.joueur.inventaire.pokeball;
            label_potion_mauve.Content = "x " + parti.joueur.inventaire.potion_vie;
            label_potion_mana.Content = "x " + parti.joueur.inventaire.potion_mana;
            label_potion_or.Content = "x " + parti.joueur.inventaire.potion_max;
        }

        private void button_quitter_Click(object sender, RoutedEventArgs e)
        {
            Map newMap = new Map(parti);
            newMap.Show();
            this.Close();
        }


        //###############################################################################
        //#		                    Fonctions associés                                  #
        //###############################################################################
        
            // Choix de la difficulté
        private void pick_difficulte(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
        }

        // Cette fonction attribut les images au bouton de choix (Fonction identique à afficher_team() dans Map.xaml.cs)
        private void init_interface()
        {
            //Choix 1
            string pokemon;
            if (parti.joueur.equipe[0] != null)
            {
                pokemon = parti.joueur.equipe[0].nomMonstre;
                image_choix1.Source = Monstre.portrait(pokemon); 
            }
            else
            {
                image_choix1.Source = Monstre.portrait("inconnu");
            }

            //Choix 2
            if (parti.joueur.equipe[1] != null)
            {
                pokemon = parti.joueur.equipe[1].nomMonstre;
                image_choix2.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_choix2.Source = Monstre.portrait("inconnu");
            }

            //Choix 3
            if (parti.joueur.equipe[2] != null)
            {
                pokemon = parti.joueur.equipe[2].nomMonstre;
                image_choix3.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_choix3.Source = Monstre.portrait("inconnu");
            }

            //Choix 4
            if (parti.joueur.equipe[3] != null)
            {
                pokemon = parti.joueur.equipe[3].nomMonstre;
                image_choix4.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_choix4.Source = Monstre.portrait("inconnu");
            }

            //Choix 5
            if (parti.joueur.equipe[4] != null)
            {
                pokemon = parti.joueur.equipe[4].nomMonstre;
                image_choix5.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_choix5.Source = Monstre.portrait("inconnu");
            }
            afficher_pokemon(parti.joueur.equipe[0]);
        }

        // Affiche le pokemon dans le panel de pokemon et l'envoie au Combat
        private void afficher_pokemon(Monstre monstre)
        {
            label_nom.Content = monstre.nomMonstre;
            label_level.Content = "Level " + monstre.niveauExp;
            label_id.Content = "# " + monstre.id;
            label_element.Content = monstre.typeMonstre;
            label_xp.Content = "XP : " + monstre.pointExp;
            label_mana_Copy.Content = "Regen : +" + monstre.total[2];
            label_attaque.Content = "Attaque : " + monstre.total[3];
            label_défense.Content = "Défense : " + monstre.total[4];
            image_pokemon_panel.Source = Monstre.portrait(monstre.nomMonstre);
            image_pokemon_player.Source = Monstre.portrait(monstre.nomMonstre);

            button_habilete_1.Content = monstre.listeHabileteActive[0].nom;
            if (monstre.listeHabileteActive[1] != null)
            {
                button_habilete_2.Content = monstre.listeHabileteActive[1].nom;
            }
            else
            {
                button_habilete_2.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
