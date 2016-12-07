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
        public Monstre monstre_selectionne;
        bool liste_affiche = false;

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

                label_argent.Content = parti.joueur.argent;
                label_nb_pokeball.Content = parti.joueur.inventaire.pokeball;
                label_nb_potMauve.Content = parti.joueur.inventaire.potion_vie;
                label_nb_potOr.Content = parti.joueur.inventaire.potion_max;
                label_nb_potMax.Content = parti.joueur.inventaire.potion_mana;
           
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
            }
            else
            {
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void icone_enregistrer_Click(object sender, RoutedEventArgs e)
        {
            Aventure.Sauvegarder_Aventure(parti);
            label_avertissement.Visibility = System.Windows.Visibility.Visible;
            System.Threading.Thread.Sleep(2000);
            label_avertissement.Visibility = System.Windows.Visibility.Hidden;

        }

        private void icone_quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void afficher_team()
        {
            //Choix 1
            string pokemon;
            if (parti.joueur.equipe[0] != null)
            {
                pokemon = parti.joueur.equipe[0].nomMonstre;
                image_pokemon_choix_1.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_1.Source = Monstre.portrait("inconnu");
            }

            //Choix 2
            if (parti.joueur.equipe[1] != null)
            {
                pokemon = parti.joueur.equipe[1].nomMonstre;
                image_pokemon_choix_2.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_2.Source = Monstre.portrait("inconnu");
            }


            //Choix 3
            if (parti.joueur.equipe[2] != null)
            {
                pokemon = parti.joueur.equipe[2].nomMonstre;
                image_pokemon_choix_3.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_3.Source = Monstre.portrait("inconnu");
            }


            //Choix 4
            if (parti.joueur.equipe[3] != null)
            {
                pokemon = parti.joueur.equipe[3].nomMonstre;
                image_pokemon_choix_4.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_4.Source = Monstre.portrait("inconnu");
            }


            //Choix 5
            if (parti.joueur.equipe[4] != null)
            {
                pokemon = parti.joueur.equipe[4].nomMonstre;
                image_pokemon_choix_5.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_5.Source = Monstre.portrait("inconnu");
            }


            //Menu déroulant contenant la liste des pokemons capturés
            if (liste_affiche != true)
            {
                foreach (Monstre x in parti.joueur.monstreCapture)
                {
                    if (x != null)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = x.nomMonstre;
                        comboBox_liste_pokemon.Items.Add(item);
                    }
                }
                liste_affiche = true;
            }
        }

        private void afficher_stat(Monstre monstre)
        {
            image_pokemon_afficher.Source = Monstre.portrait(monstre.nomMonstre);
            label_nom.Content = monstre.nomMonstre;
            label_level.Content = "Level " + monstre.niveauExp;
            label_id.Content ="# "+ monstre.id;
            label_element.Content = monstre.typeMonstre;
            label_xp.Content = "XP : " + monstre.pointExp;
            label_vie.Content = "Vie : " + monstre.total[0];
            label_mana.Content = "Mana : " + monstre.total[1];
            label_mana_Copy.Content = "Regen : +" + monstre.total[2];
            label_attaque.Content = "Attaque : " + monstre.total[3];
            label_défense.Content = "Défense : " + monstre.total[4];

            monstre_selectionne = monstre;
        }

        //########################################################################
        //#                     Contenu des icônes de la map                     #
        //########################################################################

        //Bouton Stade
        private void button_stade_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat(parti,TypeElement.Feu);
            newWin.Show();
            this.Close();
        }

        //Bouton Port
        private void button_port_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat(parti,TypeElement.Eau);
            newWin.Background = new ImageBrush( new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/port.jpg")));
            newWin.Show();
            this.Close();
        }

        //Bouton Parc
        private void button_parc_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat(parti,TypeElement.Vegetation);
            newWin.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/parc-bg.jpg")));
            newWin.Show();
            this.Close();
        }

        //Bouton Central électrique
        private void button_central_h_Click(object sender, RoutedEventArgs e)
        {
            Combat newWin = new Combat(parti,TypeElement.Electricite);
            newWin.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/TP-Pokemon;component/Images/electrique.jpg")));
            newWin.Show();
            this.Close();
        }

        //Bouton Shop
        private void button_shop_Click(object sender, RoutedEventArgs e)
        {
            Shop newShop = new Shop(parti);
            newShop.Show();
            this.Close();
        }

        //Bouton Cheat (petite icone clé en haut de la map)
        private void bouton_secret_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste = Monstre.Charger_Liste_Monstre();
            int x = 0;
            while(parti.joueur.monstreCapture[x]!=null)
            {
                x++;
            }
            parti.joueur.monstreCapture[x] = liste[3];
            parti.joueur.monstreCapture[x+1] = liste[9];
            parti.joueur.monstreCapture[x+2] = liste[7];
            parti.joueur.monstreCapture[x+3] = liste[12];
            parti.joueur.argent += 1000;
        }

        //###############################################################################
        //#		                   Panel Utilisateur                                    #
        //###############################################################################
        private void button_change_name_Click(object sender, RoutedEventArgs e)
        {
            parti.joueur.nomJoueur = textBox_change_name.Text;
            label_nom_user.Content = parti.joueur.nomJoueur;
        }

        //###############################################################################
        //#		                   Panel Equipe (Pokemon)                               #
        //###############################################################################
        private void button_afficher_pokemon_Click(object sender, RoutedEventArgs e)
        {
            string nom = comboBox_liste_pokemon.Text;
            Monstre monstre = Monstre.trouver_monstre(nom);
            afficher_stat(monstre);

            comboBox_habilete_1.Items.Clear();
            comboBox_habilete_2.Items.Clear();
            foreach (Habilete x in monstre.listeHabileteActive)
            {
                if (x!=null)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = x.nom;
                    ComboBoxItem item2 = new ComboBoxItem();
                    item2.Content = x.nom;

                    comboBox_habilete_1.Items.Add(item);
                    comboBox_habilete_1.SelectedIndex = 0;
                    comboBox_habilete_2.Items.Add(item2);
                }
            }
        }

        private void button_changer_choix_Click(object sender, RoutedEventArgs e)
        {
            string choix = comboBox_choix_equipe.Text;

            for (int x=0;x<5;x++)
            {
               if (parti.joueur.equipe[x] == monstre_selectionne)
                {
                    parti.joueur.equipe[x] = null;
                }
            }

            switch(choix)
            {
                case "Choix 1":
                    parti.joueur.equipe[0] = monstre_selectionne;
                    break;
                case "Choix 2":
                    parti.joueur.equipe[1] = monstre_selectionne;
                    break;
                case "Choix 3":
                    parti.joueur.equipe[2] = monstre_selectionne;
                    break;
                case "Choix 4":
                    parti.joueur.equipe[3] = monstre_selectionne;
                    break;
                case "Choix 5":
                    parti.joueur.equipe[4] = monstre_selectionne;
                    break;
                default:
                    break;
            }
            afficher_team();
        }

        private void button_help_Click(object sender, RoutedEventArgs e)
        {
            panel_habilete.Visibility = System.Windows.Visibility.Visible;
            TypeElement element = TypeElement.Eau;
            afficher_habilete(element);
        }

        //###############################################################################
        //#		                   Panel Habilete (Pokemon)                             #
        //###############################################################################

        private void button_afficher_habilete_Click(object sender, RoutedEventArgs e)
        {
            string choix = comboBox_liste_habilete_element.Text;
            Habilete[] liste = new Habilete[25];
            TypeElement element = new TypeElement();

            switch (choix)
            {
                case "Eau":
                    element = TypeElement.Eau;
                    break;
                case "Electricite":
                    element = TypeElement.Electricite;
                    break;
                case "Feu":
                    element = TypeElement.Feu;
                    break;
                case "Vegetation":
                    element = TypeElement.Vegetation;
                    break;
                default:
                    element = TypeElement.Eau;
                    break;
            }
            afficher_habilete(element);
        }
        
        public void afficher_habilete(TypeElement element)
        {
            Habilete[] liste = Habilete.Charger_Liste_Habilete_Element(element);

            //Habilete 1
            label_nom_h1.Content = liste[0].nom;
            label_description_h1.Content = liste[0].description;
            label_cout_h1.Content = "Cout : " + liste[0].cout;
            label_cible_h1.Content = "Cible : " + liste[0].cible;
            label_effet_h1.Content = "Effet : " + liste[0].effet;
            label_magnitude_h1.Content = "Magnitude : " + liste[0].magnitude;
            label_duree_h1.Content = "Duree : " + liste[0].duree;

            //Habilete 2
            label_nom_h2.Content = liste[1].nom;
            label_description_h2.Content = liste[1].description;
            label_cout_h2.Content = "Cout : " + liste[1].cout;
            label_cible_h2.Content = "Cible : " + liste[1].cible;
            label_effet_h2.Content = "Effet : " + liste[1].effet;
            label_magnitude_h2.Content = "Magnitude : " + liste[1].magnitude;
            label_duree_h2.Content = "Duree : " + liste[1].duree;

            //Habilete 3
            label_nom_h3.Content = liste[2].nom;
            label_description_h3.Content = liste[2].description;
            label_cout_h3.Content = "Cout : " + liste[2].cout;
            label_cible_h3.Content = "Cible : " + liste[2].cible;
            label_effet_h3.Content = "Effet : " + liste[2].effet;
            label_magnitude_h3.Content = "Magnitude : " + liste[2].magnitude;
            label_duree_h3.Content = "Duree : " + liste[2].duree;

            //Habilete 4
            label_nom_h4.Content = liste[3].nom;
            label_description_h4.Content = liste[3].description;
            label_cout_h4.Content = "Cout : " + liste[3].cout;
            label_cible_h4.Content = "Cible : " + liste[3].cible;
            label_effet_h4.Content = "Effet : " + liste[3].effet;
            label_magnitude_h4.Content = "Magnitude : " + liste[3].magnitude;
            label_duree_h4.Content = "Duree : " + liste[3].duree;

            //Habilete 5
            label_nom_h5.Content = liste[4].nom;
            label_description_h5.Content = liste[4].description;
            label_cout_h5.Content = "Cout : " + liste[4].cout;
            label_cible_h5.Content = "Cible : " + liste[4].cible;
            label_effet_h5.Content = "Effet : " + liste[4].effet;
            label_magnitude_h5.Content = "Magnitude : " + liste[4].magnitude;
            label_duree_h5.Content = "Duree : " + liste[4].duree;
        }

        private void button_quitter_h_Click(object sender, RoutedEventArgs e)
        {
            panel_habilete.Visibility = System.Windows.Visibility.Hidden;
        }


    }
}
