
namespace LBFVideoLib.Common
{
    public class BackgroundProcessData
    {
        public VideoInfo CurrentVideoInfo { get; set; } = new VideoInfo();
        public string OrignalVideoPath { get; set; } = "";
        public string DecryptedVideoPath { get; set; } = "";
        public BackgroundAppState State { get; set; }
    }

    public enum BackgroundAppState
    {
        DecryptingVideoToPlay = 1,
        OnUpcomingFormHideOrClosing = 2,
        RegisterCliet=3,
    }
}
