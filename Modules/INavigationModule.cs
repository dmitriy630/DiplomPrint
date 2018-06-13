using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Modularity;
using DiplomPrint.Pages;
using DiplomPrint.Model;
using DiplomPrint.Model.DBContext;

namespace DiplomPrint.Modules
{
    public interface INavigationModule : IModule
    {
        void NavigateTo(PageNames pageName);

        void NavigateTo(PageNames pageName, NavigationParameters param);

        void NavigateTo(PageNames pageName, NavigationParameters param, Student SelectedStudent, StudentContext DB);
    }
}
