using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_classbasics
{
    class Preferences
    {
        bool _autoPlay;
        double _volumeLevel;

        public bool GetAutoPlay()
        {
            return _autoPlay;
        }
        public bool SetAutoPlay(bool autoplay)
        {
            _autoPlay = autoplay;
            return _autoPlay;
        }
        public double SetVolumeLevel(double volumLevel)
        {
            _volumeLevel = volumLevel;
            return _volumeLevel;
        }
        public double GetVolumeLevel()
        {
            return _volumeLevel;
        }
        public Preferences(bool autoPlay, double volumeLevel)
        {
            _volumeLevel = volumeLevel;
            _autoPlay = autoPlay;
        }
    }
}
