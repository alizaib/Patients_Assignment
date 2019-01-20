using Microsoft.EntityFrameworkCore;
using Patients.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Patients.Domain {
    public class PatientContext : DbContext, IContext<Patient> {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options) {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Kin> Kins { get; set; }
        public Patient CreateEntity() {
            var patient = new Patient {

            };
            Add(patient);
            return patient;
        }
        public void AddEntity(Patient entity) {
            Add(entity);
        }

        public void RemoveEntity(Patient entity) {
            Remove(entity);
        }
        public IQueryable<Patient> GetAll() => this.Set<Patient>();
        public IQueryable<Patient> FindBy(Expression<Func<Patient, bool>> predicate) {
            IQueryable<Patient> query = this.Set<Patient>().Where(predicate);
            return query;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Kin>().ToTable("Kin");
        }

        public void SaveContextChanges() {
            SaveChanges();
        }
    }
    public class Patient {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PasNumber { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DoB { get; set; }
        public string SexCode { get; set; }
        public string ContactNumber { get; set; }
        public Kin NextOfKin { get; set; }
    }
    public class Kin {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RelationshopCode { get; set; }
        public string Address { get; set; }
    }
}
