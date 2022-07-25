using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class CruisesService
    {
        private readonly CruisesRepository _repo;


        public CruisesService(CruisesRepository repo)
        {
            _repo = repo;
        }
        internal Cruise GetById(int id)
        {
            Cruise Found = _repo.GetById(id);
            if (Found == null)
            {
                throw new Exception("No cruise found");
            }
            return Found;
        }

        internal Cruise Create(Cruise newCruise)
        {
            Cruise exists = _repo.FindExisting(newCruise);
            if (exists != null)
            {
                throw new Exception("Cruise already exists");
            }
            return _repo.Create(newCruise);
        }

        internal Cruise Delete(int id, string userId)
        {
            Cruise original = GetById(id);
            if (original.AccountId != userId)
            {
                throw new Exception("You can't delete this cruise");
            }
            _repo.Delete(id);
            return original;
        }


        
    }
}