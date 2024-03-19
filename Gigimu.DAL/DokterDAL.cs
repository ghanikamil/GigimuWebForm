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
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
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

        public Dokter Login(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "LoginDokter";
                var param = new { Email = email, Password = password };
                var result = conn.QueryFirstOrDefault<Dokter>(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    throw new ArgumentException("Username atau Password salah");
                }

                var strSqlRole = @"select r.* from UserRole ur
                                    join Role r on ur.RoleID = r.RoleID
                                    join Dokter d on ur.DokterID = d.DokterID
                                    where d.Email = @Email";
                var roles = conn.Query<Role>(strSqlRole, param);
                result.Roles = roles;

                return result;
            }
        }

        public void AddUserToRole(int dokterId, int roleId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into UserRole(DokterID, RoleID) values(@DokterID, @RoleID)";
                var param = new { DokterID = dokterId, RoleID = roleId };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new Exception("Data tidak berhasil ditambahkan");
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Kesalahan: " + ex.Message);
                }
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Role order by RoleName desc";
                var results = conn.Query<Role>(strSql);
                return results;
            }
        }
    }
}
