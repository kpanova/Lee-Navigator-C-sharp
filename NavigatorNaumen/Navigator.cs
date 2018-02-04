using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorNaumen
{


    public class Navigator : INavigator
    {
        /* int rows;
         int columns;
         char[,] map;
         public char[,] searchRoute(char[,] map)
         {
             this.map = map;
             //string[,] newMap = new string[map.GetLength(0), ((char[])map.GetValue(0)).Length];
             Point finishPoint;
             Point startPoint;
             List<Point> points = new List<Point>();
             rows = map.GetLength(0)-1;
             columns = ((char[])map.GetValue(0)).Length - 1;
             Point point = new Point(map[rows, columns], rows, columns);
             point.SetNeighborPoints(Points.Up, new Point(map[rows--, columns], rows--, columns, point, Points.Down));
             point.SetNeighborPoints(Points.Left, new Point(map[rows, columns--], rows--, columns, point, Points.Right));
             if (States.IsFinish(point.GetState()))
             {
                 finishPoint = point;
             }
             /*for (int i = rows; i >= 0; i--)
             {
                 for (int j = columns; j >= 0; j--)
                 {
                     Point point = new Point(map[i, j], i, j);
                     if (States.IsFinish(point.GetState()))
                     {
                         points.Add(point);
                         continue;
                     }
                 }

                 if (true)
                 {
                     return null;
                 }
                 else { return null; }
             }
             return null;
         }
         void Recurs(ref Point point)
         {
            //point.SetNeighborPoints(Points.Up, Recurs(new Point(map[rows--, columns], rows--, columns, point, Points.Down)));
         }
     }*/
        public char[,] searchRoute(char[,] map)
        {
            throw new NotImplementedException();
        }
    }
}