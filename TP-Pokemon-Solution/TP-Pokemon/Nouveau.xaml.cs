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
    /// Logique d'interaction pour Nouveau.xaml
    /// </summary>
    public partial class Nouveau : Window
    {
        public Nouveau()
        {
            InitializeComponent();
        }


        // Je suis en train de créer une liste mannuelle de tout les habileté disponible dans le jeu
        private void button_ajouter_Click(object sender, RoutedEventArgs e)
        {
            Habilete lanceSoleil = new Habilete("Lance-Soleil", "absorbe la lumière et l'envoie sur l'ennemi", 40, TypeElement.Vegetation, Cible.ennemi, Effet.degat, 20, 1);

            Habilete poudreToxique = new Habilete("Poudre Toxique", "Répand une poudre toxique pendent 3 tour", 15, TypeElement.Vegetation, Cible.ennemi, Effet.degat,10, 3);



    }
    }
}
