using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM WeatherVM { get; set; }

        public SearchCommand(WeatherVM weatherVM)
        {
            WeatherVM = weatherVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;
            if (string.IsNullOrWhiteSpace(query))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            WeatherVM.MakeQuery();
        }
    }
}
