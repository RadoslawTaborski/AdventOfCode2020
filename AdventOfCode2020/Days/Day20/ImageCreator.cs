using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class ImageCreator
    {
        public static Image Create(Dictionary<int, List<TileOrientation>> posibilities, Dictionary<int, Tile> tiles)
        {
            var start = GetStartTileId(posibilities);

            var tilesMatrix = Create2DimArray(start, posibilities, tiles);

            return CreateImage(tilesMatrix, tiles);
        }

        private static List<List<TileOrientation>> Create2DimArray(int start, Dictionary<int, List<TileOrientation>> posibilities, Dictionary<int, Tile> tiles)
        {
            var tilesMatrix = new List<List<TileOrientation>>
            {
                new List<TileOrientation> { new TileOrientation(start, Direction.Up, Rotation._0, false) }
            };

            Create2DimArrayTemplate(start, posibilities, tilesMatrix, tiles);

            Fill2DimArray(posibilities, tilesMatrix, tiles);

            return tilesMatrix;
        }

        private static void Fill2DimArray(Dictionary<int, List<TileOrientation>> posibilities, List<List<TileOrientation>> tilesMatrix, Dictionary<int, Tile> tiles)
        {
            for (var i = 0; i < tilesMatrix.Count; ++i)
            {
                var collection = GetValues(tilesMatrix[i][0], Direction.Right, posibilities, tiles);
                var value = collection.First();
                while (true)
                {
                    tilesMatrix[i].Add(value);
                    collection = GetValues(value, Direction.Right, posibilities, tiles);
                    if (collection.Count == 0)
                    {
                        break;
                    }
                    value = collection.First();
                }
            }
        }

        private static void Create2DimArrayTemplate(int start, Dictionary<int, List<TileOrientation>> posibilities, List<List<TileOrientation>> tilesMatrix, Dictionary<int, Tile> tiles)
        {
            var collection = posibilities[start];
            collection = collection.Where(x => x.Direction == Direction.Down).ToList();
            if (collection.Count > 1)
            {
                collection.ForEach(x => Console.WriteLine(x.Direction + "" + x.Id));
            }
            var value = collection.First();
            while (true)
            {
                tilesMatrix.Add(new List<TileOrientation> { value });
                collection = GetValues(value, Direction.Down, posibilities, tiles);
                if (collection.Count == 0)
                {
                    break;
                }
                value = collection.First();

            }
        }

        private static Image CreateImage(List<List<TileOrientation>> tilesMatrix, Dictionary<int, Tile> tiles)
        {
            var result = new Image();
            foreach (var dim1 in tilesMatrix)
            {
                var tileRow = new TilesRow();
                foreach (var dim2 in dim1)
                {
                    var tile = tiles[dim2.Id].SetTile(dim2);
                    tileRow.Add(tile);
                }

                result.Add(tileRow);
            }
            return result;
        }

        private static List<TileOrientation> GetValues(TileOrientation baseTile, Direction direction, Dictionary<int, List<TileOrientation>> possibilities, Dictionary<int, Tile> tiles)
        {
            var values = possibilities[baseTile.Id];
            var newPossibilities = new List<TileOrientation>();
            var tile = tiles[baseTile.Id];
            tile = tile.SetTile(baseTile);
            foreach (var inp in values)
            {
                newPossibilities.AddRange(tile.TileMatch(tiles[inp.Id]));
            }
            newPossibilities = newPossibilities.Where(x => x.Direction == direction).ToList();

            if (newPossibilities.Count > 1)
            {
                newPossibilities.ForEach(x => Console.WriteLine(x.Direction + "" + x.Id));
            }

            return newPossibilities;
        }

        private static int GetStartTileId(Dictionary<int, List<TileOrientation>> posibilities)
        {
            var corners = new List<int>();
            foreach (var inp in posibilities)
            {
                var set = new HashSet<Direction>();
                foreach (var inp2 in inp.Value)
                {
                    switch (inp2.Direction)
                    {
                        case Direction.Up:
                            set.Add(Direction.Up);
                            break;
                        case Direction.Right:
                            set.Add(Direction.Right);
                            break;
                        case Direction.Down:
                            set.Add(Direction.Down);
                            break;
                        case Direction.Left:
                            set.Add(Direction.Left);
                            break;
                    }
                }
                if (!set.Contains(Direction.Left) && !set.Contains(Direction.Up))
                {
                    return inp.Key;
                }
            }

            return -1;
        }
    }
}
