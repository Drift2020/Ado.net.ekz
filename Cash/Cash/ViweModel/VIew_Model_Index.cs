using Cash.Code;
using Cash.Command;
using Cash.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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


        }
        #region Pole


        #region Filter

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
        string serch_category;
        public string Serch_category
        {
            set
            {
                serch_category = value;
                OnPropertyChanged(nameof(Serch_category));
            }
            get
            {
                return serch_category;
            }
        }

      
        #endregion

        #region Goods
        string serch_goods;
        public string Serch_goods
        {
            set
            {
                serch_goods = value;
                OnPropertyChanged(nameof(Serch_goods));
            }
            get
            {
                return serch_goods;
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

     
        #endregion

        #region Name
        string serch_name;
        public string Serch_name
        {
            set
            {
                serch_name = value;
                OnPropertyChanged(nameof(Serch_name));
            }
            get
            {
                return serch_name;
            }
        }
        #endregion

        #region Surname
        string serch_surname;
        public string Serch_surname
        {
            set
            {
                serch_surname = value;
                OnPropertyChanged(nameof(Serch_surname));
            }
            get
            {
                return serch_surname;
            }
        }
        #endregion

        #region Patronymic
        string serch_patronymic;
        public string Serch_patronymic
        {
            set
            {
                serch_patronymic = value;
                OnPropertyChanged(nameof(Serch_patronymic));
            }
            get
            {
                return serch_patronymic;
            }
        }
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

        #endregion

        #region price start

        string price_start;
        public string Price_start
        {
            set
            {
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

        string price_end;
        public string Price_end
        {
            set
            {
                price_end = value;
                OnPropertyChanged(nameof(Price_end));
            }
            get
            {
                return price_start;
            }
        }

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



        #endregion

        #region Date start

        string date_start;

        public string Date_start
        {
            set
            {
                date_start = value;
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

        #region Date incomes

        bool incomes;
        public bool Incomes
        {
            set
            {
                incomes = value;
                OnPropertyChanged(nameof(Incomes));
            }
            get
            {
                return incomes;
            }
        }

        #endregion

        #region Date costs

        bool costs;
        public bool Costs
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


                Link_final.Clear();


                if (Product_box)
                {
                    temp = GetSelectedCategory();
                    temp_product = GetSelectedGoods();
                }

                foreach (var i in myDB.Finals.ToList())
                {
                    List_view_final_my temp_elem = new List_view_final_my(i);

                    if (my_profile.FamilyID == i.Person.FamilyID)
                    {
                        if(Product_box)
                        {                          
                            foreach(var i_category in temp)
                            {
                                foreach (var i_product_category in i.Product.Categories)
                                {
                                    if (i_category.ID == i_product_category.ID &&
                                        Link_final.ToList().Find(x=>x.ID ==i.ID) == null

                                        )
                                    {
                                        Link_final.Add(temp_elem);
                                    }
                                }
                            }

                          
                            foreach (var i_goods in temp_product)
                            {
                                if (i_goods.ID == i.Product.ID)
                                {
                                    if (Link_final.ToList().Find(x => x.ID == i.ID) == null)
                                    {
                                        Link_final.Add(temp_elem);
                                    }
                                }
                            }
                          
                        }      
                        
                        if(Person_box)
                        {

                        }
                    }
                }

                if (!Product_box|| (temp.Count==0&& temp_product.Count==0))
                {
                    foreach (var iF in myDB.Finals.ToList())
                        if (my_profile.FamilyID == iF.Person.FamilyID)
                            Link_final.Add(new List_view_final_my(iF));
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
