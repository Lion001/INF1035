using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TP_Pokemon
{
    
    public enum Sexe
    {
        homme,
        femme
    }
    [Serializable]
    public class Joueur
    {
        public string nomJoueur;
        public double argent;
        public Sexe sexe;
        public Inventaire inventaire;
        public Monstre monstreDepart;
        public Monstre[] monstreCapture;
        public Monstre[] equipe;

        //constructeur par defaut
        public Joueur(string nom,Sexe sexe, Monstre monstre_dep )
        {
            nomJoueur = nom;
            this.sexe = sexe;
            argent =100.00;
            monstreDepart = monstre_dep;
            monstreCapture = new Monstre[25];
            equipe = new Monstre[5];
            equipe[0] = monstreDepart;
            inventaire = new Inventaire(3, 0, 0, 0); // Inventaire par défaut 3 pokeballs, 0 potions
        }
    }
}
