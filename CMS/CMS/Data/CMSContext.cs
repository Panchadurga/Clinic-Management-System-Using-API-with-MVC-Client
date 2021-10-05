using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.Models;

namespace CMS.Data
{
    public class CMSContext : DbContext
    {
        public CMSContext (DbContextOptions<CMSContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<CMS.Models.UserSetup> UserSetup { get; set; }
        public DbSet<CMS.Models.Doctor> Doctor { get; set; }
        public DbSet<CMS.Models.Patient> Patient { get; set; }
        public DbSet<CMS.Models.Schedule> Schedule { get; set; }
       
        
    }
}
