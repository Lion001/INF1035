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
        Magma,
        Terre,
        Vegetation,
        Eau,
        Glace,
        Air,
        Electricite
    }

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
