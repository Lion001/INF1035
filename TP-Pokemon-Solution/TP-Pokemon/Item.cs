using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    class Item
    {

        public string nomItem { get; set;}
        public string descripItem { get; set;}
        public TypeElement typeElementItem { get; set;}
        public float valeurItem { get; set;}
        public float coutEnergieItem { get; set;}
        public int quantite { get; set;}


        //Constructeur par defaut
        public Item()
        {
            nomItem = "pogo";
            descripItem = "c'est grand";
            typeElementItem = TypeElement.Electricite;
            valeurItem = 20;
            coutEnergieItem = 15;
            quantite = 1;
        }

        //constructeur
        public Item(string nomItem, string descripItem, TypeElement typeElementItem, float valeurItem, float coutEnergieItem, int quantite)
        {
            this.nomItem = nomItem;
            this.descripItem = descripItem;
            this.typeElementItem = typeElementItem;
            this.valeurItem = valeurItem;
            this.coutEnergieItem = coutEnergieItem;
            this.quantite = quantite;
        }

    }
}
