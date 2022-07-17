using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppLesson19_Circle.Models;

namespace WpfAppLesson19_Circle.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double number1;
        public double Number1
        {
            get => number1;
            set
            { 
                number1 = value;
                OnPropertyChanged();
            }
        }

        private double number2;
        public double Number2
        {
            get => number2;
            set
            { 
                number2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcCommand { get; }

        private void OnCalcCommandExecute(object p)
        {
            Number2 = Ariph.Calc(Number1);
        }

        private bool CanCalcCommandExecuted (object p)
        {
            if (Number1 > 0) return true;
            else return false;
        }

        public MainWindowViewModel()
        { CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecuted); }

    }
}

