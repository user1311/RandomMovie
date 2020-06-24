using RandomMovie.Data;
using RandomMovie.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RandomMovie.Commands
{
    public class SearchPerformCommand : ICommand
    {
        private MainViewModel vm;

        public SearchPerformCommand(MainViewModel mainViewModel)
        {
            vm = mainViewModel;
        }
        
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(vm.SearchParam))
            {
                return false;
            }
            return true;
        }

        public async void Execute(object parameter)
        {
            if (vm.CurrentMovie != null)
                vm.CurrentMovie = null;

            vm.CurrentMovie = await MoviesManager.GetMovieByTitle(vm.SearchParam);
            
        }
    }
}
