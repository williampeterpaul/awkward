using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace awkward.api.Models
{
    public class Repository
    {
        private List<Entity> Entities = new List<Entity>
        {
            new Entity
            {
                Id = 1,
                Name = "Test A",
                Description = "Sentence describing test A",
                Content = "Content",
                CreationDate = DateTime.Now
            },
            new Entity
            {
                Id = 2,
                Name = "Test B",
                Description = "Sentence describing test B",
                Content = "Content",
                CreationDate = DateTime.Now
            },
            new Entity
            {
                Id = 3,
                Name = "Test C",
                Description = "Sentence describing test C",
                Content = "Content",
                CreationDate = DateTime.Now
            }
        };

        public List<Entity> Get()
        {
            return Entities;
        }

        public Entity Get(int id)
        {
            return Entities.First(e => e.Id == id);
        }

        public void Add(Entity entity)
        {
            Entities.Add(entity);
        }

        public void Update(Entity entity)
        {
            Entities.Remove(Entities.First(e => e.Id == entity.Id));
            Add(entity);
        }

        public void Remove(int id)
        {
            Entities.Remove(Entities.First(x => x.Id == id));
        }
    }
}
