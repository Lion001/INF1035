using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_Pokemon
{
    [Serializable, XmlRoot(Namespace = "Monstre")]
    public class Joueur
    {
        public string nomJoueur;
        //public string deviseArgent; --> Sera afficher par l'interface
        public double argent;
        public Inventaire inventaire;
        public Monstre monstreDepart;
        public Monstre[] monstreCapture;
        public Monstre[] equipe;

        //constructeur par defaut
        public Joueur(string nom, Monstre monstre_dep )
        {
            nomJoueur = nom;
            argent =100.00;
            monstreDepart = monstre_dep;
            monstreCapture = new Monstre[25];
            equipe = new Monstre[5];
            equipe[0] = monstreDepart;
            //Inventaire
        }
    }
}
