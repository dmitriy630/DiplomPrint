using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using DiplomPrint.Modules;
using Microsoft.Practices.ServiceLocation;

namespace DiplomPrint.Pages
{
    public abstract class MasterNavigationViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        protected INavigationModule Navigator
        {
            get
            {
                return ServiceLocator.Current.GetInstance<INavigationModule>();
            }
        }

        public virtual bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        public abstract bool IsNavigationTarget(NavigationContext navigationContext);

        public abstract void OnNavigatedFrom(NavigationContext navigationContext);

        public abstract void OnNavigatedTo(NavigationContext navigationContext);
    }
}
