using Dapper;
using Gigimu.BO;
using Gigimu.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace Gigimu.DAL
{
    public class JadwalDAL : IJadwalDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(Jadwal entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jadwal> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from JadwalDokter order by Tanggal";
                var results = conn.Query<Jadwal>(strSql);
                return results;
            }
        }

        public Jadwal GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from JadwalDokter where JadwalDokterID= @JadwalID";
                var param = new { JadwalID = id };
                var result = conn.QueryFirstOrDefault<Jadwal>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Jadwal> GetJadwalByDokter(int dokterId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Jadwal> jadwals = new List<Jadwal>();
                var strSql = @"select d.DokterID, d.Email, d.isSpesialis, 
                                d.Nama, d.Password, d.Spesialis, jd.DokterID, 
                                jd.JadwalDokterID, jd.MaxOrang, 
                                jd.PasienTerdaftar, jd.Status, jd.Tanggal from Dokter as d  
                                 join JadwalDokter as jd on d.DokterID = jd.DokterID where jd.DokterID = @DokterID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@DokterID",dokterId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var jadwal = new Jadwal()
                        {
                            JadwalDokterID = Convert.ToInt32(dr["JadwalDokterID"]),
                            DokterID = Convert.ToInt32(dr["DokterID"]),
                            MaxOrang = Convert.ToInt32(dr["MaxOrang"]),
                            PasienTerdaftar = Convert.ToInt32(dr["PasienTerdaftar"]),
                            Status = dr["Status"].ToString(),
                            Tanggal = Convert.ToDateTime(dr["Tanggal"]),
                            Dokter = new Dokter()
                            {
                                DokterID = Convert.ToInt32(dr["DokterID"]),
                                //Email = dr["Email"].ToString(),
                                //IsSpesialis = Convert.ToBoolean(dr["IsSpesialis"]),
                                //Nama = dr["Email"].ToString(),
                                //Password = dr["Password"].ToString(),
                                //Spesialis = dr["Spesialis"].ToString(),
                            }
                        };
                        jadwals.Add(jadwal);
                    }
                } return jadwals;
            }
        }

        public IEnumerable<Jadwal> GetJadwalWithDokter()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Jadwal> jadwals = new List<Jadwal>();
                var strSql = @"select d.DokterID, d.Email, d.isSpesialis, 
                                d.Nama, d.Password, d.Spesialis, jd.DokterID, 
                                jd.JadwalDokterID, jd.MaxOrang, 
                                jd.PasienTerdaftar, jd.Status, jd.Tanggal from Dokter as d  
                                 join JadwalDokter as jd on d.DokterID = jd.DokterID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var jadwal = new Jadwal()
                        {
                            JadwalDokterID = Convert.ToInt32(dr["JadwalDokterID"]),
                            DokterID = Convert.ToInt32(dr["DokterID"]),
                            MaxOrang = Convert.ToInt32(dr["MaxOrang"]),
                            PasienTerdaftar = Convert.ToInt32(dr["PasienTerdaftar"]),
                            Status = dr["Status"].ToString(),
                            Tanggal = Convert.ToDateTime(dr["Tanggal"]),
                            Dokter = new Dokter()
                            {
                                DokterID = Convert.ToInt32(dr["DokterID"]),
                                Email = dr["Email"].ToString(),
                                //IsSpesialis = Convert.ToBoolean(dr["IsSpesialis"]),
                                Nama = dr["Nama"].ToString(),
                                //Password = dr["Password"].ToString(),
                                Spesialis = dr["Spesialis"].ToString(),
                            }
                        };
                        jadwals.Add(jadwal);
                    }
                }
                return jadwals;
            }
        }

        public void Insert(Jadwal entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "createJadwal";
                var param = new
                {
                    DokterID = entity.DokterID,
                    Tanggal = entity.Tanggal,
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

        public void Update(Jadwal entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"UPDATE [JadwalDokter] SET [MaxOrang] = @MaxOrang WHERE [JadwalDokterID] = @JadwalDokterID";
                    var param = new { MaxOrang = entity.MaxOrang, JadwalDokterID = entity.JadwalDokterID };
                    int result = conn.Execute(strSql, param);

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

        public void DeteteByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var strSql = "delete from JadwalDokter where JadwalDokterID = @JadwalDokterID";
                var param = new { JadwalDokterID = id };
                try
                {
                    int result = conn.Execute(strSql, param);
                    if (result != 1)
                    {
                        throw new ArgumentException("Delete data failed..");
                    }
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
    }
}
