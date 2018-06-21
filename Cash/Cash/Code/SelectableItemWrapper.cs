using Cash.ViweModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Code
{
    public class SelectableItemWrapper<T>: View_Model_Base
    {
        bool isSelected=false;
        public bool IsSelected {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
              
            }
        }
        public T Item { get; set; }
    }
}
