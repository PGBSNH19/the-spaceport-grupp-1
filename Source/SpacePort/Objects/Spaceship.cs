using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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

<<<<<<< HEAD
        public static async Task<List<Spaceship>> GetSpaceShipsAsync()
        {
            SpaceParkContext context = new SpaceParkContext();
            List<Spaceship> spaceships = new List<Spaceship>();
            var ids = context.SpaceshipInfo.Select(s => s.SpaceshipDbModelId).ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                SpaceshipDbModel model = await SpaceshipDbModel.CreateModelFromDb(ids[i]);
                Spaceship spaceship = model.CreateObjectFromModel();
                spaceships.Add(spaceship);
            }
            return spaceships;

=======
        public static Spaceship CreateObjectFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            SpaceshipData spaceshipData = dataFetch.GetSpaceShip(searchIndex);
            return new Spaceship
            {
                Name = spaceshipData.name,
                Length = double.Parse(spaceshipData.length)
            };
>>>>>>> origin
        }
    }
}
