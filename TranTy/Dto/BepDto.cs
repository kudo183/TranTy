using System;
using TranTy.Entity;

namespace TranTy.Dto
{
    public class BepDto : IDto<Bep>
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

        public BepDto()
        {
            NgayTaoUtc = DateTime.UtcNow;
        }

        #region Implementation of IDto<Bep>

        public bool HasChange { get; set; }

        public int GetKey()
        {
            return Ma;
        }

        public void FromEntity(Bep entity)
        {
            Ma = entity.Ma;
            Ten = entity.Ten;
            NgayTaoUtc = entity.NgayTaoUtc;
        }

        public Bep ToEntity()
        {
            return new Bep()
            {
                Ma = Ma,
                Ten = Ten,
                NgayTaoUtc = NgayTaoUtc
            };
        }

        #endregion
    }
}
