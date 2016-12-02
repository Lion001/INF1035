using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_Pokemon
{
    public enum TypeElement
    {
        Feu,
        Vegetation,
        Eau,
        Electricite
    }

    public enum Cible
    {
        soi,
        ennemi
    }

    public enum Effet
    {
        degat,
        guerison,
        regeneration,
        sommeil,
        paralysie,
        force,
        faiblesse
    }
    [Serializable]
   public class Habilete
    {
        //Initialisation des variables
        public string nom { get; set; }
        public string description { get; set; }
        public int cout { get; set; }
        public TypeElement element { get; set; }
        public Cible cible { get; set; }
        public Effet effet { get; set; }
        public int magnitude { get; set; }
        public int duree { get; set; }

        public Habilete() { }
        //Constructeur
        public Habilete (string nom, string description, int cout, TypeElement element, Cible cible, Effet effet, int magnitude, int duree)
        {
            this.nom = nom;
            this.description = description;
            this.cout = cout;
            this.element = element;
            this.cible = cible;
            this.effet = effet;
            this.magnitude = magnitude;
            this.duree = duree;
        }

        // Enregistrer une liste d'habilete en XML
        public static void Enregistrer_Liste_Habilete(Habilete[] liste)
        {
            XmlSerializer format = new XmlSerializer(typeof(Habilete[]));
            using (Stream stream = new FileStream(@".\liste_habilete.xml", FileMode.Create, FileAccess.Write, FileShare.None))format.Serialize(stream, liste) ;

        }

        // Charger une liste d'habilete en XML
        public static Habilete[] Charger_Liste_Habilete()
        {
            Habilete[] nouveau;

            XmlSerializer format = new XmlSerializer(typeof(Habilete[]));
            using (Stream stream = new FileStream(@"liste_habilete.xml", FileMode.Open, FileAccess.Read, FileShare.None)) nouveau = (Habilete[])format.Deserialize(stream);
            return nouveau;
        }

        // Charger une liste d'habilete du même element 
        public static Habilete[] Charger_Liste_Habilete_Element(TypeElement element)
        {
            Habilete[] nouveau = new Habilete[5];
            Habilete[] liste_com = Charger_Liste_Habilete();
            int loop = 0;
            foreach (Habilete x in liste_com )
            {
                if (x != null)
                {
                    if (x.element == element)
                    {
                        nouveau[loop] = x;
                        loop++;
                    }
                }
            }
            return nouveau;
        }
    }
}