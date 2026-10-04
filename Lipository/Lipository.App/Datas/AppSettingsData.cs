// ======================================================================================================
// File Name        : AppSettingsData.cs
// Project          : Lipository.App
// Last Update      : 2026.10.04 - yc.jeon (Eskeptor)
// ======================================================================================================

namespace Lipository.App.Datas
{
    /// <summary>
    /// JSON으로 직렬화/역직렬화되는 설정 데이터 모델.
    /// 기존 Properties.Settings(System.Configuration) 기반 저장 방식을 대체합니다.
    /// </summary>
    public class AppSettingsData
    {
        public bool IsFirstRun { get; set; } = true;

        public int TotalInfoWidth { get; set; } = 240;
        public int TotalInfoHeight { get; set; } = 340;

        public int ImageInfoWidth { get; set; } = 220;
        public int ImageInfoHeight { get; set; } = 165;
        public int ImageInfoXPos { get; set; } = 9;
        public int ImageInfoYPos { get; set; } = 9;
        public bool ImageInfoVisible { get; set; } = true;

        public string TitleInfoText { get; set; } = string.Empty;
        public int TitleInfoXPos { get; set; } = 7;
        public int TitleInfoYPos { get; set; } = 175;
        public bool TitleInfoVisible { get; set; } = true;

        public string SubTitleInfoText { get; set; } = string.Empty;
        public int SubTitleInfoXPos { get; set; } = 7;
        public int SubTitleInfoYPos { get; set; } = 200;
        public bool SubTitleInfoVisible { get; set; } = true;

        public string RateInfoText { get; set; } = string.Empty;
        public int RateInfoXPos { get; set; } = 125;
        public int RateInfoYPos { get; set; } = 200;
        public bool RateInfoVisible { get; set; } = true;

        public string Etc1InfoText { get; set; } = string.Empty;
        public int Etc1InfoXPos { get; set; } = 7;
        public int Etc1InfoYPos { get; set; } = 215;
        public bool Etc1InfoVisible { get; set; } = true;

        public string Etc2InfoText { get; set; } = string.Empty;
        public int Etc2InfoXPos { get; set; } = 7;
        public int Etc2InfoYPos { get; set; } = 230;
        public bool Etc2InfoVisible { get; set; } = true;

        public string Etc3InfoText { get; set; } = string.Empty;
        public int Etc3InfoXPos { get; set; } = 7;
        public int Etc3InfoYPos { get; set; } = 245;
        public bool Etc3InfoVisible { get; set; } = true;

        public string Etc4InfoText { get; set; } = string.Empty;
        public int Etc4InfoXPos { get; set; } = 7;
        public int Etc4InfoYPos { get; set; } = 260;
        public bool Etc4InfoVisible { get; set; } = true;

        public string MemoInfoText { get; set; } = string.Empty;
        public int MemoInfoXPos { get; set; } = 7;
        public int MemoInfoYPos { get; set; } = 275;
        public bool MemoInfoVisible { get; set; } = true;

        public string ReleaseInfoText { get; set; } = string.Empty;
        public int ReleaseInfoXPos { get; set; } = 7;
        public int ReleaseInfoYPos { get; set; } = 290;
        public bool ReleaseInfoVisible { get; set; } = true;

        public string LastInfoText { get; set; } = string.Empty;
        public int LastInfoXPos { get; set; } = 7;
        public int LastInfoYPos { get; set; } = 305;
        public bool LastInfoVisible { get; set; } = true;

        public string MediaExtensions { get; set; } = "avi,mp4,wmv,mpg,mkv,mov,ts,tp,flv";
        public string ImageExtensions { get; set; } = "jpg,jpeg,png,bmp";
        public string DefaultImagePath { get; set; } = string.Empty;
    }
}
