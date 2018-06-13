using DiplomPrint.Model;
using DiplomPrint.Model.DBContext;
using DiplomPrint.View;
using Ninject;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using iTextSharp.text.pdf;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Practices.Prism.Regions;
using DiplomPrint.Modules;
using DiplomPrint.Pages;

namespace DiplomPrint.ViewModel
{
    public class ViewModelEditStudent : ViewModelBase
    {
        /// <summary>
        /// Properties & Commands
        /// </summary>
        private StudentContext _db;
        private Student _diplom;

        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AttachmentPrintCommand { get; set; }
        public ICommand DiplomPrintCommand { get; set; }


        private string _chairpersonStateCommission;
        public string ChairpersonStateCommission
        {
            get { return _chairpersonStateCommission; }
            set { _chairpersonStateCommission = value; OnPropertyChanged("ChairpersonStateCommission"); }
        }

        private string _leader;
        public string Leader
        {
            get { return _leader; }
            set { _leader = value; OnPropertyChanged("Leader"); }
        }

        private string _secretary;
        public string Secretary
        {
            get { return _secretary; }
            set { _secretary = value; OnPropertyChanged("Secretary"); }
        }

        private ObservableCollection<string> _ratingBase;
        public ObservableCollection<string> RatingBase
        {
            get { return _ratingBase; }
            set { _ratingBase = value; OnPropertyChanged("RatingBase"); }
        }

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

        public StudentContext DB
        {
            get { return _db; }
            set
            {
                _db = value;
                OnPropertyChanged("_db");
            }
        }

