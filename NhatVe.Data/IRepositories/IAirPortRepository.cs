using NhatVe.Data.Entities;
using NhatVe.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace NhatVe.Data.IRepositories
{
    public interface IAirPortRepository : IRepository<AirPort, int>
    {
        List<AirPort> GetAirPortByAlias(string alias);
    }
}