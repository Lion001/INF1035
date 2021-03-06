﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace TP_Pokemon
{
 
    [Serializable, XmlRoot(Namespace="Habilete")]
    public class Monstre : IRandom
    {
        public enum etat_actif
        {
            Mort,Vivant,Paralysie,Empoisonnement,Faiblesse,Force_Decuple
        }
        public int id { get; set;}
        public string nomMonstre { get; set;}
        public string descripMonstre { get; set;}
        public string aliasMonstre { get; set;}
        public TypeElement typeMonstre { get; set;}
        public int rarete { get; set;}
        public int niveauExp { get; set;}
        public int pointExp { get; set;}
        public int[] deBase, prog, total, actuel; 
        public etat_actif etat_actuel = new etat_actif();
        public Habilete[] listeHabilete { get; set; }
        public Habilete[] listeHabileteActive { get; set; }
        public string nom_Image { get; set; }


        //Constructeur sans paramètre utilisé dans la Serialization
        public Monstre() { }

        //constructeur
        public Monstre(int id, string nomMonstre, string descripMonstre, string aliasMonstre, TypeElement typeMonstre, string nom_Image)
        {
            this.id = id;
            this.nomMonstre = nomMonstre;
            this.descripMonstre = descripMonstre;
            this.aliasMonstre = aliasMonstre;
            this.typeMonstre = typeMonstre;
            this.rarete = getRandomChiffre(0,101);
            this.niveauExp = 1;//valeur par defaut
            this.pointExp = 100;//valeur par defaut
            //-- Caracteristique --- // Tableau de Int :  [0] = point_vie, [1] point_energie, [2] regen_energie, [3] attaque, [4] defense
            deBase = new int[5];
            prog = new int[5];
            total = new int[5];
            actuel = new int[5];
            //-----------------------
            etat_actuel= etat_actif.Vivant;
            listeHabilete = new Habilete[6]; // Cette liste contiendra seulement 5 habilete possible mais j'ai créer un tableau plus gros au cas ou
            listeHabileteActive = new Habilete[2]; // Cette liste contiendra seulement 2 habilete possible mais ^
            this.nom_Image = nom_Image;
    
        }

        // Fonction qui calcul les caractèristiques totales (Total = Base + prog*lvl)
        public void calcul_caract()
        {
            int[] total2 = new int[5];
            total2[0] = deBase[0] + prog[0] * this.niveauExp;
            total2[1] = deBase[1] + prog[1] * this.niveauExp;
            total2[2] = deBase[2] + prog[2] * this.niveauExp;
            total2[3] = deBase[3] + prog[3] * this.niveauExp;
            total2[4] = deBase[4] + prog[4]*this.niveauExp;
            actuel= total = total2;
        }

        // Fonction qui ramene les stats actuel au stats total
        public void renew_caract()
        {
            actuel[0] = total[0];
            actuel[1] = total[1];
            actuel[2] = total[2];
            actuel[3] = total[3];
            actuel[4] = total[4];
        }

        // Enregistrer une liste de Monstre en XML
        public static void Enregistrer_Liste_Monstre(Monstre[] liste)
        {
            XmlSerializer format = new XmlSerializer(typeof(Monstre[]));
            using (Stream stream = new FileStream(@".\liste_monstres.xml", FileMode.Create, FileAccess.Write, FileShare.None)) format.Serialize(stream, liste);
        }

        // Charger une liste de Monstre en XML
        public static Monstre[] Charger_Liste_Monstre()
        {
            Monstre[] nouveau;
            XmlSerializer format = new XmlSerializer(typeof(Monstre[]));
            using (Stream stream = new FileStream(@"liste_monstres.xml", FileMode.Open, FileAccess.Read, FileShare.None)) nouveau = (Monstre[])format.Deserialize(stream);
            return nouveau;
        }

        //Retour une liste de monstre d'un element donnée
        public static Monstre[] Liste_par_Element(TypeElement element)
        {
            Monstre[] liste_general = Monstre.Charger_Liste_Monstre();
            Monstre[] liste_element = new Monstre[5];
            int loop = 0;
            foreach (Monstre x in liste_general)
            {
                if(x!=null && x.typeMonstre == element)
                {
                    liste_element[loop] = x;
                    loop++;
                }
            }
            return liste_element;
        }

        // Ajout de l'experience et modification relié
        public string add_xp(int xp_add, Aventure parti)
        {
            if (niveauExp < 5)  //Si le pokémon n'a pas atteint le level maximal
            {
                int reference = parti.joueur.trouver_monstre_listeCapture(this); //------> permet de trouver l'index du pokémon qui recoit l'xp
                this.pointExp = this.pointExp + xp_add;
                parti.joueur.monstreCapture[reference].pointExp = this.pointExp;
                int x = this.pointExp;
                if (x == 150 || x == 250 || x == 400 || x == 600) // Si le pokémon a assez XP pour passer au level 2, 3, 4 ou 5
                {
                    this.niveauExp++;
                    this.calcul_caract(); 
                    parti.joueur.monstreCapture[reference].calcul_caract();// Calculation des nouvelles caractéristiques

                    // Ajout d'une habilete
                    Habilete[] liste_possible = Habilete.Charger_Liste_Habilete_Element(typeMonstre);


                    // Assigner l'habileter
                    listeHabilete[niveauExp - 1] = liste_possible[niveauExp - 1];

                    return "\n" + nomMonstre + " a passé au level " + niveauExp + " et \na appris l'habilete " + liste_possible[niveauExp - 1].nom;

                }
                return "\nAjout de " + xp_add + " point d'exp. !";
            }
            else
            {
                return "\n" + nomMonstre + " est déja au level maximum !";
            }
        }

        //Retourne le portrait du monstre
        public static BitmapImage portrait(string nom)
        {
            Image image_final = new Image();
            string path = "Images/" + nom + ".png";
            BitmapImage image_tmp = new BitmapImage(new Uri(path, UriKind.Relative));
            return image_tmp;
        }

        //Retourne un monstre de la liste complete
        public static Monstre trouver_monstre(string nom)
        {
            Monstre[] liste = Charger_Liste_Monstre();
            Monstre reponse = new Monstre();
            int loop;
            for(loop=0;loop<20;loop++)
            {
                if(liste[loop]!=null && liste[loop].nomMonstre==nom)
                {
                    reponse = liste[loop];
                }
            }
            return reponse;
        }

        //Compare 2 Pokemon, cette fonction est utilisé dans les fonctions de combat ( Attaque() )
        public static bool estIdentique(Monstre monstre1, Monstre monstre2)
        {
            bool comparaison = false;
            if(monstre1.pointExp == monstre2.pointExp && monstre1.nomMonstre == monstre2.nomMonstre)  // Je compare simplement les points d'exp (et le nom) car durant la génération d'un pokemon aleatoire, j'ajoute 1 point d'exp.
            {
                comparaison = true;
            }
            return comparaison;
        }

        //Retourne une habilete trouvé par le nom dans la liste d'habilete 
        public Habilete trouver_habilete(string nom)
        {
            foreach(Habilete x in listeHabilete)
            {
                if (x !=null && x.nom == nom)
                {
                    return x;
                }
            }
            return null;
        }

        //Retourne un nombre randomn (Interface IRandom)
        public int getRandomChiffre(int minimum, int maximum)
        {
            Random rand = new Random();
            int rarete_1 = rand.Next(minimum, maximum);
            return rarete_1;
        }
    }
}
