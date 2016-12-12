using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_Pokemon
{
    public class NoPokemonException : Exception
    {

        public NoPokemonException()
            :base("Veuillez choisir un pokémon de départ ! ")
        { }

        public void DisplayError()
        {
            MessageBox.Show(base.Message);
        }
    }
}
