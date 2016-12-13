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

namespace TP_Pokemon
{
    public partial class MainWindow : Window
    {
        public Joueur inconnu = new Joueur("inconnu",Sexe.homme ,null);
        public MainWindow()
        {
            InitializeComponent();
        }

        //###############################################################################
        //#		            	      Menu principal                                    #
        //###############################################################################

        // Affiche le panel permettant la création d'une nouvelle aventure
        private void bouton_New_Click(object sender, RoutedEventArgs e)
        {
            panel_nouveauJoueur.Visibility = System.Windows.Visibility.Visible;
        }

        // Affiche le panel permettant de charger une aventure préalablement sauvegardé
        private void bouton_Charger_Click(object sender, RoutedEventArgs e)
        {
            if(panel_enregistrement.Visibility == System.Windows.Visibility.Hidden)
            {
                panel_enregistrement.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        
        // Exit
        private void bouton_Quitter_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        //-------------------------------------------------------------------------------

        //###############################################################################
        //#			                 Panel Nouveau Joueur                               #
        //###############################################################################

        // Fait une vérification des entrés de l'utilisateur durant la création du joueur et créer une nouvelle aventure et ouvre une fenetre Map
        private void button_creer_Click(object sender, RoutedEventArgs e)
        {
            // Exception sur input
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_nickname.Text))
                {
                    throw new Exception ("Veuillez entrer un nom de joueur !");
                }
                if (string.IsNullOrWhiteSpace(textBox_nickname.Text))
                {
                    throw new Exception ("Veuillez entrer un surnom de pokémon !");
                }
                if(inconnu.equipe[0] == null)
                {
                    throw new NoPokemonException();
                }
            }
            catch (Exception lol)
            {
                textBox_newName.SelectAll();
                MessageBox.Show(lol.Message);
                return;
            }

            Aventure nouveau = creer_aventure();
            Map newMap = new Map(nouveau);
            newMap.Show();
            this.Close();
        }

        // Fonction utilisé dans la fonction ci-dessus pour créer l'aventure en tant que tel
        public Aventure creer_aventure()
        {
            //Nom
            inconnu.nomJoueur = textBox_newName.Text;
            //Sexe
            if (radioButton_homme.IsChecked == true) { inconnu.sexe = Sexe.homme; }
            else { inconnu.sexe = Sexe.homme; }
            // Nickname du Monstre
            inconnu.equipe[0].aliasMonstre = textBox_nickname.Text;
            Aventure nouvelle = new Aventure(inconnu);
            return nouvelle;
        }

        // Créer et attribution du Pokemon de Départ
        private void button_bulbasaur_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste = Monstre.Charger_Liste_Monstre();
            inconnu.monstreDepart = liste[8]; // liste[8] point sur l'objet bulbasaur
            inconnu.monstreCapture[0] = liste[8];
            inconnu.equipe[0] = liste[8];
        }

        private void button_charmander_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste = Monstre.Charger_Liste_Monstre();
            inconnu.monstreDepart = liste[12];
            inconnu.monstreCapture[0] = liste[12];
            inconnu.equipe[0] = liste[12];
        }

        private void button_pikachu_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste = Monstre.Charger_Liste_Monstre();
            inconnu.monstreDepart = liste[0];
            inconnu.monstreCapture[0] = liste[0];
            inconnu.equipe[0] = liste[0];
        }

        private void button_squirtle_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste = Monstre.Charger_Liste_Monstre();
            inconnu.monstreDepart = liste[4];
            inconnu.monstreCapture[0] = liste[4];
            inconnu.equipe[0] = liste[4];
        }

        //###############################################################################
        //#			                 Panel Charger                                      #
        //###############################################################################
        
       // Chargement d'une partie
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
                textBox_newName.SelectAll();
                MessageBox.Show(lol.Message);
                return;
            }
            string aventure = textBox_enregistrement.Text;

            // Exception sur le chargement de l'aventure
            Aventure chargement;
            try
            {
               chargement = Aventure.Charger_Aventure(aventure);
            }
            catch (Exception lol)
            {
                MessageBox.Show(lol.Message + "\nVeuillez entrer un nom d'aventure valide !");
                return;
            }
            
            Map newMap = new Map(chargement);
            newMap.Show();
            this.Close();
        }

        // Cancel (ferme le panel)
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            textBox_enregistrement.Text = "";
            panel_enregistrement.Visibility = System.Windows.Visibility.Hidden;
        }
        //-------------------------------------------------------------------------------
    }

}
