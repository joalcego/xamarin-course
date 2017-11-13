using System;
using System.Collections.ObjectModel;
namespace Lab1JC.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public static ObservableCollection<PersonModel> FindPeople() {
            return new ObservableCollection<PersonModel>() {
                new PersonModel() { Id=1, Name = "Jose", LastName="Cerdas", Description="Hola esta es una descripcion" },
                new PersonModel() { Id=2, Name = "Luis", LastName="Cerdas", Description="Hola esta es una descripcion" },
                new PersonModel() { Id=3, Name = "Anayansi", LastName="Cerdas", Description="Hola esta es una descripcion" },
                new PersonModel() { Id=4, Name = "Micela", LastName="Gonzalez", Description="Hola esta es una descripcion" },
                new PersonModel() { Id=5, Name = "Marcos", LastName="Cerdas", Description="Hola esta es una descripcion" },
            };
        }
    }
}
