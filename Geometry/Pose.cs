﻿namespace Geometry
{
    public class Pose
    {
        private readonly Position _position;
        private readonly Orientation _orientation;

        public Pose()
        {
            _position = new Position();
            _orientation = new Orientation();
        }

        public Pose(Position position, Orientation orientation)
        {
            _position = position;
            _orientation = orientation;
        }

        public Position Position
        {
            get { return _position; }
        }

        public Orientation Orientation
        {
            get { return _orientation; }
        }
    }
}
