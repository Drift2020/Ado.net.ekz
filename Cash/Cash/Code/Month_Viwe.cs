using Cash.ViweModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Code
{
    class Month_Viwe: View_Model_Base
    {
        public Month_Viwe(string n,int i)
        {
            name = n;
            id = i;
        }
        public Month_Viwe()
        {
            name = null;
            id = 0;
        }

        public string name { set; get; }
        public int id { set; get; }
    }
}
