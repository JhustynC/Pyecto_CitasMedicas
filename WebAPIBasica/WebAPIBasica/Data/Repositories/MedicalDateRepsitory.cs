using Dapper;
using Npgsql;
using WebAPIBasica.Application;
using WebAPIBasica.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPIBasica.Data.Datasource
{
    public class MedicalDateRepsitory : IMedicDateRepository
    {
        private PostgresSQLConfiguration _connectionString;
        private NpgsqlConnection connection;

        public MedicalDateRepsitory(PostgresSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
            connection = new NpgsqlConnection(_connectionString.ConnectionString);
        }

        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
          
        public async Task<IEnumerable<MedicDate>> GetAllMedicDates()
        {
            var connection = DbConnection();
            
            string sql = @"
                SELECT id, doctor, patient, hour, date FROM medicdate
            ";

            return await connection.QueryAsync<MedicDate>(sql, new {});
        }

        public async Task<bool> DeleteMedicaDate(MedicDate md)
        {
            string sql = @"
                DELETE FROM medicdate 
                WHERE id = @Id
            ";

            var result = await connection.ExecuteAsync(sql, new { Id = md.Id });
            return result > 0;
        }


        public async Task<MedicDate?> GetMedicDate(int id)
        {
            string sql = @"
                SELECT * FROM medicdate md
                WHERE id = @Id
            ";

            return await connection.QueryFirstOrDefaultAsync<MedicDate?>(sql, new { Id = id });
        }

        public async Task<bool> InsertMedicaDate(MedicDate md)
        {
            var connection = this.DbConnection();

            var sql = @"
                INSERT INTO medicdate (doctor, patient, hour, date) 
                VALUES (@doctor, @patient, @hour, @date)
                
            ";

            var result = await connection.ExecuteAsync(sql, new { md.Doctor, md.Patient, md.Hour, md.Date});
            return result > 0;
        }

        public async Task<bool> UpdateMedicaDate(MedicDate md)
        {
            var connection = this.DbConnection();

            var sql = @"
                UPDATE medicdate                  
                VALUES doctor = @doctor , patient=@patient, hour=@hour, date=@date
                WHERE id = @Id
            ";

            var result = await connection.ExecuteAsync(sql, new { md.Doctor, md.Patient, md.Hour, md.Date, md.Id });
            return result > 0;
        }
    }
}
