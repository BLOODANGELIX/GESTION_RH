using System;
using FontAwesome.WPF;
using System.Windows.Input;
using ejemplo.Views;

namespace ejemplo.ViewModels
{
    public class InicioAdministradorViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private string _description;
        private FontAwesomeIcon _icon;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public FontAwesomeIcon Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Comandos
        public ICommand ShowEmpleadoViewCommand { get; }
        public ICommand ShowDepartamentoViewCommand { get; }
        public ICommand ShowPuestoViewCommand { get; }

        public InicioAdministradorViewModel()
        {
            ShowDepartamentoViewCommand = new ViewModelCommand(ExecuteShowDepartamentoView);
            ShowEmpleadoViewCommand = new ViewModelCommand(ExecuteShowEmpleadoView);
            ShowPuestoViewCommand = new ViewModelCommand(ExecuteShowPuestoView);

            // Vista por defecto
            ExecuteShowEmpleadoView(null);
        }

        private void ExecuteShowPuestoView(object obj)
        {
            CurrentView = new PuestosViewModel();
            Description = "Puestos";
            Icon = FontAwesomeIcon.IdBadge;
        }

        private void ExecuteShowEmpleadoView(object obj)
        {
            CurrentView = new EmpleadosViewModel();
            Description = "Empleados";
            Icon = FontAwesomeIcon.Users;
        }

        private void ExecuteShowDepartamentoView(object obj)
        {
            CurrentView = new DepartamentoViewModel();
            Description = "Departamentos";
            Icon = FontAwesomeIcon.Building;
        }
    }
}
