using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Training
    {
        public virtual string name { get; set; }
        public virtual string location { get; set; }
        public virtual int id { get; set; }
        public virtual ICollection<Registration> registrations { get; set; }
        public virtual string description { get; set; }
        public virtual DateTime startDate { get; set; }
    }

    public class Registration
    {
        public int id { get; set; }
        public Training training { get; set; }
        public string StudentName { get; set; }

    }

    public class TrainingDatabase : DbContext
    {
        public TrainingDatabase()
            : base("Server=tcp:ledqqicban.database.windows.net,1433;Database=JohnGorterDB;User ID=JohnGorter@ledqqicban;Password=<pwd>;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        {

        }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
    }

    public class RegistrationEntity : TableEntity {
        public RegistrationEntity(string partition, string rowkey)
        {
            PartitionKey = partition;
            RowKey = rowkey;
        }

        public RegistrationEntity()
        {

        }

        public string student { get; set; }
        public string training { get; set; }
    
    }


}
