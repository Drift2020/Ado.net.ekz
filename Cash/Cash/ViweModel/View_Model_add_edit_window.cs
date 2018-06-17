using Cash.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_add_edit_window : View_Model_Base
    {
        public View_Model_add_edit_window()
        {

        }

        #region pole
        public Action OK;

        #region title
        string title;
        public string Title
        {
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
            get
            {
                return title;
            }
        }
        #endregion


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
        private DelegateCommand _Command_ok;
        public ICommand Button_clik_ok
        {
            get
            {
                if (_Command_ok == null)
                {
                    _Command_ok = new DelegateCommand(Execute_ok, CanExecute_ok);
                }
                return _Command_ok;
            }
        }
        private void Execute_ok(object o)
        {






        }
        private bool CanExecute_ok(object o)
        {
            return true;
        }
        #endregion Ok

        #endregion command

        #region List

        #endregion
    }
}
