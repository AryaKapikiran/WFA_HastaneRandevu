using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_HastaneRendevu
{
    public class Doktor:Branş
    {
        public string AdSoyad { get; set; }
        public  Branş Branş { get; set; }

        public override string ToString()
        {
            return AdSoyad;
        }

    }
}
