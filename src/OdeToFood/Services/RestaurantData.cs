using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace OdeToFood.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
        void Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Mister Cat" },
                new Restaurant { Id = 2, Name = "Noodle Doodle" },
                new Restaurant { Id = 3, Name = "Mafia" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public void Commit()
        {
            // no op
        }
    }
}
