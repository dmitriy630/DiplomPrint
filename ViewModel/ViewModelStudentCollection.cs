using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using DiplomPrint.Pages;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using DiplomPrint.Model.DBContext;
using System.Collections.ObjectModel;
using DiplomPrint.Model;
using Ninject;
using DiplomPrint.Modules;
using System;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using DiplomPrint.View;
using System.Data.Entity;

namespace DiplomPrint.ViewModel
{
    public class ViewModelStudentCollection : MasterNavigationViewModel
    {       
        /// <summary>
        /// поля, свойства
        /// </summary>



        private StudentContext _db;
        public StudentContext DB
        {
            get { return _db; }
            set { _db = value; OnPropertyChanged("DB"); }
        }

        /// <summary>
        /// Свойство, ItemSource для DataGrid
        /// </summary>
        private ObservableCollection<Student> _db0;
        public ObservableCollection<Student> DB0
        {
            get { return _db0; }
            set { _db0 = value; OnPropertyChanged("DB0"); }
        }

        /// <summary>
        /// Свойство, отвечающее за выбранного студента (строку) в DataGrid
        /// </summary>
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; OnPropertyChanged("SelectedStudent"); }
        }

        #region Commands
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        #endregion


        #region Ctors
        public ViewModelStudentCollection()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectConfigurationModule());
            DB = ninjectKernel.Get<StudentContext>();
            DB0 = new ObservableCollection<Student>(DB.Student);
            AddStudentCommand = new DelegateCommand(AddStudentMethod);
            EditStudentCommand = new DelegateCommand(EditStudentMethod);
            ExitCommand = new RelayCommand(arg => ExitMethod());
            DeleteStudentCommand = new RelayCommand(arg => DeleteStudentMethod());
            CopyCommand = new RelayCommand(arg => CopyStudentMethod());
        }
        #endregion
        /// <summary>
        /// страница будет жить в памяти даже когда мы её покинем
        /// </summary>
        //public override bool KeepAlive
        //{
        //    get
        //    {
        //        return true; 
        //    }
        //}

        #region Methods
        /// <summary>
        /// Метод отвечающий за обновление  DataGrid  при внесении изменений
        /// </summary>
        private void RefreshDG()
        {
            DB0.Clear();
            var studentCollection = DB.Student;
            foreach (var item in studentCollection)
            {
                DB0.Add(item);
            }
        }

        /// <summary>
        /// Метод выхода в ОС
        /// </summary>
        private void ExitMethod()
        {
            try
            {
                DB.Dispose();
            }
            catch (ObjectDisposedException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Метод, удаляющий студента из БД 
        /// </summary>
        private void DeleteStudentMethod()
        {
            if (SelectedStudent != null)
            {
                var confirmResult = System.Windows.Forms.MessageBox.Show("Вы собираетесь удалить студента из базы данных. Вы уверены?",
                    "Подтвердите удаление",
                    System.Windows.Forms.MessageBoxButtons.YesNo);
                if (confirmResult == System.Windows.Forms.DialogResult.Yes)
                {
                    DB.Student.Remove(DB.Student.FirstOrDefault(x => x.StudentID == SelectedStudent.StudentID));
                    DB.SaveChanges();
                    RefreshDG();
                }
                else
                {
                    return;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Студент не выбран");
            }
        }

        /// <summary>
        /// Метод перехода на view добавления студента
        /// </summary>
        private void AddStudentMethod()
        {
            Navigator.NavigateTo(PageNames.AddStudentView);
            RefreshDG();
        }

        /// <summary>
        /// Метод перехода на view добавления редактирования студента
        /// </summary>
        private void EditStudentMethod()
        {
            if (SelectedStudent != null)
            {
                Navigator.NavigateTo(PageNames.EditStudentView, null, SelectedStudent, DB);
                RefreshDG();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Студент не выбран");
            }
        }

        /// <summary>
        /// Метод копирования студента
        /// </summary>
        private void CopyStudentMethod()
        {
            if (SelectedStudent != null)
            {

                DeepCloneStudent(SelectedStudent);
                RefreshDG();
                System.Windows.Forms.MessageBox.Show("Копирование студента прошло успешно!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Студент не выбран");
            }
        }

        public Student DeepCloneStudent(Student student)
        {
            Student studentClone = DB.Student.FirstOrDefault(i => i.StudentID == SelectedStudent.StudentID);
            deepClone(studentClone);
            DB.SaveChanges();
            return studentClone;
        }

        private void deepClone(Student itemClone)
        {
            foreach (Student child in itemClone.ChildrenStudent) { deepClone(child); }

            foreach (Discipline dis in itemClone.Discipline) { DB.Entry(dis).State = EntityState.Added; }
            foreach (Electives electi in itemClone.Electives) { DB.Entry(electi).State = EntityState.Added; }
            foreach (CourseWork course in itemClone.CourseWork) { DB.Entry(course).State = EntityState.Added; }
            foreach (StateAttestation stateAtt in itemClone.StateAtt) { DB.Entry(stateAtt).State = EntityState.Added; }
            foreach (Practice pract in itemClone.Practice) { DB.Entry(pract).State = EntityState.Added; }
            foreach (AdditionalInformation addInfo in itemClone.AddInfo) { DB.Entry(addInfo).State = EntityState.Added; }
            
            DB.Entry(itemClone).State = EntityState.Added;
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
