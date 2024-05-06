using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table("tbl_uye")] //tablo adı
    public class tbl_uye
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //otomatik artan anahtar
        public int  uyeID { get; set; }

        //public virtual int? tarifID { get; set; }

        [Required, StringLength(50)] //zorunlu alan, 50 karakter
        public string uyeKullaniciAd { get; set; }

        [Required, StringLength(50)]
        public string uyeAd { get; set; }

        [Required, StringLength(50)]
        public string uyeSoyad { get; set; }

        [Required, StringLength(50)]
        public string uyeEposta { get; set; }

        [Required, StringLength(50)]
        public string uyeParola { get; set; }

        public int UyeTipi { get; set; }

        //[ForeignKey("tarifID")]
        //public virtual List<tbl_tarif> tarifler { get; set; }

        public List<tbl_yorum> yorumlar { get; set; }
        //public  List<tbl_begeni> begeniler { get; set; }

    }
}