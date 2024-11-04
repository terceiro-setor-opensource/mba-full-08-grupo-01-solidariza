using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solidariza.Domain.Models;

namespace Solidariza.Repository.Interfaces
{
    public interface IAbrigoRepository
    {
        Task AddAsync(Abrigo abrigo);
    }
}
