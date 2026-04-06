using NAudio.Vorbis;
using NAudio.Wave;
using System.Reflection.PortableExecutable;

namespace Limbus_Combat_Console
{
    class Audio
    {
        private VorbisWaveReader? _reader;
        private WaveOutEvent? _wave;
        public bool is_loop { get; set; }

        public Audio(string path, bool is_loop = false)
        {
            _reader = new VorbisWaveReader(path);
            _wave = new WaveOutEvent();
            _wave.Init(_reader);
            this.is_loop = is_loop;
        }

        public void Play()
        {
            _wave.PlaybackStopped += _wave_PlaybackStopped;
            _wave.Play();
        }

        public void Pause()
        {
            _wave.PlaybackStopped -= _wave_PlaybackStopped;
            _wave.Pause();
        }

        //public void Stop()
        //{
        //    _wave.PlaybackStopped -= _wave_PlaybackStopped;
        //    _wave.Stop();
        //    if (_reader != null) { _reader.Dispose(); }
        //    _reader = null;
        //}

        //public void Load(string path)
        //{
        //    if (_wave.PlaybackState == PlaybackState.Playing)
        //    {
        //        throw new Exception("[ERROR]Audio Still Playing.");
        //    }
        //    if (_reader != null) { _reader.Dispose(); }
        //    _reader = null;
        //    _reader = new VorbisWaveReader(path);
        //}

        private void _wave_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            _reader.CurrentTime = TimeSpan.Zero;
            if (!is_loop)
            {
                _wave.Dispose();
                _wave = null;
                _reader.Dispose();
                _reader = null;
            }
            else
            {
                Play();
            }
        }
    }
}
