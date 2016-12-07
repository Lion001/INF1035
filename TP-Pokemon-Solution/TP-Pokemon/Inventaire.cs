using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pokemon
{
    [Serializable]
    public class Inventaire 
    {
        public int pokeball { get; set; }
        public int potion_vie { get; set; }
        public int potion_mana { get; set; }
        public int potion_max { get; set; }

        public Inventaire(int pokeball, int potion_vie, int potion_mana, int potion_max)
        {
            this.pokeball = pokeball;
            this.potion_vie = potion_vie;
            this.potion_mana = potion_mana;
            this.potion_max = potion_max;
        }
    }
}
