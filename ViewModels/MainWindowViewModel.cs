using System;
using LibVLCSharp.Shared;

namespace LibVLCSharp.Avalonia.Sample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private readonly LibVLC _libVlc = new LibVLC();
        public MainWindowViewModel()
        {
            MediaPlayer = new MediaPlayer(_libVlc);
            _libVlc.Log += _libVlc_Log;
        }

        private void _libVlc_Log(object sender, LogEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void Play()
        {
            using var media = new Media(_libVlc, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            MediaPlayer.Play(media);
        }

        public MediaPlayer MediaPlayer { get; }

        public void Dispose()
        {
            MediaPlayer?.Dispose();
            _libVlc?.Dispose();
        }
    }
}
