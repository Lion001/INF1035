using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    /// <summary>
    /// un enum pour la rareté, un pour la santé, pour l'energie, pour la force, pour monsterShield 
    /// </summary>

    class Monstre
    {
        public string id { get; set;}
        public string nomMonstre { get; set;}
        public string descripMonstre { get; set;}
        public string aliasMonstre { get; set;}
        public TypeElement typeMonstre { get; set;}
        //public byte rarete;
        public int rarete { get; set;}
        public int niveauExp { get; set;}
        public int pointExp { get; set;}
        List<Habilete> listeHabilete { get; set; }
        List<Habilete> listeHabileteActive { get; set; }


        public int hasard()
        {
            Random rand = new Random();
            int rarete = rand.Next(0, 101);

            return rarete;
        }

        //constructeur par defaut
        public Monstre()
        {
            id = "001M";
            nomMonstre = "piton";
            descripMonstre = "il est fort";
            aliasMonstre = "le roi";
            typeMonstre = TypeElement.Eau;
            rarete = hasard();
            niveauExp = 3;
            pointExp = 360;

        }

        //constructeur
        public Monstre(string id, string nomMonstre, string descripMonstre, string aliasMonstre, TypeElement typeMonstre)
        {
            this.id = id;
            this.nomMonstre = nomMonstre;
            this.descripMonstre = descripMonstre;
            this.aliasMonstre = aliasMonstre;
            this.typeMonstre = typeMonstre;
            this.rarete = hasard();
            this.niveauExp = 1;//valeur par defaut
            this.pointExp = 100;//valeur par defaut

        }

        //le but est de prendre les informations sur le fichier xml pour le remplir
        public Monstre(string id, string nomMonstre, string descripMonstre, string aliasMonstre)
        {

        }




    }
}
