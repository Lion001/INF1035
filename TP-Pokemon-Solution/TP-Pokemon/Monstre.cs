using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace TP_Pokemon
{
    /// <summary>
    /// un enum pour la rareté, un pour la santé, pour l'energie, pour la force, pour monsterShield 
    /// </summary>

    [Serializable, XmlRoot(Namespace="Habilete")]
    public class Monstre
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
            this.rarete = hasard();
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

        //Fonction qui genere automatiquement la rarete du pokemon
        public int hasard()
        {
            Random rand = new Random();
            int rarete_1 = rand.Next(0, 101);

            return rarete_1;
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
        public void add_xp(int xp_add)
        {
            this.pointExp += xp_add;
            int x = this.pointExp;
            if (x==150||x==250||x==400||x==600||x==850||x==1150)
            {
                this.niveauExp++;
                this.calcul_caract();
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

        //Retourne l'index du monstre de la liste de monstres capturé d'un joueur donné
        public static int trouver_monstre_equipe(Monstre monstre,Joueur joueur)
        {
            int loop = 0;
            Monstre[] liste = joueur.equipe;

            while (liste[loop]!=monstre)
            {
                loop++;
            }

            return loop;
        }
    }
}
