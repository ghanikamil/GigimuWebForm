using Dapper;
using Gigimu.BO;
using Gigimu.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Gigimu.DAL
{
    public class PasienDAL : IPasienDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(Pasien entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pasien> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Pasien";
                var results = conn.Query<Pasien>(strSql);
                return results;
            }
        }

        public Pasien GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "getPasienById";
                var param = new { PasienID = id };
                var results = conn.QuerySingleOrDefault<Pasien>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }

        public void Insert(Pasien entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "addPasien";
                    var param = new
                    {
                        Nama = entity.Nama,
                        Alamat = entity.Alamat,
                        Telepon = entity.Telepon,
                        Email = entity.Email,
                        Password = entity.Password
                    };
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new System.Exception("Data tidak berhasil ditambahkan");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public Pasien Login(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "LoginPasien";
                var param = new { Email = email, Password = password };
                var result = conn.QueryFirstOrDefault<Pasien>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    throw new ArgumentException("Username atau Password salah");
                }
                return result;
            }
        }

        public void Update(Pasien entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "updatePasienProfil";
                    var param = new 
                    { 
                        Nama = entity.Nama, 
                        Alamat = entity.Alamat,
                        Telepon = entity.Telepon,
                        PasienID = entity.PasienID,
                    };
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);

                    //jika result = -1, berarti update data gagal
                    if (result != 1)
                    {
                        throw new Exception("Update data failed..");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
