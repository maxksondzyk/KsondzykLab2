using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using KsondzykLab2.Models;
using KsondzykLab2.Tools.Managers;
using KsondzykLab2.Tools.MVVM;

namespace KsondzykLab2.ViewModels
{

    internal class ViewModel : INotifyPropertyChanged
    {
        #region Fields
        private bool _filledName;
        private bool _filledLastName;
        private bool _filledMail;
        private bool _filledBirthday;
        private RelayCommand<object> _startCommand;
        private Person _person = new Person();
        private string _name;
        private string _lastName;
        private string _mail;
        private string _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private string _isBirthday;
        private DateTime? _birthday;
        private string _birth;
        #endregion

        #region Properties
        public DateTime? Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                if (value != null)
                {
                    _birth = value.Value.ToShortDateString();
                    _filledBirthday = true;
                }
                else _filledBirthday = false;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                if (value != "")
                    _filledName = true;
                else _filledName = false;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                if (value != "")
                    _filledLastName = true;
                else _filledLastName = false;
                OnPropertyChanged();
            }
        }
        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                if (value != "")
                    _filledMail = true;
                else _filledMail = false;
                OnPropertyChanged();
            }
        }

        public string IsAdult
        {
            get
            {
                return _isAdult;
            }
            set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }
        public string IsBirthday
        {
            get
            {
                return _isBirthday;
            }
            set
            {
                _isBirthday = value;
                OnPropertyChanged();
            }
        }
        public string SunSign
        {
            get
            {
                return _sunSign;
            }
            set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }
        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
            set
            {
                _chineseSign = value;
                OnPropertyChanged();
            }
        }
        public string UserMail
        {
            get
            {
                return _person.Mail;
            }
            set
            {
                _person.Mail = value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get
            {
                return _person.Name;
            }
            set
            {
                _person.Name = value;
                OnPropertyChanged();
            }
        }
        public string UserLastName
        {
            get
            {
                return _person.LastName;
            }
            set
            {
                _person.LastName = value;
                OnPropertyChanged();
            }
        }
        
        public string Birth
        {
            get
            {
                return _birth;
            }
            set
            {
                _birth = value;
                OnPropertyChanged();
            }
        }
        #endregion
        private bool CanExecute()
        {
            return _filledMail&&_filledBirthday&&_filledLastName&&_filledName;
        }
        public RelayCommand<object> StartCommand
        {
            get
            {
                return _startCommand ??= new RelayCommand<object>(Calculate, o => CanExecute());
            }

        }
        
        private async void Calculate(object obj)
        {
            
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(2000));
            _person = new Person(Name,LastName,Mail,Birthday);
            LoaderManager.Instance.HideLoader();
            if (_person.IsAdult=="wrong")
            {
                MessageBox.Show("Incorrect date!");
                IsAdult = "";
                SunSign = "";
                ChineseSign = "";
                IsBirthday = "";
                UserName = "";
                UserLastName = "";
                Birth = "";
                UserMail = "";
            }
            else
            {
                IsAdult = $"Adult: {_person.IsAdult}";
                SunSign = $"Your sun sign: {_person.SunSign}";
                ChineseSign = $"Your chinese sign: {_person.ChineseSign}";
                IsBirthday = $"It's your birthday: {_person.isBirthday}";

                UserName = $"Your name is {_person.Name}";
                UserLastName = $"Your last name is {_person.LastName}";
                Birth = $"Your birthday is: {_person.Birthday.Value.ToShortDateString()}";
                UserMail = $"Your mail is: {_person.Mail}";
                if (_person.Birthday.Value.DayOfYear.Equals(DateTime.Today.DayOfYear))
                {
                    MessageBox.Show("Happy Birthday!");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
