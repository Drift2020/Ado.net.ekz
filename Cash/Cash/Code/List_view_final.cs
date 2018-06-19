using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash.Model;
using Cash.ViweModel;

namespace Cash.Code
{
    class List_view_final_my: View_Model_Base
    {

        Link_Final final =null;
        
        public List_view_final_my(Link_Final _final)
        {
            final = _final;
          

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
                return final.Specification;
            }
            set
            {
                final.Specification = value;
                OnPropertyChanged(nameof(Specification));
            }
        }

      
        public string Type_of_purchase
        {
            get
            {
                return final.Type__of_purchase == true ? "+" : "-";
            }
            set
            {
                final.Type__of_purchase = value == "+" ? true : false;
                OnPropertyChanged(nameof(Type_of_purchase));
            }
        }


        public string FIO
        {
            get
            {
                return final.Person.surname + " " + final.Person.name + " " + final.Person.patronymic;
            }
            set
            {

            }
        }

        public string Product
        {
            get
            {
                return final.Product.name;
            }
            set
            {
                final.Product.name = value;
                OnPropertyChanged(nameof(Product));
            }
        }

     


        public ICollection<Category> Category_my
        {
            get
            {
                return final.Product.Categories.ToList();

            }
            set
            {
                final.Product.Categories = value;
                OnPropertyChanged(nameof(Category_my));
            }
        }

       
    }
}
