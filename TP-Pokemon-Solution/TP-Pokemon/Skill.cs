﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    enum TypeElement
    {
        Feu,
        Vegetation,
        Eau,
        Electricite
    }

    enum Cible
    {
        soi,
        ennemi
    }

    enum Effet
    {
        degat,
        guerison,
        regeneration,
        sommeil,
        paralysie,
        force,
        faiblesse
    }

    class Skill
    {
        //Initialisation des variables
        string nom, description;
        int cout;
        TypeElement element;
        Cible cible;
        Effet effet;
        int magnitude;
        int duree;
        
        //Constructeur
        public Skill (string nom, string description, int cout, TypeElement element, Cible cible, Effet effet, int magnitude, int duree)
        {
            this.nom = nom;
            this.description = description;
            this.cout = cout;
            this.element = element;
            this.cible = cible;
            this.effet = effet;
            this.magnitude = magnitude;
            this.duree = duree;
        }

        // Get - Set
        public string nom { get; set; }

        public string description { get; set; }
        
        public int cout { get; set; }
        
        public TypeElement element { get; set; }
        
        public Cible cible { get; set; }

        public Effet effet { get; set; }

        public int magnitude { get; set; }

        public int duree { get; set; }


    }
}