using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    //cette classe permet de prendre tous les items disponibles sur un xml et gerer les opérations d'achats
    class Boutique
    {
        //List<Item> listeItemDispo;
        Inventaire inventaire;

        //constructeur
        public Boutique(Inventaire inventaire)
        {
            this.inventaire = inventaire;
        }

        //afficher tous les items disponibles
        public void afficherItem()
        {
            foreach(Item item in this.inventaire.listeItem)
            {
                Console.WriteLine(item);
            }
        }
        
        //vendre un item de la liste
        //pour cela il faut verifier le prix
        //verifier la disponibilité
        public Item venteItem(String nomItem, int quantiteVendu)
        {
            Item itemAVendre = this.inventaire.rechercheItem(nomItem);


            return null;
        }

    }
}
