using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Lab1JC.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;

namespace Lab1JC.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        #region Properties
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

        public ICommand AddPersonCommand { get; set; }
        public ICommand RemovePersonCommand { get; set; }

        #endregion

        public PersonViewModel()
        {
            InitClass();
            InitCommand();
        }

        private void InitClass()
        {
            PersonList = PersonModel.FindPeople();
            originalPersonList = PersonList.ToList();
        }

        private void InitCommand()
        {
            AddPersonCommand = new Command(AddPerson);
            RemovePersonCommand = new Command<int>(RemovePerson);
        }

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

        private void FilterPeople(string value)
        {
            value = value.ToLower();
            PersonList.Clear();
            PersonList = new ObservableCollection<PersonModel>(originalPersonList.Where(p => p.Name.ToLower().Contains(value) || p.Description.ToLower().Contains(value) || p.LastName.ToLower().Contains(value)));
            //originalPersonList.Where(p => p.Name.ToLower().Contains(value) || p.Description.ToLower().Contains(value) || p.LastName.ToLower().Contains(value)).ForEach(p => PersonList.Add((p)));
        }

        #endregion
    }
}