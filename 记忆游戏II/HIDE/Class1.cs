using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIDE
{
    public class TANYA
    {
        public int picnum;
        public bool first=false;
        public bool haschecked = false;
        //TANYA() { }
       // TANYA(int pic)
       // {
          //  picnum = pic;
        //}
        public void firstop()
        {
            first = true;
        }
        public void then(TANYA b)
        {
            haschecked = true;
            b.haschecked = true;
            first = false;
            b.first = false;
            
        }
    }

    

}
