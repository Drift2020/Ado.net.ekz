using Cash.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_Edit_Article: View_Model_Base
    {
        #region Pole
        public Action _Edit;
        public Action _Close;

        string _Button_ok;
        public string Button_ok
        {
            get { return _Button_ok; }
            set
            {
                _Button_ok = value;
                OnPropertyChanged(nameof(Button_ok));
            }
        }

        string _Price;
        public string Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        string _Specification;
        public string Specification
        {
            get { return _Specification; }
            set
            {
                _Specification = value;
                OnPropertyChanged(nameof(Specification));
            }
        }
        #endregion Pole

        #region Code

        #endregion Code


        #region Command
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

        private DelegateCommand _Command_cancel;
        public ICommand Button_clik_cancel
        {
            get
            {
                if (_Command_cancel == null)
                {
                    _Command_cancel = new DelegateCommand(Execute_cancel, CanExecute_cancel);
                }
                return _Command_cancel;
            }
        }
        private void Execute_cancel(object o)
        {






        }
        private bool CanExecute_cancel(object o)
        {
            return true;
        }
        #endregion Command
    }
}
