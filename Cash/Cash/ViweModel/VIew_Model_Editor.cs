using Cash.Code;
using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region name category
        string name_category;
        public string Name_category {
            set
            {
                name_category = value;
                OnPropertyChanged(nameof(Name_category));
            }
            get
            {

                return name_category;
            }
        }
        #endregion
        #region name product
        string name_product;
        public string Name_product
        {
            set
            {
                name_product = value;
                OnPropertyChanged(nameof(Name_product));
            }
            get
            {
                return name_product;
            }
        }
        #endregion
        #endregion Pole

        #region Code

        public View_Model_Editor()
        {
            list_category = myDB.Categories.ToList();
            list_product = myDB.Products.ToList();

            category_list = new ObservableCollection<SelectableItemWrapper<Category>>();
            foreach (var i in myDB.Categories)
            {
                SelectableItemWrapper<Category> temp = new SelectableItemWrapper<Category>();
                temp.Item = i;
                category_list.Add(temp);
            }
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

            Product temp = new Product();
            temp.Name = Name_product;


            var List_final = from i in Category_list
                             where i.IsSelected==true
                             select i;
            foreach (var i in List_final)
                temp.Categories.Add(i.Item);

            myDB.Products.Add(temp);
            myDB.SaveChanges();

            list_product.Clear();
            List_product = myDB.Products.ToList();
            SetNull();
        }
        private bool CanExecute_add_product(object o)
        {
            if (name_product != null && name_product.Length > 0)
            {
                var List_final2 = from i in myDB.Products
                                  where i.Name == name_product
                                  select i;
                if (List_final2.Count() == 0)
                    return true;
               

            }

            return false;
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
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);
            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Do you really want to change this product?";
            messege_view_Model.Messeg_Titel = "Change product";
            messege.ShowDialog();

            if (messege_view_Model.is_ok)
            {

                Select_item_product.Name = name_product;

                Select_item_product.Categories.Clear();

                var List_final = from i in Category_list
                                 where i.IsSelected == true
                                 select i;
                foreach (var i in List_final)
                    Select_item_product.Categories.Add(i.Item);

                Select_item_product = null;

                myDB.SaveChanges();

                list_product.Clear();
                List_product = myDB.Products.ToList();
                SetNull();
            }
        }
        private bool CanExecute_edit_product(object o)
        {
            if (name_product != null && name_product.Length > 0 && select_item_product!=null)
            {
                var List_final2 = from i in myDB.Products
                                  where i.Name == name_product && i.ID!= select_item_product.ID
                                  select i;
                if (List_final2.Count() == 0)
                    return true;


            }

            return false;
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
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);
            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Are you sure you want to delete this product?";
            messege_view_Model.Messeg_Titel = "Deleting product";
            messege.ShowDialog();

            if (messege_view_Model.is_ok)
            {
                Name_product = null;
                list_product.Remove(select_item_product);
                myDB.Products.Remove(select_item_product);
                Select_item_product = null;
                try
                {
                    myDB.SaveChanges();
                }
                catch(Exception e)
                {
                     messege = new Messege();
                     messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden, System.Windows.Visibility.Hidden);

                    if (messege_view_Model._OK == null)
                        messege_view_Model._OK = new Action(messege.Close);
                  
                    messege.DataContext = messege_view_Model;
                    messege_view_Model.Messege = "With this product there is a connection of records with users.\nRemoval is not possible.";
                    messege_view_Model.Messeg_Titel = "Error";
                    messege.ShowDialog();
                }

                list_product = myDB.Products.ToList();
                OnPropertyChanged(nameof(List_product));
            }


            }
        private bool CanExecute_delete_product(object o)
        {
            if ( select_item_product != null)                     
            return true;
            return false;
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
           
              

             
                    Category temp = new Category();
                    temp.Name = name_category;
                    myDB.Categories.Add(temp);
                    myDB.SaveChanges();

                    list_category.Clear();
                    List_category = myDB.Categories.ToList();
             
               
             
            

        }
        private bool CanExecute_add_category(object o)
        {
           

            if (name_category!=null && name_category.Length>0 )
            {
                var List_final2 = from i in myDB.Categories
                                  where i.Name == name_category
                                  select i;
                if (List_final2.Count() == 0)               
                    return true;
                           
                   
                
            }
         
            return false;
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

            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);
            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Do you really want to change this category?";
            messege_view_Model.Messeg_Titel = "Change category";
            messege.ShowDialog();

            if (messege_view_Model.is_ok)
            {

                Select_item_category.Name = name_category;
                myDB.SaveChanges();
                list_category = myDB.Categories.ToList();
                OnPropertyChanged(nameof(List_category));
                OnPropertyChanged(nameof(List_product));

            }
        }
        private bool CanExecute_edit_category(object o)
        {
          
            if (select_item_category != null&&
                name_category != null && 
                name_category.Length > 0)
            {
                var List_final2 = from i in myDB.Categories
                                  where i.Name == name_category && select_item_category.ID != i.ID
                                  select i;
                if (List_final2.Count() == 0)
                    return true;
               

            }

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
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);
            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Are you sure you want to delete this category?";
            messege_view_Model.Messeg_Titel = "Deleting category";
            messege.ShowDialog();

            if (messege_view_Model.is_ok)
            {
                Name_category = null;
                list_category.Remove(select_item_category);
                myDB.Categories.Remove(select_item_category);
                Select_item_category = null;
              
                myDB.SaveChanges();

                list_category = myDB.Categories.ToList();
                OnPropertyChanged(nameof(List_category));
            }

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
                if(select_item_category!=null)
                Name_category = select_item_category.Name;
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
                SetNull();
                select_item_product = value;
                if (select_item_product != null)
                {

                    Name_product = select_item_product.Name;

                   

                    foreach (var i in category_list)
                    {
                        foreach (var x in select_item_product.Categories)
                        {
                            if(i.Item.ID==x.ID)
                            {
                                i.IsSelected = true;
                            }
                        }
                    }
                }
                else
                {

                    Name_product = null;
                    
                }
                OnPropertyChanged(nameof(Select_item_product));
            }
            get
            {
                return select_item_product;
            }
        }


        ObservableCollection<SelectableItemWrapper<Category>> category_list;
        public ObservableCollection<SelectableItemWrapper<Category>> Category_list
        {
            get
            {
                return category_list;
            }
        }

        public ObservableCollection<Category> GetSelectedCategory()
        {
            var selected = Category_list
                .Where(p => p.IsSelected)
                .Select(p => p.Item)
                .ToList();
            return new ObservableCollection<Category>(selected);
        }

        void SetNull()
        {
            if(category_list!=null)
            foreach (var i in category_list)
            {
                i.IsSelected = false;
            }
        }

        //category_list = new ObservableCollection<SelectableItemWrapper<Category>>();
        //foreach (var i in myDB.Categories)
        //{
        //        SelectableItemWrapper<Category> temp = new SelectableItemWrapper<Category>();
        //temp.Item = i;
        //        category_list.Add(temp);
        //}

        #endregion Product
        #endregion


    }
}
