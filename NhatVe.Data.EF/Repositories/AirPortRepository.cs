using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NhatVe.Data.Entities;
using NhatVe.Data.IRepositories;

namespace NhatVe.Data.EF.Repositories
{
    public class AirPortRepository : EFRepository<AirPort, int>, IAirPortRepository
    {
        AppDbContext _context;
        public AirPortRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<AirPort> GetAirPortByAlias(string alias)
        {
            return _context.AirPorts.Where(x => x.SeoAlias == alias).ToList();
        }
    }
}