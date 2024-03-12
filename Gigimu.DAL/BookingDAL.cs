using Dapper;
using Gigimu.BO;
using Gigimu.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Gigimu.DAL
{
    public class BookingDAL : IBookingDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(Booking entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookingByPasien(int pasienId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Booking> books = new List<Booking>();
                var strSql = @"getBookingByPasien";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PasienID", pasienId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var booking = new Booking()
                        {
                            BookingID = Convert.ToInt32(dr["BookingID"]),
                            JadwalDokterID = Convert.ToInt32(dr["JadwalDokterID"]),
                            PasienID = Convert.ToInt32(dr["PasienID"]),
                            JamBooking = Convert.ToDateTime(dr["JamBooking"]),
                            dokter = new Dokter()
                            {
                                Nama = dr["Nama"].ToString(),
                                Spesialis = dr["Spesialis"].ToString()
                            },
                            jadwal = new Jadwal()
                            {
                                Tanggal = Convert.ToDateTime(dr["Tanggal"]),
                            }
                        };
                        books.Add(booking);
                    }
                }
                return books;
                //-------------
                //List<Jadwal> jadwals = new List<Jadwal>();
                //var strSql = @"select d.DokterID, d.Email, d.isSpesialis, 
                //                d.Nama, d.Password, d.Spesialis, jd.DokterID, 
                //                jd.JadwalDokterID, jd.MaxOrang, 
                //                jd.PasienTerdaftar, jd.Status, jd.Tanggal from Dokter as d  
                //                 join JadwalDokter as jd on d.DokterID = jd.DokterID where jd.DokterID = @DokterID";
                //SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.Parameters.AddWithValue("@DokterID", dokterId);
                //conn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        var jadwal = new Jadwal()
                //        {
                //            JadwalDokterID = Convert.ToInt32(dr["JadwalDokterID"]),
                //            DokterID = Convert.ToInt32(dr["DokterID"]),
                //            MaxOrang = Convert.ToInt32(dr["MaxOrang"]),
                //            PasienTerdaftar = Convert.ToInt32(dr["PasienTerdaftar"]),
                //            Status = dr["Status"].ToString(),
                //            Tanggal = Convert.ToDateTime(dr["Tanggal"]),
                //            Dokter = new Dokter()
                //            {
                //                DokterID = Convert.ToInt32(dr["DokterID"]),
                //                //Email = dr["Email"].ToString(),
                //                //IsSpesialis = Convert.ToBoolean(dr["IsSpesialis"]),
                //                //Nama = dr["Email"].ToString(),
                //                //Password = dr["Password"].ToString(),
                //                //Spesialis = dr["Spesialis"].ToString(),
                //            }
                //        };
                //        jadwals.Add(jadwal);
                //    }
                //}
                //return jadwals;
            }
        }

        public Booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Booking entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = "addBooking";
                    var param = new
                    {
                        PasienID = entity.PasienID,
                        JadwalDokterID = entity.JadwalDokterID,
                        JamBooking = entity.JamBooking
                    };
                    int result = conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
                    //if (result != 1)
                    //{
                    //    throw new System.Exception("Data tidak berhasil ditambahkan");
                    //}
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

        public void Update(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void DeteteByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var strSql = "deleteBooking";
                var param = new { BookingID = id };
                conn.Execute(strSql, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
