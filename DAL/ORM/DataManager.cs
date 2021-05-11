namespace DAL.ORM
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Entities;

    public class DataManager : DbContext
    {
        // Your context has been configured to use a 'DataManager' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.ORM.DataManager' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataManager' 
        // connection string in the application configuration file.
        public DataManager()
            : base("name=DataManager")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Vaccine> Vaccines { get; set; }
    }
}