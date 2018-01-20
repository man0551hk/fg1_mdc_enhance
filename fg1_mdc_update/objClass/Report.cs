using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fg1_mdc_update.objClass
{
    public class Report
    {
        public double countTime { set; get; }
        public double sampleWeight { set; get; }
        public double i131Act { set; get; }
        public double ru103Act { set; get; }
        public double cs137Act { set; get; }
        public double cs134Act { set; get; }
        public double k40Act { set; get; }
        public double cs137134Act { set; get; }

        public double i131Mdc { set; get; }
        public double ru103Mdc { set; get; }
        public double cs137Mdc { set; get; }
        public double cs134Mdc { set; get; }
        public double k40Mdc { set; get; }
        public double cs137134Mdc { set; get; }

        public string i131Res { set; get; }
        public string ru103Res { set; get; }
        public string cs137Res { set; get; }
        public string cs134Res { set; get; }
        public string k40Res { set; get; }
        public string cs137134Res { set; get; }


        public string i131Uncert { set; get; }
        public string ru103Uncert { set; get; }
        public string cs137Uncert { set; get; }
        public string cs134Uncert { set; get; }
        public string k40Uncert { set; get; }
        public string cs137134Uncert { set; get; }
    }
}
