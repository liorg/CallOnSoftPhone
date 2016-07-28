using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFHosting
{
    public class Config
    {
        static Config _config = null;
        public string UserName { get; set; }
        public string Pws { get; set; }
        Action _doit = null;
        public void SetRefresh(Action doit)
        {
            _doit = doit;
        }

        public void Close()
        {
            try
            {
                if (frmProprties.host != null)
                    frmProprties.host.Close();
              
            }
            catch
            {


            }
            if (_doit != null)
                _doit();

        }

        public static Config GetSinglton()
        {
            if (_config == null)
                _config = new Config();
            return _config;
        }
    }
}
