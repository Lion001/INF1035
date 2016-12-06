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
        public Joueur inconnu = new Joueur("inconnu", null);
        public MainWindow()
        {
            InitializeComponent();
        }

        //###############################################################################
        //#		            	      Menu principal                                    #
        //###############################################################################

        private void bouton_New_Click(object sender, RoutedEventArgs e)
        {
            panel_nouveauJoueur.Visibility = System.Windows.Visibility.Visible;
        }

        private void bouton_Charger_Click(object sender, RoutedEventArgs e)
        {
    
            Nouveau newMap = new Nouveau();           
            newMap.Show();
            this.Close();
        }

        private void bouton_Quitter_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //-------------------------------------------------------------------------------

        //###############################################################################
        //#			                 Panel Nouveau Joueur                               #
        //###############################################################################

        public Aventure creer_aventure()
        {
            string nom = textBox_newName.Text;
            inconnu.nomJoueur = nom;
            Aventure nouvelle = new Aventure(inconnu);
            return nouvelle;
        }

        private void button_creer_Click(object sender, RoutedEventArgs e)
        {
            Aventure nouveau = creer_aventure();
            Map newMap = new Map(nouveau);
            newMap.Show();
            this.Close();
        }

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
        //-------------------------------------------------------------------------------
    }

}
