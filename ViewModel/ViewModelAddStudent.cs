using Microsoft.Practices.Prism.Regions;
using DiplomPrint.Model.DBContext;
using DiplomPrint.Model;
using DiplomPrint.View;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using DiplomPrint.Modules;
using DiplomPrint.Pages;

namespace DiplomPrint.ViewModel
{
    public class ViewModelAddStudent : ViewModelBase
    {
        #region Command
        public ICommand SaveCommand { get; set; }
        #endregion

        private static AddStudentView _addStudentView;
        public static AddStudentView addStudentView
        {
            get
            {
                if (_addStudentView == null)
                    _addStudentView = new AddStudentView();
                return _addStudentView;
            }
        }

        private StudentContext _db;
        public StudentContext DB
        {
            get { return _db; }
            set
            {
                _db = value;
                OnPropertyChanged("DB");
            }
        }

        /// <summary>
        /// Студент, который будет добавлен в бд по нажатию кнопки "Сохранить"
        /// </summary>
        private Student _diplom;
        public Student Diplom
        {
            get { return _diplom; }
            set
            {
                _diplom = value;
                OnPropertyChanged("Diplom");
            }
        }

        private ObservableCollection<string> _ratingBase;
        public ObservableCollection<string> RatingBase
        {
            get { return _ratingBase; }
            set { _ratingBase = value; OnPropertyChanged("RatingBase"); }
        }

        /// <summary>
        /// Коллекции курсовых, практик, госаттестаций, дисциплин, факультативов и дополнительных сведений
        /// </summary>
        private ObservableCollection<CourseWork> _CourseWork;
        public ObservableCollection<CourseWork> CourseWork
        {
            get { return _CourseWork; }
            set { _CourseWork = value; OnPropertyChanged("CourseWork"); }
        }

        private ObservableCollection<Practice> _Practice;
        public ObservableCollection<Practice> Practice
        {
            get { return _Practice; }
            set { _Practice = value; OnPropertyChanged("Practice"); }
        }
        private ObservableCollection<StateAttestation> _StateAttestation;
        public ObservableCollection<StateAttestation> StateAttestation
        {
            get { return _StateAttestation; }
            set { _StateAttestation = value; OnPropertyChanged("StateAttestation"); }
        }


        private ObservableCollection<Discipline> _Discipline;
        public ObservableCollection<Discipline> Discipline
        {
            get { return _Discipline; }
            set { _Discipline = value; OnPropertyChanged("Discipline"); }
        }


        private ObservableCollection<Electives> _Electives;
        public ObservableCollection<Electives> Electives
        {
            get { return _Electives; }
            set { _Electives = value; OnPropertyChanged("Electives"); }
        }
        private ObservableCollection<AdditionalInformation> _AdditionalInformation;
        public ObservableCollection<AdditionalInformation> AdditionalInformation
        {
            get { return _AdditionalInformation; }
            set { _AdditionalInformation = value; OnPropertyChanged("AdditionalInformation"); }
        }

        public ViewModelAddStudent()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectConfigurationModule());
            DB = ninjectKernel.Get<StudentContext>();
            Diplom = ninjectKernel.Get<Student>();

            CourseWork = new ObservableCollection<CourseWork>();
            Practice = new ObservableCollection<Practice>();
            StateAttestation = new ObservableCollection<StateAttestation>();
            Discipline = new ObservableCollection<Discipline>();
            Electives = new ObservableCollection<Electives>();
            AdditionalInformation= new ObservableCollection<AdditionalInformation>();
            RatingBase = new ObservableCollection<string> { "Отлично", "Хорошо", "Удовлетворительно", "Неудовлетворительно" };


            SaveCommand = new RelayCommand(arg => SaveMethod());
        }

        #region Methods

        /// <summary>
        /// Метод формирует отъект типа Students и добавляет его в БД.
        /// Вызывается по нажатию кнопуи "Сохранить"
        /// </summary>
        private void SaveMethod()
        {
            try
            {
                foreach (var item in Discipline) { Diplom.Discipline.Add(item); }
                foreach (var item in StateAttestation) { Diplom.StateAtt.Add(item); }
                foreach (var item in AdditionalInformation) { Diplom.AddInfo.Add(item); }
                foreach (var item in CourseWork) { Diplom.CourseWork.Add(item); }
                foreach (var item in Practice) { Diplom.Practice.Add(item); }
                foreach (var item in Electives) { Diplom.Electives.Add(item); }
                DB.Student.Add(Diplom);
                DB.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Добавление прошло успешно");
                GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    sb.Append("Object: " + validationError.Entry.Entity.ToString());
                    Debug.Write(" ");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Debug.Write(err.ErrorMessage + " ");
                    }
                }
                System.Windows.Forms.MessageBox.Show(sb.ToString());
            }
            catch (NullReferenceException e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка подключения к базе данных или не выбран элемент для редактирования" + e.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Метод возращения на главную страницу
        /// </summary>
        private void GoBack()
        {
            Navigator.NavigateTo(PageNames.StudentCollectionView);
        }
        #endregion

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
