using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTy.Entity;

namespace TranTy.Dto
{
    public class ChiPhiBepDto : IDto<ChiPhiBep>
    {
        public int Ma { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public long ChiPhi { get; set; }

        public int MaVersion { get; set; }
        public int MaBep { get; set; }
        public int MaLoaiChiPhi { get; set; }

        #region Implementation of IDto<ChiPhiBep>

        public bool HasChange { get; set; }

        public int GetKey()
        {
            return Ma;
        }

        public void FromEntity(ChiPhiBep entity)
        {
            Ma = entity.Ma;
            Nam = entity.Nam;
            Thang = entity.Thang;
            ChiPhi = entity.ChiPhi;
            MaVersion = entity.MaVersion;
            MaBep = entity.MaBep;
            MaLoaiChiPhi = entity.MaLoaiChiPhi;
        }

        public ChiPhiBep ToEntity()
        {
            return new ChiPhiBep()
                       {
                           Ma = Ma,
                           Nam = Nam,
                           Thang = Thang,
                           ChiPhi = ChiPhi,
                           MaVersion = MaVersion,
                           MaBep = MaBep,
                           MaLoaiChiPhi = MaLoaiChiPhi
                       };
        }

        #endregion
    }
}
