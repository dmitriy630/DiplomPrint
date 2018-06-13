using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using DiplomPrint.Pages;
using System.ComponentModel;

namespace DiplomPrint.ViewModel
{
    public abstract class ViewModelBase : MasterNavigationViewModel, INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            GoBackCommand = new DelegateCommand(GoBack);
        }

        public ICommand GoBackCommand { get; set; }

        private void GoBack()
        {
            Navigator.NavigateTo(PageNames.StudentCollectionView);
        }
    }
}
