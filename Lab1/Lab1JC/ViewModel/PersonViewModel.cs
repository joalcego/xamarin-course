using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Lab1JC.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab1JC.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        private ObservableCollection<PersonModel> personList = new ObservableCollection<PersonModel>() {
            new PersonModel() { Name = "Jose", LastName="Cerdas", Description="Hola esta es una descripcion" },
            new PersonModel() { Name = "Luis", LastName="Cerdas", Description="Hola esta es una descripcion" },
            new PersonModel() { Name = "Anayansi", LastName="Cerdas", Description="Hola esta es una descripcion" },
            new PersonModel() { Name = "Micela", LastName="Gonzalez", Description="Hola esta es una descripcion" },
            new PersonModel() { Name = "Marcos", LastName="Cerdas", Description="Hola esta es una descripcion" },
        };

        public ObservableCollection<PersonModel> PersonList
        {
            get
            {
                if (String.IsNullOrWhiteSpace(FilterValue))
                {
                    return personList;
                }
                else {
                    return new ObservableCollection<PersonModel>(personList.Where(p => p.Name.Contains(FilterValue) || p.Description.Contains(FilterValue) || p.LastName.Contains(FilterValue)));
                }
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
            get {
                return newName;
            }
            set {
                newName = value;
                OnPropertyChanged("NewName"); //TODO: find a different way to do
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
                OnPropertyChanged("PersonList");
            }
        }

        public ICommand AddPersonCommand { get; set; }

        public PersonViewModel()
        {
            AddPersonCommand = new Command(AddPerson);
        }

        private void AddPerson() {
            PersonList.Add(new PersonModel() { Name = NewName });
        }
    }
}