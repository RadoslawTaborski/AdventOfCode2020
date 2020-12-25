using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Days.Day24
{
    public class Tile
    {
        public Coordinates Coords { get; private set; }

        public Tile(Coordinates coordinates)
        {
            Coords = coordinates;
        }

        public Dictionary<string, Tile> Neighbors { get; private set; } = new Dictionary<string, Tile>();
        public Color TopColor { get; private set; } = Color.White;

        public bool SetNeighbor(string direction, Tile cell)
        {
            if (!Neighbors.ContainsKey(direction))
            {
                Neighbors.Add(direction, cell);
                cell.SetNeighbor(Directions.Oposition[direction], this);
                return true;
            }
            return false;
        }

        public void Flipe()
        {
            TopColor = TopColor.GetOposite();
        }

        public override string ToString()
        {
            return $"({Coords}) - {TopColor}";
        }
    }
}