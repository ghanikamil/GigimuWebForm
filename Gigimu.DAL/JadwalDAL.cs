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
    public class JadwalDAL : IJadwalDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Insert(Jadwal entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Jadwal entity)
        {
            throw new NotImplementedException();
        }
    }
}
