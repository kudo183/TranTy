using System.Collections.Generic;
using TranTy.Entity;

namespace TranTy.Dto
{
    public class ChiPhiBepDto : IDto<ChiPhiBep>
    {
        private int _nam;
        private int _thang;
        private long _chiPhi;

        private int _maBep;
        private int _maLoaiChiPhi;

        public int Ma { get; set; }

        public int Nam
        {
            get { return _nam; }
            set
            {
                if (_nam == value)
                    return;

                _nam = value;
                HasChange = true;
            }
        }

        public int Thang
        {
            get { return _thang; }
            set
            {
                if (_thang == value)
                    return;

                _thang = value;
                HasChange = true;
            }
        }

        public long ChiPhi
        {
            get { return _chiPhi; }
            set
            {
                if (_chiPhi == value)
                    return;

                _chiPhi = value;
                HasChange = true;
            }
        }

        public int MaVersion { get; set; }

        public int MaBep
        {
            get { return _maBep; }
            set
            {
                if (_maBep == value)
                    return;

                _maBep = value;
                HasChange = true;
            }
        }

        public int MaLoaiChiPhi
        {
            get { return _maLoaiChiPhi; }
            set
            {
                if (_maLoaiChiPhi == value)
                    return;

                _maLoaiChiPhi = value;
                HasChange = true;
            }
        }

        public VersionDto Version { get; set; }
        public BepDto Bep { get; set; }
        public LoaiChiPhiDto LoaiChiPhi { get; set; }

        public List<VersionDto> Versions { get; set; }
        public List<BepDto> Beps { get; set; }
        public List<LoaiChiPhiDto> LoaiChiPhis { get; set; }

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
