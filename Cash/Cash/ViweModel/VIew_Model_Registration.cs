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
    class View_Model_Registration : View_Model_Base
    {
        CashDB myDB;
        public View_Model_Registration()
        {
            myDB = new CashDB();
            // my_users = new СontainerUser();
            //   my_users.SetSerializer(new XMLSerializer());
            //  my_users.Load("user");

            Family_ = myDB.Families.ToList();
            
          

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
        #region Pole 
        // СontainerUser my_users;


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
        #endregion name
        #region surname
        string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        #endregion
        #region Patronymic

        string patronymic;
        public string Patronymic
        {
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(patronymic));
            }
            get
            {
                return patronymic;
            }
        }

        #endregion

        #region login
        string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        #endregion
        #region password
        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        #endregion
        #region password2
        string password2;
        public string Password2
        {
            get
            {
                return password2;
            }
            set
            {
                password2 = value;
                OnPropertyChanged(nameof(Password2));
            }
        }
        #endregion
        #endregion Pole 



        #region Command_button

        #region OK
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
            if (password != password2 || password.Length <= 3)
            {
                OpenMessege("Passwords do not match, the minimum length is 4 characters.", "Error");
                return;
            }

            //for (int i = 0; i < my_users.Count(); i++)
            //{
            //    if (my_users.Element(i).login == login)
            //    {

            //        OpenMessege("This login is already in use.", "Error");
            //        break;
            //    }
            //}

            //my_users.Add(new Users(name, surname, login, password));
            is_ok = true;

            //my_users.Save("user");
            _OK();


        }
        private bool CanExecute_ok(object o)
        {

            if ((login != null && login != "") &&
                (password != null && password != "") &&
                (password2 != null && password2 != "") &&
                (name != null && name != "") &&
                (surname != null && surname != ""))
                return true;
            return false;

        }
        #endregion



        #region New family
        private DelegateCommand _Command_new;
        public ICommand Button_clik_new
        {
            get
            {
                if (_Command_new == null)
                {
                    _Command_new = new DelegateCommand(Execute_new, CanExecute_new);
                }
                return _Command_new;
            }
        }
        private void Execute_new(object o)
        {
            Add_Edit_window window = new Add_Edit_window();
            View_Model_add_edit_window view= new View_Model_add_edit_window();

            window.DataContext = view;
            view.OK = window.Close;
            window.ShowDialog();

            Family temp = new Family();
            temp.Name = view.Name;
            family.Add(temp);

        }
        private bool CanExecute_new(object o)
        {
         
            return true;
           

        }
        #endregion add family
    

        #endregion Command_button


        #region Action
        public bool is_ok;

        public bool is_no;


        public Action _OK { get; set; }
        public Action _NO { get; set; }
        #endregion


        #region List

        #region Family
        List<Family> family=new List<Family>();
        public ICollection<Family> Family_
        {
            set
            {
                family=value.ToList();
                OnPropertyChanged(nameof(Family_));
            }
            get
            {
                if (family != null)
                    return family;
                else
                    return (new List<Family>());

            }
        }

        Family select_item_family = null;
        public Family Select_item_family
        {
            set
            {
                select_item_family = value;
                OnPropertyChanged(nameof(Select_item_family));
            }
            get
            {
                
                return select_item_family;
            }
        }

        #endregion

     

        #region level
     
        public ICollection<Right> Right_in_family
        {
           
            get
            {
                return myDB.Rights.ToList();
            }
        }
        #endregion

        #endregion
    }
}
