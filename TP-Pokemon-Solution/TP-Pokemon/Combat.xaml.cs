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
        public Monstre adversaire;
        public TypeElement element;

        public Combat(Aventure parti, TypeElement element)
        {
            InitializeComponent();
            fenetre_difficulty.Visibility = System.Windows.Visibility.Visible;
            this.parti = parti;
            this.element = element;
            selectionne = parti.joueur.equipe[0];
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
            textBox_Console.Text = "\n--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[0].nomMonstre + " au combat !";
            selectionne = parti.joueur.equipe[0];
            barre_vie_player.Value = parti.joueur.equipe[0].actuel[0];
            barre_mana_player.Value = parti.joueur.equipe[0].actuel[1];
        }
        private void button_choix2_Click(object sender, RoutedEventArgs e)
        {
            if(parti.joueur.equipe[1]!=null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[1]);
                textBox_Console.Text = "\n--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[1].nomMonstre + " au combat !";
                selectionne = parti.joueur.equipe[1];
                barre_vie_player.Value = parti.joueur.equipe[1].actuel[0];
                barre_mana_player.Value = parti.joueur.equipe[1].actuel[1];

            }
        }
        private void button_choix3_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[2] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[2]);
                textBox_Console.Text = "\n--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[2].nomMonstre + " au combat !";
                selectionne = parti.joueur.equipe[2];
                barre_vie_player.Value = parti.joueur.equipe[2].actuel[0];
                barre_mana_player.Value = parti.joueur.equipe[2].actuel[1];
            }
        }
        private void button_choix4_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[3] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[3]);
                textBox_Console.Text ="\n--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[3].nomMonstre + " au combat !";
                selectionne = parti.joueur.equipe[3];
                barre_vie_player.Value = parti.joueur.equipe[3].actuel[0];
                barre_mana_player.Value = parti.joueur.equipe[3].actuel[1];
            }
        }
        private void button_choix5_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.equipe[4] != null)
            {
                panel_pokemon.Visibility = System.Windows.Visibility.Visible;
                panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                afficher_pokemon(parti.joueur.equipe[4]);
                textBox_Console.Text ="\n--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[4].nomMonstre + " au combat !";
                selectionne = parti.joueur.equipe[4];
                barre_vie_player.Value = parti.joueur.equipe[4].actuel[0];
                barre_mana_player.Value = parti.joueur.equipe[4].actuel[1];
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
            foreach(Monstre x in parti.joueur.equipe)
            {
                if(x !=null)
                {
                    x.actuel[0] = x.total[0];
                    x.actuel[1] = x.total[1];
                    x.actuel[2] = x.total[2];
                    x.actuel[3] = x.total[3];
                    x.actuel[4] = x.total[4];
                }
            }
            Map newMap = new Map(parti);
            newMap.Show();
            this.Close();
        }

        //###############################################################################
        //#		             Panel du choix de difficulte                               #
        //###############################################################################
        private void button_facile_Click(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
            generer_adversaire(1);
        }

        private void button_moyen_Click(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
            generer_adversaire(2);
        }

        private void button_Difficile_Click(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
            generer_adversaire(3);
        }

        private void button_expert_Click(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
            generer_adversaire(4);
        }

        private void button_Legende_Click(object sender, RoutedEventArgs e)
        {
            fenetre_difficulty.Visibility = System.Windows.Visibility.Hidden;
            generer_adversaire(5);
        }

        //###############################################################################
        //#		                    Fonctions associés                                  #
        //###############################################################################

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
            label_mana_Copy.Content = "Regen : +" + monstre.actuel[2];
            label_attaque.Content = "Attaque : " + monstre.actuel[3];
            label_défense.Content = "Défense : " + monstre.actuel[4];
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

        public void generer_adversaire(int level)
        {
            Monstre ennemi;
            Monstre[] liste = Monstre.Liste_par_Element(element);
            // Ici un concept de generation de niveau de rarete devrait être retravailler
            Random rand = new Random();
            int rarete = rand.Next(0, 4);
            ennemi = liste[rarete];
            //---------------------------------------------------------------------------
            ennemi.niveauExp = level;
            ennemi.calcul_caract();
            image_pokemon_adverse.Source = Monstre.portrait(ennemi.nomMonstre);
            adversaire = ennemi;
            textBox_Console.Text = ennemi.nomMonstre + " apparait face à vous !\n Veuillez choisir une action rapidement !";
       
        }

        private void attaquer(Monstre attaquant, Monstre cible, Habilete spell_use)
        {
            Habilete spell = spell_use;
            if (attaquant.actuel[1] < spell.cout)
            {
                System.Windows.MessageBox.Show("Ce pokemon n'a pas assez de mana pour effectuer l'attaque: Mana" + attaquant.actuel[1] + " Cout " + spell.cout);
            }
            else
            {
                //Si l'attaquant est de type eau, l'electricite diminu de moitier le spell et le feu encaisse le double
                if (attaquant.typeMonstre == TypeElement.Eau) {
                    if (cible.typeMonstre == TypeElement.Electricite)
                    {
                        spell.magnitude = spell.magnitude / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Feu)
                    {
                        spell.magnitude = spell.magnitude * 2;
                    }
                }

                //Si l'attaquant est de type Electricite, l'eau encaisse le double et la vegetation resiste de moititer
                if (attaquant.typeMonstre == TypeElement.Electricite)
                {
                    if (cible.typeMonstre == TypeElement.Vegetation)
                    {
                        spell.magnitude = spell.magnitude / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Eau)
                    {
                        spell.magnitude = spell.magnitude * 2;
                    }
                }

                //Si l'attaquant est de type Feu, l'eau encaisse la moitier et vegetation le double
                if (attaquant.typeMonstre == TypeElement.Feu)
                {
                    if (cible.typeMonstre == TypeElement.Eau)
                    {
                        spell.magnitude = spell.magnitude / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Vegetation)
                    {
                        spell.magnitude = spell.magnitude * 2;
                    }
                }

                //Si l'attaquant est de type Vegetation, l'electricite encaisse le double et le feu la moitie
                if (attaquant.typeMonstre == TypeElement.Vegetation)
                {
                    if (cible.typeMonstre == TypeElement.Feu)
                    {
                        spell.magnitude = spell.magnitude / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Electricite)
                    {
                        spell.magnitude = spell.magnitude * 2;
                    }
                }

                //Calcul de l'attaque
                int damageBrute = spell.magnitude + attaquant.actuel[3];
                int damageNet = damageBrute - cible.actuel[4];
                cible.actuel[0] -= damageNet;
                attaquant.actuel[1] -= spell.cout;

                if (cible == selectionne)
                {
                    adversaire.actuel[0] = cible.actuel[0];
                    selectionne.actuel[1] = attaquant.actuel[1];
                }
                else
                {
                    selectionne.actuel[0] = cible.actuel[0];
                    adversaire.actuel[1] = attaquant.actuel[1];
                }

                MAJ_barre();
                textBox_Console.Text = textBox_Console.Text + "\n-------------------------------------------------\n" + attaquant.nomMonstre + " utilise " + spell.nom + " !\n" + cible.nomMonstre + " encaisse " + spell.magnitude + " de damage !";

            }

        }

        private void reponse_adverse()
        {
            if(adversaire.actuel[0]<=0)
            {
                adversaire.etat_actuel = Monstre.etat_actif.Mort;
                textBox_Console.Text = adversaire.nomMonstre + "est mort !\nVous avez gagné !";
                panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                disable_button();
                //Attribution des récompenses
                int numero_monstre = Monstre.trouver_monstre_equipe(selectionne, parti.joueur);
                switch (adversaire.niveauExp)
                {
                    case 1:
                        // 50xp                        
                        parti.joueur.equipe[numero_monstre].add_xp(50);
                        break;
                    case 2:
                        // 50xp + 200 $
                        parti.joueur.equipe[numero_monstre].add_xp(50);
                        parti.joueur.argent += 200;
                        break;
                    case 3:
                        // 100 xp
                        parti.joueur.equipe[numero_monstre].add_xp(100);
                        break;
                    case 4:
                        // 100 xp + 500 $
                        parti.joueur.equipe[numero_monstre].add_xp(100);
                        parti.joueur.argent += 500;
                        break;
                    case 5:
                        // 100 xp + 1000$
                        parti.joueur.equipe[numero_monstre].add_xp(100);
                        parti.joueur.argent += 1000;
                        break;
                }

                // Fin du combat
            }

            else if(adversaire.actuel[0]<=10)
            {
                textBox_Console.Text = adversaire.nomMonstre + "s'est enfui ! \nVeuillez revenir plus tard !";
                image_pokemon_adverse.Source = Monstre.portrait("iconnu.xml");
                panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                disable_button();
            }
            else if(adversaire.actuel[0]<=40)
            {
                TypeElement element = adversaire.typeMonstre;
                Habilete supporting = Habilete.habilete_protection_element(element);
                // Utilise l'habilete
            }
            else
            {
                attaquer(adversaire, selectionne, adversaire.listeHabilete[0]);
            }
        }

        //Fonction qui  met les barres de vie et de mana à jour
        private void MAJ_barre()
        {
            int valeur = (selectionne.actuel[0]*100) / selectionne.total[0];
            barre_vie_player.Value = valeur;

            valeur = (selectionne.actuel[1]*100) / selectionne.total[1];
            barre_mana_player.Value = valeur;

            valeur = (adversaire.actuel[0]*100) / adversaire.total[0];
            textBox_Console.Text = textBox_Console.Text + " \n Actuel :"+ adversaire.actuel[0]+" Total: "+adversaire.total[0]+ " Valeur :  " + valeur;
            barre_vie_adverse.Value = valeur;

            valeur = (adversaire.actuel[1]*100) / adversaire.total[1];
            barre_mana_adverse.Value = valeur;

        }

        //Fonction qui disable les boutons en fin de parti
        public void disable_button()
        {
            button_choix1.IsEnabled = false;
            button_choix2.IsEnabled = false;
            button_choix3.IsEnabled = false;
            button_choix4.IsEnabled = false;
            button_choix5.IsEnabled = false;
            button_inventaire.IsEnabled = false;
        }

        private void button_habilete_1_Click(object sender, RoutedEventArgs e)
        {
            Habilete spell = selectionne.listeHabileteActive[0];
            if (spell.cible == Cible.ennemi)
            {
                attaquer(selectionne, adversaire, spell);
                reponse_adverse();
            }
        }

        private void button_habilete_2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
