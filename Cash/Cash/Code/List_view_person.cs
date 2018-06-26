using Cash.Model;
using Cash.ViweModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Code
{
    class List_view_person : View_Model_Base
    {
        public Person person = null;

        public List_view_person(Person _person)
        {
            person = _person;         
        }


        public string Secret_word
        {
            set
            {
                person.Secret_word = value;
                OnPropertyChanged(nameof(Secret_word));

            }
            get
            {
                return person.Secret_word;
            }

        }

        public string Login
        {
            set
            {
                person.Login = value;
                OnPropertyChanged(nameof(Login));
                    
            }
            get
            {
                return person.Login;
            }

        }
        public string Right
        {
            set
            {
                person.Right.Name = value;
                OnPropertyChanged(nameof(Right));

            }
            get
            {
                return person.Right.Name;
            }

        }
        public string Password
        {
            set
            {
                person.Password = value;
                OnPropertyChanged(nameof(Password));

            }
            get
            {
                return person.Password;
            }

        }
        public string Name
        {
            set
            {
                person.Name = value;
                OnPropertyChanged(nameof(Name));

            }
            get
            {
                return person.Name;
            }

        }
        public string Surname
        {
            set
            {
                person.Surname = value;
                OnPropertyChanged(nameof(Surname));

            }
            get
            {
                return person.Surname;
            }

        }
        public string Patronymic
        {
            set
            {
                person.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));

            }
            get
            {
                return person.Patronymic;
            }

        }
        public string Family
        {
            set
            {
                person.Family.Name = value;
                OnPropertyChanged(nameof(Family));

            }
            get
            {
                return person.Family.Name;
            }
        }
        //public string Secret_word
        //{

        //    set
        //    {
        //        person.Secret_word = value;
        //        OnPropertyChanged(nameof(Secret_word));

        //    }
        //    get
        //    {
        //        return person.Secret_word;
        //    }
        //}


        public string FIO
        {
            set
            {
                FIO = value;
                OnPropertyChanged(nameof(FIO));
            }
            get
            {
                return person.ID.ToString() + " " + person.Surname + " " + person.Name + " " + person.Patronymic;
            }
          
        }

        public int ID
        {
            set
            {
                person.ID = value;
                OnPropertyChanged(nameof(ID));
            }
            get
            {
                return person.ID;
            }         
        }
    }
}
