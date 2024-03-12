using Dapper;
using Gigimu.BO;
using Gigimu.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace Gigimu.DAL
{
    public class DokterDAL : IDokterDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(Dokter entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dokter> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"getAllDokter";
                var results = conn.Query<Dokter>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public Dokter GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Dokter where DokterID = @DokterID";
                var param = new { DokterID = id };
                var result = conn.QuerySingleOrDefault<Dokter>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Dokter> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Dokter where Nama like @Nama";
                var param = new { Nama = $"%{name}%" };
                var results = conn.Query<Dokter>(strSql, param);
                return results;
            }
        }

        public void Insert(Dokter entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "addDokter";
                var param = new 
                { 
                    Nama = entity.Nama, 
                    Spesialis = entity.Spesialis,
                    Email = entity.Email,
                    Password = entity.Password
                };
                try
                {
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    //if (result != 1)
                    //{
                    //    throw new ArgumentException("Insert data failed..");
                    //}
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Update(Dokter entity)
        {
            throw new NotImplementedException();
        }
    }
}
