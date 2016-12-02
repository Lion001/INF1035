using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{

    // Cette classe sera utilisé afin d'utiliser l'heritage avec la classe habilete. Par la suite, la classe pokeball 
    //  heritera de cette même classe. Le but est d'éviter la réécriture de code inutilement
    public class Item : Habilete
    {
        int valeur_monetaire;
        public Item (string nom, string description, int cout, TypeElement element, Cible cible, Effet effet,int magnitude, int duree, int valeur)
            :base(nom,description,cout,element,cible,effet,magnitude,duree)
        {
            valeur_monetaire = valeur;
        }
    }
}
