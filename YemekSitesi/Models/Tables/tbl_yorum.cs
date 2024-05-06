using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table("tbl_yorum")]
    public class tbl_yorum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //otomatik artan anahtar
        public int yorumID { get; set; }

        [Required, StringLength(200)]
        public string yorum { get; set; }

        public int uyeID { get; set; } // KategoriID'yi ekledik.
        public int tarifID { get; set; } // KategoriID'yi ekledik.


        
        public tbl_uye sahip { get; set; }

        public tbl_tarif tarifler { get; set; }
    }
}