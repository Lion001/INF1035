using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //Bouton qui permet de choisir un pokemon parmi la liste des pokemons actif
        private void button_choix1_Click(object sender, RoutedEventArgs e)
        {
            panel_pokemon.Visibility = System.Windows.Visibility.Visible;
            panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
            afficher_pokemon(parti.joueur.equipe[0]);
            textBox_Console.Text = "--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[0].nomMonstre + " au combat !";
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
                textBox_Console.Text = "--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[1].nomMonstre + " au combat !";
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
                textBox_Console.Text = "--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[2].nomMonstre + " au combat !";
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
                textBox_Console.Text ="--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[3].nomMonstre + " au combat !";
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
                textBox_Console.Text ="--------------------------------\n" + parti.joueur.nomJoueur + " envoie " + parti.joueur.equipe[4].nomMonstre + " au combat !";
                selectionne = parti.joueur.equipe[4];
                barre_vie_player.Value = parti.joueur.equipe[4].actuel[0];
                barre_mana_player.Value = parti.joueur.equipe[4].actuel[1];
            }
        }

        //Bouton qui donne accès au panel de l'inventaire
        private void button_inventaire_Click(object sender, RoutedEventArgs e)
        {
            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
            panel_inventaire.Visibility = System.Windows.Visibility.Visible;

            label_pokeball.Content = "x " + parti.joueur.inventaire.pokeball;
            label_potion_mauve.Content = "x " + parti.joueur.inventaire.potion_vie;
            label_potion_mana.Content = "x " + parti.joueur.inventaire.potion_mana;
            label_potion_or.Content = "x " + parti.joueur.inventaire.potion_max;
        }

        //Bouton pour quitter
        private void button_quitter_Click(object sender, RoutedEventArgs e)
        {
            foreach(Monstre x in parti.joueur.equipe)
            {
                if(x !=null)
                {
                    x.calcul_caract();
                    x.renew_caract();
                }
            }
            Map newMap = new Map(parti);
            newMap.Show();
            this.Close();
        }

        //Bouton qui permet l'utilisation de l'habilete 1
        private void button_habilete_1_Click(object sender, RoutedEventArgs e)
        {
            Habilete spell = selectionne.listeHabileteActive[0];
            if (spell.cible == Cible.ennemi)
            {
                attaquer(selectionne, adversaire, spell);
            }
            else
            {
                TypeElement element = selectionne.typeMonstre;
                Habilete supporting = Habilete.habilete_protection_element(element);
                textBox_Console.AppendText("\n-------------------------------------------------\n" + selectionne.nomMonstre + " utilise " + supporting.nom + " !");
                // Utilise l'habilete
                selectionne.actuel[1] = selectionne.actuel[1] - supporting.cout;
                if (supporting.effet == Effet.regeneration)
                {
                    selectionne.actuel[0] = selectionne.actuel[0] + supporting.magnitude;
                    if (selectionne.actuel[0] > selectionne.total[0])
                    {
                        selectionne.actuel[0] = selectionne.total[0];
                    }
                    textBox_Console.AppendText("\n" + selectionne.nomMonstre + " récupère " + supporting.magnitude + " points de vie !");
                }
                else
                {
                    selectionne.actuel[4] = selectionne.actuel[4] + supporting.magnitude;
                    textBox_Console.AppendText("\n" + selectionne.nomMonstre + " augmente ces défenses de " + supporting.magnitude + " points !");
                }
            }
            reponse_adverse();
        }
        //Bouton qui permet l'utilisation de l'habilete 2
        private void button_habilete_2_Click(object sender, RoutedEventArgs e)
        {
            Habilete spell = selectionne.listeHabileteActive[1];
            if (spell.cible == Cible.ennemi)
            {
                attaquer(selectionne, adversaire, spell);
            }
            else
            {
                TypeElement element = selectionne.typeMonstre;
                Habilete supporting = Habilete.habilete_protection_element(element);
                textBox_Console.AppendText("\n-------------------------------------------------\n" + selectionne.nomMonstre + " utilise " + supporting.nom + " !");
                // Utilise l'habilete
                selectionne.actuel[1] = selectionne.actuel[1] - supporting.cout;
                if (supporting.effet == Effet.regeneration)
                {
                    selectionne.actuel[0] = selectionne.actuel[0] + supporting.magnitude + selectionne.niveauExp;
                    if (selectionne.actuel[0] > selectionne.total[0])
                    {
                        selectionne.actuel[0] = selectionne.total[0];
                    }
                    textBox_Console.AppendText("\n" + selectionne.nomMonstre + " récupère " + supporting.magnitude + " points de vie !");
                }
                else
                {
                    selectionne.actuel[4] = selectionne.actuel[4] + supporting.magnitude;
                    textBox_Console.AppendText("\n" + selectionne.nomMonstre + " augmente ces défenses de " + supporting.magnitude + " points !");
                }
            }
            reponse_adverse();
        }

        //###############################################################################
        //#		             Panel du choix de difficulte                               #
        //###############################################################################

        // Fonction qui modifi la difficulté du combat
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

            barre_vie_player.Maximum = monstre.total[0];
            barre_vie_player.Value = monstre.actuel[0];

            barre_mana_player.Maximum = monstre.total[1];
            barre_mana_player.Value = monstre.actuel[1];

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

        // Genere un pokemon aleatoire 
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
            ennemi.pointExp = ennemi.pointExp + 1; // Cette ligne permettera de différencier les pokémons dans la fonction estIdentique de la classe Monstre
            ennemi.calcul_caract();
            image_pokemon_adverse.Source = Monstre.portrait(ennemi.nomMonstre);
            barre_vie_adverse.Maximum = ennemi.total[0];
            barre_vie_adverse.Value = ennemi.total[0];
            barre_mana_adverse.Maximum = ennemi.total[1];
            barre_mana_adverse.Value = ennemi.total[1];
            adversaire = ennemi;
            textBox_Console.Text = ennemi.nomMonstre + " apparait face à vous !\n Veuillez choisir une action rapidement !";
       
        }

        //Utilisation d'une attaque
        private void attaquer(Monstre attaquant, Monstre cible, Habilete spell_use)
        {
            Habilete spell = spell_use;
            if (attaquant.actuel[1] < spell.cout)
            {
                System.Windows.MessageBox.Show("Ce pokemon n'a pas assez de mana pour effectuer l'attaque: Mana" + attaquant.actuel[1] + " Cout " + spell.cout);
            }
            else
            {
                int damageBrute = spell.magnitude + attaquant.actuel[3];

                //Si l'attaquant est de type eau, l'electricite diminu de moitier le spell et le feu encaisse le double
                if (attaquant.typeMonstre == TypeElement.Eau) {
                    if (cible.typeMonstre == TypeElement.Electricite)
                    {
                        damageBrute = damageBrute / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Feu)
                    {
                        damageBrute = damageBrute * 2;
                    }
                }

                //Si l'attaquant est de type Electricite, l'eau encaisse le double et la vegetation resiste de moititer
                if (attaquant.typeMonstre == TypeElement.Electricite)
                {
                    if (cible.typeMonstre == TypeElement.Vegetation)
                    {
                        damageBrute = damageBrute / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Eau)
                    {
                        damageBrute = damageBrute * 2;
                    }
                }

                //Si l'attaquant est de type Feu, l'eau encaisse la moitier et vegetation le double
                if (attaquant.typeMonstre == TypeElement.Feu)
                {
                    if (cible.typeMonstre == TypeElement.Eau)
                    {
                        damageBrute = damageBrute / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Vegetation)
                    {
                        damageBrute = damageBrute * 2;
                    }
                }

                //Si l'attaquant est de type Vegetation, l'electricite encaisse le double et le feu la moitie
                if (attaquant.typeMonstre == TypeElement.Vegetation)
                {
                    if (cible.typeMonstre == TypeElement.Feu)
                    {
                        damageBrute = damageBrute / 2;
                    }

                    if (cible.typeMonstre == TypeElement.Electricite)
                    {
                        damageBrute = damageBrute * 2;
                    }
                }

                //Calcul de l'attaque             
                int damageNet = damageBrute - cible.actuel[4];
                cible.actuel[0] = cible.actuel[0] -  damageNet;
                attaquant.actuel[1] = attaquant.actuel[1] - spell.cout;

                if (Monstre.estIdentique(cible,selectionne)) // Si la cible est le pokemon du joueur
                {
                    selectionne.actuel[0] = cible.actuel[0]; // La vie du pokemon du joueur est = a la vie de la cible 
                    adversaire.actuel[1] = attaquant.actuel[1]; // La mana du pokemon adverse est = a la mana de l'attaquant
                }
                else // Sinon, la cible est le pokemon de l'adversaire
                {
                    adversaire.actuel[0] = cible.actuel[0];
                    selectionne.actuel[1] = attaquant.actuel[1];
                }

                MAJ_barre();
                textBox_Console.AppendText( "\n-------------------------------------------------\n" + attaquant.nomMonstre + " utilise " + spell.nom + " !\n" + cible.nomMonstre + " encaisse " + damageBrute + " de damage !");

            }

        }

        //Reponse de l'adversaire (Intelligence artificielle)
        private void reponse_adverse()
        {
            if(adversaire.actuel[0]<=0) // Si la vie de l'adversaire est moins ou égal a 0
            {
                textBox_Console.Text = adversaire.nomMonstre + " est mort !\nVous avez gagné !";
                panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                disable_button();
                //Attribution des récompenses
                int numero_monstre = parti.joueur.trouver_monstre_equipe(selectionne);
                switch (adversaire.niveauExp)
                {
                    case 1:
                        // 50xp                        
                        textBox_Console.AppendText(parti.joueur.equipe[numero_monstre].add_xp(50,parti));
                        break;
                    case 2:
                        // 50xp + 200 $
                        textBox_Console.AppendText(parti.joueur.equipe[numero_monstre].add_xp(50, parti));
                        parti.joueur.argent = parti.joueur.argent +  200;
                        break;
                    case 3:
                        // 100 xp
                        textBox_Console.AppendText(parti.joueur.equipe[numero_monstre].add_xp(100, parti));
                        break;
                    case 4:
                        // 100 xp + 500 $
                        textBox_Console.AppendText(parti.joueur.equipe[numero_monstre].add_xp(100, parti));
                        parti.joueur.argent = parti.joueur.argent + 500;
                        break;
                    case 5:
                        // 100 xp + 1000$
                        textBox_Console.AppendText(parti.joueur.equipe[numero_monstre].add_xp(100, parti));
                        parti.joueur.argent = parti.joueur.argent + 1000;
                        break;
                }

                // Fin du combat
            }

            // Si la vie de l'adversaire est égal ou plus petit que 10
            else if (adversaire.actuel[0]<=10) 
            {
                textBox_Console.AppendText("\n" + adversaire.nomMonstre + "s'est enfui ! \nVeuillez revenir plus tard !");
                image_pokemon_adverse.Source = Monstre.portrait("iconnu.xml");
                panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                disable_button();
            }

            // Si l'adversaire a pas assez de mana pour une habilete
            else if (adversaire.actuel[1] < adversaire.listeHabilete[0].cout && adversaire.actuel[1] < adversaire.listeHabilete[1].cout) 
            {
                textBox_Console.AppendText( "\n-------------------------------------------------\n" + adversaire.nomMonstre + " n'a pas assez de mana pour utiliser une habilete ! ");
                Regen_mana();
            }

            // Si la vie de l'adversaire est plus petit ou égal a 30
            else if (adversaire.actuel[0]<=30 || (adversaire.actuel[1] < adversaire.listeHabilete[0].cout && adversaire.actuel[1] > adversaire.listeHabilete[1].cout)) 
            {
                TypeElement element = adversaire.typeMonstre;
                Habilete supporting = Habilete.habilete_protection_element(element);
                textBox_Console.AppendText( "\n-------------------------------------------------\n" + adversaire.nomMonstre + " utilise " + supporting.nom + " !");
                // Utilise l'habilete
                adversaire.actuel[1] = adversaire.actuel[1] - supporting.cout;
                if (supporting.effet == Effet.regeneration)
                {
                    adversaire.actuel[0] = adversaire.actuel[0] + supporting.magnitude;
                    if(adversaire.actuel[0]>adversaire.total[0])
                    {
                        adversaire.actuel[0] = adversaire.total[0];
                    }
                    textBox_Console.AppendText( "\n" + adversaire.nomMonstre + " récupère "+supporting.magnitude+" points de vie !" );
                }
                else
                {
                    adversaire.actuel[4] = adversaire.actuel[4] + supporting.magnitude;
                    textBox_Console.AppendText( "\n" + adversaire.nomMonstre + " augmente ces défenses de " + supporting.magnitude + " points !");
                }
                Regen_mana();
            }

            else
            {
                attaquer(adversaire, selectionne, adversaire.listeHabilete[0]);
                if(selectionne.actuel[0]<1)
                {
                    textBox_Console.AppendText( "\n" +selectionne.nomMonstre + " est mort !\nVeuillez sélectionner un autre pokemon ou quitter ! ");
                    int x = parti.joueur.trouver_monstre_equipe(selectionne);
                    
                    switch (x)
                    {
                        case 0:
                            button_choix1.IsEnabled = false;
                            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        case 1:
                            button_choix2.IsEnabled = false;
                            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        case 2:
                            button_choix3.IsEnabled = false;
                            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        case 3:
                            button_choix4.IsEnabled = false;
                            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        case 4:
                            button_choix5.IsEnabled = false;
                            panel_pokemon.Visibility = System.Windows.Visibility.Hidden;
                            break;
                    }
                    // Si tout les pokemons sont morts, disable le boutton inventaire ainsi que le panel relié
                    if(button_choix1.IsEnabled == false && button_choix2.IsEnabled == false && button_choix3.IsEnabled == false && button_choix4.IsEnabled == false && button_choix5.IsEnabled == false)
                    {
                        button_inventaire.IsEnabled = false;
                        panel_inventaire.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
                else
                {
                    Regen_mana();
                }
            }
            
        }

        //Fonction qui  met les barres de vie et de mana à jour
        private void MAJ_barre()
        {
            barre_vie_player.Value = selectionne.actuel[0];
            barre_mana_player.Value = selectionne.actuel[1];

            barre_vie_adverse.Value = adversaire.actuel[0];
            barre_mana_adverse.Value = adversaire.actuel[1];
        }

        //Fonction qui applique le regen de mana
        private void Regen_mana()
        {
            //Ajout de la mana 
            selectionne.actuel[1] = selectionne.actuel[1] + selectionne.actuel[2];
            adversaire.actuel[1] = adversaire.actuel[1] + adversaire.actuel[2];
            //
            MAJ_barre();
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

        //###############################################################################
        //#		                 Button du Panel Inventaire                             #
        //###############################################################################

        private void button_pokeball_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.inventaire.pokeball > 0)
            {
                image_pokemon_adverse.Source = image_pokeball.Source;
                textBox_Console.Text = "-------------------------------------------------\n" + parti.joueur.nomJoueur + " utilise une pokeball !";
                Task.Delay(3000);

                if (adversaire.actuel[0] <= 40)
                {
                    Random rand = new Random();
                    int random = rand.Next(1, 5);

                    if (random >= adversaire.niveauExp)
                    {
                        textBox_Console.AppendText("\n" + adversaire.nomMonstre + " a été capturé !");

                        // Remis a zéro des stats du monstre
                        adversaire.calcul_caract();
                        adversaire.renew_caract();
                        //Fermeture de l'interface
                        disable_button();
                        adversaire.pointExp--; 
                        //Ajout du pokémon dans la liste de capture
                        parti.joueur.Ajouter_Pokemon_listeTotal(adversaire);
                    }
                    else
                    {
                        textBox_Console.AppendText("\n" + adversaire.nomMonstre + " résiste à la pokeball !");
                        image_pokemon_adverse.Source = Monstre.portrait(adversaire.nomMonstre);
                        reponse_adverse();
                    }
                }
                else
                {
                    textBox_Console.AppendText("\n" + adversaire.nomMonstre + " résiste à la pokeball !");
                    image_pokemon_adverse.Source = Monstre.portrait(adversaire.nomMonstre);
                    reponse_adverse();
                }
                parti.joueur.inventaire.pokeball--;
                label_pokeball.Content = "x " + parti.joueur.inventaire.pokeball;
            }
        }

        private void button_potion_vie_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.inventaire.potion_vie > 0)
            {
                textBox_Console.Text = "-------------------------------------------------\n" + parti.joueur.nomJoueur + " utilise une potion de vie !\n" + selectionne.nomMonstre + " récupère 100 points de vie! ";
                selectionne.actuel[0] = selectionne.actuel[0] + 100;
                selectionne.calcul_caract();
                if (selectionne.actuel[0] > selectionne.total[0])
                {
                    selectionne.actuel[0] = selectionne.total[0];
                }
                MAJ_barre();
                parti.joueur.inventaire.potion_vie--;
                label_potion_mauve.Content = "x " + parti.joueur.inventaire.potion_vie;
                reponse_adverse();
            }

        }

        private void button_potion_mana_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.inventaire.potion_mana > 0)
            {
                textBox_Console.Text = "-------------------------------------------------\n" + parti.joueur.nomJoueur + " utilise une potion de mana !\n" + selectionne.nomMonstre + " récupère 100 points de mana! ";
                selectionne.actuel[1] = selectionne.actuel[1] + 100;
                selectionne.calcul_caract();
                if (selectionne.actuel[1] > selectionne.total[1])
                {
                    selectionne.actuel[1] = selectionne.total[1];
                }
                MAJ_barre();
                parti.joueur.inventaire.potion_mana--;
                label_potion_mana.Content = "x " + parti.joueur.inventaire.potion_mana;
                reponse_adverse();
            }
        }

        private void button_potion_max_Click(object sender, RoutedEventArgs e)
        {
            if (parti.joueur.inventaire.potion_max > 0)
            {
                textBox_Console.Text = "-------------------------------------------------\n" + parti.joueur.nomJoueur + " utilise une potion en or !\n" + selectionne.nomMonstre + " récupère toute sa vie et sa mana ! ";
                selectionne.calcul_caract();
                selectionne.actuel[0] = selectionne.total[0];
                selectionne.actuel[1] = selectionne.total[1];
                MAJ_barre();
                parti.joueur.inventaire.potion_max--;
                label_potion_or.Content = "x " + parti.joueur.inventaire.potion_max;
                reponse_adverse();
            }
        }
    }
}
