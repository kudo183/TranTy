using System.Collections.Generic;

namespace TranTy
{
    public class TextManager
    {
        #region LanguageCode
        public const string VN = "vn";
        public const string EN = "en";
        public const string KR = "kr";

        private static string _languageCode = VN;
        public static string LanguageCode
        {
            get { return _languageCode; }
            set { _languageCode = value; }
        }
        #endregion

        #region text key
        public const string MainWindow_Title = "MainWindow_Title";
        public const string MainWindow_TabItemHeader_Version = "MainWindow_TabItem_Version";
        public const string MainWindow_TabItemHeader_Bep = "MainWindow_TabItem_Bep";
        public const string MainWindow_TabItemHeader_LoaiChiPhi = "MainWindow_TabItem_LoaiChiPhi";
        public const string MainWindow_TabItemHeader_ChiPhiBep = "MainWindow_TabItem_ChiPhiBep";

        public const string VersionView_Column_Ten = "VersionView_Column_Ten";
        public const string VersionView_Column_GhiChu = "VersionView_Column_GhiChu";
        public const string VersionView_Column_NgayTao = "VersionView_Column_NgayTao";

        public const string VersionView_Button_ChonVersion = "VersionView_Button_ChonVersion";
        #endregion

        #region text property
        public static string Text_MainWindow_Title { get { return GetText(MainWindow_Title); } }
        public static string Text_MainWindow_TabItemHeader_Version { get { return GetText(MainWindow_TabItemHeader_Version); } }
        public static string Text_MainWindow_TabItemHeader_Bep { get { return GetText(MainWindow_TabItemHeader_Bep); } }
        public static string Text_MainWindow_TabItemHeader_LoaiChiPhi { get { return GetText(MainWindow_TabItemHeader_LoaiChiPhi); } }
        public static string Text_MainWindow_TabItemHeader_ChiPhiBep { get { return GetText(MainWindow_TabItemHeader_ChiPhiBep); } }

        public static string Text_VersionView_Column_Ten { get { return GetText(VersionView_Column_Ten); } }
        public static string Text_VersionView_Column_GhiChu { get { return GetText(VersionView_Column_GhiChu); } }
        public static string Text_VersionView_Column_NgayTao { get { return GetText(VersionView_Column_NgayTao); } }
        public static string Text_VersionView_Button_ChonVersion { get { return GetText(VersionView_Button_ChonVersion); } }
        #endregion

        #region define text collection
        private static Dictionary<string, string> _vnTexts = new Dictionary<string, string>()
        {
            {MainWindow_Title, "chọn Version để dùng hết tính năng" },
            {MainWindow_TabItemHeader_Version, "Version" },
            {MainWindow_TabItemHeader_Bep, "Bep" },
            {MainWindow_TabItemHeader_LoaiChiPhi, "Loại CP" },
            {MainWindow_TabItemHeader_ChiPhiBep, "CP Bếp" },

            {VersionView_Column_Ten, "Tên" },
            {VersionView_Column_GhiChu, "Ghi Chú" },
            {VersionView_Column_NgayTao, "Ngày Tạo" },
            {VersionView_Button_ChonVersion, "Chọn Version" },
        };

        private static Dictionary<string, string> _enTexts = new Dictionary<string, string>()
        {
            {MainWindow_Title, "select Version to enable all function" },
            {MainWindow_TabItemHeader_Version, "Version" },
            {MainWindow_TabItemHeader_Bep, "Kitchen" },
            {MainWindow_TabItemHeader_LoaiChiPhi, "Cost Type" },
            {MainWindow_TabItemHeader_ChiPhiBep, "Kitchen Cost" },

            {VersionView_Column_Ten, "Name" },
            {VersionView_Column_GhiChu, "Note" },
            {VersionView_Column_NgayTao, "Create Date" },
            {VersionView_Button_ChonVersion, "Select Version" },
        };

        private static Dictionary<string, string> _krTexts = new Dictionary<string, string>()
        {
            {"","" }
        };

        private static Dictionary<string, Dictionary<string, string>> _texts = new Dictionary<string, Dictionary<string, string>>()
        {
            { VN, _vnTexts },
            { EN, _enTexts },
            { KR, _krTexts },
        };
        #endregion

        private static string GetText(string key)
        {
            return _texts[LanguageCode][key];
        }
    }
}
