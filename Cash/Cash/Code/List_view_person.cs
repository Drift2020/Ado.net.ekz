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
        Person person = null;

        public List_view_person(Person _person)
        {
            person = _person;         
        }

        public string FIO
        {
            get
            {
                return person.ID.ToString() + " " + person.Surname + " " + person.Name + " " + person.Patronymic;
            }
          
        }

        public int ID
        {
            get
            {
                return person.ID;
            }         
        }
    }
}
