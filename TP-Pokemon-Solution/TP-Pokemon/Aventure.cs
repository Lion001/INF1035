using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
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
    }
}
