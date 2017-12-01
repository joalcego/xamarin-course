using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Lab1JC.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;
using Lab1JC.View;

namespace Lab1JC.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        #region Properties
        private static PersonViewModel instance;
        private PersonModel currentPerson;
        private List<PersonModel> originalPersonList;
        private ObservableCollection<PersonModel> personList;
        public ObservableCollection<PersonModel> PersonList
        {
            get
            {
                return personList;
            }
            set
            {
                personList = value;
                OnPropertyChanged("PersonList");
            }
        }

        private string newName = String.Empty;
        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                newName = value;
                OnPropertyChanged("NewName");
            }
        }

        private string filterValue = String.Empty;
        public string FilterValue
        {
            get
            {
                return filterValue;
            }
            set
            {
                filterValue = value;
                OnPropertyChanged("FilterValue");
                FilterPeople(filterValue);
            }
        }

        public PersonModel CurrentPerson {
            get
            {
                return currentPerson;
            }
            set
            {
                currentPerson = value;
                OnPropertyChanged("CurrentPerson");
            }
        }

        public ICommand AddPersonCommand { get; set; }
        public ICommand RemovePersonCommand { get; set; }
        public ICommand GoPersonDetailsCommand { get; set; }
        public ICommand GoAddSaleCommand { get; set; }

        #endregion

        #region Constructors

        private PersonViewModel()
        {
            InitProperties();
            InitCommands();
        }

        private void InitProperties()
        {
            PersonList = PersonModel.FindPeople();
            originalPersonList = PersonList.ToList();
        }

        private void InitCommands()
        {
            AddPersonCommand = new Command(AddPerson);
            RemovePersonCommand = new Command<int>(RemovePerson);
            GoPersonDetailsCommand = new Command<int>(GoPersonDetails);
            GoAddSaleCommand = new Command(GoAddSale);
        }

        public static PersonViewModel GetInstance() {
            if(instance == null) {
                instance = new PersonViewModel();
            }
            return instance;
        }

        public static void DeleteInstance() {
            if(instance != null) {
                instance = null;
            }
        }

        #endregion

        #region Methods

        private void AddPerson()
        {
            PersonList.Add(new PersonModel() { Name = NewName });
        }

        private void RemovePerson(int id)
        {
            PersonList.Clear();
            originalPersonList = originalPersonList.Where(p => p.Id != id).ToList();
            PersonList = new ObservableCollection<PersonModel>(originalPersonList);
        }

        private void GoPersonDetails(int id) {
            CurrentPerson = PersonList.FirstOrDefault(p => p.Id == id);
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PersonDetail());
        }

        private void GoAddSale()
        {
            //CurrentPerson = PersonList.FirstOrDefault(p => p.Id == id);
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AddSalePage());
        }

        private void FilterPeople(string value)
        {
            value = value.ToLower();
            PersonList.Clear();
            PersonList = new ObservableCollection<PersonModel>(originalPersonList.Where(p => p.Name.ToLower().Contains(value) || p.LastName.ToLower().Contains(value)));
            //originalPersonList.Where(p => p.Name.ToLower().Contains(value) || p.Description.ToLower().Contains(value) || p.LastName.ToLower().Contains(value)).ForEach(p => PersonList.Add((p)));
        }

        #endregion
    }
}