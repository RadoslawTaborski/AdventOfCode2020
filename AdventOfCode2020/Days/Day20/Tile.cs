using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days.Day20
{
    public class Tile
    {
        public int Id { get; init; }
        public List<List<char>> Pixels { get; private set; }
        private Rotation Rotation = Rotation._0;
        private bool flipped = false;
        public List<char> LeftColumn { get; private set; }
        public List<char> RightColumn { get; private set;  }
        public List<char> TopRow { get; private set; }
        public List<char> DownRow { get; private set; }

        public Tile(int id, List<List<char>> pixels)
        {
            Id = id;
            Pixels = pixels;

            SetLeftAndRight();
            TopRow = Pixels[0];
            DownRow = Pixels.Last();
        }

        private void SetLeftAndRight()
        {
            LeftColumn = new List<char>();
            RightColumn = new List<char>();
            foreach (var pixelrow in Pixels)
            {
                LeftColumn.Add(pixelrow[0]);
                RightColumn.Add(pixelrow[^1]);
            }
        }

        public Tile Rotate()
        {
            Pixels = Rotate(Pixels);
            Rotation = (Rotation + 1 % (int)Rotation._270);

            SetLeftAndRight();

            TopRow = Pixels[0];
            DownRow = Pixels.Last();

            return this;
        }

        public Tile Flippe()
        {
            Pixels.Reverse();
            this.flipped = !this.flipped;

            SetLeftAndRight();

            TopRow = Pixels[0];
            DownRow = Pixels.Last();

            return this;
        }

        private List<List<char>> Rotate(List<List<char>> pixels)
        {
            List<List<char>> ret = new List<List<char>>(pixels);
            for(var i=0; i < ret.Count; ++i)
            {
                ret[i] = new List<char>(pixels[i]);
            }

            for (var j = 0; j < pixels.Count; ++j)
            {
                for (int i = 0; i < pixels[0].Count; ++i)
                {
                    ret[i][ret[0].Count-j-1] = pixels[j][i];
                }
            }

            return ret;
        }

        public List<KeyValuePair<Directions, TileIdentifier>> TileMatch(Tile tile)
        {
            var result = new List<KeyValuePair<Directions, TileIdentifier>>();

            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            tile.Flippe();
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));

            return result;
        }

        public List<KeyValuePair<Directions, TileIdentifier>> TileMatchSub(Tile tile)
        {
            var result = new List<KeyValuePair<Directions, TileIdentifier>>();

            if (RightColumn.SequenceEqual(tile.LeftColumn))
            {
                result.Add(new KeyValuePair<Directions, TileIdentifier>(Directions.Right, new TileIdentifier { Rotation = tile.Rotation, Id = tile.Id }));
            }

            if (LeftColumn.SequenceEqual(tile.RightColumn))
            {
                result.Add(new KeyValuePair<Directions, TileIdentifier>(Directions.Left, new TileIdentifier { Rotation = tile.Rotation, Id = tile.Id }));
            }

            if (TopRow.SequenceEqual(tile.DownRow))
            {
                result.Add(new KeyValuePair<Directions, TileIdentifier>(Directions.Up, new TileIdentifier { Rotation = tile.Rotation, Id = tile.Id }));
            }

            if (DownRow.SequenceEqual(tile.TopRow))
            {
                result.Add(new KeyValuePair<Directions, TileIdentifier>(Directions.Down, new TileIdentifier { Rotation = tile.Rotation, Id = tile.Id }));
            }

            return result;
        }

        public override string ToString()
        {
            var arr = new List<string>();
            foreach(var i in Pixels)
            {
                arr.Add(new string(i.ToArray()));
            }

            return string.Join("\r\n", arr);
        }
    }

    public class TileIdentifier
    {
        public int Id { get; init; }
        public Rotation Rotation { get; init; }
    }
}
