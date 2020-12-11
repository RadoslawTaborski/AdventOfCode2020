using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day11
{
    public class Area : IEquatable<Area>
    {
        private Place[,] area;

        public Area(int y, int x)
        {
            this.area = new Place[y, x];
        }

        public void SetPlace(int y, int x, Place value)
        {
            this.area[y, x] = value;
        }

        public int GetRows()
        {
            return area.GetLength(0);
        }

        public int GetColumns()
        {
            return area.GetLength(1);
        }

        public Place? GetValue(int y, int x)
        {
            if (y >= GetRows() || x >= GetColumns() || y < 0 || x < 0)
            {
                return null;
            }
            return area[y, x];
        }

        public bool Equals(Area other)
        {
            for (var i = 0; i < GetRows() ; ++i)
            {
                for (var j = 0; j < GetColumns() ; ++j)
                {
                    if (this.GetValue(i, j) != other.GetValue(i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int GetNoOfOccupiedPlaces()
        {
            var result = 0;
            for (var i = 0; i < GetRows(); ++i)
            {
                for (var j = 0; j < GetColumns(); ++j)
                {
                    if (GetValue(i,j)==Place.Occupied)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (var i = 0; i < GetRows(); ++i)
            {
                for (var j = 0; j < GetColumns(); ++j)
                {
                    result.Append((char) GetValue(i, j));
                }
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
