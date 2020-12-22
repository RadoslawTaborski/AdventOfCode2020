using AdventOfCode2020.Helpers;
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
        public List<char> LeftColumn { get; private set; }
        public List<char> RightColumn { get; private set;  }
        public List<char> TopRow { get; private set; }
        public List<char> DownRow { get; private set; }

        private Rotation Rotation = Rotation._0;
        private bool Flipped = false;

        public Tile(int id, List<List<char>> pixels)
        {
            Id = id;
            Pixels = pixels;

            SetLeftAndRight();
            TopRow = Pixels[0];
            DownRow = Pixels.Last();
        }

        public List<List<char>> GetWithoutBorder()
        {
            var result = new List<List<char>>();

            for(var i =1; i< Pixels.Count-1; ++i)
            {
                result.Add(Pixels[i].Skip(1).Take(Pixels[i].Count-2).ToList());
            }

            return result;
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
            Pixels = ArrayModifier.Rotate(Pixels);
            Rotation = (Rotation)(((int)Rotation + 1) % ((int)Rotation._270+1));

            SetLeftAndRight();

            TopRow = Pixels[0];
            DownRow = Pixels.Last();

            return this;
        }

        public Tile Flippe()
        {
            Pixels.Reverse();
            this.Flipped = !this.Flipped;

            SetLeftAndRight();

            TopRow = Pixels[0];
            DownRow = Pixels.Last();

            return this;
        }

        public List<TileOrientation> TileMatch(Tile tile)
        {
            var result = new List<TileOrientation>();

            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            tile.Flippe();
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            result.AddRange(TileMatchSub(tile.Rotate()));
            tile.Flippe();

            return result;
        }

        public List<TileOrientation> TileMatchSub(Tile tile)
        {
            var result = new List<TileOrientation>();

            if (RightColumn.SequenceEqual(tile.LeftColumn))
            {
                result.Add(new TileOrientation(tile.Id, Direction.Right, tile.Rotation, tile.Flipped));
            }

            if (LeftColumn.SequenceEqual(tile.RightColumn))
            {
                result.Add(new TileOrientation(tile.Id, Direction.Left, tile.Rotation, tile.Flipped));
            }

            if (TopRow.SequenceEqual(tile.DownRow))
            {
                result.Add(new TileOrientation(tile.Id, Direction.Up, tile.Rotation, tile.Flipped));
            }

            if (DownRow.SequenceEqual(tile.TopRow))
            {
                result.Add(new TileOrientation(tile.Id, Direction.Down, tile.Rotation, tile.Flipped));
            }

            return result;
        }

        public Tile SetTile(TileOrientation orientation)
        {
            if(Flipped == orientation.Flipped && Rotation == orientation.Rotation)
            {
                return this;
            }
            if (orientation.Flipped)
            {
                Flippe();
            }

            _ = orientation.Rotation switch
            {
                Rotation._0 => this,
                Rotation._90 => Rotate(),
                Rotation._180 => Rotate().Rotate(),
                Rotation._270 => Rotate().Rotate().Rotate(),
                _ => throw new Exception("Rotate not found"),
            };

            return this;
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
}
