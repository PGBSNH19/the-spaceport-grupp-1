using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SpacePort
{
    public class Spaceship
    {
        public int SpaceshipID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Person Owner { get; set; }

        /// <summary>
        /// Warning: Use only when constructing object from database!
        /// </summary>
        /// <param name="id"></param>
        public void SetID(int id)
        {
            this.SpaceshipID = id;
        }

        /// <summary>
        /// Converts this type to a type that represents it's database model structure.
        /// </summary>
        /// <returns></returns>
        public SpaceshipModel ToDbModel()
        {
            if (Owner != null)
            {
                return new SpaceshipModel
                {
                    Name = this.Name,
                    Length = this.Length,
                    Person = Owner.ToDbModel()
                };
            }
            SetID(this.SpaceshipID);

            return new SpaceshipModel();
        }

        public static async Task<List<Spaceship>> GetSpaceShipsAsync()
        {
            SpaceParkContext context = new SpaceParkContext();
            List<Spaceship> spaceships = new List<Spaceship>();
            var ids = context.Spaceship.Select(s => s.SpaceshipID).ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                SpaceshipModel model = await SpaceshipModel.CreateModelFromDb(ids[i]);
                Spaceship spaceship = model.CreateObjectFromModel();
                spaceships.Add(spaceship);
            }
            return spaceships;
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

        public static void AddSpaceShipToDb(Spaceship spaceship, Person person)
        {
            using (var context = new SpaceParkContext())
            {
                var spaceshipModel = context.Spaceship.Where(s => s.SpaceshipID == spaceship.SpaceshipID).First();
                spaceshipModel.Person = person.ToDbModel();
                context.SaveChanges();
            }
        }

        public static void DeleteSpaceshipFromDb(Spaceship spaceship)
        {
            using (var context = new SpaceParkContext())
            {
                var s = context.Spaceship.Single(s => s.SpaceshipID == spaceship.SpaceshipID);
                s.Person = null;
                context.Update(s);
                context.SaveChanges();
            }
        }
    }
}

