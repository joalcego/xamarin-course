using System;
using System.Collections.ObjectModel;
namespace Lab1JC.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }
        public string Address { get; set; }
        public bool IsMale { get; set; }
        public string Notes { get; set; }
        public ObservableCollection<SaleModel> Sales { get; set; }

        public string FullName {
            get {
                return $"{Name} {LastName} {LastName2}";
            }
        }

        public int Age {
            get {
                return ((int)(DateTime.Today - BirthDate).TotalDays) / 365;
            }
        }

        public static ObservableCollection<PersonModel> FindPeople() {
            return new ObservableCollection<PersonModel>() {
                new PersonModel() { 
                    Id = 1, 
                    Name = "Jose", 
                    LastName = "Cerdas", 
                    LastName2 = "Gonzalez",
                    Address = "My awesome address",
                    BirthDate = new DateTime(1995, 4, 28),
                    IsMale = true,
                    Notes = "There are not notes",
                    Picture = "http://iconshow.me/media/images/Mixed/small-n-flat-icon/png/512/user-alt.png",
                    Sales = new ObservableCollection<SaleModel>() {
                        new SaleModel() {
                            Id = 1,
                            Amount = 1,
                            Product = new ProductModel() {
                                Id = 1,
                                Description = "Lavadora",
                                Price = 400000
                            }
                        },
                        new SaleModel() {
                            Id = 2,
                            Amount = 3,
                            Product = new ProductModel() {
                                Id = 2,
                                Description = "Cama",
                                Price = 200000
                            }
                        }
                    }
                },
                new PersonModel() {
                    Id = 2,
                    Name = "Luis",
                    LastName = "Cerdas",
                    LastName2 = "Gonzalez",
                    Address = "My awesome address",
                    BirthDate = new DateTime(1990, 12, 3),
                    IsMale = true,
                    Notes = "There are not notes",
                    Picture = "http://iconshow.me/media/images/Mixed/small-n-flat-icon/png/512/user-alt.png",
                    Sales = new ObservableCollection<SaleModel>() {
                        new SaleModel() {
                            Id = 3,
                            Amount = 2,
                            Product = new ProductModel() {
                                Id = 1,
                                Description = "Lavadora",
                                Price = 400000
                            }
                        },
                    }
                },
                new PersonModel() {
                    Id = 3,
                    Name = "Anayansi",
                    LastName = "Cerdas",
                    LastName2 = "Gonzalez",
                    Address = "My awesome address",
                    BirthDate = new DateTime(1986, 8, 4),
                    IsMale = false,
                    Notes = "There are not notes",
                    Picture = "http://iconshow.me/media/images/Mixed/small-n-flat-icon/png/512/user-alt.png",
                    Sales = new ObservableCollection<SaleModel>()
                },
            };
        }
    }
}
