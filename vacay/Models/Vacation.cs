using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Interfaces;

namespace vacay.Models
{
    public class Vacation : RepoItem<int>, ICreated
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }

        public Profile Creator { get; set; }
        public string Destination { get; set; }
        public string ImageUrl { get; set; }

        
    }

    public class VacationCruiseViewModel : Vacation
    {
        public int CruiseId { get; set; }
    }

    public class VacationTourViewModel : Vacation
    {
        public int TourId { get; set; }
    }

    

}