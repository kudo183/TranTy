using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranTy.Entity
{
    public class LoaiChiPhi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ma { get; set; }
        public string Ten { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTaoUtc { get; set; }

        public virtual List<ChiPhiBep> ChiPhiBeps { get; set; }
    }
}
