using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    //elle permet de gerer à la fois l'inventaire du joueur et celui de la boutique
    [Serializable]
    class Inventaire
    {
        public List<Item> listeItem;

        //constructeur
        public Inventaire()
        {
            this.listeItem = new List<Item>();
        }

        //afficher tous les items de l'inventaire selon qu'ils soient du joueur ou de la boutique
        public void afficherItem()
        {
            foreach (Item item in listeItem)
            {
                Console.WriteLine(item);
            }
        }

        //ajouter des items dans l'inventaire du joueur
        public void ajoutItem()
        {

        }

        //supprimer des items dans l'inventaire du joueur
        public void supprimertItem()
        {

        }

        //augmenter la quantité des items dans l'inventaire du joueur et celui de la boutique
        public void augmenterItem()
        {

        }

        //diminuer la quantité des items dans l'inventaire du joueur et celui de la boutique
        public void diminuerItem()
        {

        }

        //rechercher un item dans la liste des items disponibles
        public Item rechercheItem(string nomChercher)
        {
            Item itemRechercher = null;
            foreach (Item item in listeItem)
            {
                if (String.Compare(item.nomItem, nomChercher) == 0)
                {
                    itemRechercher = item;
                }
            }
            return itemRechercher;
        }
    }
}
