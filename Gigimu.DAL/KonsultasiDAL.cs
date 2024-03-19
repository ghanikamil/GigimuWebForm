using Dapper;
using Gigimu.BO;
using Gigimu.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gigimu.DAL
{
    public class KonsultasiDAL : IKonsultasiDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(Konsultasi entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Konsultasi> GetAll()
        {
            throw new NotImplementedException();
        }

        public Konsultasi GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Konsultasi entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"INSERT INTO [gigimu].[dbo].[Konsultasi] ([Tanggal], [Keluhan], [Diagnosa], [ResepObat], [TotalPay], [PasienID], [DokterID])
                            VALUES (@Tanggal, @Keluhan, @Diagnosa, @ResepObat, @TotalPay, @PasienID, @DokterID);";
                var param = new
                {
                    Tanggal = entity.Tanggal,
                    Keluhan = entity.Keluhan,
                    Diagnosa = entity.Diagnosa,
                    ResepObat = entity.ResepObat,
                    TotalPay = entity.TotalPay,
                    PasienID = entity.PasienID,
                    DokterID = entity.DokterID,
                };
                try
                {
                    int result = conn.Execute(strSql, param);
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

        public void Update(Konsultasi entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Konsultasi> GetKonsultasiWithDokterPasien()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Konsultasi> konsultasis = new List<Konsultasi>();
                var strSql = @"select k.*, d.Nama as NamaDokter, p.Nama as NamaPasien from Konsultasi as k
                            join Pasien as p on p.PasienID = k.PasienID
                            join Dokter as d on d.DokterID = k.DokterID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var konsultasi = new Konsultasi()
                        {
                            KonsultasiID = Convert.ToInt32(dr["KonsultasiID"]),
                            PasienID = Convert.ToInt32(dr["PasienID"]),
                            DokterID = Convert.ToInt32(dr["DokterID"]),
                            Keluhan = dr["Keluhan"].ToString(),
                            ResepObat = dr["ResepObat"].ToString(),
                            TotalPay = Convert.ToDecimal(dr["TotalPay"]),
                            Diagnosa = dr["Diagnosa"].ToString(),
                            Tanggal = Convert.ToDateTime(dr["Tanggal"]),
                            Dokter = new Dokter()
                            {
                                DokterID = Convert.ToInt32(dr["DokterID"]),
                                //Email = dr["Email"].ToString(),
                                //IsSpesialis = Convert.ToBoolean(dr["IsSpesialis"]),
                                Nama = dr["NamaDokter"].ToString(),
                                //Password = dr["Password"].ToString(),
                                //Spesialis = dr["Spesialis"].ToString(),
                            },
                            Pasien = new Pasien()
                            {
                                PasienID = Convert.ToInt32(dr["DokterID"]),
                                Nama = dr["NamaPasien"].ToString(),
                            }
                        };
                        konsultasis.Add(konsultasi);
                    }
                }
                return konsultasis;
            }
            
        }

        public IEnumerable<Konsultasi> GetKonsultasiPasienByDokter(int dokterId)
        {
            throw new NotImplementedException();
        }
    }
}
