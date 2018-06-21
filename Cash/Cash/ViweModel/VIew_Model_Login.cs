using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class Viwe_Model_Login : View_Model_Base
    {
        #region Pole
        Person my_users;
        CashDB myDB;
        Family Family;


        public Viwe_Model_Login()
        {
            myDB = new CashDB();
           my_users = new Person();
        
        }

        public Viwe_Model_Login(Visibility Visibility_reg, int level,Family family)
        {
            visibility_reg = Visibility_reg;
            myDB = new CashDB();
            my_users = new Person();
            LEVEL = level;
            Family = family;
            is_ok = false;
        }

        int LEVEL;

        #region visibility_reg
        Visibility visibility_reg = Visibility.Visible;
        public Visibility Visibility_reg
        {
            get { return visibility_reg; }
            set
            {
                visibility_reg = value;
                OnPropertyChanged(nameof(Visibility_reg));
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
        #endregion Pole

        #region Code
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


        public bool is_ok;
        public bool is_none_user;
        public bool is_no;

        public Action _Visibility_on { get; set; }
        public Action _Visibility_off { get; set; }

      
        public Action _OK { get; set; }
        public Action _NO { get; set; }
        public Action _NONE_USER { get; set; }
        public Action _Close { get; set; }
        void Now_Registr(Person autor)
        {
            _Visibility_off();
            Login = "";
            Password = "";

            if (is_ok)
            {


                Index MainWindows = new Index();

                Viwe_Model_Index viewModelIndex = new Viwe_Model_Index(autor);



                MainWindows.DataContext = viewModelIndex;

                MainWindows.ShowDialog();
               // viewModelIndex.Save();

            }
            else if (is_no)
            {

            }
            else if (is_none_user)
            {
                Registration view_registration = new Registration();

                View_Model_Registration View_model_reg = new View_Model_Registration();

                if (View_model_reg._OK == null)
                   View_model_reg._OK = new Action(view_registration.Ok);

                view_registration.DataContext = View_model_reg;

                view_registration.ShowDialog();
                myDB = new CashDB();
            }
           // my_users.Load("user");

            _Visibility_on();


        }
        #endregion Code


        #region Command
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
            myDB = new CashDB();
           if(visibility_reg==Visibility.Visible)
            foreach (var i in myDB.People)
            {
                if(i.Login==login && i.Password==password)
                {
                    is_ok = true;
                    _OK();
                    Now_Registr(i);
                    return;

                }
              
            }
            else
            {
                foreach (var i in myDB.People)
                {
                    if (Family.ID == i.Family.ID && 
                        i.Login == login &&
                        i.Password == password &&
                        LEVEL>= i.Right.Level)
                    {                                            
                        is_ok = true;
                        _OK();
                        _Close();
                        return;

                    }                    
                }
            
            }
            OpenMessege("Password or login is not correct.", "Error");
            return;

        }
        private bool CanExecute_ok(object o)
        {

            if ((login != null && login != "") && (password != null && password != ""))
                return true;
            return false;

        }





        private DelegateCommand _Command_no;
        public ICommand Button_clik_no
        {
            get
            {
                if (_Command_no == null)
                {
                    _Command_no = new DelegateCommand(Execute_no, CanExecute_no);
                }
                return _Command_no;
            }
        }
        private void Execute_no(object o)
        {


            is_none_user = true;

             _NO();
            Now_Registr(null);
        }
        private bool CanExecute_no(object o)
        {

            return true;


        }

        #endregion Command

        #region List

        #endregion
    }
}
