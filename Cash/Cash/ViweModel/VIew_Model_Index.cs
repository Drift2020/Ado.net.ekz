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
using System.Windows.Controls;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class Viwe_Model_Index : View_Model_Base
    {
        public CashDB myDB = new CashDB();

        Person my_profile=new Person();

        public Viwe_Model_Index(Person _my_profile)
        {
            my_profile = _my_profile;
            foreach (var i in myDB.Finals.ToList())
                if(my_profile.FamilyID==i.Person.FamilyID)
                    Link_final.Add(new List_view_final_my(i));


            category_list = new ObservableCollection<SelectableItemWrapper<Category>>();
            foreach (var i in myDB.Categories)
            {
                SelectableItemWrapper<Category> temp = new SelectableItemWrapper<Category>();
                temp.Item = i;
                category_list.Add(temp);
            }

            goods_list = new ObservableCollection<SelectableItemWrapper<Product>>();
            foreach (var i in myDB.Products)
            {
                SelectableItemWrapper<Product> temp = new SelectableItemWrapper<Product>();
                temp.Item = i;
                goods_list.Add(temp);
            }

            people_list = new ObservableCollection<SelectableItemWrapper<List_view_person>>();
            foreach (var i in myDB.People)
            {
                SelectableItemWrapper<List_view_person> temp = new SelectableItemWrapper<List_view_person>();
                temp.Item =new List_view_person(i);
                if(i.FamilyID== my_profile.FamilyID)
                people_list.Add(temp);
            }


            
            
        }
        #region Pole


        #region Filter

        Regex regex_price = new Regex(@"^\s*(\+|-)?((\d+(\,\d\d)?)|(\,\d\d))\s*$");

        #region Product

        bool product=false;
        public bool Product_box
        {
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product_box));
            }
            get
            {
                return product;
            }
        }


      
        #endregion Product

        #region category
        string search_category;
        public string Search_category
        {
            set
            {
                search_category = value;
                OnPropertyChanged(nameof(Search_category));
            }
            get
            {
                return search_category;
            }
        }

      
        #endregion

        #region Goods
        string search_goods;
        public string Search_goods
        {
            set
            {
                search_goods = value;
                OnPropertyChanged(nameof(Search_goods));
            }
            get
            {
                return search_goods;
            }
        }
        #endregion

        #region Person

        bool person;
        public bool Person_box
        {
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person_box));
            }
            get
            {
                return person;
            }
        }

     
      

        #region Name
        string search_name;
        public string Search_name
        {
            set
            {
                search_name = value;
                OnPropertyChanged(nameof(Search_name));
            }
            get
            {
                return search_name;
            }
        }
        #endregion

        #region Surname
        string search_surname;
        public string Search_surname
        {
            set
            {
                search_surname = value;
                OnPropertyChanged(nameof(Search_surname));
            }
            get
            {
                return search_surname;
            }
        }
        #endregion

        #region Patronymic
        string search_patronymic;
        public string Search_patronymic
        {
            set
            {
                search_patronymic = value;
                OnPropertyChanged(nameof(Search_patronymic));
            }
            get
            {
                return search_patronymic;
            }
        }
        #endregion
        #endregion

        #region Price

        bool price;
        public bool Price_box
        {
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price_box));
            }
            get
            {
                return price;
            }
        }

       

        #region price start

        string price_start;
        public string Price_start
        {
            set
            {
                bool is_ok = regex_price.IsMatch(value);

                if (is_ok || value == "")
                    price_start = value;
                OnPropertyChanged(nameof(Price_start));
            }
            get
            {
                return price_start;
            }
        }

        #endregion

        #region price end

        string price_end="";
        public string Price_end
        {
            set
            {
               
                bool is_ok = regex_price.IsMatch(value);

                if (is_ok|| value=="")
                    price_end = value;

                OnPropertyChanged(nameof(Price_end));
            }
            get
            {
                return price_end;
            }
        }

        #endregion

    

        #endregion

        #region Date

        bool date;
        public bool Date_box
        {
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date_box));
            }
            get
            {
                return date;
            }
        }



      

        #region Date start

        string date_start;

        public string Date_start
        {
            set
            {
                date_start = value.ToString();
                OnPropertyChanged(nameof(Date_start));
            }
            get
            {
                return date_start;
            }
        }

        #endregion

        #region Date end

        string date_end;

        public string Date_end
        {
            set
            {
                date_end = value;
                OnPropertyChanged(nameof(Date_end));
            }
            get
            {
                return date_end;
            }
        }

        #endregion


        #endregion

        #region Type
        #region box
        bool type = false;
        public bool Type_box
        {
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type_box));
            }
            get
            {
                return type;
            }
        }
        #endregion
        #region box_in
        bool type_Income = false;
        public bool Type_Income
        {
            set
            {
                type_Income = value;
                OnPropertyChanged(nameof(Type_Income));
            }
            get
            {
                return type_Income;
            }
        }
        #endregion
        #region box cos
        bool type_Costs = false;
        public bool Type_Costs
        {
            set
            {
                type_Costs = value;
                OnPropertyChanged(nameof(Type_Costs));
            }
            get
            {
                return type_Costs;
            }
        }
        #endregion
        #endregion

        #endregion

        #endregion Pole

        #region Code
        #endregion Code


        #region Command
        #region Add
        private DelegateCommand _Command_add;
        public ICommand Button_clik_add
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

            Add_Article my_add = new Add_Article();

            View_Model_Add_Article my_model_add = new View_Model_Add_Article();


            if (my_model_add.Add == null)
                my_model_add.Add = new Action(my_add.Close);

            my_add.DataContext = my_model_add;

            //   my_model_add.Autor = _i_autor;

            my_add.ShowDialog();
            //if (my_model_add.is_add)
            //{
            //    my_photo.Add(new PhotoViewModel(my_model_add.Temp.Clone() as Photos));
            //}

        }
        private bool CanExecute_add(object o)
        {
            return true;
        }
        #endregion Add

        #region Edit
        private DelegateCommand _Command_Edit;
        public ICommand Button_clik_edit
        {
            get
            {
                if (_Command_Edit == null)
                {
                    _Command_Edit = new DelegateCommand(Execute_Edit, CanExecute_Edit);
                }
                return _Command_Edit;
            }
        }
        private void Execute_Edit(object o)
        {

            Add_Article my_add = new Add_Article();

            View_Model_Edit_Article my_model_Edit = new View_Model_Edit_Article();


            if (my_model_Edit.Edit == null)
                my_model_Edit.Edit = new Action(my_add.Close);

            my_add.DataContext = my_model_Edit;

            //   my_model_add.Autor = _i_autor;

            my_add.ShowDialog();
            //if (my_model_add.is_add)
            //{
            //    my_photo.Add(new PhotoViewModel(my_model_add.Temp.Clone() as Photos));
            //}

        }
        private bool CanExecute_Edit(object o)
        {
            return true;
        }
        #endregion Edit

        #region delete
        private DelegateCommand _Command_del;
        public ICommand Button_clik_del
        {
            get
            {
                if (_Command_del == null)
                {
                    _Command_del = new DelegateCommand(Execute_del, CanExecute_del);
                }
                return _Command_del;
            }
        }
        private void Execute_del(object o)
        {



        }
        private bool CanExecute_del(object o)
        {
            return true;
        }
        #endregion delete

        #region Editor
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
        }
        private bool CanExecute_editor(object o)
        {
            return true;
        }
        #endregion Editor

        #region Log out
        private DelegateCommand _Command_log_out;
        public ICommand Button_clik_log_out
        {
            get
            {
                if (_Command_log_out == null)
                {
                    _Command_log_out = new DelegateCommand(Execute_log_out, CanExecute_log_out);
                }
                return _Command_log_out;
            }
        }
        private void Execute_log_out(object o)
        {


        }
        private bool CanExecute_log_out(object o)
        {
            return true;
        }
        #endregion  Log out


        #endregion Command

        #region List

        #region list final

        List<List_view_final_my> link_final = new List<List_view_final_my>();
        public List<List_view_final_my> Link_final
        {
            set
            {
                link_final = value;
                OnPropertyChanged(nameof(Link_final));
            }
            get
            {
                return link_final;
            }
        }

        List_view_final_my select_item_final = null;
        public List_view_final_my Select_item_final
        {
            set
            {
                select_item_final = value;
                OnPropertyChanged(nameof(Select_item_final));
            }
            get
            {
                return select_item_final;
            }
        }

        #endregion

        #region list family

        List<Family> my_family = new List<Family>();
        List<Family> My_family
        {
            set
            {
                my_family = value;
            }
        }


        #endregion


        #region Category

        ObservableCollection<SelectableItemWrapper<Category>> category_list;
        public ObservableCollection<SelectableItemWrapper<Category>> Category_list
        {
            get
           {
               return category_list;
            }
        }  

        public ObservableCollection<Category> GetSelectedCategory()
        {
            var selected = Category_list
                .Where(p => p.IsSelected)
                .Select(p => p.Item)
                .ToList();
            return new ObservableCollection<Category>(selected);
        }

        #endregion


        #region Goods

        ObservableCollection<SelectableItemWrapper<Product>> goods_list;
        public ObservableCollection<SelectableItemWrapper<Product>> Goods_list
        {
            get
            {
                return goods_list;
            }
        }

        public ObservableCollection<Product> GetSelectedGoods()
        {
            var selected = Goods_list
                .Where(p => p.IsSelected)
                .Select(p => p.Item)
                .ToList();
            return new ObservableCollection<Product>(selected);
        }

        #endregion


        #region People

       


        ObservableCollection<SelectableItemWrapper<List_view_person>> people_list;
        public ObservableCollection<SelectableItemWrapper<List_view_person>> People_list
        {
            get
            {
                return people_list;
            }
        }

        public ObservableCollection<List_view_person> GetSelectedPeople()
        {
            var selected = People_list
                .Where(p => p.IsSelected)
                .Select(p => p.Item)
                .ToList();
            return new ObservableCollection<List_view_person>(selected);
        }

        #endregion

        int vmSelectedTabIndex;
        public int VMSelectedTabIndex
        {
            set
            {
                vmSelectedTabIndex = value;

                ObservableCollection<Category> temp=null;
                ObservableCollection<Product> temp_product = null;
                ObservableCollection<List_view_person> temp_people = null;
               

                IEnumerable<List_view_final_my> List_final2 = null;

                Link_final.Clear();
                foreach (var iF in myDB.Finals.ToList())
                    if (my_profile.FamilyID == iF.Person.FamilyID)
                        Link_final.Add(new List_view_final_my(iF));

                if (product)
                {
                    temp = GetSelectedCategory();
                    temp_product = GetSelectedGoods();


                    
                    if (temp.Count != 0)
                    {
                        List_final2 = from i in Link_final
                                      from categ in i.Category_my
                                      where temp.ToList().Find(x => x.ID == categ.ID) != null
                                      select i;
                        Link_final = List_final2.ToList();
                    }
                    if (search_category != null && search_category.Length > 0)
                    {
                        List_final2 = from i in Link_final
                                      from categ in i.Category_my
                                      where categ.Name.Contains(search_category)
                                      select i;
                        Link_final = List_final2.ToList();
                    }


                    if (temp_product.Count != 0)
                    {
                        List_final2 = from i in Link_final
                                      where temp_product.ToList().Find(x => x.ID == i.ProductID) != null
                                      select i;
                        Link_final = List_final2.ToList();
                    }
                    if (search_goods != null && search_goods.Length > 0)
                    {
                        List_final2 = from i in Link_final                             
                                      where i.Product.Contains(search_goods)
                                      select i;
                        Link_final = List_final2.ToList();
                    }

                }

                if (person)
                {
                    temp_people = GetSelectedPeople();

                    if (temp_people.Count != 0)
                    {
                        List_final2 = from i in Link_final
                                      where temp_people.ToList().Find(x=>x.ID == i.FIO_ID) != null
                                      select i;
                        Link_final = List_final2.ToList();
                    }
                    if (search_name != null && search_name.Length>0)
                    {
                        List_final2 = from i in Link_final
                                      where i.Name_person.Contains(search_name)
                                      select i;
                        Link_final = List_final2.ToList();
                    }
                    if (search_surname != null && search_surname.Length > 0)
                    {
                        List_final2 = from i in Link_final
                                      where i.Surname_person.Contains(search_surname)
                                      select i;
                        Link_final = List_final2.ToList();
                    }
                    if (search_patronymic != null && search_patronymic.Length > 0)
                    {
                        List_final2 = from i in Link_final
                                      where i.Patronymic_person.Contains(search_patronymic)
                                      select i;
                        Link_final = List_final2.ToList();
                    }


                }

                if (price)
                {
                    if (price_start!=null&&price_start.Length>0)
                    {

                       
                            List_final2 = from i in Link_final
                                          where i.Money >= Convert.ToDecimal(price_start)
                                          select i;
                      
                       

                        Link_final = List_final2.ToList();
                    }
                    if (price_end != null && price_end.Length > 0)
                    {

                        
                            List_final2 = from i in Link_final
                                          where i.Money <= Convert.ToDecimal(price_end)
                                          select i;
                     

                        Link_final = List_final2.ToList();
                    }
                }

                if(date)
                {
                    if(date_start!=null&&date_start.Length>0 )
                    {
                        List_final2 = from i in Link_final
                                      where Convert.ToDateTime(i.Date) >= Convert.ToDateTime(date_start)
                                      select i;




                        Link_final = List_final2.ToList();
                    }
                    if (date_end != null && date_end.Length > 0)
                    {
                        List_final2 = from i in Link_final
                                      where Convert.ToDateTime(i.Date) <= Convert.ToDateTime(date_end)
                                      select i;




                        Link_final = List_final2.ToList();
                    }
                }

                if (type)
                {


                    if (type_Income&&!type_Costs)
                    {
                        List_final2 = from i in Link_final
                                      where i.Type=="-"
                                      select i;




                        Link_final = List_final2.ToList();
                    }
                    else if (type_Costs&&!type_Income)
                    {
                        List_final2 = from i in Link_final
                                      where i.Type == "+"
                                      select i;




                        Link_final = List_final2.ToList();
                    }
                }

                OnPropertyChanged(nameof(Link_final));
                OnPropertyChanged(nameof(VMSelectedTabIndex));
            }
            get
            {
                return vmSelectedTabIndex;
            }
        }

        #endregion
    }
}
