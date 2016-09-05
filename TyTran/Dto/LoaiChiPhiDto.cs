using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTy.Entity;

namespace TranTy.Dto
{
    public class LoaiChiPhiDto : IDto<LoaiChiPhi>
    {
        public int Ma { get; set; }
        public string Ten { get; set; }
        public DateTime NgayTaoUtc { get; set; }

        #region Implementation of IDto<LoaiChiPhi>

        public bool HasChange { get; set; }

        public int GetKey()
        {
            return Ma;
        }

        public void FromEntity(LoaiChiPhi entity)
        {
            Ma = entity.Ma;
            Ten = entity.Ten;
            NgayTaoUtc = entity.NgayTaoUtc;
        }

        public LoaiChiPhi ToEntity()
        {
            return new LoaiChiPhi()
                       {
                           Ma = Ma,
                           Ten = Ten,
                           NgayTaoUtc = NgayTaoUtc
                       };
        }

        #endregion
    }
}
