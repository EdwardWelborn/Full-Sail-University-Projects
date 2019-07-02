using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_interfaces
{
    class FaceLogin : iLogin
    {
        private string _faceData;

        public FaceLogin(string faceData)
        {
            _faceData = faceData;
        }
        public void SetPassword(string faceData)
        {
            _faceData = faceData;
        }
        public bool HandleLogin()
        {
            return true;
        }
    }
}
