using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_Edit_Article: View_Model_Base
    {
        #region Pole
        public Action Edit;
        Person myProfile;

      
      
        CashDB myDB ;
        Regex regex_price = new Regex(@"^\s*(\+|-)?((\d+(\,\d\d)?)|(\,\d\d))\s*$");

        Final my_z=new Final();
        public string Title
        {
            get
            {
                return "Edit a post";
            }
        }


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

        public bool is_ok;
        #endregion button_ok

        #region price
        string price="";
        public string Price
        {
            set
            {
                int r = value.IndexOf(",") + 1;
                if (value.Length - r == 4)
                    value = value.Substring(0, value.Length-2);

                bool is_ok = regex_price.IsMatch(value);

                if (is_ok || value == "")
                    price = value;
                OnPropertyChanged(nameof(Price));
            }
            get
            {
                return price;
            }
        }
        #endregion

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
        #endregion

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

        #region type
        bool type = false;
        public bool Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        #endregion name



        #endregion



        #region Code

        public View_Model_Edit_Article(CashDB _myDB, Final temp,Person temp_person)
        {
            myDB = _myDB;
            List_product = myDB.Products.ToList();
            my_z = temp;
            Date = temp.Date.ToString();
            Price = temp.Money.ToString();
            Type = temp.Type;
            Specification = temp.Specific;
            myProfile = temp_person;
            Select_item_product = List_product.Find(x=>x.ID==my_z.Product.ID);
           
        }

        #endregion Code


        #region Command

        #region edit
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
            try
            {
                Messege messege = new Messege();
                View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

                if (messege_view_Model._OK == null)
                    messege_view_Model._OK = new Action(messege.Close);
                if (messege_view_Model._NO == null)
                    messege_view_Model._NO = new Action(messege.Close);
                messege.DataContext = messege_view_Model;
                messege_view_Model.Messege = "Are you sure you want to change this entry?";
                messege_view_Model.Messeg_Titel = "Edit entry";
                messege.ShowDialog();

                if (messege_view_Model.is_ok)
                {

                    my_z.Specific = specification;
                    my_z.Date = Convert.ToDateTime(date);
                    my_z.Money = Convert.ToDecimal(price);
                    my_z.Type = type;
                    my_z.Product = select_item_product;
                    my_z.ProductID = select_item_product.ID;
                    is_ok = true;
                    Edit();

                }
            }
            catch (Exception e)
            {

            }
        }
        private bool CanExecute_edit(object o)
        {
            return true;
        }
        #endregion edit

        #region editor
        private DelegateCommand _Command_editor;
        public ICommand Button_clik_editor
        {
            get
            {
                if (_Command_editor == null)
                {
                    _Command_editor = new DelegateCommand(Execute_editor, CanExecute_editor);
                }
                return _Command_editor;
            }
        }
        private void Execute_editor(object o)
        {
            try
            {

                Editor edit_window = new Editor();
                View_Model_Editor model = new View_Model_Editor(myProfile, myDB);
                edit_window.DataContext = model;


                edit_window.ShowDialog();
               // myDB = new CashDB();
                List_product = myDB.Products.ToList();
                OnPropertyChanged(nameof(List_product));
            }
            catch(Exception e)
            {

            }

        }
        private bool CanExecute_editor(object o)
        {
            return true;
        }
        #endregion

        #endregion Command

        #region List
        List<Product> list_product;
        public List<Product> List_product
        {
            get
            {
                return list_product;
            }
            set
            {
                list_product = value;
                OnPropertyChanged(nameof(List_product));
            }
        }

        Product select_item_product;
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
        #endregion List
    }
}
