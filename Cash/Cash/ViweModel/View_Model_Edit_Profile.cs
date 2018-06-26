using Cash.Code;
using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_Edit_Profile : View_Model_Base
    {
        CashDB myDB;
        Person my_profile = new Person();
        public View_Model_Edit_Profile(Person temp, CashDB tempDB)
        {
            myDB = tempDB;
            my_profile = temp;

            // my_users = new СontainerUser();
            //   my_users.SetSerializer(new XMLSerializer());
            //  my_users.Load("user");

            Family_ = myDB.Families.ToList();
            Name = my_profile.Name;
            Surname = my_profile.Surname;
            Patronymic = my_profile.Patronymic;
            

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
            View_Model_add_edit_window view = new View_Model_add_edit_window();


            view.OK = window.Close;
            window.DataContext = view;
            window.ShowDialog();

            Family temp = new Family();
            temp.Name = view.Name;

            if (myDB.Families.ToList().Find(x => x.Name == temp.Name) == null)
            {
                Family_.Add(temp);
                OnPropertyChanged(nameof(Family_));

                myDB.Families.Add(temp);
                myDB.SaveChanges();

                OpenMessege("Family successfully added", "Successful operation");
            }
            else
            {
                OpenMessege("Family is not added, there is already such a family.", "Operation error");
            }
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

