using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public caracteristique deBase, progression, total, actuel;
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
            //-- Caracteristique ---
            deBase = new caracteristique();
            progression = new caracteristique();
            total = calcul_caract(deBase, progression);
            actuel = total;  // Actuel sera modifier au cours des combats
            //-----------------------
            etat_actuel= etat_actif.Vivant;
            listeHabilete = new Habilete[6]; // Cette liste contiendra seulement 5 habilete possible mais j'ai créer un tableau plus gros au cas ou
            listeHabileteActive = new Habilete[2]; // Cette liste contiendra seulement 2 habilete possible mais ^
            this.nom_Image = nom_Image;
    
        }
       
        public int hasard()
        {
            Random rand = new Random();
            int rarete_1 = rand.Next(0, 101);

            return rarete_1;
        }

        // Fonction qui calcul les caractèristiques totales (Total = Base + prog*lvl)
        public caracteristique calcul_caract(caracteristique deBase, caracteristique prog)
        {
            caracteristique total = new caracteristique();
            total.point_vie = deBase.point_vie + prog.point_vie * this.niveauExp;
            total.point_energie = deBase.point_energie + prog.point_energie * this.niveauExp;
            total.regen_energie = deBase.regen_energie + prog.regen_energie * this.niveauExp;
            total.attaque = deBase.attaque + prog.attaque * this.niveauExp;
            total.defense = deBase.defense + prog.defense*this.niveauExp;
            return total;
        }

        //le but est de prendre les informations sur le fichier xml pour le remplir 
        /** Gab:  Je pense que tu veux charger un pokemon garder en mémoir si je comprend bien ? On devrait plutot charger un array de pokemon dans ce cas-ci car l'utilisateur va vouloir
          sauvegarder tout son équipe. Voir les fonctions plus bas  **/
        public Monstre(string id, string nomMonstre, string descripMonstre, string aliasMonstre)
        {

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



    }
}
