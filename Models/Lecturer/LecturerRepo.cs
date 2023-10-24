using System;
using assessment_net_be.Models.Lecturer;
using assessment_net_be.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;

namespace assessment_net_be.Models.Lecturer
{
    public class LecturerRepo
    {
        private readonly IConfiguration _configuration;

        public LecturerRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Lecturer/GetLecturers.sql");
            IEnumerable<Lecturer> lecturers = dbConnection.Query<Lecturer>(sqlQuery);
            return lecturers;
        }

        public Lecturer GetLecturerById(int LECTURER_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Lecturer/GetLecturerById.sql");
            Lecturer lecturer = dbConnection.Query<Lecturer>(sqlQuery, new { LECTURER_ID }).FirstOrDefault();
            return lecturer;
        }

        public ResponseMessage Save(Lecturer lecturer)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Lecturer/SaveLecturer.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, lecturer).FirstOrDefault();
            return result;
        }

        public ResponseMessage Delete(int LECTURER_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Lecturer/DeleteLecturer.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { LECTURER_ID }).FirstOrDefault();
            return result;
        }

        public ResponseMessage Update(Lecturer lecturer)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Lecturer/UpdateLecturer.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, lecturer).FirstOrDefault();
            return result;
        }
    }
}