        /// <summary>
        /// Студент, который будет добавлен в бд по нажатию кнопки "Сохранить"
        /// </summary>
        public Student Diplom
        {
            get { return _diplom; }
            set
            {
                _diplom = value;
                OnPropertyChanged("_diplom");
            }
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

        /// <summary>
        /// Ctors
        public ViewModelEditStudent()
        {
            IKernel ninjectKernel = new StandardKernel(new NinjectConfigurationModule());
            DB = ninjectKernel.Get<StudentContext>();
            Diplom = ninjectKernel.Get<Student>();

            CourseWork = new ObservableCollection<CourseWork>();
            Practice = new ObservableCollection<Practice>();
            StateAttestation = new ObservableCollection<StateAttestation>();
            Discipline = new ObservableCollection<Discipline>();
            Electives = new ObservableCollection<Electives>();
            AdditionalInformation = new ObservableCollection<AdditionalInformation>();
            RatingBase = new ObservableCollection<string> { "Отлично", "Хорошо", "Удовлетворительно", "Неудовлетворительно" };

            SaveCommand = new RelayCommand(arg => SaveMethod());
            //AttachmentPrintCommand = new RelayCommand(arg => AttachmentPrintMethod());
            //DiplomPrintCommand = new RelayCommand(arg => DiplomPrintMethod());
        }

        public ViewModelEditStudent(Student SelectedStudent, StudentContext DB) : base()
        {
            this.DB = DB;
            Diplom = SelectedStudent;
            CourseWork = new ObservableCollection<CourseWork>();
            Practice = new ObservableCollection<Practice>();
            StateAttestation = new ObservableCollection<StateAttestation>();
            Discipline = new ObservableCollection<Discipline>();
            Electives = new ObservableCollection<Electives>();
            AdditionalInformation = new ObservableCollection<AdditionalInformation>();
            RatingBase = new ObservableCollection<string> { "Отлично", "Хорошо", "Удовлетворительно", "Неудовлетворительно" };
            ChairpersonStateCommission = Properties.Settings.Default.ChairpersonStateCommission;
            Leader = Properties.Settings.Default.Leader;
            Secretary = Properties.Settings.Default.Secretary;

            foreach (var item in Diplom.StateAtt) { StateAttestation.Add(item); }
            foreach (var item in Diplom.Discipline) { Discipline.Add(item); }
            foreach (var item in Diplom.AddInfo) { AdditionalInformation.Add(item); }
            foreach (var item in Diplom.CourseWork) { CourseWork.Add(item); }
            foreach (var item in Diplom.Practice) { Practice.Add(item); }
            foreach (var item in Diplom.Electives) { Electives.Add(item); }

            SaveCommand = new RelayCommand(arg => SaveMethod());
            AttachmentPrintCommand = new RelayCommand(arg => AttachmentPrintMethod());
            DiplomPrintCommand = new RelayCommand(arg => DiplomPrintMethod());
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
                Diplom.Secession = Properties.Settings.Default.Secession;
                DB.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Изменение прошло успешно");
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

        private void AttachmentPrintMethod()
        {
            var pdfTemplate = @"templateAttachment.pdf";
            var pdfFile = @"resultAttachment.pdf";

            string[] fio = Diplom.FullName.Split(new char[] { ' ' });
            string fam = fio[0];
            string name = fio[1];
            string otch = fio[2];

            

            string obraz = "";
            switch (Diplom.ExcellentAttribute)
            {
                case true:
                    obraz = "о среднем профессиональном образовании с отличием";
                    break;
                case false:
                    obraz = "о среднем профессиональном образовании";
                    break;
            }

            using (var templateReader = new PdfReader(pdfTemplate))
            {
                using (var resultStamper = new PdfStamper(templateReader, new FileStream(pdfFile, FileMode.Create)))
                {
                    var form = resultStamper.AcroFields;
                    var fonts = templateReader.GetFormFonts();

                    for (int i = 0; i <= CourseWork.Count - 1; i++)
                    {
                        form.SetFieldWithFont(templateReader, fonts, "kursName" + i, CourseWork[i].CourseWorkName);
                        form.SetFieldWithFont(templateReader, fonts, "kursOcenka" + i, CourseWork[i].Rating);
                    }

                    form.SetFieldProperty("Fam", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("Fam", fam);

                    form.SetFieldProperty("Name", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("Name", name);

                    form.SetFieldProperty("Otchestvo", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("Otchestvo", otch);

                    string BirthDateMouth;
                    MouthSelect(Diplom.BirthDate.Month, out BirthDateMouth);
                    form.SetFieldProperty("DR", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("DR", Diplom.BirthDate.Day + " " + BirthDateMouth + Diplom.BirthDate.Year + " года");

                    form.SetFieldWithFont(templateReader, fonts, "lvlObrazovaniya", Diplom.PreviousLevelEducation);

                    form.SetFieldProperty("otlich", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("otlich", obraz);

                    form.SetFieldProperty("seriyaNomer", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("seriyaNomer", Diplom.AttachmentSeries + " № " + Diplom.AttachmentNumber);

                    form.SetFieldProperty("regNomer", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("regNomer", Diplom.RegistrationNumber.ToString());


                    string DecisionDateMouth;
                    MouthSelect(Diplom.BirthDate.Month, out DecisionDateMouth);
                    form.SetFieldProperty("dateVidachi", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("dateVidachi", Diplom.DecisionDate.Day + " " + DecisionDateMouth +  Diplom.ExtraditionDate.Year + " года");

                    form.SetFieldProperty("srokOsvoeniya", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("srokOsvoeniya", Diplom.Lifetime);

                    form.SetFieldProperty("kval", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("kval", Diplom.Qualification);

                    form.SetFieldProperty("spec", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("spec", Diplom.Specialty);

                    int allHour = 0;
                    int roundCount = 0;
                    string selectedItem;
                    for (int i = 0; i <= Discipline.Count - 1; i++)
                    {
                        selectedItem = Discipline[i].DisciplineName;
                        if (selectedItem.Length > 50)
                        {
                            var chunkSize = 50;
                            var result = (from Match m in Regex.Matches(selectedItem, @".{1," + chunkSize + "}")
                                          select m.Value).ToList();
                            for (int j = 0; j <= result.Count - 1; j++)
                            {
                                form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, result[j]);
                                roundCount++;
                            }
                            roundCount = roundCount - 1;
                        }
                        else
                        {
                            form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, selectedItem);
                        }

                        form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, Discipline[i].QuantityHours.ToString());
                        if (Discipline[i].Rating!= "_")
                        {
                            form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, Discipline[i].Rating);
                        }

                        if (Discipline[i].QuantityHours.ToString() != "")
                        {
                            allHour += Discipline[i].QuantityHours;
                        }
                        roundCount++;
                    }

                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "ВСЕГО часов теоретического обучения:");
                    form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, allHour.ToString());
                    form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, "X");

                    roundCount = roundCount + 1;

                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "в том числе аудиторных часов:");
                    form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, Diplom.ClassroomHours);

                    form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, "X");

                    int allWeek = 0;
                    for (int i = 0; i <= Practice.Count - 1; i++)
                    {
                        allWeek += Practice[i].QuantityWeeks;
                    }

                    roundCount = roundCount + 1;
                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "Практика");
                    form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, allWeek.ToString() + " недель");
                    form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, "X");

                    roundCount = roundCount + 1;
                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "в том числе:");

                    roundCount = roundCount + 1;
                    for (int i = 0; i <= Practice.Count - 1; i++)
                    {
                        form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, Practice[i].PracticeName);
                        if (Practice[i].QuantityWeeks >= 10)
                        {
                            form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, Practice[i].QuantityWeeks + " недель");
                        }
                        else if ((int.Parse(Practice[i].QuantityWeeks.ToString()) == 1) || (int.Parse(Practice[i].QuantityWeeks.ToString()) == 21))
                        {
                            form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, Practice[i].QuantityWeeks + " неделя");
                        }
                        else
                        {
                            form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, Practice[i].QuantityWeeks + " недели");
                        }
                        if (Practice[i].Rating != "_")
                        {
                            form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, Practice[i].Rating);
                        }
                        roundCount++;
                    }

                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "Государственная итоговая аттестация");
                    form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, StateAttestation[0].QuantityWeeks + " недель");
                    form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, "X");

                    roundCount = roundCount + 1;
                    form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, "в том числе:");

                    roundCount = roundCount + 1;
                    if (StateAttestation[0].StateAttestationName.Length >= 50)
                    {
                        var chunkSize = 50;
                        var result = (from Match m in Regex.Matches(StateAttestation[0].StateAttestationName, @".{1," + chunkSize + "}")
                                      select m.Value).ToList();
                        for (int i = 0; i <= result.Count - 1; i++)
                        {
                            form.SetFieldWithFont(templateReader, fonts, "disc" + roundCount, result[i]);
                            roundCount++;
                        }
                    }

                    roundCount = roundCount - 1;
                    form.SetFieldWithFont(templateReader, fonts, "discHour" + roundCount, "X");
                    form.SetFieldWithFont(templateReader, fonts, "discOcenka" + roundCount, StateAttestation[0].Rating);

                    resultStamper.Close();
                }
                templateReader.Close();
            }
            Process.Start(Environment.CurrentDirectory + @"\resultAttachment.pdf");
        }

        private void MouthSelect (int MouthNumber, out string MouthName)
        {
            MouthName = "";
            switch (MouthNumber)
            {
                case 1:
                    MouthName = "января ";
                    return;
                case 2:
                    MouthName = "февраля ";
                    return;
                case 3:
                    MouthName = "марта ";
                    return;
                case 4:
                    MouthName = "апреля ";
                    return;
                case 5:
                    MouthName = "мая ";
                    return;
                case 6:
                    MouthName = "июня ";
                    return;
                case 7:
                    MouthName = "июля ";
                    return;
                case 8:
                    MouthName = "августа ";
                    return;
                case 9:
                    MouthName = "сентября ";
                    return;
                case 10:
                    MouthName = "октября ";
                    return;
                case 11:
                    MouthName = "ноября ";
                    return;
                case 12:
                    MouthName = "декабря ";
                    return;
            }
        }

        private void DiplomPrintMethod()
        {
            var pdfTemplate = @"templateDiplom.pdf";
            var pdfFile = @"resultDiplom.pdf";

            using (var templateReader = new PdfReader(pdfTemplate))
            {
                using (var resultStamper = new PdfStamper(templateReader, new FileStream(pdfFile, FileMode.Create)))
                {
                    var form = resultStamper.AcroFields;
                    var fonts = templateReader.GetFormFonts();

                    form.SetFieldProperty("FIO", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("FIO", Diplom.FullName);

                    form.SetFieldProperty("kval", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("Kval", Diplom.Qualification);

                    form.SetFieldProperty("regNomer", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("RegNum", Diplom.RegistrationNumber.ToString());

                    string ExtraditionDateMouth;
                    MouthSelect(Diplom.ExtraditionDate.Month, out ExtraditionDateMouth);
                    form.SetFieldProperty("VidachaDate", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("VidachaDate", Diplom.ExtraditionDate.Day + " " + ExtraditionDateMouth + Diplom.ExtraditionDate.Year + " года");

                    form.SetFieldProperty("spec", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("Spec", Diplom.Specialty);

                    string DecisionDateMouth;
                    MouthSelect(Diplom.DecisionDate.Month, out DecisionDateMouth);
                    form.SetFieldProperty("ReshDate", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("ReshDate", Diplom.DecisionDate.Day + " " + DecisionDateMouth + Diplom.DecisionDate.Year + " года");

                    form.SetFieldProperty("predsed", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("PredsedName", "Сидоров");

                    form.SetFieldProperty("director", "TimesNewRoman", BaseFont.COURIER_BOLD, null);
                    form.SetField("DirectorName", "Петров");

                    resultStamper.Close();
                }
                templateReader.Close();
            }
            Process.Start(System.Windows.Forms.Application.StartupPath + @"\resultDiplom.pdf");
        }
        #endregion

        private void GoBack()
        {
            Navigator.NavigateTo(PageNames.StudentCollectionView);
        }

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
