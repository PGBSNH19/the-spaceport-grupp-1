using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Spaceship
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public Person Owner { get; set; }

        /// <summary>
        /// Converts this type to a type that represents it's database model structure.
        /// </summary>
        /// <returns></returns>
        public SpaceshipDbModel ToDbModel()
        {
            if (Owner != null)
            {
                return new SpaceshipDbModel
                {
                    Name = this.Name,
                    Length = this.Length,
                    PersonDbModel = Owner.ToDbModel()
                };
            }

            return new SpaceshipDbModel();
        }
    }
}
