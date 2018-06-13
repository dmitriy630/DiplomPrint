using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using DiplomPrint.Pages;
using DiplomPrint.View;
using DiplomPrint.ViewModel;
using Microsoft.Practices.Unity;
using DiplomPrint.Model;
using DiplomPrint.Model.DBContext;

namespace DiplomPrint.Modules.Helpers
{
    public static class InitializeViewHelper
    {
        public static void Run(PageNames pageName, IUnityContainer unityContainer, IRegionManager regionManager)
        {
            switch (pageName)
            {
                case PageNames.StudentCollectionView:
                    regionManager.Regions["RegionShell"].Add(GetStudentCollectionView(unityContainer));
                    return;
                case PageNames.AddStudentView:
                    regionManager.Regions["RegionShell"].Add(GetAddStudentView(unityContainer));
                    return;
                case PageNames.EditStudentView:
                    regionManager.Regions["RegionShell"].Add(GetEditStudentView(unityContainer));
                    return;
            }
        }

        public static void RunEdit (PageNames pageName, IUnityContainer unityContainer, IRegionManager regionManager, Student SelectedStudent, StudentContext DB)
        {
            switch (pageName)
            {
                case PageNames.StudentCollectionView:
                    regionManager.Regions["RegionShell"].Add(GetStudentCollectionView(unityContainer));
                    return;
                case PageNames.AddStudentView:
                    regionManager.Regions["RegionShell"].Add(GetAddStudentView(unityContainer));
                    return;
                case PageNames.EditStudentView:
                    regionManager.Regions["RegionShell"].Add(GetTest(unityContainer, SelectedStudent, DB));
                    return;
            }
            
        }

        private static UserControl GetTest(IUnityContainer unityContainer, Student selectedStudent, StudentContext db)
        {
            var view = unityContainer.Resolve<EditStudentView>();
            //ViewModelEditStudent vm = new ViewModelEditStudent(selectedStudent, db);
            view.DataContext = new ViewModelEditStudent(selectedStudent, db);
            return view;
        }

        private static UserControl GetStudentCollectionView(IUnityContainer unityContainer)
        {
            var view = unityContainer.Resolve<StudentCollectionView>();
            view.DataContext = unityContainer.Resolve<ViewModelStudentCollection>();
            return view;
        }

        private static UserControl GetAddStudentView(IUnityContainer unityContainer)
        {
            var view = unityContainer.Resolve<AddStudentView>();
            view.DataContext = unityContainer.Resolve<ViewModelAddStudent>();
            return view;
        }

        private static UserControl GetEditStudentView(IUnityContainer unityContainer)
        {
            var view = unityContainer.Resolve<EditStudentView>();
            view.DataContext = unityContainer.Resolve<ViewModelEditStudent>();
            return view;

        }
    }
}
