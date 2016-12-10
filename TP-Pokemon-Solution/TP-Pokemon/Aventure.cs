using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    [Serializable]
    public class Aventure
    {
        public Joueur joueur;
        Habilete[] liste_habilete;
        Monstre[] liste_monstre;

        public Aventure(Joueur joueur)
        {
            this.joueur = joueur;
            liste_habilete = Habilete.Charger_Liste_Habilete();
            liste_monstre = Monstre.Charger_Liste_Monstre();
        }

        public void acheter_pokeball(int nombre)
        {
            joueur.inventaire.pokeball+=nombre;
            joueur.argent = joueur.argent - (100*nombre);
        }

        public void acheter_potion(int potion_vie, int potion_mana, int potion_max)
        {
            if (potion_vie > 0)
            {
                joueur.inventaire.potion_vie += potion_vie;
                joueur.argent = joueur.argent - (200 * potion_vie);
            }
            if (potion_mana > 0)
            {
                joueur.inventaire.potion_mana += potion_mana;
                joueur.argent = joueur.argent- (200 * potion_mana);
            }
            if (potion_max > 0)
            {
                joueur.inventaire.potion_max += potion_max;
                joueur.argent = joueur.argent- (500 * potion_max);
            }
        }

        public static void Sauvegarder_Aventure(Aventure aventure)
        {
            BinaryFormatter format = new BinaryFormatter();
            using (Stream stream = new FileStream(@".\aventure.ply",FileMode.Create, FileAccess.Write, FileShare.None)) format.Serialize(stream, aventure);
        }

        public static Aventure Charger_Aventure()
        {
            Aventure aventure;
            BinaryFormatter format = new BinaryFormatter();
            using (Stream stream = new FileStream(@".\aventure.ply", FileMode.Open, FileAccess.Read, FileShare.None)) aventure = (Aventure)format.Deserialize(stream);
            return aventure;
        }
    }
}
