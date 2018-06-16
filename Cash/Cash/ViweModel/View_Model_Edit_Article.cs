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
        public Action Edit;
        public Action New_category;
        public Action New_product;

        #region button_ok
        string button_ok;
        public string Button_ok
        {
            get { return button_ok; }
            set
            {
                button_ok = value;
                OnPropertyChanged(nameof(Button_ok));
            }
        }
        #endregion button_ok

        #region price
        string price;
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        #endregion price

        #region date
        string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        #endregion date

        #region specification
        string specification;
        public string Specification
        {
            get { return specification; }
            set
            {
                specification = value;
                OnPropertyChanged(nameof(Specification));
            }
        }
        #endregion specification

        #region name
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion name

        #region surname
        string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        #endregion surname 

        #region patronymic
        string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        #endregion patronymic
        #endregion
        #region Code

        #endregion Code


        #region Command
        #region
        private DelegateCommand Command_edit;
        public ICommand Button_clik_ok
        {
            get
            {
                if (Command_edit == null)
                {
                    Command_edit = new DelegateCommand(Execute_edit, CanExecute_edit);
                }
                return Command_edit;
            }
        }
        private void Execute_edit(object o)
        {






        }
        private bool CanExecute_edit(object o)
        {
            return true;
        }
        #endregion
        #region new category
        private DelegateCommand Command_new_category;
        public ICommand Button_clik_new_category
        {
            get
            {
                if (Command_new_category == null)
                {
                    Command_new_category = new DelegateCommand(Execute_new_category, CanExecute_new_category);
                }
                return Command_new_category;
            }
        }
        private void Execute_new_category(object o)
        {






        }
        private bool CanExecute_new_category(object o)
        {
            return true;
        }
        #endregion
        #region new product
        private DelegateCommand Command_new_product;
        public ICommand Button_clik_new_product
        {
            get
            {
                if (Command_new_product == null)
                {
                    Command_new_product = new DelegateCommand(Execute_new_product, CanExecute_new_product);
                }
                return Command_new_product;
            }
        }
        private void Execute_new_product(object o)
        {






        }
        private bool CanExecute_new_product(object o)
        {
            return true;
        }
        #endregion
        #endregion Command
    }
}
