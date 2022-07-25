using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Repositories;
using vacay.Models;

namespace vacay.Services
{
    public class VacationsService
    {
        private readonly VacationsRepository _repo;

        public VacationsService(VacationsRepository repo)
        {
            _repo = repo;
        }

        internal List<Vacation> GetAll()
        {
            return _repo.GetAll();
        }

        internal Vacation GetById(int id)
        {
            Vacation found = _repo.GetById(id);
            return _repo.GetById(id);
        }

        internal Vacation Create(Vacation newVacation)
        {
            return _repo.Create(newVacation);
        }

        internal Vacation Delete(int id, string userId)
        {
            Vacation original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You can't delete this vacation");
            }
             _repo.Delete(id);
            return original;
        }

        internal List<VacationCruiseViewModel> GetCruiseByAccountId(string userId)
        {
            return _repo.GetCruiseByAccountId(userId);
        }
       
        
    }
}