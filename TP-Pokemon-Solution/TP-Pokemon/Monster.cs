using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{

    enum TypeMonster
    {
        Feu,
        Vegetation,
        Eau,
        Electricite
    }
    /// <summary>
    /// un enum pour la rareté, un pour la santé, pour l'energie, pour la force, pour monsterShield 
    /// </summary>

    class Monster
    {
        public string id;
        public string nameMonster;
        public string descripMonster;
        public string nicknameMonster;
        public TypeMonster typeMonster;
        public int scarcity;
        public int levelExp;
        public int pointExp;


    }
}
