using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Spaceship
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Person Owner { get; set; }

        /// <summary>
        /// Warning: Use only when constructing object from database!
        /// </summary>
        /// <param name="id"></param>
        public void SetID(int id)
        {
            this.ID = id;
        }

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

        public static Spaceship CreateObjectFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            SpaceshipData spaceshipData = dataFetch.GetSpaceShip(searchIndex);
            return new Spaceship
            {
                Name = spaceshipData.name,
                Length = double.Parse(spaceshipData.length)
            };
        }
    }
}
