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
            Habilete[] liste_complet = new Habilete[20];
            // Végétation
            Habilete lanceSoleil = new Habilete("Lance-Soleil", "absorbe la lumière et l'envoie sur l'ennemi", 40, TypeElement.Vegetation, Cible.ennemi, Effet.degat, 20, 1);
            liste_complet[1] = lanceSoleil;
            Habilete poudreToxique = new Habilete("Poudre Toxique", "Répand une poudre toxique pendent 3 tour", 15, TypeElement.Vegetation, Cible.ennemi, Effet.degat,10, 3);
            liste_complet[2] = poudreToxique;
            Habilete Photosynthese = new Habilete("Photosynthèse", "Regénère sa vie grâce au soleil", 40, TypeElement.Vegetation, Cible.soi, Effet.regeneration, 20, 1);
            liste_complet[3] = Photosynthese;
            Habilete GraineCanon = new Habilete( "Graine Canon", "Propulse des graines sur l'ennemi", 75, TypeElement.Vegetation, Cible.ennemi,Effet.degat, 70, 1);
            liste_complet[4] = GraineCanon;
            Habilete Cocon = new Habilete ("Cocon", "S'enveloppe d'une barrière qui bloque l'ennemi pour un tour", 75, TypeElement.Vegetation,Cible.ennemi, Effet.force, 100, 1);
            liste_complet[5] = Cocon;
            
            // Electrique
            Habilete Eclair = new Habilete ("Éclair", "Choc électrique", 30, TypeElement.Electricite, Cible.ennemi,Effet.degat, 20, 1);
            liste_complet[6] = Eclair;
            Habilete Cage = new Habilete ("Cage","Choc électrique qui paralyse l'ennemi pour 3 tours", 50, TypeElement.Electricite, Cible.ennemi,Effet.paralysie,40, 3);
            liste_complet[7] = Cage;
            Habilete MangeTonnerre = new Habilete("Mange-tonnerre", "Absorbe l'énergie du tonnerre pour régénéré", 20, TypeElement.Electricite, Cible.soi, Effet.regeneration, 30, 1);
            liste_complet[8] = MangeTonnerre;
            Habilete Coup_foudroyant = new Habilete ("Coup foudroyant", "Lance un éclair sur l'ennemi", 40, TypeElement.Electricite, Cible.ennemi, Effet.degat, 80,1);
            liste_complet[9] = Coup_foudroyant;
            Habilete Champ_Magnetique = new Habilete ("Champ magnétique", "Créer un bouclier qui donne de la force pour 2 tour", 20, TypeElement.Electricite, Cible.soi,Effet.force,80, 2);
            liste_complet[10] = Champ_Magnetique;
            
            //Eau
            Habilete HydroCannon = new Habilete ("HydroCannon", "Envoie un puissant jet d'eau", 30,TypeElement.Eau,Cible.ennemi,Effet.degat, 20, 1);

            Habilete Siphon = new Habilete ("Siphon"," Piège l'ennemi pendent 2 tours",50,TypeElement.Eau,Cible.ennemi,Effet.paralysie, 50, 2);

            Habilete Sauna = new Habilete ("Sauna", "S'enveloppe d'eau chaude pour régénérer 2 tours",40,TypeElement.Eau,Cible.soi,Effet.regeneration, 50, 2);

            Habilete Carapace_eau = new Habilete ("Carapace D'eau", "S'enveloppe d'eau pour se défendre 2 tours", 10,TypeElement.Eau,Cible.soi,Effet.force, 40, 2);

            Habilete Tsunami = new Habilete ("Tsunami", "Propulse un Tsunami sur l'ennemi", 90,TypeElement.Eau,Cible.ennemi,Effet.degat, 90, 1);

            liste_complet[11] = HydroCannon;
            liste_complet[12] = Siphon;
            liste_complet[13] = Sauna;
            liste_complet[14] = Carapace_eau;
            liste_complet[15] = Tsunami;
            //Feu

            Habilete Flameche = new Habilete ("Flammeche", "Faible attaque de feu", 15,TypeElement.Feu,Cible.ennemi,Effet.degat, 20, 1);

            Habilete Prison_feu = new Habilete ("Prison de feu","Entour l'ennemi d'un cercle de feu pour un tour", 35,TypeElement.Feu,Cible.ennemi,Effet.paralysie,35, 1);

            Habilete Canicule = new Habilete ("Canicule", "Souffle ardent qui réduit les défenses de l'ennemi", 35,TypeElement.Feu,Cible.ennemi,Effet.faiblesse, 35, 1);

            Habilete Flamme_bleu = new Habilete ("Flamme bleu", "S'entour d'un cercle de feu bleu qui protège", 35,TypeElement.Feu,Cible.soi,Effet.force, 70, 1);

            Habilete Magma = new Habilete ("Magma", "Propulse du magma sur l'ennemi", 75,TypeElement.Feu,Cible.ennemi,Effet.degat, 95, 1);

            liste_complet[16] = Flameche;
            liste_complet[17] = Prison_feu;
            liste_complet[18] = Canicule;
            liste_complet[19] = Flamme_bleu;
            liste_complet[20] = Magma;
    }
    }
}
