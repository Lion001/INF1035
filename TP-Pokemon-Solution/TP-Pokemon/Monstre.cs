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

        public struct caracteristique
        {
            public int point_vie { get; set; }
            public int point_energie { get; set; }
            public int regen_energie { get; set; }
            public int attaque { get; set; }
            public int defense { get; set; }
        }


        public int id { get; set;}
        public string nomMonstre { get; set;}
        public string descripMonstre { get; set;}
        public string aliasMonstre { get; set;}
        public TypeElement typeMonstre { get; set;}
        public int rarete { get; set;}
        public int niveauExp { get; set;}
        public int pointExp { get; set;}
        public caracteristique deBase, prog, total, actuel;
        public etat_actif etat_actuel = new etat_actif();
        public Habilete[] listeHabilete { get; set; }
        public Habilete[] listeHabileteActive { get; set; }
        public Image nom_Image { get; set; }

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
            //-- Caracteristique ---
            deBase = new caracteristique();
            prog = new caracteristique();
            calcul_caract();
            actuel = total;  // Actuel sera modifier au cours des combats
            //-----------------------
            etat_actuel= etat_actif.Vivant;
            listeHabilete = new Habilete[6]; // Cette liste contiendra seulement 5 habilete possible mais j'ai créer un tableau plus gros au cas ou
            listeHabileteActive = new Habilete[2]; // Cette liste contiendra seulement 2 habilete possible mais ^
            this.nom_Image = Image.FromFile("");
    
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
            caracteristique total2 = new caracteristique();
            total2.point_vie = deBase.point_vie + prog.point_vie * this.niveauExp;
            total2.point_energie = deBase.point_energie + prog.point_energie * this.niveauExp;
            total2.regen_energie = deBase.regen_energie + prog.regen_energie * this.niveauExp;
            total2.attaque = deBase.attaque + prog.attaque * this.niveauExp;
            total2.defense = deBase.defense + prog.defense*this.niveauExp;
            total = total2;
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

        //Trouver un monstre dans la liste complete
        public static Monstre chercher_m(string nom)
        {
            Monstre[] liste = Charger_Liste_Monstre();
            foreach(Monstre x in liste)
            {
                if (x != null)
                {
                    if (x.nomMonstre == nom)
                    {
                        return x;
                    }
                }
            }
            return null;
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

        // Tableau contenant tout les Images
        public Image portrait_monstre(string nom)
        {
            Image portrait = new Image();
            string path = "/Images/" + nom + ".PNG";
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("plane.png", UriKind.Relative);
            bi.EndInit();
            portrait.Source = bi;
            return portrait;
        }
    }
}
