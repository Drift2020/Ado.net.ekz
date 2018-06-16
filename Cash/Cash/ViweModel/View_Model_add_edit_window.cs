using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.ViweModel
{
    class View_Model_add_product_window : View_Model_Base
    {
        public View_Model_add_product_window()
        {

        }

        #region pole

        public Action OK;

        #region 
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion

        #endregion pole
    }
}
