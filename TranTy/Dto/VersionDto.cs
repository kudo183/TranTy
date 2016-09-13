using System;
using Version = TranTy.Entity.Version;

namespace TranTy.Dto
{
    public class VersionDto : IDto<Version>
    {
        private string _ten;
        private string _ghiChu;
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

        public string GhiChu
        {
            get { return _ghiChu; }
            set
            {
                if (_ghiChu == value)
                    return;

                _ghiChu = value;
                HasChange = true;
            }
        }

        public DateTime NgayTaoUtc { get; set; }
        public DateTime NgayTaoLocal { get { return NgayTaoUtc.ToLocalTime(); } }

        public VersionDto()
        {
            NgayTaoUtc = DateTime.UtcNow;
        }

        #region Implementation of IDto<Version>

        public bool HasChange { get; set; }

        public int GetKey()
        {
            return Ma;
        }

        public void FromEntity(Version entity)
        {
            Ma = entity.Ma;
            _ten = entity.Ten;
            NgayTaoUtc = new DateTime(entity.NgayTaoUtc.Ticks, DateTimeKind.Utc);
            _ghiChu = entity.GhiChu;
        }

        public Version ToEntity()
        {
            return new Version()
            {
                Ma = Ma,
                Ten = Ten,
                NgayTaoUtc = NgayTaoUtc,
                GhiChu = GhiChu
            };
        }

        #endregion

        public string ToShortString()
        {
            return string.Format("{0} - {1} - {2}", Ten, GhiChu, NgayTaoUtc);
        }

        public override string ToString()
        {
            return string.Format("VersionDto: {0} - {1} - {2} - {3}", Ma, Ten, GhiChu, NgayTaoUtc);
        }
    }
}
