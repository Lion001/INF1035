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

        private void button_ajouter_Click(object sender, RoutedEventArgs e)
        {
            Monstre[] liste_monstre = new Monstre[20];
            Habilete[] liste_eau = Habilete.Charger_Liste_Habilete_Element(TypeElement.Eau);
            Habilete[] liste_electricite = Habilete.Charger_Liste_Habilete_Element(TypeElement.Electricite);
            Habilete[] liste_feu = Habilete.Charger_Liste_Habilete_Element(TypeElement.Feu);
            Habilete[] liste_veg = Habilete.Charger_Liste_Habilete_Element(TypeElement.Vegetation);


            Monstre pikachu = new Monstre(1, "Pikachu", "Souris électrique", "aucun", TypeElement.Electricite, "pikachu.png");
            pikachu.deBase[0] = 100; pikachu.prog[0] = 5;
            pikachu.deBase[1] = 100; pikachu.prog[1] = 10;
            pikachu.deBase[2] = 10; pikachu.prog[2] = 2;
            pikachu.deBase[3] = 20; pikachu.prog[3] = 10;
            pikachu.deBase[4] = 5; pikachu.prog[4] = 1;
            pikachu.listeHabilete = Habilete.Charger_Liste_Habilete_Element(pikachu.typeMonstre);
            pikachu.listeHabileteActive[0] = pikachu.listeHabilete[0];
            pikachu.calcul_caract();
            pikachu.listeHabilete = liste_electricite;
            pikachu.listeHabileteActive[0] = pikachu.listeHabilete[0];
            liste_monstre[0] = pikachu;

            Monstre Magneton = new Monstre(2, "Magneton", "Creature a trois oeil", "aucun", TypeElement.Electricite, "Magneton.png");
            Magneton.deBase[0] = 100; Magneton.prog[0] = 5;
            Magneton.deBase[1] = 100; Magneton.prog[1] = 20;
            Magneton.deBase[2] = 10; Magneton.prog[2] = 2;
            Magneton.deBase[3] = 20; Magneton.prog[3] = 10;
            Magneton.deBase[4] = 5; Magneton.prog[4] = 10;
            Magneton.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Magneton.typeMonstre);
            Magneton.listeHabileteActive[0] = Magneton.listeHabilete[0];
            Magneton.calcul_caract();
            Magneton.listeHabilete = liste_electricite;
            Magneton.listeHabileteActive[0] = Magneton.listeHabilete[0];
            liste_monstre[1] = Magneton;

            Monstre Zapdos = new Monstre(3, "Zapdos", "Oiseau électrique", "aucun", TypeElement.Electricite, "Zapdos.png");
            Zapdos.deBase[0] = 100; Zapdos.prog[0] = 10;
            Zapdos.deBase[1] = 100; Zapdos.prog[1] = 10;
            Zapdos.deBase[2] = 10; Zapdos.prog[2] = 10;
            Zapdos.deBase[3] = 20; Zapdos.prog[3] = 15;
            Zapdos.deBase[4] = 5; Zapdos.prog[4] = 5;
            Zapdos.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Zapdos.typeMonstre);
            Zapdos.listeHabileteActive[0] = Zapdos.listeHabilete[0];
            Zapdos.calcul_caract();
            Zapdos.listeHabilete = liste_electricite;
            Zapdos.listeHabileteActive[0] = Zapdos.listeHabilete[0];
            liste_monstre[2] = Zapdos;

            Monstre Elektek = new Monstre(4, "Elektek", "Creature electrique mortelle", "aucun", TypeElement.Electricite, "Elektek.png");
            Elektek.deBase[0] = 100; Elektek.prog[0] = 10;
            Elektek.deBase[1] = 100; Elektek.prog[1] = 20;
            Elektek.deBase[2] = 10; Elektek.prog[2] = 5;
            Elektek.deBase[3] = 20; Elektek.prog[3] = 45;
            Elektek.deBase[4] = 5; Elektek.prog[4] = 10;
            Elektek.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Elektek.typeMonstre);
            Elektek.listeHabileteActive[0] = Elektek.listeHabilete[0];
            Elektek.calcul_caract();
            Elektek.listeHabilete = liste_electricite;
            Elektek.listeHabileteActive[0] = Elektek.listeHabilete[0];
            liste_monstre[3] = Elektek;

            Monstre Squirtle = new Monstre(5, "Squirtle", "Tortue aquatique", "aucun", TypeElement.Eau, "Squirtle.png");
            Squirtle.deBase[0] = 100; Squirtle.prog[0] = 5;
            Squirtle.deBase[1] = 100; Squirtle.prog[1] = 10;
            Squirtle.deBase[2] = 10; Squirtle.prog[2] = 2;
            Squirtle.deBase[3] = 20; Squirtle.prog[3] = 10;
            Squirtle.deBase[4] = 5; Squirtle.prog[4] = 1;
            Squirtle.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Squirtle.typeMonstre);
            Squirtle.listeHabileteActive[0] = Squirtle.listeHabilete[0];
            Squirtle.calcul_caract();
            Squirtle.listeHabilete = liste_eau;
            Squirtle.listeHabileteActive[0] = Squirtle.listeHabilete[0];
            liste_monstre[4] = Squirtle;

            Monstre Milotic = new Monstre(6, "Milotic", "Serpent aquatique", "aucun", TypeElement.Eau, "Milotic.png");
            Milotic.deBase[0] = 100; Milotic.prog[0] = 10;
            Milotic.deBase[1] = 100; Milotic.prog[1] = 20;
            Milotic.deBase[2] = 10; Milotic.prog[2] = 5;
            Milotic.deBase[3] = 20; Milotic.prog[3] = 10;
            Milotic.deBase[4] = 5; Milotic.prog[4] = 1;
            Milotic.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Milotic.typeMonstre);
            Milotic.listeHabileteActive[0] = Milotic.listeHabilete[0];
            Milotic.calcul_caract();
            Milotic.listeHabilete = liste_eau;
            Milotic.listeHabileteActive[0] = Milotic.listeHabilete[0];
            liste_monstre[5] = Milotic;

            Monstre Golduck = new Monstre(7, "Golduck", "Canard tres agressif", "aucun", TypeElement.Eau, "Golduck.png");
            Golduck.deBase[0] = 100; Golduck.prog[0] = 10;
            Golduck.deBase[1] = 100; Golduck.prog[1] = 15;
            Golduck.deBase[2] = 10; Golduck.prog[2] = 7;
            Golduck.deBase[3] = 20; Golduck.prog[3] = 30;
            Golduck.deBase[4] = 5; Golduck.prog[4] = 5;
            Golduck.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Golduck.typeMonstre);
            Golduck.listeHabileteActive[0] = Golduck.listeHabilete[0];
            Golduck.calcul_caract();
            Golduck.listeHabilete = liste_eau;
            Golduck.listeHabileteActive[0] = Golduck.listeHabilete[0];
            liste_monstre[6] = Golduck;

            Monstre Vapoeron = new Monstre(8, "Vapoeron", "Creature a 4 pattes aquatique", "aucun", TypeElement.Eau, "Vapoeron.png");
            Vapoeron.deBase[0] = 100; Vapoeron.prog[0] = 10;
            Vapoeron.deBase[1] = 100; Vapoeron.prog[1] = 15;
            Vapoeron.deBase[2] = 10; Vapoeron.prog[2] = 10;
            Vapoeron.deBase[3] = 20; Vapoeron.prog[3] = 50;
            Vapoeron.deBase[4] = 5; Vapoeron.prog[4] = 20;
            Vapoeron.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Vapoeron.typeMonstre);
            Vapoeron.listeHabileteActive[0] = Vapoeron.listeHabilete[0];
            Vapoeron.calcul_caract();
            Vapoeron.listeHabilete = liste_eau;
            Vapoeron.listeHabileteActive[0] = Vapoeron.listeHabilete[0];
            liste_monstre[7] = Vapoeron;

            Monstre Bulbasaur = new Monstre(9, "Bulbasaur", "Tortue Vegetale", "aucun", TypeElement.Vegetation, "Bulbasaur.png");
            Bulbasaur.deBase[0] = 100; Bulbasaur.prog[0] = 5;
            Bulbasaur.deBase[1] = 100; Bulbasaur.prog[1] = 10;
            Bulbasaur.deBase[2] = 10; Bulbasaur.prog[2] = 2;
            Bulbasaur.deBase[3] = 20; Bulbasaur.prog[3] = 10;
            Bulbasaur.deBase[4] = 5; Bulbasaur.prog[4] = 1;
            Bulbasaur.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Bulbasaur.typeMonstre);
            Bulbasaur.listeHabileteActive[0] = Bulbasaur.listeHabilete[0];
            Bulbasaur.calcul_caract();
            Bulbasaur.listeHabilete = liste_veg;
            Bulbasaur.listeHabileteActive[0] = Bulbasaur.listeHabilete[0];
            liste_monstre[8] = Bulbasaur;

            Monstre Vileplume = new Monstre(10, "Vileplume", "Fleur mobile", "aucun", TypeElement.Vegetation, "Vileplume.png");
            Vileplume.deBase[0] = 100; Vileplume.prog[0] = 5;
            Vileplume.deBase[1] = 100; Vileplume.prog[1] = 30;
            Vileplume.deBase[2] = 10; Vileplume.prog[2] = 15;
            Vileplume.deBase[3] = 20; Vileplume.prog[3] = 10;
            Vileplume.deBase[4] = 5; Vileplume.prog[4] = 1;
            Vileplume.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Vileplume.typeMonstre);
            Vileplume.listeHabileteActive[0] = Vileplume.listeHabilete[0];
            Vileplume.calcul_caract();
            Vileplume.listeHabilete = liste_veg;
            Vileplume.listeHabileteActive[0] = Vileplume.listeHabilete[0];
            liste_monstre[9] = Vileplume;

            Monstre Exeggutor = new Monstre(11, "Exeggutor", "Anana malefique", "aucun", TypeElement.Vegetation, "Exeggutor.png");
            Exeggutor.deBase[0] = 500; Exeggutor.prog[0] = 5;
            Exeggutor.deBase[1] = 100; Exeggutor.prog[1] = 10;
            Exeggutor.deBase[2] = 10; Exeggutor.prog[2] = 2;
            Exeggutor.deBase[3] = 20; Exeggutor.prog[3] = 20;
            Exeggutor.deBase[4] = 5; Exeggutor.prog[4] = 10;
            Exeggutor.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Exeggutor.typeMonstre);
            Exeggutor.listeHabileteActive[0] = Exeggutor.listeHabilete[0];
            Exeggutor.calcul_caract();
            Exeggutor.listeHabilete = liste_veg;
            Exeggutor.listeHabileteActive[0] = Exeggutor.listeHabilete[0];
            liste_monstre[10] = Exeggutor;

            Monstre Venusaur = new Monstre(12, "Venusaur", "Tortue géante", "aucun", TypeElement.Vegetation, "Venusaur.png");
            Venusaur.deBase[0] = 500; Venusaur.prog[0] = 20;
            Venusaur.deBase[1] = 100; Venusaur.prog[1] = 10;
            Venusaur.deBase[2] = 10; Venusaur.prog[2] = 2;
            Venusaur.deBase[3] = 20; Venusaur.prog[3] = 10;
            Venusaur.deBase[4] = 20; Venusaur.prog[4] = 20;
            Venusaur.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Venusaur.typeMonstre);
            Venusaur.listeHabileteActive[0] = Venusaur.listeHabilete[0];
            Venusaur.calcul_caract();
            Venusaur.listeHabilete = liste_veg;
            Venusaur.listeHabileteActive[0] = Venusaur.listeHabilete[0];
            liste_monstre[11] = Venusaur;

            Monstre Charmander = new Monstre(13, "Charmander", "Lézard de feu", "aucun", TypeElement.Feu, "Charmander.png");
            Charmander.deBase[0] = 100; Charmander.prog[0] = 5;
            Charmander.deBase[1] = 100; Charmander.prog[1] = 10;
            Charmander.deBase[2] = 10; Charmander.prog[2] = 2;
            Charmander.deBase[3] = 20; Charmander.prog[3] = 10;
            Charmander.deBase[4] = 5; Charmander.prog[4] = 1;
            Charmander.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Charmander.typeMonstre);
            Charmander.listeHabileteActive[0] = Charmander.listeHabilete[0];
            Charmander.calcul_caract();
            Charmander.listeHabilete = liste_feu;
            Charmander.listeHabileteActive[0] = Charmander.listeHabilete[0];
            liste_monstre[12] = Charmander;

            Monstre Ninetales = new Monstre(14, "Ninetales", "Loup volcanique", "aucun", TypeElement.Feu, "Ninetales.png");
            Ninetales.deBase[0] = 100; Ninetales.prog[0] = 5;
            Ninetales.deBase[1] = 100; Ninetales.prog[1] = 10;
            Ninetales.deBase[2] = 10; Ninetales.prog[2] = 10;
            Ninetales.deBase[3] = 30; Ninetales.prog[3] = 30;
            Ninetales.deBase[4] = 5; Ninetales.prog[4] = 1;
            Ninetales.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Ninetales.typeMonstre);
            Ninetales.listeHabileteActive[0] = Ninetales.listeHabilete[0];
            Ninetales.calcul_caract();
            Ninetales.listeHabilete = liste_feu;
            Ninetales.listeHabileteActive[0] = Ninetales.listeHabilete[0];
            liste_monstre[13] = Ninetales;

            Monstre Rapidash = new Monstre(15, "Rapidash", "Cheval volcanique", "aucun", TypeElement.Feu, "Rapidash.png");
            Rapidash.deBase[0] = 100; Rapidash.prog[0] = 15;
            Rapidash.deBase[1] = 100; Rapidash.prog[1] = 20;
            Rapidash.deBase[2] = 10; Rapidash.prog[2] = 2;
            Rapidash.deBase[3] = 20; Rapidash.prog[3] = 30;
            Rapidash.deBase[4] = 5; Rapidash.prog[4] = 5;
            Rapidash.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Rapidash.typeMonstre);
            Rapidash.listeHabileteActive[0] = Rapidash.listeHabilete[0];
            Rapidash.calcul_caract();
            Rapidash.listeHabilete = liste_feu;
            Rapidash.listeHabileteActive[0] = Rapidash.listeHabilete[0];
            liste_monstre[14] = Rapidash;

            Monstre Moltres = new Monstre(16, "Moltres", "Oiseau Volcanique", "aucun", TypeElement.Feu, "Moltres.png");
            Moltres.deBase[0] = 100; Moltres.prog[0] = 30;
            Moltres.deBase[1] = 100; Moltres.prog[1] = 10;
            Moltres.deBase[2] = 10; Moltres.prog[2] = 5;
            Moltres.deBase[3] = 20; Moltres.prog[3] = 60;
            Moltres.deBase[4] = 5; Moltres.prog[4] = 10;
            Moltres.listeHabilete = Habilete.Charger_Liste_Habilete_Element(Moltres.typeMonstre);
            Moltres.listeHabileteActive[0] = Moltres.listeHabilete[0];
            Moltres.calcul_caract();
            Moltres.listeHabilete = liste_feu;
            Moltres.listeHabileteActive[0] = Moltres.listeHabilete[0];
            liste_monstre[15] = Moltres;

            Monstre.Enregistrer_Liste_Monstre(liste_monstre);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
