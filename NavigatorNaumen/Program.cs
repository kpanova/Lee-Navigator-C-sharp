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
        static char[,] map = new char[,]
       {
                {'#', '.', '.', '.','.'},
                {'.', '#', '.', '#','.'},
                {'#', '#', '.', '.','.'},
                {'#', '#', '.', '#','#'},
                {'.', '.', '.', '.','.'},
                {'.', 'X', '.', '.','@'}
        };
        static int[,] intMap = new int[,]
        {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
        };
        static int rows;
        static int columns;

        /*static Point startPoint;
        static Point finishPoint;*/

        static void Main(string[] args)
        {
            int weight = 0;
            rows = map.GetLength(0) - 1;
            columns = map.GetLength(1) - 1;
            for (int i = rows; i >= 0; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (IsFinish(i, j))
                    {
                        list.Add(new Point(j, i, weight));
                        list.First().IsFinish();
                        GetWeight(list[0].x, list[0].y, list[0].weight);
                        intMap[list[0].y, list[0].x] = list[0].weight;
                        Write(intMap);
                        break;
                    }
                }
            }

            for(int i = 1; ; i++)
            {
                try
                {
                    weight = GetWeight(list[i].x, list[i].y, list[i].weight);
                    Write(intMap);
                    if (weight == -2)
                    {
                        Write(intMap);
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }

            Write(intMap);
        }
        static int GetWeight(int x, int y, int weight)
        {
            int newWeight = 0;
            newWeight = weight + 1;
            int up = y - 1;
            int left = x - 1;
            int down = y + 1;
            int right = x + 1;
            if (IsExist(up, x) && GetWeight(up, x) == 0 && !IsFinish(up, x))
            {
                if (IsWall(up, x))
                {
                    intMap[up, x] = -1;
                }
                else
                {
                    list.Add(new Point(x, up, newWeight));
                    intMap[up, x] = newWeight;
                    if (IsStart(up, x))
                    {
                        list.Last().IsStart();
                        return -2;
                    }
                }
            }
            if (IsExist(y, left) && GetWeight(y, left) == 0 && !IsFinish(y, left))
            {
                if (IsWall(y, left))
                {
                    intMap[y, left] = -1;
                }
                else
                {
                    list.Add(new Point(left, y, newWeight));
                    intMap[y, left] = newWeight;
                    if (IsStart(y, left))
                    {
                        list.Last().IsStart();
                        return -2;
                    }
                }
            }
            if (IsExist(down, x) && GetWeight(down, x) == 0 && !IsFinish(down, x))
            {
                if (IsWall(down, x))
                {
                    intMap[down, x] = -1;
                }
                else
                {
                    list.Add(new Point(x, down, newWeight));
                    intMap[down, x] = newWeight;
                    if (IsStart(down, x))
                    {
                        list.Last().IsStart();
                        return -2;
                    }
                }
            }
            if (IsExist(y, right) && GetWeight(y, right) == 0 && !IsFinish(y, right))
            {
                if (IsWall(y, right))
                {
                    intMap[y, right] = -1;
                }
                else
                {
                    list.Add(new Point(right, y, newWeight));
                    intMap[y, right] = newWeight;
                    if (IsStart(y, right))
                    {
                        list.Last().IsStart();
                        return -2;
                    }
                }
            }
            return newWeight;
        }

        
        static bool IsWall(int i, int j)
        {
            if (map[i, j] == '#')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool IsExist(int i, int j)
        {
            try
            {
                var m = map[i, j];
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        static bool IsFinish(int i, int j)
        {
            if (map[i, j] == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool IsStart(int i, int j)
        {
            if (map[i, j] == '@')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int GetWeight(int i, int j)
        {
            return intMap[i, j];
        }
        
        static void Write(int[,] map)
        {
            Console.WriteLine("");
            string s = "";
            string s2 = "";
            for (int i = 0; i <= rows; i++)
            {
                s = "";
                s2 = "";
                for (int j = 0; j <= columns; j++)
                {
                    s += map[i, j]+"\t"+"|";
                    s2 += "_" + "\t" + "|";
                }
                Console.WriteLine(s);
                Console.WriteLine(s2);
            }
        }
    }
}
