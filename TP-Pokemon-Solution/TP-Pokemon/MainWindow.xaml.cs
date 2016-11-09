using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_Pokemon
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Joueur
    {
        public string nom;


        public void addPlayer()
        {
            Console.WriteLine("c'est quoi ton nom?");

        }

        public void deletePlayer()
        {
            Console.Read();

        }

        public void modifyPlayer()
        {
            Console.Read();

        }
    }

    public class Monster
    {
        public string nameMonster;
        public string descripMonster;


        public void addMonster()
        {
            Console.WriteLine("c'est quoi le nom du monstre?");

        }

        public void deleteMonster()
        {
            Console.Read();

        }

        public void modifyMonster()
        {
            Console.Read();

        }
    }
}
