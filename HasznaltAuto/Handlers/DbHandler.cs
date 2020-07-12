using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HasznaltAuto.Models;

namespace HasznaltAuto.Handlers
{
    class DbHandler
    {
        #region DataBase Connection
        private MySqlConnection conn;
        private MySqlConnectionStringBuilder connStr;

        public DbHandler()
        {
            connStr = new MySqlConnectionStringBuilder();
            connStr.Server = "127.0.0.1";
            connStr.UserID = "root";
            connStr.Password = "";
            connStr.Database = "hasznaltautok";

            try
            {
                conn = new MySqlConnection(connStr.ConnectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                DateTime now = DateTime.Now;
                string errorLog = $"hiba: {ex.Message} \n";
                errorLog += $"time of error: {now.ToString("yyyy-mm-dd hh:mm:ss")} \n";
                File.AppendAllText("mysql_error.log", errorLog);
            }
        }
        #endregion

        protected void SetHasznaltauto(Hasznaltauto hasznaltAuto)
        {
            string sql = "INSERT INTO hasznaltautok(AutoGyarto, AutoTipus, HirdetesKod, VetelarHUF, VetelarEUR, EvjaratEv, EvjaratHonap, Allapot, Kivitel, " +
                "KmAllas, SzemelyekSzama, AjtokSzama, Szin, Tomeg, TeljesTomeg, CsomagtartoMeret, KlimaFajta, Uzemanyag, " +
                "Hengerurtartalom, TeljesitmenyKW, TeljesitmenyLE, Hajtas, Sebessegvalto, Okmanyok, MuszakivizsgaEv, " +
                "muszakivizsgaHonap, AbroncsMeret, Link) " +
                "VALUES(@AutoGyarto, @AutoTipus, @HirdetesKod, @VetelarHUF, @VetelarEUR, @EvjaratEv, @EvjaratHonap, @Allapot, @Kivitel, " +
                "@KmAllas, @SzemelyekSzama, @AjtokSzama, @Szin, @Tomeg, @TeljesTomeg, @CsomagtartoMeret, @KlimaFajta, @Uzemanyag, " +
                "@Hengerurtartalom, @TeljesitmenyKW, @TeljesitmenyLE, @Hajtas, @Sebessegvalto, @Okmanyok, @MuszakivizsgaEv, " +
                "@MuszakivizsgaHonap, @AbroncsMeret, @Link)";

            using(MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AutoGyarto", hasznaltAuto.AutoGyarto);
                cmd.Parameters.AddWithValue("@AutoTipus", hasznaltAuto.AutoTipus);
                cmd.Parameters.AddWithValue("@VetelarHUF", hasznaltAuto.VetelarHUF);
                cmd.Parameters.AddWithValue("@VetelarEUR", hasznaltAuto.VetelarEUR);
                cmd.Parameters.AddWithValue("@EvjaratEv", hasznaltAuto.EvjaratEv);
                cmd.Parameters.AddWithValue("@EvjaratHonap", hasznaltAuto.EvjaratHonap);
                cmd.Parameters.AddWithValue("@Allapot", hasznaltAuto.Allapot);
                cmd.Parameters.AddWithValue("@Kivitel", hasznaltAuto.Kivitel);
                cmd.Parameters.AddWithValue("@KmAllas", hasznaltAuto.KmAllas);
                cmd.Parameters.AddWithValue("@SzemelyekSzama", hasznaltAuto.SzemelyekSzama);
                cmd.Parameters.AddWithValue("@AjtokSzama", hasznaltAuto.AjtokSzama);
                cmd.Parameters.AddWithValue("@Szin", hasznaltAuto.Szin);
                cmd.Parameters.AddWithValue("@Tomeg", hasznaltAuto.Tomeg);
                cmd.Parameters.AddWithValue("@TeljesTomeg", hasznaltAuto.TeljesTomeg);
                cmd.Parameters.AddWithValue("@CsomagtartoMeret", hasznaltAuto.CsomagtartoMeret);
                cmd.Parameters.AddWithValue("@KlimaFajta", hasznaltAuto.KlimaFajta);
                cmd.Parameters.AddWithValue("@Uzemanyag", hasznaltAuto.Uzemanyag);
                cmd.Parameters.AddWithValue("@Hengerurtartalom", hasznaltAuto.Hengerurtartalom);
                cmd.Parameters.AddWithValue("@TeljesitmenyKW", hasznaltAuto.TeljesitmenyKW);
                cmd.Parameters.AddWithValue("@TeljesitmenyLE", hasznaltAuto.TeljesitmenyLE);
                cmd.Parameters.AddWithValue("@Hajtas", hasznaltAuto.Hajtas);
                cmd.Parameters.AddWithValue("@Sebessegvalto", hasznaltAuto.Sebessegvalto);
                cmd.Parameters.AddWithValue("@Okmanyok", hasznaltAuto.Okmanyok);
                cmd.Parameters.AddWithValue("@MuszakivizsgaEv", hasznaltAuto.MuszakiVizsgaEv);
                cmd.Parameters.AddWithValue("@MuszakivizsgaHonap", hasznaltAuto.MuszakiVizsgaHonap);
                cmd.Parameters.AddWithValue("@AbroncsMeret", hasznaltAuto.AbroncsMeret);
                cmd.Parameters.AddWithValue("@Link", hasznaltAuto.Link);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
