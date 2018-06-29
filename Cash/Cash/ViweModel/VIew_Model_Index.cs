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
    class Viwe_Model_Index : View_Model_Base
    {
        string [] month = {"January", "February", "March",
            "April", "May", "June", "July", "August", "September",
            "October", "November", "December" };

      
        #region Pole
        public CashDB myDB = new CashDB();
        Person my_profile = new Person();
        Regex regex_price = new Regex(@"^\s*(\+|-)?((\d+(\,\d\d)?)|(\,\d\d))\s*$");



        #region Costs
        string costs;
        public string Costs
        {
            set
            {
                costs = value;
                OnPropertyChanged(nameof(Costs));
            }
            get
            {
                return costs;
            }
        }
        #endregion Costs
        #region Income
        string income;
        public string Income
        {
            set
            {
                income = value;
                OnPropertyChanged(nameof(Income));
            }
            get
            {
                return income;
            }
        }
        #endregion Income

        #region Filter



        #region Product

        bool product =false;
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

        #region Month Comparison

        Regex regex_year = new Regex(@"^\s*(\+|-)?((\d+?))\s*$$");

        #region Month start

        Month_Viwe select_item_month_viwe_start = null;
        public Month_Viwe Select_item_month_viwe_start
        {
            set
            {
                select_item_month_viwe_start = value;
                OnPropertyChanged(nameof(Select_item_month_viwe_start));
            }
            get
            {
                return select_item_month_viwe_start;
            }
        }

        #endregion Month start

        #region Month end

        Month_Viwe select_item_month_viwe_end = null;
        public Month_Viwe Select_item_month_viwe_end
        {
            set
            {
                select_item_month_viwe_end = value;
                OnPropertyChanged(nameof(Select_item_month_viwe_end));
            }
            get
            {
                return select_item_month_viwe_end;
            }
        }

        #endregion Month end

        #region year start

        string year_start="";
        public string Year_start
        {
            set
            {
                bool is_ok = regex_year.IsMatch(value);

                if (is_ok&& value.Length<5 || value == "")
                    year_start = value;
                OnPropertyChanged(nameof(Year_start));
            }
            get
            {
                return year_start;
            }
        }

        #endregion year start

        #region year end


        string year_end = "";
        public string Year_end
        {
            set
            {
                bool is_ok = regex_year.IsMatch(value);

                if (is_ok && value.Length < 5 || value == "")
                    year_end = value;
                OnPropertyChanged(nameof(Year_end));
            }
            get
            {
                return year_end;
            }
        }


        #endregion year end

        #region costs_start

        string costs_start = "";
        public string Costs_start
        {
            set
            {
                costs_start = value;
                OnPropertyChanged(nameof(Costs_start));
            }
            get
            {
                return costs_start;
            }
        }

        #endregion costs_start

        #region costs_end

        string costs_end = "";
        public string Costs_end
        {
            set
            {
                costs_end = value;
                OnPropertyChanged(nameof(Costs_end));
            }
            get
            {
                return costs_end;
            }
        }

        #endregion costs_end

        #region Income_start

        string income_start = "";
        public string Income_start
        {
            set
            {
                income_start = value;
                OnPropertyChanged(nameof(Income_start));
            }
            get
            {
                return income_start;
            }
        }

        #endregion costs_start

        #region Income_end

        string income_end = "";
        public string Income_end
        {
            set
            {
                income_end = value;
                OnPropertyChanged(nameof(Income_end));
            }
            get
            {
                return income_end;
            }
        }

        #endregion Income_end

        #region Income_is

        string income_is = "";
        public string Income_is
        {
            set
            {
                income_is = value;
                OnPropertyChanged(nameof(Income_is));
            }
            get
            {
                return income_is;
            }
        }

        #endregion Income_is

        #region Costs_is

        string costs_is = "";
        public string Costs_is
        {
            set
            {
                costs_is = value;
                OnPropertyChanged(nameof(Costs_is));
            }
            get
            {
                return costs_is;
            }
        }

        #endregion Costs_is

        #region  Costs_d

        string costs_d = "";
        public string Costs_d {
            set
            {
                costs_d = value;
                OnPropertyChanged(nameof(Costs_d));
            }
            get
            {
                return costs_d;
            }
        }

        #endregion Costs_d

        #region  Income_d

        string income_d = "";
        public string Income_d
        {
            set
            {
                income_d = value;
                OnPropertyChanged(nameof(Income_d));
            }
            get
            {
                return income_d;
            }
        }

        #endregion Income_d

        #endregion Month Comparison

        #region Profiles

        #region Visibility

        Visibility is_visibility = Visibility.Hidden;
        public Visibility Is_visibility
        {
            set
            {
                is_visibility = value;
                OnPropertyChanged(nameof(Is_visibility));
            }
            get
            {
                return is_visibility;
            }
        }

        #endregion Visibility

        #endregion Profiles

        #endregion Pole

        #region Code
        public Viwe_Model_Index(Person _my_profile)
        {
            my_profile = _my_profile;

            if (my_profile.Right.Level == 0)
                Is_visibility = Visibility.Visible;
            else
                Is_visibility = Visibility.Hidden;


            foreach (var i in myDB.Finals.ToList())
                if (my_profile.FamilyID == i.Person.FamilyID)
                    Link_final.Add(new List_view_final_my(i));


            Set_Filter();



            for (int i = 0; i < 12; i++)
                list_month_viwe_start.Add(new Month_Viwe(month[i], i + 1));
            for (int i = 0; i < 12; i++)
                list_month_viwe_end.Add(new Month_Viwe(month[i], i + 1));

            SetCosts();
            SetIncome();
        }
        void Set_Filter()
        {

            category_list = new ObservableCollection<SelectableItemWrapper<Category>>();
            foreach (var i in myDB.Categories)
            {
                SelectableItemWrapper<Category> temp = new SelectableItemWrapper<Category>();
                temp.Item = i;
                category_list.Add(temp);
            }
            OnPropertyChanged(nameof(Category_list));

            goods_list = new ObservableCollection<SelectableItemWrapper<Product>>();
            foreach (var i in myDB.Products)
            {
                SelectableItemWrapper<Product> temp = new SelectableItemWrapper<Product>();
                temp.Item = i;
                goods_list.Add(temp);
            }
            OnPropertyChanged(nameof(Goods_list));

            people_list = new ObservableCollection<SelectableItemWrapper<List_view_person>>();
            foreach (var i in myDB.People)
            {
                SelectableItemWrapper<List_view_person> temp = new SelectableItemWrapper<List_view_person>();
                temp.Item = new List_view_person(i);
                if (i.FamilyID == my_profile.FamilyID)
                    people_list.Add(temp);
            }
            OnPropertyChanged(nameof(People_list));

            Profiles = new ObservableCollection<List_view_person>();
            foreach (var i in myDB.People)
            {
                List_view_person temp = new List_view_person(i);
                if (i.FamilyID == my_profile.FamilyID)
                    Profiles.Add(temp);
            }
            OnPropertyChanged(nameof(Profiles));
        }
        void Set_new_items()
        {
            my_profile = myDB.People.ToList().Find(x => x.ID == my_profile.ID);

            Link_final.Clear();
            foreach (var i in myDB.Finals.ToList())
                if (my_profile.FamilyID == i.Person.FamilyID)
                    Link_final.Add(new List_view_final_my(i));
            OnPropertyChanged(nameof(Link_final));

            category_list = new ObservableCollection<SelectableItemWrapper<Category>>();
            foreach (var i in myDB.Categories)
            {
                SelectableItemWrapper<Category> temp = new SelectableItemWrapper<Category>();
                temp.Item = i;
                category_list.Add(temp);
            }
            OnPropertyChanged(nameof(Category_list));

            goods_list = new ObservableCollection<SelectableItemWrapper<Product>>();
            foreach (var i in myDB.Products)
            {
                SelectableItemWrapper<Product> temp = new SelectableItemWrapper<Product>();
                temp.Item = i;
                goods_list.Add(temp);
            }
            OnPropertyChanged(nameof(Goods_list));

            Profiles = new ObservableCollection<List_view_person>();
            foreach (var i in myDB.People)
            {
                List_view_person temp = new List_view_person(i);
                if (i.FamilyID == my_profile.FamilyID)
                    profiles.Add(temp);
            }
            OnPropertyChanged(nameof(Profiles));

            if (my_profile.Right.Level == 0)
                Is_visibility = Visibility.Visible;
            else
                Is_visibility = Visibility.Hidden;
            SetCosts();
            SetIncome();
        }
        bool Levels()
        {
            if (select_item_final != null)
            {
                var i = myDB.People.ToList().Find(x => x.ID == select_item_final.FIO_ID);
                if (my_profile.Right.Level < i.Right.Level|| my_profile.ID==i.ID)
                    return true;
            }
            return false;
        }

        bool Levels_profile()
        {
            if (select_item_profile != null)
            {
                var i = myDB.People.ToList().Find(x => x.ID == select_item_profile.ID);
                if (my_profile.Right.Level < i.Right.Level || my_profile.ID == i.ID)
                    return true;
            }
            return false;
        }
        void SetCosts()
        {
           
           var temp = from i in link_final
                      where i.Type=="+"
                          select (i.Money);
            if (temp.Count() > 0)
                Costs = temp.ToList().Sum().ToString();
             else
                Costs = "";
        }
        void SetIncome()
        {

            var temp = from i in link_final
                       where i.Type == "-"
                       select (i.Money);
            if (temp.Count() > 0)
                Income = temp.ToList().Sum().ToString();
            else
                Income = "";
        }
        void Month_Comparison()
        {
            decimal c_s, c_e, i_s, i_e, end_c,end_i;


            var Temp1 = from i in Link_final                       
                        where i.Date.Month == select_item_month_viwe_start.id &&
                              i.Date.Year == Convert.ToInt32(year_start)
                        select i;

            var Temp2 = from i in Link_final
                        where i.Date.Month == select_item_month_viwe_end.id &&
                              i.Date.Year == Convert.ToInt32(year_end)
                        select i;


            var temp_costs1 = from i in Temp1
                              where i.Type == "+"
                       select (i.Money);
            var temp_costs2 = from i in Temp2
                              where i.Type == "+"
                              select (i.Money);
            var temp_income1 = from i in Temp1
                               where i.Type == "-"
                               select (i.Money);
            var temp_income2 = from i in Temp2
                               where i.Type == "-"
                               select (i.Money);

            if (temp_costs1.Count() > 0)
            {
                c_s = temp_costs1.ToList().Sum();
               
            }
            else
            {
                c_s = 0;
               
            }


            if (temp_costs2.Count() > 0)
            {
                c_e = temp_costs2.ToList().Sum();
              
            }
            else
            {
                c_e = 0;
               
            }


            if (temp_income1.Count() > 0)
            {
                i_s = temp_income1.ToList().Sum();
               
            }
            else
            {
                i_s = 0;
               
            }


            if (temp_income2.Count() > 0)
            {
                i_e = temp_income2.ToList().Sum();             
            }
            else
            {
                i_e = 0;              
            }



            if (c_s > c_e)
            {
                Costs_is = ">";
            }
            else if (c_s < c_e)
            {
                Costs_is = "<";
            }
            else
            {
                Costs_is = "=";
            }


            if (i_s > i_e)
            {
                Income_is = ">";
            }
            else if (i_s < i_e)
            {
                Income_is = "<";
            }
            else
            {
                Income_is = "=";
            }




            if (temp_costs1.Count() > 0)
            {
                string proz = (100 * c_s / (c_s + i_s)).ToString();
                if(proz.IndexOf(",")==-1)
                    Costs_start = c_s.ToString() + " / " + proz; 
                else if(proz.IndexOf(",")+3== proz.Length)
                    Costs_start = c_s.ToString() + " / " + proz;
                else
                    Costs_start = c_s.ToString() + " / " + proz.Substring(0, proz.IndexOf(",") + 3);
                Costs_start += "%";
            }
            else
            {
                
                Costs_start = "0 / 0%";
            }
         
           
            if (temp_costs2.Count() > 0)
            {
                string proz = (100 * c_e / (c_e + i_e)).ToString();
                if (proz.IndexOf(",") == -1)
                    Costs_end = c_e.ToString() + " / " + proz;
                else if (proz.IndexOf(",") + 3 == proz.Length)
                    Costs_end = c_e.ToString() + " / " + proz;
                else
                    Costs_end = c_e.ToString() + " / " + proz.Substring(0, proz.IndexOf(",") + 3);
                Costs_end += "%";
            }
            else
            {
                
                Costs_end = "0 / 0%";
            }

            
            if (temp_income1.Count() > 0)
            {
                string proz = (100 * i_s / (c_s + i_s)).ToString();
                if (proz.IndexOf(",") == -1)
                    Income_start = i_s.ToString() + " / " + proz;
                else if (proz.IndexOf(",") + 3 == proz.Length)
                    Income_start = i_s.ToString() + " / " + proz;
                else
                    Income_start = i_s.ToString() + " / " + proz.Substring(0, proz.IndexOf(",") + 3);
                Income_start += "%";
            }
            else
            {
                
                Income_start = "0 / 0%";
            }

           
            if (temp_income2.Count() > 0)
            {
                string proz = (100 * i_e / (c_e + i_e)).ToString();
                if (proz.IndexOf(",") == -1)
                    Income_end = i_e.ToString() + " / " + proz;
                else if (proz.IndexOf(",") + 3 == proz.Length)
                    Income_end = i_e.ToString() + " / " + proz;
                else
                    Income_end = i_e.ToString() + " / " + proz.Substring(0, proz.IndexOf(",") + 3);
                Income_end += "%";
            }
            else
            {
               
                Income_end = "0 / 0%";
            }



            end_c  = (c_s - c_e);
            end_i = (i_s-i_e);

            string proz_d_c;
            if (end_c + end_i != 0)
                proz_d_c = (100 * end_c / (end_c + end_i)).ToString();
            else
                proz_d_c = "0";

            string proz_d_i;
            if (end_c + end_i != 0)
                proz_d_i = (100 * end_i / (end_c + end_i)).ToString();
            else
                proz_d_i = "0";

            if (proz_d_i.IndexOf(",") == -1)
                Income_d = end_i.ToString() + " / " + proz_d_c;
            else if (proz_d_i.IndexOf(",") + 3 == proz_d_i.Length)
                Income_d = end_i.ToString() + " / " + proz_d_i;
            else
                Income_d = end_i.ToString() + " / " + proz_d_i.Substring(0, proz_d_i.IndexOf(",") + 3);


            if (proz_d_c.IndexOf(",") == -1)
                Costs_d = end_c.ToString() + " / " + proz_d_c;
            else if (proz_d_c.IndexOf(",") + 3 == proz_d_c.Length)
                Costs_d = end_c.ToString() + " / " + proz_d_c;
            else
                Costs_d = end_c.ToString() + " / " + proz_d_c.Substring(0, proz_d_c.IndexOf(",") + 3);

            Costs_d += "%";
            Income_d += "%";


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

            View_Model_Add_Article my_model_add = new View_Model_Add_Article(my_profile,myDB);
            my_model_add.Button_ok = "Add";

            if (my_model_add.Add == null)
                my_model_add.Add = new Action(my_add.Close);

            my_add.DataContext = my_model_add;

           

            my_add.ShowDialog();
            Set_new_items();

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
            try
            {
                Add_Article my_add = new Add_Article();

                View_Model_Edit_Article my_model_Edit = new View_Model_Edit_Article(myDB, select_item_final.final, my_profile);
                my_model_Edit.Button_ok = "Edit";

                if (my_model_Edit.Edit == null)
                    my_model_Edit.Edit = new Action(my_add.Close);

                my_add.DataContext = my_model_Edit;



                my_add.ShowDialog();
                if (my_model_Edit.is_ok)
                    Set_new_items();
            }catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_Edit(object o)
        {
            if(select_item_final!=null &&  Levels())
          
            return true;
            return false;
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
            try
            {
                Messege messege = new Messege();
                View_Model_Messege messege_view_Model = new View_Model_Messege(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);

                if (messege_view_Model._OK == null)
                    messege_view_Model._OK = new Action(messege.Close);
                if (messege_view_Model._NO == null)
                    messege_view_Model._NO = new Action(messege.Close);
                messege.DataContext = messege_view_Model;
                messege_view_Model.Messege = "Are you sure you want to delete this entry?";
                messege_view_Model.Messeg_Titel = "deleting entry";
                messege.ShowDialog();

                if (messege_view_Model.is_ok)
                {
                    link_final.Remove(select_item_final);


                    var t = myDB.Finals.ToList().Find(x => x.ID == select_item_final.final.ID);
                    myDB.Finals.Remove(t);


                    myDB.SaveChanges();

                    Set_new_items();

                }
            }
            catch (Exception e)
            {
                OpenMessege(e.Message, "Error");
            }
        }
        private bool CanExecute_del(object o)
        {
            if(select_item_final!=null && Levels())
            return true;
            return false;
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
            try
            {
                Editor edit_window = new Editor();
                View_Model_Editor model = new View_Model_Editor(my_profile, myDB);
                edit_window.DataContext = model;


                edit_window.ShowDialog();
              //  myDB = new CashDB();
                Set_new_items();
            }catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_editor(object o)
        {
            return true;
        }
        #endregion Editor
       
        #region profile
        private DelegateCommand _Command_profile;
        public ICommand Button_clik_profile
        {
            get
            {
                if (_Command_profile == null)
                {
                    _Command_profile = new DelegateCommand(Execute_profile, CanExecute_profile);
                }
                return _Command_profile;
            }
        }
        private void Execute_profile(object o)
        {
            try
            {
                My_account window = new My_account();
                View_Model_Profile view_model = new View_Model_Profile(myDB, my_profile);
                window.DataContext = view_model;

                view_model._Edit = new Action(window.Close);
                view_model._Delite = new Action(window.Close);

                window.ShowDialog();

              //  myDB = new CashDB();
                Set_new_items();
                Set_Filter();
                VMSelectedTabIndex = 0;
            }catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_profile(object o)
        {
            return true;
        }
        #endregion  profile

        #region Check
        private DelegateCommand _Command_Check;
        public ICommand Button_clik_Check
        {
            get
            {
                if (_Command_Check == null)
                {
                    _Command_Check = new DelegateCommand(Execute_Check, CanExecute_Check);
                }
                return _Command_Check;
            }
        }
        private void Execute_Check(object o)
        {
            try
            {
                Month_Comparison();
            }catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_Check(object o)
        {
            if (select_item_month_viwe_start != null &&
                select_item_month_viwe_end != null &&
                year_start!=null &&
                year_start.Length > 0&&
                 year_end != null &&
                year_end.Length > 0)
            return true;
            return false;
        }
        #endregion Check

        #region closining

       
        private DelegateCommand _Command_close;
        public ICommand Button_clik_close
        {
            get
            {
                if (_Command_close == null)
                {
                    _Command_close = new DelegateCommand(Execute_close, CanExecute_close);
                }
                return _Command_close;
            }
        }
        private void Execute_close(object o)
        {

            

        }
        private bool CanExecute_close(object o)
        {
           
                return true;
            
        }

        #endregion closining 


        #region profile


        #region Add
        private DelegateCommand _Command_add_profile;
        public ICommand Button_clik_add_profile
        {
            get
            {
                if (_Command_add_profile == null)
                {
                    _Command_add_profile = new DelegateCommand(Execute_add_profile, CanExecute_add_profile);
                }
                return _Command_add_profile;
            }
        }
        private void Execute_add_profile(object o)
        {
            try
            {
                Registration view_registration = new Registration();

                View_Model_Registration View_model_reg = new View_Model_Registration(myDB);

                if (View_model_reg._OK == null)
                    View_model_reg._OK = new Action(view_registration.Ok);

                view_registration.DataContext = View_model_reg;

                view_registration.ShowDialog();
               // myDB = new CashDB();
                Set_new_items();
                Set_Filter();
                VMSelectedTabIndex = 0;
            }catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_add_profile(object o)
        {
            return true;
        }
        #endregion Add

        #region Edit
        private DelegateCommand _Command_Edit_profile;
        public ICommand Button_clik_edit_profile
        {
            get
            {
                if (_Command_Edit_profile == null)
                {
                    _Command_Edit_profile = new DelegateCommand(Execute_Edit_profile, CanExecute_Edit_profile);
                }
                return _Command_Edit_profile;
            }
        }
        private void Execute_Edit_profile(object o)
        {
            try
            {
                My_account window = new My_account();
                View_Model_Profile view_model = new View_Model_Profile(myDB, select_item_profile.person);
                window.DataContext = view_model;

                view_model._Edit = new Action(window.Close);
                view_model._Delite = new Action(window.Close);

                window.ShowDialog();

               // myDB = new CashDB();
                Set_new_items();
                Set_Filter();
                VMSelectedTabIndex = 0;
            }
            catch (Exception e) { OpenMessege(e.Message, "Error"); }
        }
        private bool CanExecute_Edit_profile(object o)
        {
            if (select_item_profile != null && Levels_profile())

                return true;
            return false;
        }
        #endregion Edit

        #region delete
        private DelegateCommand _Command_del_profile;
        public ICommand Button_clik_del_profile
        {
            get
            {
                if (_Command_del_profile == null)
                {
                    _Command_del_profile = new DelegateCommand(Execute_del_profile, CanExecute_del_profile);
                }
                return _Command_del_profile;
            }
        }
        private void Execute_del_profile(object o)
        {
           

        }
        private bool CanExecute_del_profile(object o)
        {
           // if (select_item_profile != null && Levels_profile())
            //    return true;
            return false;
        }
        #endregion delete
        #endregion profile




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

        #region filter
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

        #endregion filter

        #region profiles

        ObservableCollection<List_view_person> profiles;
        public ObservableCollection<List_view_person> Profiles
        {
            set
            {
                profiles = value;
                OnPropertyChanged(nameof(Profiles));
            }
            get
            {
                return profiles;
            }
        }

        List_view_person select_item_profile = null;
        public List_view_person Select_item_profile
        {
            set
            {
                select_item_profile = value;
                OnPropertyChanged(nameof(Select_item_profile));
            }
            get
            {
                return select_item_profile;
            }
        }

        #endregion profiles

        #region Month Comparison

        #region Month start

        List<Month_Viwe> list_month_viwe_start = new List<Month_Viwe>();
        public List<Month_Viwe> List_month_viwe_start
        {
            set
            {
                list_month_viwe_start = value;
                OnPropertyChanged(nameof(List_month_viwe_start));
            }
            get
            {
                return list_month_viwe_start;
            }
        }

        #endregion Month start

        #region Month end

        List<Month_Viwe> list_month_viwe_end = new List<Month_Viwe>();
        public List<Month_Viwe> List_month_viwe_end
        {
            set
            {
                list_month_viwe_end = value;
                OnPropertyChanged(nameof(List_month_viwe_end));
            }
            get
            {
                return list_month_viwe_end;
            }
        }

        #endregion Month end

        #endregion Month Comparison


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
                foreach (var i in myDB.Finals.ToList())
                    if (my_profile.FamilyID == i.Person.FamilyID)
                        Link_final.Add(new List_view_final_my(i));
                OnPropertyChanged(nameof(Link_final));
                //   Set_new_items();

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
                SetIncome();
                SetCosts();
            }
            get
            {
                return vmSelectedTabIndex;
            }
        }

        #endregion
    }
}
