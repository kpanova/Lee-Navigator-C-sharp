using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorNaumen
{


    public class Navigator : INavigator
    {

        List<Point> list = new List<Point>();
        List<Point> finalList = new List<Point>();

        int[,] WeightMap = new int[,]
        {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}
        };
        int rows;
        int columns;

        public char[,] searchRoute(char[,] map)
        {
            WeightMap = ResizeWeightMap(map);
            int weight = 0;
            rows = map.GetLength(0) - 1;
            columns = map.GetLength(1) - 1;
            for (int i = rows; i >= 0; i--)
            {
                for (int j = 0; j <= columns; j++)
                {
                    if (IsFinish(i, j, map))
                    {
                        list.Add(new Point(j, i, weight));
                        list.First().IsFinish();
                        GetWeight(list[0].x, list[0].y, list[0].weight, map);
                        WeightMap[list[0].y, list[0].x] = list[0].weight;
                        break;
                    }
                }
            }

            for (int i = 1; ; i++)
            {
                try
                {
                    weight = GetWeight(list[i].x, list[i].y, list[i].weight, map);
                    if (weight == -2)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            }
            return FindBacktrace(map);
        }

        int[,] ResizeWeightMap(char[,] map)
        {
            int[,] newMap;
            if (map.Length > WeightMap.Length) 
            {
                newMap = new int[map.GetLength(0), map.GetLength(1)];
                for (int i = 0; i < newMap.GetLength(0); i++)
                {
                    for (int j = 0; j < newMap.GetLength(1); j++)
                    {
                        newMap[i, j] = 0;
                    }
                }
                return newMap;
            }
            return WeightMap;
        }

        char[,] FindBacktrace(char[,] map)
        {
            int weight = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (IsStart(list[i].y, list[i].x, map))
                {
                    finalList.Add(list[i]);
                    weight = list[i].weight - 1;
                }
                else if (IsFinish(list[i].y, list[i].x, map))
                {
                    finalList.Add(list[i]);
                    break;
                }
                else if (list[i].weight == weight && Math.Abs((finalList.Last().y - list[i].y)) <= 1 && Math.Abs((finalList.Last().x - list[i].x)) <= 1)
                {
                    finalList.Add(list[i]);
                    map[list[i].y, list[i].x] = '+';
                    weight--;
                }
            }
            return map;
        }
        int GetWeight(int x, int y, int weight, char[,] map)
        {
            int newWeight = 0;
            newWeight = weight + 1;
            int up = y - 1;
            int left = x - 1;
            int down = y + 1;
            int right = x + 1;

            if (GetPoint(x, up, newWeight, map) == -2)
            {
                return -2;
            }
            if (GetPoint(left, y, newWeight, map) == -2)
            {
                return -2;
            }
            if (GetPoint(x, down, newWeight, map) == -2)
            {
                return -2;
            }
            if (GetPoint(right, y, newWeight, map) == -2)
            {
                return -2;
            }

            return newWeight;
        }

        int GetPoint(int x, int y, int newWeight, char[,] map)
        {
            if (IsExist(y, x, map) && GetWeight(y, x) == 0 && !IsFinish(y, x, map))
            {
                if (IsWall(y, x, map))
                {
                    WeightMap[y, x] = -1;
                    return newWeight;
                }
                else
                {
                    list.Add(new Point(x, y, newWeight));
                    WeightMap[y, x] = newWeight;
                    if (IsStart(y, x, map))
                    {
                        list.Last().IsStart();
                        return -2;
                    }
                    return newWeight;
                }
            }
            return newWeight;
        }

        bool IsWall(int i, int j, char[,] map)
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
        bool IsExist(int i, int j, char[,] map)
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
        bool IsFinish(int i, int j, char[,] map)
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
        bool IsStart(int i, int j, char[,] map)
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
        int GetWeight(int i, int j)
        {
            return WeightMap[i, j];
        }


    }
}