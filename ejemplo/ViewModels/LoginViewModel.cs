using ejemplo.Models;
using ejemplo.Repositories;
using ejemplo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ejemplo.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private int idUsuario;
        private string usuario;
        private SecureString contrasenia;
        private string errorMessage;
        private bool isViewVisible;


        private IUserRepository userRepository;

        public int IdUsuario
        {
            get => idUsuario;

            set
            {
                if (idUsuario != value)
                {
                    idUsuario = value;
                    OnPropertyChanged(nameof(idUsuario));
                }
            }
        }
        public string Usuario
        {
            get => usuario;

            set
            {
                if (usuario != value)
                {
                    usuario = value;
                    OnPropertyChanged(nameof(usuario));
                }
            }

        }
        public SecureString Contrasenia
        {
            get => contrasenia;

            set
            {
                if (contrasenia != value)
                {
                    contrasenia = value;
                    OnPropertyChanged(nameof(contrasenia));
                }
            }

        }
        public string ErrorMessage
        {
            get => errorMessage;

            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(errorMessage));
            }

        }
        public bool IsViewVisible
        {
            get => isViewVisible;

            set
            {
                isViewVisible = value;
                OnPropertyChanged(nameof(isViewVisible));
            }

        }

        // Comandos

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, canExecuteLoginCommand);
            ShowPasswordCommand = new ViewModelCommand(executeShowPassword);

        }

        private void executeShowPassword(object obj)
        {
            throw new NotImplementedException();
        }

        private bool canExecuteLoginCommand(object obj)
        {
            bool datosValidos = true;

            if (string.IsNullOrWhiteSpace(usuario) || contrasenia == null || 
                usuario.Length < 3) {
                    datosValidos = false;
            }

            return datosValidos;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(usuario,contrasenia));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(usuario), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Usuario o contraseña incorrecta";
            }

        }
    }
}
