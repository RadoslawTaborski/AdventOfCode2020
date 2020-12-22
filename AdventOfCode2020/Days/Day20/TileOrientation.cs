namespace AdventOfCode2020.Days.Day20
{
    public class TileOrientation
    {
        public int Id { get; private set; }
        public Direction Direction { get; private set; }
        public Rotation Rotation { get; private set; }
        public bool Flipped { get; private set; }

        public TileOrientation(int id, Direction direction, Rotation rotation, bool flipped)
        {
            Id = id;
            Direction = direction;
            Rotation = rotation;
            Flipped = flipped;
        }

        //public TileOrientation Combinate(TileOrientation baseTile)
        //{
        //    var result = new TileOrientation(Id, Direction, Rotation, Flipped);
        //    if (!baseTile.Flipped && baseTile.Rotation == Rotation._0)
        //    {
        //        return result;
        //    }
        //    var baseRotation = (int)baseTile.Rotation;
        //    if (baseTile.Flipped)
        //    {
        //        result.Flipped = !Flipped;

        //        baseRotation = -(int)baseTile.Rotation;
        //    }
        //    if (baseTile.Rotation != Rotation._0)
        //    {
        //        int tmp = (baseRotation + (int)result.Rotation)%4;
        //        result.Rotation = tmp < 0 ? (Rotation)(tmp + 4) : (Rotation)tmp;
        //    }
        //    switch (baseRotation < 0 ? (Rotation)(baseRotation+4) : (Rotation)baseRotation)
        //    {
        //        case Rotation._0:
        //            break;
        //        case Rotation._90:
        //            result.Direction = (Direction)(((int)result.Direction + 1) % ((int)Direction.Left + 1));
        //            break;
        //        case Rotation._180:
        //            result.Direction = (Direction)(((int)result.Direction + 2) % ((int)Direction.Left + 1));
        //            break;
        //        case Rotation._270:
        //            result.Direction = (Direction)(((int)result.Direction + 3) % ((int)Direction.Left + 1));
        //            break;
        //    }
        //    if (baseTile.Flipped)
        //    {
        //        switch (Direction)
        //        {
        //            case Direction.Up:
        //                result.Direction = Direction.Down;
        //                break;
        //            case Direction.Down:
        //                result.Direction = Direction.Up;
        //                break;
        //        }
        //    }

        //    return result;
        //}

        public override string ToString()
        {
            return $"{Direction}-{Id}-{Rotation} - {Flipped}";
        }
    }
}
