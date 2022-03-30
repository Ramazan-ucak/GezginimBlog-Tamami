using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }
        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Email = @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID, YoneticiTurID, Isim, Soyad, Email, Sifre, Durum FROM Yoneticiler WHERE Email = @m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyad = reader.GetString(3);
                        y.Email = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }



        #endregion

        #region Şehir Metotları

        public bool SehirEkle(Sehir s)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Sehirler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", s.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Sehir> SehirListele()
        {
            try
            {
                List<Sehir> sehirler = new List<Sehir>();
                cmd.CommandText = "SELECT ID, Isim FROM Sehirler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sehir s = new Sehir();
                    s.ID = reader.GetInt32(0);
                    s.Isim = reader.GetString(1);
                    sehirler.Add(s);
                }
                return sehirler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SehirSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Sehirler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
                
        }

        public Sehir SehirGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Sehirler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Sehir s = new Sehir();
                while (reader.Read())
                {
                    s.ID = reader.GetInt32(0);
                    s.Isim = reader.GetString(1);
                }
                return s;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool SehirGuncelle(Sehir s)
        {
            try
            {
                cmd.CommandText = "UPDATE Sehirler SET Isim = @i WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", s.Isim);
                cmd.Parameters.AddWithValue("@id", s.ID);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool DeneyimEkle(Deneyim dn)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Deneyimler(SehirID, YazarID, Baslik, Onyazi, Icerik, GeziResim, GoruntulemeSayisi, EklemeTarihi, Durum) VALUES(@sehirID, @yazarID ,@baslik, @onyazi, @icerik, @geziresim, @goruntulemesayisi, @eklemetarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sehirID", dn.Sehir_ID);
                cmd.Parameters.AddWithValue("@yazarID", dn.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", dn.Baslik);
                cmd.Parameters.AddWithValue("@onyazi", dn.Onyazi);
                cmd.Parameters.AddWithValue("@icerik", dn.Icerik);
                cmd.Parameters.AddWithValue("@geziresim", dn.GeziResim);
                cmd.Parameters.AddWithValue("@goruntulemesayisi", dn.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@eklemetarihi", dn.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", dn.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Deneyim> DeneyimListele()
        {
            try
            {
                List<Deneyim> deneyimler = new List<Deneyim>();
                cmd.CommandText = "SELECT D.ID, D.SehirID, S.Isim, D.YazarID, Y.Isim+ ' '+Y.Soyad, D.Baslik, D.Onyazi, D.Icerik, D.GeziResim, D.GoruntulemeSayisi, D.EklemeTarihi, D.Durum FROM Deneyimler AS D JOIN Sehirler AS S ON S.ID = D.SehirID JOIN Yoneticiler AS Y ON Y.ID = D.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Deneyim d = new Deneyim();
                    d.ID = reader.GetInt32(0);
                    d.Sehir_ID = reader.GetInt32(1);
                    d.Sehir = reader.GetString(2);
                    d.Yazar_ID = reader.GetInt32(3);
                    d.Yazar = reader.GetString(4);
                    d.Baslik = reader.GetString(5);
                    d.Onyazi = reader.GetString(6);
                    d.Icerik = reader.GetString(7);
                    d.GeziResim = reader.GetString(8);
                    d.GoruntulemeSayisi = reader.GetInt32(9);
                    d.EklemeTarih = reader.GetDateTime(10);
                    d.Durum = reader.GetBoolean(11);
                    deneyimler.Add(d);

                }
                return deneyimler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }



        public List<Deneyim> DeneyimListele(int shrID)
        {
            try
            {
                List<Deneyim> deneyimler = new List<Deneyim>();
                cmd.CommandText = "SELECT D.ID, D.SehirID, S.Isim, D.YazarID, Y.Isim+ ' '+Y.Soyad, D.Baslik, D.Onyazi, D.Icerik, D.GeziResim, D.GoruntulemeSayisi, D.EklemeTarihi, D.Durum FROM Deneyimler AS D JOIN Sehirler AS S ON S.ID = D.SehirID JOIN Yoneticiler AS Y ON Y.ID = D.YazarID WHERE D.SehirID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", shrID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Deneyim d = new Deneyim();
                    d.ID = reader.GetInt32(0);
                    d.Sehir_ID = reader.GetInt32(1);
                    d.Sehir = reader.GetString(2);
                    d.Yazar_ID = reader.GetInt32(3);
                    d.Yazar = reader.GetString(4);
                    d.Baslik = reader.GetString(5);
                    d.Onyazi = reader.GetString(6);
                    d.Icerik = reader.GetString(7);
                    d.GeziResim = reader.GetString(8);
                    d.GoruntulemeSayisi = reader.GetInt32(9);
                    d.EklemeTarih = reader.GetDateTime(10);
                    d.Durum = reader.GetBoolean(11);
                    deneyimler.Add(d);

                }
                return deneyimler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }




        public bool DeneyimDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Deneyimler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum =(bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Deneyimler SET Durum=@d WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }

        }

        public bool DeneyimSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Deneyimler WHERE ID =@id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Deneyim DeneyimGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT D.ID, D.SehirID, S.Isim, D.YazarID, Y.Isim+ ' '+Y.Soyad, D.Baslik, D.Onyazi, D.Icerik, D.GeziResim, D.GoruntulemeSayisi, D.EklemeTarihi, D.Durum FROM Deneyimler AS D JOIN Sehirler AS S ON S.ID = D.SehirID JOIN Yoneticiler AS Y ON Y.ID = D.YazarID WHERE D.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Deneyim d = new Deneyim();
                while (reader.Read())
                {
                    d.ID = reader.GetInt32(0);
                    d.Sehir_ID = reader.GetInt32(1);
                    d.Sehir = reader.GetString(2);
                    d.Yazar_ID = reader.GetInt32(3);
                    d.Yazar = reader.GetString(4);
                    d.Baslik = reader.GetString(5);
                    d.Onyazi = reader.GetString(6);
                    d.Icerik = reader.GetString(7);
                    d.GeziResim = reader.GetString(8);
                    d.GoruntulemeSayisi = reader.GetInt32(9);
                    d.EklemeTarih = reader.GetDateTime(10);
                    d.Durum = reader.GetBoolean(11);
                }
                return d;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeneyimGuncelle(Deneyim dn)
        {
            try
            {
                cmd.CommandText = "UPDATE Deneyimler SET SehirID = @sehirID, Baslik = @baslik, Onyazi = @onyazi, Icerik = @icerik, GeziResim = @geziresim, Durum = @durum WHERE ID = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", dn.ID);
                cmd.Parameters.AddWithValue("@sehirID", dn.Sehir_ID);
                cmd.Parameters.AddWithValue("@baslik", dn.Baslik);
                cmd.Parameters.AddWithValue("@onyazi", dn.Onyazi);
                cmd.Parameters.AddWithValue("@icerik", dn.Icerik);
                cmd.Parameters.AddWithValue("@geziresim", dn.GeziResim);
                cmd.Parameters.AddWithValue("@durum", dn.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Uye Metotları

        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email= @m AND Sifre= @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());


                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyad, Email, Sifre, UyelikTarihi, Durum FROM Uyeler WHERE Email= @m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();

                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyad = reader.GetString(2);
                        u.Mail = reader.GetString(3);
                        u.Sifre = reader.GetString(4);
                        u.UyelikTarihi = reader.GetDateTime(5);
                        u.Durum = reader.GetBoolean(6);
                    }
                    return u;

                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Yorum Metotları

        public  List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();

            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.Isim, Y.DeneyimID, D.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y. UyeID JOIN Deneyimler AS D ON D.ID = Y.DeneyimID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.DeneyimID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }



        public List<Yorum> YorumListele(int Did)
        {
            List<Yorum> yorumlar = new List<Yorum>();

            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.Isim, Y.DeneyimID, D.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y. UyeID JOIN Deneyimler AS D ON D.ID = Y.DeneyimID WHERE Y.DeneyimID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Did);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.DeneyimID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(bool onay)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.Isim, Y.DeneyimID, D.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y. UyeID JOIN Deneyimler AS D ON D.ID = Y.DeneyimID WHERE  Y.OnayDurum = @d";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", onay);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.DeneyimID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            
        }

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(UyeID, DeneyimID, Icerik, YorumTarih, OnayDurum) VALUES(@uyeID, @deneyimID, @icerik, @yorumtarih, @onaydurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@deneyimID", y.DeneyimID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumtarih", y.Tarih);
                cmd.Parameters.AddWithValue("@onaydurum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }

        #endregion

        #region Kayıt ol

        public bool UyeEkle(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, Soyad, Email, Sifre, UyelikTarihi, Durum) VALUES(@is, @soy, @em, @sif, @uyelik, @dur)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@is", u.Isim);
                cmd.Parameters.AddWithValue("@soy", u.Soyad);
                cmd.Parameters.AddWithValue("@em", u.Mail);
                cmd.Parameters.AddWithValue("@sif", u.Sifre);
                cmd.Parameters.AddWithValue("@uyelik", u.UyelikTarihi);
                cmd.Parameters.AddWithValue("@dur", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }




        #endregion
    }
}
