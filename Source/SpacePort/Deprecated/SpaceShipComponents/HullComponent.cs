using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public abstract class HullComponent : IHullComponent
    {
       public double Length { get; set; }

        public HullComponent(double length)
        {
            this.Length = length;
        }

        public double GetLength()
        {
            return Length;
        }
    }
}
