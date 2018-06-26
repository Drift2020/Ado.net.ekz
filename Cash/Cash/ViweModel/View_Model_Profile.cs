using Cash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.ViweModel
{
    class View_Model_Profile : View_Model_Base
    {
        public View_Model_Profile(CashDB tempDB, Person temp)
        {
            myDB = tempDB;
            my_profile = temp;

        }


        #region pole
        CashDB myDB;
        Person my_profile = new Person();
        #region name
       
        public string Name
        {
            get
            {
                return my_profile.Name;
            }
            set
            {
                my_profile.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion name
        #region surname
      
        public string Surname
        {
            get
            {
                return my_profile.Surname;
            }
            set
            {
                my_profile.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        #endregion
        #region Patronymic

       
        public string Patronymic
        {
            set
            {
                my_profile.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
            get
            {
                return my_profile.Patronymic;
            }
        }

        #endregion
        #region Family
        string family_str;
        public string Family_str
        {
            get
            {
                return family_str;
            }
            set
            {
                family_str = value;
                OnPropertyChanged(nameof(Family_str));
            }
        }
        #endregion
        #region login
      
        public string Login
        {
            get
            {
                return my_profile.Login;
            }
            set
            {
                my_profile.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        #endregion

        #region New login
        string new_login;
        public string New_login
        {
            get
            {
                return new_login;
            }
            set
            {
                new_login = value;
                OnPropertyChanged(nameof(New_login));
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
        #region Family
        string family_str_e;
        public string Family_str_e
        {
            get
            {
                return family_str_e;
            }
            set
            {
                family_str_e = value;
                OnPropertyChanged(nameof(Family_str_e));
            }
        }
        #endregion
        #region new name
        string new_name;
        public string New_name
        {
            get
            {
                return new_name;
            }
            set
            {
                new_name = value;
                OnPropertyChanged(nameof(New_name));
            }
        }
        #endregion name
        #region new surname
        string new_surname;
        public string New_surname
        {
            get
            {
                return new_surname;
            }
            set
            {
                new_surname = value;
                OnPropertyChanged(nameof(New_surname));
            }
        }
        #endregion
        #region Patronymic

        string new_patronymic;
        public string New_patronymic
        {
            set
            {
                new_patronymic = value;
                OnPropertyChanged(nameof(New_patronymic));
            }
            get
            {
                return new_patronymic;
            }
        }

        #endregion
        #region new secret word 
        string new_secret_word;
        public string New_secret_word
        {
            get
            {
                return new_secret_word;
            }
            set
            {
                new_secret_word = value;
                OnPropertyChanged(nameof(New_secret_word));
            }
        }
        #endregion new_secret_word

        #endregion pole


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
            foreach (var i in myDB.People)
            {
                if (i.Login == login)
                {
                    OpenMessege("This login is already in use.", "Error");
                    return;
                }
            }


            foreach (var i in myDB.People)
            {
                if (select_item_right.Level != 3 &&
                    i.Right.Level == select_item_right.Level &&
                    i.Family == select_item_family)
                {
                    Login window = new Login();
                    Viwe_Model_Login view = new Viwe_Model_Login(Visibility.Hidden, select_item_right.Level, select_item_family);

                    if (view._OK == null)
                        view._OK = new Action(window.Ok);

                    view._Close = new Action(window.Close);

                    window.DataContext = view;
                    window.ShowDialog();

                    if (view.is_ok == false)
                    {

                        return;
                    }

                }
            }



            Person temp = new Person();
            temp.Name = name;
            temp.Surname = surname;
            temp.Patronymic = patronymic;

            temp.Login = login;
            temp.Password = password;
            temp.Family = select_item_family;
            temp.FamilyID = select_item_family.ID;
            temp.RightsID = select_item_right.ID;
            temp.Right = select_item_right;

            myDB.People.Add(temp);
            myDB.SaveChanges();

            is_ok = true;


            _OK();


        }
        private bool CanExecute_ok(object o)
        {

            if ((login != null && login != "") &&
                (password != null && password != "") &&
                (password2 != null && password2 != "") &&
                (name != null && name != "") &&
                (surname != null && surname != "") &&
                patronymic != null && patronymic.Length > 0 &&
                select_item_family != null &&
                select_item_right != null
                )
                return true;
            return false;

        }
        #endregion


        #endregion Command_button


        #region Action
        public bool is_ok;

        public bool is_no;


        public Action _OK { get; set; }
        public Action _NO { get; set; }
        #endregion


        #region List

        #region Family
        List<Family> family = new List<Family>();
        public ICollection<Family> Family_
        {
            set
            {
                family = value.ToList();
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

        Right select_item_right = null;
        public Right Select_item_right
        {
            set
            {
                select_item_right = value;
                OnPropertyChanged(nameof(Select_item_right));
            }
            get
            {
                return select_item_right;
            }
        }
        #endregion

        #endregion
    }
}
