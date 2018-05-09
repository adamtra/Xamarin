using PatientsStory.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientsStory.Database
{
    public class DatabaseController
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseController(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Patient>().Wait();
            _database.CreateTableAsync<Visit>().Wait();
        }

        public Task<List<Patient>> GetPatientsAsync()
        {
            return _database.Table<Patient>()
                .OrderBy(t => t.LastName)
                .ThenBy(t => t.FirstName)
                .ThenBy(t => t.PESEL)
                .ToListAsync();
        }

        public Task<Patient> GetPatientAsync(int id)
        {
            return _database.Table<Patient>()
                .Where(i => i.PatientId == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SavePatientAsync(Patient patient)
        {
            if (patient.PatientId != 0)
            {
                return _database.UpdateAsync(patient);
            }
            else
            {
                return _database.InsertAsync(patient);
            }
        }

        public Task<int> DeletePatientAsync(Patient patient)
        {
            return _database.DeleteAsync(patient);
        }

        public Task<List<Visit>> GetVisitsAsync(int patientId)
        {
            return _database.Table<Visit>()
                .Where(v => v.PatientId == patientId)
                .OrderByDescending(t => t.DateOfVisit)
                .ThenBy(t => t.Diagnose)
                .ToListAsync();
        }

        public Task<Visit> GetVisitAsync(int id)
        {
            return _database.Table<Visit>()
                .Where(i => i.VisitId == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveVisitAsync(Visit visit)
        {
            if (visit.VisitId != 0)
            {
                return _database.UpdateAsync(visit);
            }
            else
            {
                return _database.InsertAsync(visit);
            }
        }
    }
}