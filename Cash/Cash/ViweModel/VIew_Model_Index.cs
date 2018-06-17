using Cash.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cash.ViweModel
{
    class Viwe_Model_Index: View_Model_Base
    {

        #region Pole

        #region Filter

        #region Product

        bool product;
        public bool Product
        {
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
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
        public bool Person
        {
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
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
        public bool Price
        {
            set
            {
                price=
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
            View_Model_Editor model= new View_Model_Editor();
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

        #endregion
    }
}
