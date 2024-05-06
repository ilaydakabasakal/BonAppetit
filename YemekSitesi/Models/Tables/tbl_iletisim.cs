using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table("tbl_iletisim")] //tablo adı

    public class tbl_iletisim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //otomatik artan anahtar
        public int mesajID { get; set; }

        [Required, StringLength(50)] //zorunlu alan, 50 karakter
        public string mesajAd { get; set; }

        [Required, StringLength(50)]
        public string mesajSoyad { get; set; }

        [Required, StringLength(50)]
        public string mesajEposta { get; set; }

        [Required, StringLength(150)]
        public string mesaj { get; set; }

    }
}
