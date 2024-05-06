using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table ("tbl_kategori")]
    public class tbl_kategori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kategoriID { get; set; }

        [Required,StringLength(50)]
        public string kategoriAd { get; set; }

        //public virtual int? tarifID { get; set; }
        //[ForeignKey("tarifID")]
        //public  List<tbl_tarif> tarifler { get; set; } 
    }
}