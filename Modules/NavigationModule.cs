using Microsoft.Practices.Prism.Regions;
using DiplomPrint.Modules;
using DiplomPrint.View;
using DiplomPrint.ViewModel;
using DiplomPrint.Pages;
using Microsoft.Practices.Unity;
using DiplomPrint.Model;
using DiplomPrint.Model.DBContext;

namespace DiplomPrint.Modules
{
    public class NavigationModule : INavigationModule
    {
        private readonly IRegionManager _RegionManager;
        private readonly IUnityContainer _UnityContainer;

        public void Initialize()
        {
            var view = _UnityContainer.Resolve<StudentCollectionView>();
            view.DataContext = _UnityContainer.Resolve<ViewModelStudentCollection>();
            _RegionManager.Regions["RegionShell"].Add(view);
        }

        public void NavigateTo(PageNames pageName)
        {
            NavigateTo(pageName, null);
        }

        public void NavigateTo(PageNames pageName, NavigationParameters param)
        {
            if (_RegionManager.Regions["RegionShell"].GetView(pageName.ToString()) == null)
            {
                Helpers.InitializeViewHelper.Run(pageName, _UnityContainer, _RegionManager);
            }

            if (param == null)
            {
                param = new NavigationParameters();
            }
            param.Add("TestParam", "testoviy param");

            _RegionManager.Regions["RegionShell"].RequestNavigate(pageName.ToString(), param);
        }

        public void NavigateTo(PageNames pageName, NavigationParameters param, Student SelectedStudent, StudentContext DB)
        {
            if (_RegionManager.Regions["RegionShell"].GetView(pageName.ToString()) == null)
            {
                Helpers.InitializeViewHelper.RunEdit(pageName, _UnityContainer, _RegionManager, SelectedStudent, DB);
            }

            if (param == null)
            {
                param = new NavigationParameters();
            }
            param.Add("TestParam", "testoviy param");

            _RegionManager.Regions["RegionShell"].RequestNavigate(pageName.ToString(), param);

        }

        public NavigationModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this._RegionManager = regionManager;
            _UnityContainer = unityContainer;
        }
    }
}
