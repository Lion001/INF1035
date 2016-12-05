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
        public MainWindow()
        {
            InitializeComponent();
        }

        //###############################################################################
        //#                                                                             #
        //#		            	      Menu principal                                    #
        //#                                                                            	#
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
        //#                                                                             #
        //#			                 Panel Nouveau Joueur                               #
        //#                                                                            	#
        //###############################################################################

        public Aventure creer_aventure()
        {
            string nom = textBox_newName.Text;

            // Monstre Depart
            Monstre depart;
            if (radioButton_bulbasaur.IsChecked == true)
            {
               depart = Monstre.chercher_m("bulbasaur");
            }
            else if (radioButton_charmander.IsChecked == true)
            {
                depart = Monstre.chercher_m("charmander");
            }
            else if (radioButton_pikachu.IsChecked == true)
            {
                depart = Monstre.chercher_m("pikachu");
            }
            else
            {
                depart = Monstre.chercher_m("squirtle");
            }
            //---------------
            Joueur nouveau = new Joueur(nom, depart);
            Aventure nouvelle = new Aventure(nouveau);
            return nouvelle;
        }

        private void button_creer_Click(object sender, RoutedEventArgs e)
        {
            Aventure nouveau = creer_aventure();
            Map newMap = new Map(nouveau);
            newMap.Show();
            this.Close();
        }
        //-------------------------------------------------------------------------------
    }

}
