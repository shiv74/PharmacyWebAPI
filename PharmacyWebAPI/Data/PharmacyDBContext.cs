using Microsoft.EntityFrameworkCore;
using PharmacyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebAPI.Data
{
    public class PharmacyDBContext: DbContext
    {
        public PharmacyDBContext(DbContextOptions<PharmacyDBContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicine { get; set; }
    }
}
