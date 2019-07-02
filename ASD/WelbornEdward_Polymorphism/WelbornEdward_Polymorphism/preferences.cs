using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Polymorphism
{
    class Preferences
    {
        private bool _autoPlay;
        private double _volumeLevel;

        public bool GetAutoPlay()
        {
            return _autoPlay;
        }
        public bool AutoPlay
        {
            get
            {
                return _autoPlay;
            }
            set
            {
                _autoPlay = value;
            }
            
        }
        public double VolumeLevel
        {
            get
            {
                return _volumeLevel;
            }
            set
            {
                _volumeLevel = value;
            }
            
            
        }

    }
}
