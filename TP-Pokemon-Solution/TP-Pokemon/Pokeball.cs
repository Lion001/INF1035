using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    // Cette classe herite de la classe Item qui herite a son tour de la classe Habilete;
    public class Pokeball : Item
    {
        int chance_capture;

        public Pokeball(string nom, string description, int cout, TypeElement element, Cible cible, Effet effet, int magnitude, int duree, int valeur,int chance)
            :base(nom,description,cout,element,cible,effet,magnitude,duree,valeur)
        {
            chance_capture = chance; // Celle-ci pourrait être différente dépendement des types de pokeballs 
        }
    }
}
