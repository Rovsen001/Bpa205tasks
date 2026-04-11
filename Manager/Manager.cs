using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Manager
{
    
    public class Manager<T, TId> where T : BaseEntity<TId>, new()
    {
        private List<T> entities = new List<T>();

        public void Add(T entity)
        {
            if (entities.Contains(entity)) 
            {
                Console.WriteLine($"Id={entity.Id} artıq movcuddur.");
                return;
            }
            entities.Add(entity);
            Console.WriteLine($"Obyekt Id={entity.Id} elave olundu.");
        }

        public void Remove(TId id)
        {
           
            T temp = new T { Id = id };
            if (!entities.Contains(temp))
            {
                Console.WriteLine($"Id={id} obyekt tapilmadi.");
                return;
            }
            entities.Remove(temp);
            Console.WriteLine($"Obyekt Id={id} silindi.");
        }

        public void Update(T entity)
        {
            if (!entities.Contains(entity))
            {
                Console.WriteLine($"Id={entity.Id} obyekt tapilmadi.");
                return;
            }
            int index = entities.IndexOf(entity);
            entities[index] = entity;
            Console.WriteLine($"Obyekt Id={entity.Id} ugurla yenilendi.");
        }

        public T GetById(TId id)
        {
            T temp = new T { Id = id };
            if (!entities.Contains(temp))
            {
                Console.WriteLine($"Id={id} obyekt tapilmadi.");
                return null;
            }
            int index = entities.IndexOf(temp);
            var entity = entities[index];
            Console.WriteLine($"Obyekt Id={id} tapildi.");
            return entity;
        }

        public List<T> GetAll()
        {
            Console.WriteLine("Butun obyektler:");
            return entities;
        }
    }
}
