using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using YemekSitesi.Models.Tables;


namespace YemekSitesi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<tbl_uye> uyeTable { get; set; }
        public DbSet<tbl_tarif> tarifTABLE { get; set; }
        public DbSet<tbl_kategori> kategoriTABLE { get; set; }
        public DbSet<tbl_yorum> yorumTable { get; set; }
        public DbSet<tbl_begeni> begeniTABLE { get; set; }
        public DbSet<tbl_iletisim> iletisimTABLE { get; set; }

    }
}