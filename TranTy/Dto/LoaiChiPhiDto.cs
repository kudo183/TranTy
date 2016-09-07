using System;
using TranTy.Entity;

namespace TranTy.Dto
{
    public class LoaiChiPhiDto : IDto<LoaiChiPhi>
    {
        private string _ten;
        public int Ma { get; set; }

        public string Ten
        {
            get { return _ten; }
            set
            {
                if (_ten == value)
                    return;

                _ten = value;
                HasChange = true;
            }
        }

        public DateTime NgayTaoUtc { get; set; }
        public DateTime NgayTaoLocal { get { return NgayTaoUtc.ToLocalTime(); } }

        public LoaiChiPhiDto()
        {
            NgayTaoUtc = DateTime.UtcNow;
        }

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
