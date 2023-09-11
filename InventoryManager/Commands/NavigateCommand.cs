using InventoryManager.Services;
using InventoryManager.Stores;
using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Commands {
    /// <summary>
    /// This class acts as the base for navigation commands.
    /// The command requires a navigation service typed to a viewmodel.
    /// 
    /// The Execute command will navigate to the typed view model.
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class NavigateCommand<TViewModel> : CommandBase 
        where TViewModel : ViewModelBase {

       
        private readonly INavigationService<TViewModel> _navigationService;

        /// <summary>
        /// Constructor.
        /// The navigation service passed in will reference the view model the service acts for.
        /// </summary>
        /// <param name="navigationService">INavigationService<typeparamref name="TViewModel"/></param>
        public NavigateCommand(INavigationService<TViewModel> navigationService) {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Navigates to the typed view model.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter) {
            _navigationService.Navigate();
        }
    }
}
