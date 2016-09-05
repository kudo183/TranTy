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
        public virtual Version Version { get; set; }
        public virtual Bep Bep { get; set; }
        public virtual LoaiChiPhi LoaChiPhi { get; set; }
    }
}
