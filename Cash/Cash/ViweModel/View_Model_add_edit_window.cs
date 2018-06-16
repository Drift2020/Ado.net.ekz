using Cash.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_add_product_window : View_Model_Base
    {
        public View_Model_add_product_window()
        {

        }

        #region pole

      

        #region name
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

        #region command

        #region Ok
        private DelegateCommand _Command_add;
        public ICommand Button_clik_add
        {
            get
            {
                if (_Command_add == null)
                {
                    _Command_add = new DelegateCommand(Execute_add, CanExecute_add);
                }
                return _Command_add;
            }
        }
        private void Execute_add(object o)
        {






        }
        private bool CanExecute_add(object o)
        {
            return true;
        }
        #endregion Ok

        #endregion command

        #region List

        #endregion
    }
}
