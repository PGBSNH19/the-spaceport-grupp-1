using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public abstract class HullComponent : IHullComponent
    {
        private readonly double length;

        public HullComponent(double length)
        {
            this.length = length;
        }

        public double GetLength()
        {
            return length;
        }
    }
}
