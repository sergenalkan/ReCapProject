﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=CarRentalDB;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Delgado\Desktop\Programlama\Uygulamalar\ReCapProject\Entities\DbReCap.mdf;Integrated Security=True");

            //(localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\DELGADO\DESKTOP\PROGRAMLAMA\UYGULAMALAR\RECAPPROJECT\ENTITIES\DBRECAP.MDF; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Encrypt = False; TrustServerCertificate = False
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AttachDbFilename=C:\Users\Delgado\Desktop\Programlama\Uygulamalar\ReCapProject\Entities\DbReCap.mdf;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
