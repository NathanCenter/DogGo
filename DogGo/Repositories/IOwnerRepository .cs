using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
       
        void AddOwner(Owner owner);
        
        void DeleteOwner(int id);
        Owner Create(Owner owner);
        void UpdateOwner(Owner owner);
        Owner GetOwnerByEmail(string email);
        
    }
}
