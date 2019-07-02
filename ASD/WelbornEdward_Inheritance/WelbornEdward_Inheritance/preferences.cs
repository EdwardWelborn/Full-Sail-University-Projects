using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Inheritance
{
    class Preferences
    {
        private bool _autoPlay;
        private double _volumeLevel;

        public bool CapsLockOn { get; set; }
        public bool ShouldVideoAutoPlay
        {
            get { return _autoPlay; }
            set { _autoPlay = value; }
        }

        public double VolumeLevel
        {
            get { return _volumeLevel; }
            set { _volumeLevel = value; }
        }
        public Preferences(bool autoPlay, double volumeLevel)
        {
            _volumeLevel = volumeLevel;
            _autoPlay = autoPlay;
        }
    }
}
