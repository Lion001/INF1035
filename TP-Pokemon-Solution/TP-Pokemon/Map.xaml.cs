﻿using System;
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

        //Bouton qui permet d'afficher/cacher le menu principal
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

        // Affiche le panel profil et cache les autres
        private void bouton_profil_Click(object sender, RoutedEventArgs e)
        {
            if(panel_utilisateur.Visibility != System.Windows.Visibility.Visible)
            {
                panel_utilisateur.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
                panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
                //Afficher le nom du joueur
                label_nom_user.Content = parti.joueur.nomJoueur;
            }
            else
            {
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        // Affiche le panel inventaire et cache les autres
        private void bouton_inventaire_Click(object sender, RoutedEventArgs e)
        {
            if (panel_inventaire.Visibility != System.Windows.Visibility.Visible)
            {
                panel_inventaire.Visibility = System.Windows.Visibility.Visible;
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
                panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;

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

        // Affiche le panel équipe et cache les autres
        private void bouton_pokemon_Click(object sender, RoutedEventArgs e)
        {
            if (panel_pokemons.Visibility != System.Windows.Visibility.Visible)
            {
                panel_pokemons.Visibility = System.Windows.Visibility.Visible;
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
                afficher_team();
            }
            else
            {
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        // Affiche le panel profil et cache les autres
        private void icone_enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (panel_enregistrement.Visibility != System.Windows.Visibility.Visible)
            {
                panel_enregistrement.Visibility = System.Windows.Visibility.Visible;
                panel_utilisateur.Visibility = System.Windows.Visibility.Hidden;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                panel_pokemons.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        // Quitte l'application
        private void icone_quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Permet d'afficher chaque Pokémon de l'équipe ( Choix 1, Choix 2,etc) ainsi que la liste déroulante contenant tout les pokémons attrapés
        public void afficher_team()
        {
            //Choix 1
            string pokemon;
            if (parti.joueur.equipe[0] != null) // Si choix 1 n'est pas vide, affichage de l'image
            {
                pokemon = parti.joueur.equipe[0].nomMonstre;
                image_pokemon_choix_1.Source = Monstre.portrait(pokemon);
            }
            else
            {
                image_pokemon_choix_1.Source = Monstre.portrait("inconnu"); // Sinon, affichage d'une image d'un pokémon inconnu 
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

            parti.joueur.argent += 10000;
        }

        //###############################################################################
        //#		                   Panel Utilisateur                                    #
        //###############################################################################

        // Permet le changement de nom du joueur
        private void button_change_name_Click(object sender, RoutedEventArgs e)
        {
            parti.joueur.nomJoueur = textBox_change_name.Text;
            label_nom_user.Content = parti.joueur.nomJoueur;
        }

        //###############################################################################
        //#		                   Panel Equipe (Pokemon)                               #
        //###############################################################################

        // Affiche le pokémon sélectionné
        private void button_afficher_pokemon_Click(object sender, RoutedEventArgs e)
        {
            string nom = comboBox_liste_pokemon.Text;
            Monstre monstre = parti.joueur.trouver_monstre_parNom(nom); // Recherche l'objet monstre avec le nom du pokémon selectionné
            afficher_stat(monstre);

            comboBox_habilete_1.Items.Clear();
            comboBox_habilete_2.Items.Clear();
            int loop = 0;
            foreach (Habilete x in monstre.listeHabilete) // Affiche les habiletés du pokémon
            {
                if (x!=null && loop<=monstre.niveauExp-1)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = x.nom;
                    ComboBoxItem item2 = new ComboBoxItem();
                    item2.Content = x.nom;

                    comboBox_habilete_1.Items.Add(item);
                    comboBox_habilete_1.SelectedIndex = 0;
                    comboBox_habilete_2.Items.Add(item2);
                    comboBox_habilete_2.SelectedIndex = 1;
                }
                loop++;
            }
        }

        // Affiche les stats du pokémons choisit dans la liste déroulante
        private void afficher_stat(Monstre monstre)
        {
            image_pokemon_afficher.Source = Monstre.portrait(monstre.nomMonstre);
            label_nom.Content = monstre.nomMonstre;
            label_level.Content = "Level " + monstre.niveauExp;
            label_id.Content = "# " + monstre.id;
            label_element.Content = monstre.typeMonstre;
            label_xp.Content = "XP : " + monstre.pointExp;
            label_vie.Content = "Vie : " + monstre.total[0];
            label_mana.Content = "Mana : " + monstre.total[1];
            label_mana_Copy.Content = "Regen : +" + monstre.total[2];
            label_attaque.Content = "Attaque : " + monstre.total[3];
            label_défense.Content = "Défense : " + monstre.total[4];

            monstre_selectionne = monstre;
        }

        // Attribution d'une position (choix 1, choix 2, etc) au pokémon selectionné
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

        // Affiche le panel des habileté (affiche les habiletés de type eau par défaut)
        private void button_help_Click(object sender, RoutedEventArgs e)
        {
            panel_habilete.Visibility = System.Windows.Visibility.Visible;
            TypeElement element = TypeElement.Eau;
            afficher_habilete(element);
        }

        // Attribution du spell sélectionné comme étant l'habileté active #1
        private void button_habilete_1_Click(object sender, RoutedEventArgs e)
        {
            string nom = comboBox_habilete_1.Text;
            Habilete  spell = monstre_selectionne.trouver_habilete(nom);
            int x = parti.joueur.trouver_monstre_listeCapture(monstre_selectionne);
            parti.joueur.monstreCapture[x].listeHabileteActive[0] = spell;
        }

        // Attribution du spell sélectionné comme étant l'habileté active #2
        private void button_habilete_2_Click(object sender, RoutedEventArgs e)
        {
            string nom = comboBox_habilete_2.Text;
            Habilete spell = monstre_selectionne.trouver_habilete(nom);
            int x = parti.joueur.trouver_monstre_listeCapture(monstre_selectionne);
            parti.joueur.monstreCapture[x].listeHabileteActive[1] = spell;
        }

        //###############################################################################
        //#		                   Panel Habilete (Pokemon)                             #
        //###############################################################################
        
        // Affiche la liste habileté en fonction de la sélection du joueur
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
        
        // Fonction principal d'affichage de la liste des habiletés
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

        // Exit
        private void button_quitter_h_Click(object sender, RoutedEventArgs e)
        {
            panel_habilete.Visibility = System.Windows.Visibility.Hidden;
        }

        //###############################################################################
        //#		                   Panel Enregistrer                                    #
        //###############################################################################

        // Enregistrer l'aventure
        private void button_enregistrer_Click(object sender, RoutedEventArgs e)
        {
            // Exception sur input
            try
            {
                if (textBox_enregistrement.Text == "")
                {
                    throw new Exception("Veuillez entrer un nom d'aventure !");
                }
            }
            catch (Exception lol)
            {
                MessageBox.Show(lol.Message);
                return;
            }

            // Exception sur l'enregistrement de l'aventure non nécessaire car tant que l'utilisateur entre du text, une sauvegarde sera créé

            string sauvegarde = textBox_enregistrement.Text;
            parti.Sauvegarder_Aventure(sauvegarde);
            panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;

        }

        // Cancel
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            textBox_enregistrement.Text = "";
            panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
