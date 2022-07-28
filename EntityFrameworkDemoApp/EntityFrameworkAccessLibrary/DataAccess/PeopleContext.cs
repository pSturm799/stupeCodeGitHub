using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        //tables
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
    }
}
