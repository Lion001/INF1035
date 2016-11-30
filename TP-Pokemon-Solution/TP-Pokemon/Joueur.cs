using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    class Joueur
    {
        public string nomJoueur;
        public string deviseArgent;
        public double argent;
        Boutique inventaire;
        Monstre monstreDepart;
        List<Monstre> monstreCapture;
        List<Monstre> equipe;

        //constructeur par defaut
        public Joueur()
        {
            nomJoueur = "rémi";
            deviseArgent = "dollars";
            argent = 100;
            //inventaire = 
        }
    }
}
