using Cash.Command;
using Cash.Model;
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

        CashDB myDB = new CashDB();

        #endregion Pole

        #region Code

        public View_Model_Editor()
        {
            list_category = myDB.Categories.ToList();
            list_product = myDB.Products.ToList();
        }


        void OpenMessege(string s, string title)
        {
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);


            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = s;
            messege_view_Model.Messeg_Titel = title;
            messege.ShowDialog();
        }
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
                model.OK = new Action(category_window.Close);

                category_window.DataContext = model;
                category_window.Title = "Add category";
                category_window.ShowDialog();

                var List_final2 = from i in myDB.Categories
                                  where i.Name == model.Name
                                  select i;

                if (List_final2.Count() <= 0)
                {
                    Category temp = new Category();
                    temp.Name = model.Name;
                    myDB.Categories.Add(temp);
                    myDB.SaveChanges();

                    list_category.Clear();
                    List_category = myDB.Categories.ToList();
             
                }
                else
                {
                    OpenMessege("This category already exists.", "Error");
                }
            

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

            model.OK = new Action(category_window.Close);
            model.Name = select_item_category.Name;
            model.Title = "Edit category";

            category_window.DataContext = model;          
            category_window.ShowDialog();



            if(model.Name.Length>0)
            {
                var List_final2 = from i in myDB.Categories
                                  where i.Name == model.Name
                                  select i;
                if(List_final2.Count() <= 0)
                {
                    Select_item_category.Name = model.Name;                   
                    myDB.SaveChanges();
                    list_category = myDB.Categories.ToList();
                    OnPropertyChanged(nameof(List_category));
                }
            }
        }
        private bool CanExecute_edit_category(object o)
        {
            if(select_item_category!=null)
            return true;
            return false;
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
            list_category.Remove(select_item_category);
            myDB.Categories.Remove(select_item_category);
            Select_item_category = null;

            myDB.SaveChanges();
            list_category = myDB.Categories.ToList();
            OnPropertyChanged(nameof(List_category));

        }
        private bool CanExecute_delete_category(object o)
        {
            if(select_item_category!=null)
            return true;
            return false;
        }
        #endregion
        #endregion category

        #endregion Command

        #region List

        #region Category
        List<Category> list_category = new List<Category>();
        public List<Category> List_category
        {
            set
            {
                list_category = value;
                OnPropertyChanged(nameof(List_category));
            }
            get
            {
                return list_category;
            }
        }

        Category select_item_category = null;
        public Category Select_item_category
        {
            set
            {
                select_item_category = value;
                OnPropertyChanged(nameof(Select_item_category));
            }
            get
            {
                return select_item_category;
            }
        }
        #endregion Category

        #region Product
        List<Product> list_product = new List<Product>();
        public List<Product> List_product
        {
            set
            {
                list_product = value;
                OnPropertyChanged(nameof(List_product));
            }
            get
            {
                return list_product;
            }
        }

        Product select_item_product = null;
        public Product Select_item_product
        {
            set
            {
                select_item_product = value;
                OnPropertyChanged(nameof(Select_item_product));
            }
            get
            {
                return select_item_product;
            }
        }
        #endregion Product
        #endregion


    }
}
