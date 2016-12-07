using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_Pokemon
{

    [Serializable]
    public class Item : Habilete
    {
        public int valeur_monetaire;

        public Item() { }

        public Item (string nom, string description, int cout, TypeElement element, Cible cible, Effet effet,int magnitude, int duree, int valeur)
            :base(nom,description,cout,element,cible,effet,magnitude,duree)
        {
            valeur_monetaire = valeur;
        }

        // Enregistrer un item en XML
        public static void Enregistrer_Item(Item item, string path)
        {
            XmlSerializer format = new XmlSerializer(typeof(Item));
            using (Stream stream = new FileStream(@path, FileMode.Create, FileAccess.Write, FileShare.None)) format.Serialize(stream, item);
        }

        // Charger un item en XML
        public static Item Charger_Item(string path)
        {
            Item nouveau;
            XmlSerializer format = new XmlSerializer(typeof(Item));
            using (Stream stream = new FileStream(@path, FileMode.Open, FileAccess.Read, FileShare.None)) nouveau = (Item)format.Deserialize(stream);
            return nouveau;
        }
    }
}
