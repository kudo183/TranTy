﻿using System.Collections.Generic;

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
        public const string VersionChooserWindow_Title = "VersionChooserWindow_Title";
        public const string MainWindow_TabItemHeader_Version = "MainWindow_TabItem_Version";
        public const string MainWindow_TabItemHeader_Bep = "MainWindow_TabItem_Bep";
        public const string MainWindow_TabItemHeader_LoaiChiPhi = "MainWindow_TabItem_LoaiChiPhi";
        public const string MainWindow_TabItemHeader_ChiPhiBep = "MainWindow_TabItem_ChiPhiBep";

        public const string VersionView_Column_Ten = "VersionView_Column_Ten";
        public const string VersionView_Column_GhiChu = "VersionView_Column_GhiChu";
        public const string VersionView_Column_NgayTao = "VersionView_Column_NgayTao";
        public const string VersionView_Button_ChonVersion = "VersionView_Button_ChonVersion";

        public const string BepView_Column_Ten = "BepView_Column_Ten";
        public const string BepView_Column_NgayTao = "BepView_Column_NgayTao";

        public const string LoaiChiPhiView_Column_Ten = "LoaiChiPhiView_Column_Ten";
        public const string LoaiChiPhiView_Column_NgayTao = "LoaiChiPhiView_Column_NgayTao";

        public const string ChiPhiBepView_Column_Thang = "ChiPhiBepView_Column_Thang";
        public const string ChiPhiBepView_Column_Nam = "ChiPhiBepView_Column_Nam";
        public const string ChiPhiBepView_Column_Bep = "ChiPhiBepView_Column_Bep";
        public const string ChiPhiBepView_Column_LoaiChiPhi = "ChiPhiBepView_Column_LoaiChiPhi";
        public const string ChiPhiBepView_Column_ChiPhi = "ChiPhiBepView_Column_ChiPhi";
        public const string ChiPhiBepView_Button_ChonVersion = "ChiPhiBepView_Button_ChonVersion";
        public const string ChiPhiBepView_Button_ThemVersion = "ChiPhiBepView_Button_ThemVersion";
        public const string ChiPhiBepView_Button_Import_FromExcel = "ChiPhiBepView_Button_Import_FromExcel";
        public const string ChiPhiBepView_Button_Import_FromVersion = "ChiPhiBepView_Button_Import_FromVersion";
        public const string ChiPhiBepView_Msg_Import_FromExcel_Confirm = "ChiPhiBepView_Msg_Import_FromExcel_Confirm";
        public const string ChiPhiBepView_Msg_Import_FromVersion_Confirm = "ChiPhiBepView_Msg_Import_FromVersion_Confirm";
        public const string ChiPhiBepView_Msg_Import_FromVersion_SameVersion = "ChiPhiBepView_Msg_Import_FromVersion_SameVersion";
        #endregion

        #region text property
        public static string Text_MainWindow_Title { get { return GetText(MainWindow_Title); } }
        public static string Text_MainWindow_TabItemHeader_Version { get { return GetText(MainWindow_TabItemHeader_Version); } }
        public static string Text_MainWindow_TabItemHeader_Bep { get { return GetText(MainWindow_TabItemHeader_Bep); } }
        public static string Text_MainWindow_TabItemHeader_LoaiChiPhi { get { return GetText(MainWindow_TabItemHeader_LoaiChiPhi); } }
        public static string Text_MainWindow_TabItemHeader_ChiPhiBep { get { return GetText(MainWindow_TabItemHeader_ChiPhiBep); } }

        public static string Text_VersionChooserWindow_Title { get { return GetText(VersionChooserWindow_Title); } }

        public static string Text_VersionView_Column_Ten { get { return GetText(VersionView_Column_Ten); } }
        public static string Text_VersionView_Column_GhiChu { get { return GetText(VersionView_Column_GhiChu); } }
        public static string Text_VersionView_Column_NgayTao { get { return GetText(VersionView_Column_NgayTao); } }
        public static string Text_VersionView_Button_ChonVersion { get { return GetText(VersionView_Button_ChonVersion); } }

        public static string Text_BepView_Column_Ten { get { return GetText(BepView_Column_Ten); } }
        public static string Text_BepView_Column_NgayTao { get { return GetText(BepView_Column_NgayTao); } }

        public static string Text_LoaiChiPhiView_Column_Ten { get { return GetText(LoaiChiPhiView_Column_Ten); } }
        public static string Text_LoaiChiPhiView_Column_NgayTao { get { return GetText(LoaiChiPhiView_Column_NgayTao); } }

        public static string Text_ChiPhiBepView_Column_Thang { get { return GetText(ChiPhiBepView_Column_Thang); } }
        public static string Text_ChiPhiBepView_Column_Nam { get { return GetText(ChiPhiBepView_Column_Nam); } }
        public static string Text_ChiPhiBepView_Column_Bep { get { return GetText(ChiPhiBepView_Column_Bep); } }
        public static string Text_ChiPhiBepView_Column_LoaiChiPhi { get { return GetText(ChiPhiBepView_Column_LoaiChiPhi); } }
        public static string Text_ChiPhiBepView_Column_ChiPhi { get { return GetText(ChiPhiBepView_Column_ChiPhi); } }
        public static string Text_ChiPhiBepView_Button_ChonVersion { get { return GetText(ChiPhiBepView_Button_ChonVersion); } }
        public static string Text_ChiPhiBepView_Button_ThemVersion { get { return GetText(ChiPhiBepView_Button_ThemVersion); } }
        public static string Text_ChiPhiBepView_Button_Import_FromExcel { get { return GetText(ChiPhiBepView_Button_Import_FromExcel); } }
        public static string Text_ChiPhiBepView_Button_Import_FromVersion { get { return GetText(ChiPhiBepView_Button_Import_FromVersion); } }
        public static string Text_ChiPhiBepView_Msg_Import_FromExcel_Confirm { get { return GetText(ChiPhiBepView_Msg_Import_FromExcel_Confirm); } }
        public static string Text_ChiPhiBepView_Msg_Import_FromVersion_Confirm { get { return GetText(ChiPhiBepView_Msg_Import_FromVersion_Confirm); } }
        public static string Text_ChiPhiBepView_Msg_Import_FromVersion_SameVersion { get { return GetText(ChiPhiBepView_Msg_Import_FromVersion_SameVersion); } }
        #endregion

        #region define text collection
        private static Dictionary<string, string> _vnTexts = new Dictionary<string, string>()
        {
            {MainWindow_Title, "chọn Version để dùng hết tính năng" },
            {MainWindow_TabItemHeader_Version, "Version" },
            {MainWindow_TabItemHeader_Bep, "Bếp" },
            {MainWindow_TabItemHeader_LoaiChiPhi, "Loại CP" },
            {MainWindow_TabItemHeader_ChiPhiBep, "CP Bếp" },

            {VersionChooserWindow_Title, "chọn Version để lấy dữ liệu" },

            {VersionView_Column_Ten, "Tên" },
            {VersionView_Column_GhiChu, "Ghi Chú" },
            {VersionView_Column_NgayTao, "Ngày Tạo" },
            {VersionView_Button_ChonVersion, "Chọn Version" },

            {BepView_Column_Ten, "Tên" },
            {BepView_Column_NgayTao, "Ngày Tạo" },

            {LoaiChiPhiView_Column_Ten, "Tên" },
            {LoaiChiPhiView_Column_NgayTao, "Ngày Tạo" },

            {ChiPhiBepView_Column_Thang, "Tháng" },
            {ChiPhiBepView_Column_Nam, "Năm" },
            {ChiPhiBepView_Column_Bep, "Bếp" },
            {ChiPhiBepView_Column_LoaiChiPhi, "Loại CP" },
            {ChiPhiBepView_Column_ChiPhi, "Chi phí" },
            {ChiPhiBepView_Button_ChonVersion, "Chọn Version" },
            {ChiPhiBepView_Button_ThemVersion, "Thêm Version" },
            {ChiPhiBepView_Button_Import_FromExcel, "Nhập từ file Excel" },
            {ChiPhiBepView_Button_Import_FromVersion, "Nhập từ Version khác" },
            {ChiPhiBepView_Msg_Import_FromExcel_Confirm, "Dữ liệu từ file {0} sẽ ghi đè dữ liệu hiện tại\nBạn có chắc mình muốn tiếp tục không ?" },
            {ChiPhiBepView_Msg_Import_FromVersion_Confirm, "Dữ liệu từ Version {0} sẽ ghi đè dữ liệu hiện tại\nBạn có chắc mình muốn tiếp tục không ?" },
            {ChiPhiBepView_Msg_Import_FromVersion_SameVersion, "Version đã chọn chính là Version hiện tại, vui lòng chọn Version khác" },
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
