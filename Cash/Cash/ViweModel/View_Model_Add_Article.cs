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
    enum Add_mod {Add,Edit};
    class View_Model_Add_Article : View_Model_Base
    {

        public View_Model_Add_Article(Person per)
        {
          
            myDB = new CashDB();
            myProfile = myDB.People.ToList().Find(x=>x.ID==per.ID);
            List_product = myDB.Products.ToList();
        }

        #region Pole
        Person myProfile;
        public Action Add;
        CashDB myDB;
        Regex regex_price = new Regex(@"^\s*(\+|-)?((\d+(\,\d\d)?)|(\,\d\d))\s*$");

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
            set
            {
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
        bool type=false;
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

      

        #endregion Pole

        #region Code

        #endregion Code


        #region Command
        #region Add
        private DelegateCommand _Command_add;
        public ICommand Button_clik_ok
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



            Final temp = new Final();
            temp.Date = Convert.ToDateTime(date);
            temp.Money = Convert.ToInt32(price);
            temp.Product = select_item_product;
            temp.ProductID = select_item_product.ID;
            temp.Specific = specification;
            temp.Person = myProfile;
            temp.PersonID = myProfile.ID;
            temp.Type = type;
            myDB.Finals.Add(temp);
            myDB.SaveChanges();

            Add();



        }
        private bool CanExecute_add(object o)
        {
            if(price!=null&& price.Length>0&&
                date!=null && date.Length>0 &&
                select_item_product!=null)
            return true;
            return false;
        }
        #endregion
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


            Editor edit_window = new Editor();
            View_Model_Editor model = new View_Model_Editor();
            edit_window.DataContext = model;


            edit_window.ShowDialog();
            myDB = new CashDB();
            List_product = myDB.Products.ToList();
            OnPropertyChanged(nameof(List_product));


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


        #endregion

    }
}
