using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_Pokemon
{
    [Serializable, XmlRoot(Namespace = "Monstre")]
    class Joueur
    {
        public string nomJoueur;
        //public string deviseArgent; --> Sera afficher par l'interface
        public double argent;
        Inventaire inventaire;
        Monstre monstreDepart;
        Monstre[] monstreCapture;
        Monstre[] equipe;

        //constructeur par defaut
        public Joueur(string nom, Monstre monstre_dep )
        {
            nomJoueur = nom;
            argent =100.00;
            //inventaire = ?
        }
    }
}
