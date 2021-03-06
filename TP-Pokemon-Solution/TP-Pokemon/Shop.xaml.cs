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
    /// Logique d'interaction pour Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Aventure parti;
        public Item selectionne;
        public Shop(Aventure parti)
        {
            InitializeComponent();
            textBox_argent.Text = parti.joueur.argent.ToString();
            this.parti = parti;
        }

        //###############################################################################
        //#		                   Différents items achetables                          #
        //###############################################################################

        // Charge l'item pokeball.xml et affiche les caractéristiques
        private void button_pokeball_Click(object sender, RoutedEventArgs e)
        {
            Item item = Item.Charger_Item("pokeball.xml");
            image_central.Source = Monstre.portrait("pokeball-inventaire");
            label_nom.Content = item.nom;
            label_description.Content = item.description;
            label_prix.Content = item.valeur_monetaire;
            selectionne = item;
        }

        // Charge l'item potion_vie.xml et affiche les caractéristiques
        private void button_potion_vie_Click(object sender, RoutedEventArgs e)
        {
            Item item = Item.Charger_Item("potion_vie.xml");
            image_central.Source = Monstre.portrait("potion-mauve");
            label_nom.Content = item.nom;
            label_description.Content = item.description;
            label_prix.Content = item.valeur_monetaire;
            selectionne = item;
        }

        // Charge l'item potion_mana.xml et affiche les caractéristiques
        private void button_potion_mana_Click(object sender, RoutedEventArgs e)
        {
            Item item = Item.Charger_Item("potion_mana.xml");
            image_central.Source = Monstre.portrait("potion-max");
            label_nom.Content = item.nom;
            label_description.Content = item.description;
            label_prix.Content = item.valeur_monetaire;
            selectionne = item;
        }

        // Charge l'item potion_max.xml et affiche les caractéristiques
        private void button_potion_max_Click(object sender, RoutedEventArgs e)
        {
            Item item = Item.Charger_Item("potion_max.xml");
            image_central.Source = Monstre.portrait("potion-or");
            label_nom.Content = item.nom;
            label_description.Content = item.description;
            label_prix.Content = item.valeur_monetaire;
            selectionne = item;
        }

        //###############################################################################
        //#		               Différents actions possibles                             #
        //###############################################################################

        // Incrémente la quantité d'item sélectionné que l'utilisateur désire acheter
        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
           int tmp = Int32.Parse(textBox_nombre.Text);
            tmp++;
            textBox_nombre.Text = tmp.ToString();
        }

        // Décrémente la quantité d'item sélectionné que l'utilisateur désire acheter
        private void button_moins_Click(object sender, RoutedEventArgs e)
        {
            int tmp = Int32.Parse(textBox_nombre.Text);

            if (tmp > 0)
            {
                tmp--;
            }
            textBox_nombre.Text = tmp.ToString();
        }

        // Exit
        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Map newMap = new Map(parti);
            newMap.Show();
            this.Close();
        }

        // Acheter un item
        private void button_buy_Click(object sender, RoutedEventArgs e)
        {
            if(selectionne == null) // Pokéball est l'item par défaut
            {
                selectionne = Item.Charger_Item("Pokeball.xml");
            }
            string item = selectionne.nom;
            double cash = parti.joueur.argent;
            int nombre = Int32.Parse(textBox_nombre.Text);
            switch(item)
            {
                case "Pokeball":
                    if(cash >= 100*nombre) // Si le joueur possède assez d'argent pour faire l'achat
                    {
                        parti.acheter_pokeball(nombre);
                    }
                    else // Sinon message D'erreur
                    {
                        System.Windows.MessageBox.Show("Fond Insuffisant");
                    }
                    break;
                case "Potion de Vie":
                    if (cash >= 200 * nombre)
                    {
                        parti.acheter_potion(nombre, 0, 0);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Fond Insuffisant");
                    }
                    break;
                case "Potion de Mana":
                    if (cash >= 200 * nombre)
                    {
                        parti.acheter_potion(0,nombre, 0);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Fond Insuffisant");
                    }
                    break;
                case "Potion Or":
                    if (cash >= 500 * nombre)
                    {
                        parti.acheter_potion(0,0,nombre);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Fond Insuffisant");
                    }
                    break;
                default:
                    break;
            }
            textBox_argent.Text = parti.joueur.argent.ToString(); // Affichage du nouveau solde du compte du joueur
            textBox_nombre.Text = "0"; // Remise à zero du textbox affichant la quantité d'un item
        }
    }
}
