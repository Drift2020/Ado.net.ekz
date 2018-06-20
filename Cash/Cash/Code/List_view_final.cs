using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash.Model;
using Cash.ViweModel;

namespace Cash.Code
{
    class List_view_final_my : View_Model_Base
    {

        Final final = null;

        public List_view_final_my(Final _final)
        {
            final = _final;
            category_my = final.Product.Categories.ToList();

        }

        public int ID
        {
            get
            {
                return final.ID;
            }
            set
            {
                final.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }


        public DateTime Date
        {
            get
            {
                return final.Date;
            }
            set
            {
                final.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }


        public decimal Money
        {
            get
            {
                return final.Money;
            }
            set
            {
                final.Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public string Specification
        {
            get
            {
                return final.Specific;
            }
            set
            {
                final.Specific = value;
                OnPropertyChanged(nameof(Specification));
            }
        }


        public string Type
        {
            get
            {
                return final.Type == true ? "+" : "-";
            }
            set
            {
                final.Type = value == "+" ? true : false;
                OnPropertyChanged(nameof(Type));
            }
        }


        public string FIO
        {
            get
            {
                return final.Person.Surname + " " + final.Person.Name + " " + final.Person.Patronymic;
            }
            set
            {

            }
        }

        public string Product
        {
            get
            {
                return final.Product.Name;
            }
            set
            {
                final.Product.Name = value;
                OnPropertyChanged(nameof(Product));
            }
        }



        List<Category> category_my = new List<Category>();
        public ICollection<Category> Category_my
        {
            get
            {
                return category_my;

            }
            set
            {
                category_my = value.ToList();
                OnPropertyChanged(nameof(Category_my));
            }
        }


    }
}
