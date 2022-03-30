using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetDogsById(int id);
        Dog Create(Dog dog);
        void AddDog(Dog dog);

        void UpdateDog(Dog dog);

        void DeleteDog(int id);
    }
}
