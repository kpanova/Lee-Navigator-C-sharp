using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorNaumen
{
    
    class Program
    {
        static List<Point> list = new List<Point>();
        static List<Point> finalList = new List<Point>();
        static INavigator navigator = new Navigator();
        static char[,] map = new char[,]
       {
                {'.', '.', '.', '.','.'},
                {'#', '#', '.', '#','.'},
                {'@', '.', '.', '#','X'},
                {'.', '#', '.', '#','.'},
                {'.', '#', '.', '#','.'},
                {'.', '#', '.', '.','.'}
        };

        static void Main(string[] args)
        {           
            
            Write(navigator.searchRoute(map));
            Console.ReadKey();
        }
        
        static void Write(int[,] map)
        {
            Console.WriteLine("");
            string s = "";
            string s2 = "";
            for (int i = 0; i <= map.GetLength(0) - 1; i++)
            {
                s = "";
                s2 = "";
                for (int j = 0; j <= map.GetLength(1) - 1; j++)
                {
                    s += map[i, j]+"\t"+"|";
                    s2 += "_" + "\t" + "|";
                }
                Console.WriteLine(s);
                Console.WriteLine(s2);
            }
            
        }
        static void Write(char[,] map)
        {
            Console.WriteLine("");
            string s = "";
            string s2 = "";
            for (int i = 0; i <= map.GetLength(0) - 1; i++)
            {
                s = "";
                s2 = "";
                for (int j = 0; j <= map.GetLength(1) - 1; j++)
                {
                    s += map[i, j] + " ";
                    s2 += "_" + " ";
                }
                Console.WriteLine(s);
                //Console.WriteLine(s2);
            }
        }
    }
}
