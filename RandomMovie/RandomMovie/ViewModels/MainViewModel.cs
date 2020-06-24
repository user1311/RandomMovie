using RandomMovie.Commands;
using RandomMovie.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomMovie.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public SearchPerformCommand SearchCommand{ get; set; }

        public MainViewModel()
        {
            SearchCommand = new SearchPerformCommand(this);
        }


        private Movie movie;

        public Movie CurrentMovie
        {
            get { return movie; }
            set {
                if (movie != value)
                {
                    movie = value;
                    OnPropertyChanged(nameof(CurrentMovie));
                }

            }
        }

        private string searchParam;

        public string SearchParam
        {
            get { return searchParam; }
            set {
                if(searchParam!=value)
                {
                    searchParam = value;
                }
                
                OnPropertyChanged(nameof(SearchParam));
                
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
