using Cash.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_Editor : View_Model_Base
    {
        #region Pole
        #endregion Pole

        #region Code
        #endregion Code


        #region Command

        #region product
        #region Add
        private DelegateCommand _Command_add_product;
        public ICommand Button_clik_add_product
        {
            get
            {
                if (_Command_add_product == null)
                {
                    _Command_add_product = new DelegateCommand(Execute_add_product, CanExecute_add_product);
                }
                return _Command_add_product;
            }
        }
        private void Execute_add_product(object o)
        {

            Add_Edit_window product_window = new Add_Edit_window();
            View_Model_add_edit_window model = new View_Model_add_edit_window();

            product_window.DataContext = model;

            product_window.ShowDialog();

        }
        private bool CanExecute_add_product(object o)
        {
            return true;
        }
        #endregion

        #region Edit
        private DelegateCommand _Command_edit_product;
        public ICommand Button_clik_edit_product
        {
            get
            {
                if (_Command_edit_product == null)
                {
                    _Command_edit_product = new DelegateCommand(Execute_edit_product, CanExecute_edit_product);
                }
                return _Command_edit_product;
            }
        }
        private void Execute_edit_product(object o)
        {

            Add_Edit_window product_window = new Add_Edit_window();
            View_Model_add_edit_window model = new View_Model_add_edit_window();

            product_window.DataContext = model;

            product_window.ShowDialog();

        }
        private bool CanExecute_edit_product(object o)
        {
            return true;
        }
        #endregion

        #region delete
        private DelegateCommand _Command_delete_product;
        public ICommand Button_clik_delete_product
        {
            get
            {
                if (_Command_delete_product == null)
                {
                    _Command_delete_product = new DelegateCommand(Execute_delete_product, CanExecute_delete_product);
                }
                return _Command_delete_product;
            }
        }
        private void Execute_delete_product(object o)
        {



        }
        private bool CanExecute_delete_product(object o)
        {
            return true;
        }
        #endregion
        #endregion product

        #region category
        #region Add
        private DelegateCommand _Command_add_category;
        public ICommand Button_clik_add_category
        {
            get
            {
                if (_Command_add_category == null)
                {
                    _Command_add_category = new DelegateCommand(Execute_add_category, CanExecute_add_category);
                }
                return _Command_add_category;
            }
        }
        private void Execute_add_category(object o)
        {

            Add_Edit_window category_window = new Add_Edit_window();
            View_Model_add_edit_window model = new View_Model_add_edit_window();

            category_window.DataContext = model;

            category_window.ShowDialog();

        }
        private bool CanExecute_add_category(object o)
        {
            return true;
        }
        #endregion

        #region Edit
        private DelegateCommand _Command_edit_category;
        public ICommand Button_clik_edit_category
        {
            get
            {
                if (_Command_edit_category == null)
                {
                    _Command_edit_category = new DelegateCommand(Execute_edit_category, CanExecute_edit_category);
                }
                return _Command_edit_category;
            }
        }
        private void Execute_edit_category(object o)
        {

            Add_Edit_window category_window = new Add_Edit_window();
            View_Model_add_edit_window model = new View_Model_add_edit_window();

            category_window.DataContext = model;

            category_window.ShowDialog();

        }
        private bool CanExecute_edit_category(object o)
        {
            return true;
        }
        #endregion

        #region delete
        private DelegateCommand _Command_delete_category;
        public ICommand Button_clik_delete_category
        {
            get
            {
                if (_Command_delete_category == null)
                {
                    _Command_delete_category = new DelegateCommand(Execute_delete_category, CanExecute_delete_category);
                }
                return _Command_delete_category;
            }
        }
        private void Execute_delete_category(object o)
        {



        }
        private bool CanExecute_delete_category(object o)
        {
            return true;
        }
        #endregion
        #endregion category

        #endregion Command

        #region List

        #endregion
    }
}
