using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Models;

namespace vacay.Interfaces
{
    public interface ICreated
    {
        string CreatorId { get; set; }

        Profile Creator { get; set; }
        
    }
}