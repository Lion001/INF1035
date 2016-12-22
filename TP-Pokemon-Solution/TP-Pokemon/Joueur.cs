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
            argent =500.00;
            monstreDepart = monstre_dep;
            monstreCapture = new Monstre[25];
            equipe = new Monstre[5];
            equipe[0] = monstreDepart;
            inventaire = new Inventaire(3, 0, 0, 0); // Inventaire par défaut 3 pokeballs, 0 potions
        }

        //Ajoute un pokemon la liste des pokemons captures
        public void Ajouter_Pokemon_listeTotal(Monstre monstre)
        {
            int x = 0;
            while(monstreCapture[x] != null )
            {
                x++;
            }
            monstreCapture[x] = monstre;
        }

        //Retourne l'index du monstre de la liste de monstres actif d'un joueur donné
        public int trouver_monstre_equipe(Monstre monstre)
        {
            int loop = 0;
            Monstre[] liste = equipe;

            foreach (Monstre x in liste)
            {
                if (x != null && Monstre.estIdentique(x, monstre))
                {
                    return loop;
                }
                loop++;
            }

            return loop;
        }

        //Retourne l'index du monstre de la liste de monstres capturé d'un joueur donné
        public int trouver_monstre_listeCapture(Monstre monstre)
        {
            int loop = 0;
            Monstre[] liste = monstreCapture;

            foreach (Monstre x in liste)
            {
                if(x!=null && Monstre.estIdentique(x,monstre))
                {
                    return loop;
                }
                loop++;
            }


            return loop;
        }

        //Retourne un monstre parmi la liste des monstres capturés (search by name)
        public Monstre trouver_monstre_parNom(string nom)
        {
            Monstre monstre = null;
            foreach(Monstre x in monstreCapture)
            {
                if (x!=null && x.nomMonstre == nom)
                {
                    monstre = x;
                }
            }
            return monstre;
        }
    }
}
