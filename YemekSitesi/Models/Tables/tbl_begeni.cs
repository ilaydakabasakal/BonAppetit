using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekSitesi.Models.Tables
{
    [Table("tbl_begeni")]
    public class tbl_begeni
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int begeniID { get; set; }

        public virtual int? tarifID { get; set; }
        public virtual int uyeID { get; set; }

        [ForeignKey("uyeID")]
        public virtual tbl_uye begenenUye { get; set; }
 
        [ForeignKey("tarifID")]
        public virtual tbl_tarif tarifler { get; set; }

    }

}