using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace DiplomPrint.Model
{
    public class Student
    {
        public Student()
        {
            CourseWork = new ObservableCollection<CourseWork>();
            StateAtt = new ObservableCollection<StateAttestation>();
            AddInfo = new ObservableCollection<AdditionalInformation>();
            Practice = new ObservableCollection<Practice>();
            Discipline = new ObservableCollection<Discipline>();
            Electives = new ObservableCollection<Electives>();
            ChildrenStudent = new ObservableCollection<Student>();
        }
        private ObservableCollection<CourseWork> _courseWork;
        private ObservableCollection<StateAttestation> _stateAtt;
        private ObservableCollection<AdditionalInformation> _addInfo;
        private ObservableCollection<Practice> _practice;
        private ObservableCollection<Discipline> _discipline;
        private ObservableCollection<Electives> _electives;
        private ObservableCollection<Student> _childrenStudent;

        public virtual ObservableCollection<Student> ChildrenStudent
        {
            get { return _childrenStudent; } set { _childrenStudent = value; }
        }

        public virtual ObservableCollection<CourseWork> CourseWork
        {
            get { return _courseWork; } set { _courseWork = value; }
        }

        public virtual ObservableCollection<StateAttestation> StateAtt
        {
            get { return _stateAtt; } set { _stateAtt = value; }
        }

        public virtual ObservableCollection<AdditionalInformation> AddInfo
        {
            get { return _addInfo; } set { _addInfo = value; }
        }

        public virtual ObservableCollection<Practice> Practice
        {
            get { return _practice; } set { _practice = value; }
        }

        public virtual ObservableCollection<Discipline> Discipline
        {
            get { return _discipline; } set { _discipline = value; }
        }

        public virtual ObservableCollection<Electives> Electives
        {
            get { return _electives; } set { _electives = value; }
        }

        [Key]
        public int StudentID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(265)]
        public string PreviousLevelEducation { get; set; }

        public int RegistrationNumber { get; set; }

        [Required]
        public DateTime ExtraditionDate { get; set; }

        [Required]
        public bool ExcellentAttribute { get; set; }

        [Required]
        public int DiplomSeries { get; set; }

        [Required]
        public int DiplomNumber { get; set; }

        [Required]
        public int AttachmentSeries { get; set; }

        [Required]
        public int AttachmentNumber { get; set; }

        [Required]
        public DateTime DecisionDate { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Specialty { get; set; }

        [Required]
        public string Lifetime { get; set; }

        [Required]
        public string Secession { get; set; }

        public string ClassroomHours { get; set; }
    }
}
