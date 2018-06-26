using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class View_Model_Profile : View_Model_Base
    {
        public View_Model_Profile(CashDB tempDB, Person temp)
        {
            myDB = tempDB;
            my_profile_ = temp;


            Family_ = myDB.Families.ToList();

            my_profile = myDB.People.ToList().Find(x => x.ID == my_profile_.ID);

            Family_str = my_profile.Family.Name;
        }


        #region pole
        CashDB myDB;
        Person my_profile_ = new Person();
        Person my_profile;
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
        Regex regex_password = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$");
        #endregion pole


        #region Command_button

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
       

        #region edit
        private DelegateCommand _Command_edit;
        public ICommand Button_clik_edit
        {
            get
            {
                if (_Command_edit == null)
                {
                    _Command_edit = new DelegateCommand(Execute_edit, CanExecute_edit);
                }
                return _Command_edit;
            }
        }
        private void Execute_edit(object o)
        {
            Messege messege = new Messege();
            View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);
            if (messege_view_Model._NO == null)
                messege_view_Model._NO = new Action(messege.Close);


            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = "Are you sure you want to change the settings?";
            messege_view_Model.Messeg_Titel = "Сhange";
            messege.ShowDialog();

            if (messege_view_Model.is_ok)
            {
                if (new_name!= null&&new_name.Length>0)
                    Name = new_name;
                if (new_surname !=null&&new_surname.Length > 0)
                    Surname = new_surname;
                if (new_patronymic!=null&&new_patronymic.Length > 0)
                    Patronymic = new_patronymic;


              
                if (password!=null&& password2!=null&&
                    password != password2 || password != null && password.Length < 1)
                {
                    OpenMessege("The password must be at least one digit, one letter (English), a large letter and any character that is not a digit and not a letter, the maximum password length is 16 characters.", "Error");
                   
                }
                else if (password != null && password2 != null )
                {
                        bool is_ok = regex_password.IsMatch(password);

                    if(is_ok)
                        my_profile.Password = password;
                    else
                    {
                        OpenMessege("The password must be at least one digit, one letter (English), a large letter and any character that is not a digit and not a letter, the maximum password length is 16 characters.", "Error");
                    }
                }

                if (New_login != null && New_login.Length > 0)
                {
                    bool iso = true;
                    foreach (var i in myDB.People)
                    {
                        if (i.Login == New_login)
                        {
                            OpenMessege("This login is already in use.", "Error");
                            iso = false;
                        }
                    }
                    if(iso)
                    my_profile.Login = Login = New_login;
                }

                if (select_item_family != null && select_item_right != null)
                {
                    bool is_oke = true;
                   
                        foreach (var i in myDB.People)
                        {
                            if (i.Right.Level < select_item_right.Level &&
                                i.Family == select_item_family)
                            {
                                is_oke = false;
                                Login window = new Login();
                                Viwe_Model_Login view = new Viwe_Model_Login(Visibility.Hidden, select_item_right.Level, select_item_family);

                                if (view._OK == null)
                                    view._OK = new Action(window.Ok);

                                view._Close = new Action(window.Close);

                                window.DataContext = view;
                                window.ShowDialog();

                                if (view.is_ok == true)
                                {
                                    
                                    my_profile.Family = select_item_family;
                                    Family_str = select_item_family.Name;

                                    my_profile.FamilyID = select_item_family.ID;
                                    my_profile.RightsID = select_item_right.ID;
                                    my_profile.Right = select_item_right;
                                }

                            }
                        }

                    if (is_oke)
                    {

                        my_profile.Family = select_item_family;
                        Family_str = select_item_family.Name;

                        my_profile.FamilyID = select_item_family.ID;
                        my_profile.RightsID = select_item_right.ID;
                        my_profile.Right = select_item_right;
                    }
                }
                else if (select_item_family != null && select_item_right == null ||
                        select_item_family == null && select_item_right != null)
                { 
                    OpenMessege("You did not select all the parameters in the family.", "Error");
                }


                if(new_secret_word!=null && new_secret_word.Length>0)
                {
                    my_profile.Secret_word = new_secret_word;
                }


                var temp = myDB.People.ToList().Find(x => x.ID == my_profile.ID);
                temp = my_profile;
                myDB.SaveChanges();

            }
        }
        private bool CanExecute_edit(object o)
        {

         
                return true;
            return false;

        }
        #endregion edit


        #endregion Command_button


        #region Action
        public bool is_ok;

        public bool is_no;


        public Action _Edit { get; set; }
        public Action _Delite { get; set; }
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
