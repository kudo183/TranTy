using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranTy.Entity
{
    public class ChiPhiBep
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ma { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public long ChiPhi { get; set; }

        public int MaVersion { get; set; }
        public int MaBep { get; set; }
        public int MaLoaiChiPhi { get; set; }

        [ForeignKey("MaVersion")]
        public virtual Version Version { get; set; }
        [ForeignKey("MaBep")]
        public virtual Bep Bep { get; set; }
        [ForeignKey("MaLoaiChiPhi")]
        public virtual LoaiChiPhi LoaiChiPhi { get; set; }
    }
}
