using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table("tbl_tarif")]
    public class tbl_tarif
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //otomatik artan anahtar
        public int tarifID { get; set; }

        public virtual int? uyeID { get; set; }

        [StringLength(60)]
        public string baslik { get; set; }

        [StringLength(500)]
        public string malzemeler { get; set; }

        [StringLength(500)]
        public string metin { get; set; }

        public string resim { get; set; }

        public virtual int? kategoriID{ get; set; } // KategoriID'yi ekledik. Sana zahmrt veritabanını tekrar kur
        [ForeignKey("kategoriID")]
        public virtual tbl_kategori kategori { get; set; }

        [ForeignKey("uyeID")]
        public virtual tbl_uye sahip { get; set; }

        public  List<tbl_yorum> yorumlar { get; set; }
        public  List<tbl_begeni> begeniler { get; set; }

    }
}
