using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace A3ZWKY_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTester
    {
        PersonLogic personLogic;
        HouseLogic houseLogic;
        WorkplaceLogic workplaceLogic;
        Mock<IRepository<Person>> mockPersonRepo;
        Mock<IRepository<House>> mockHouseRepo;
        Mock<IRepository<Workplace>> mockWorkplaceRepo;
        static List<House> houses = new List<House>()
            {
                new House() { HouseId = 1, Color = "Yellow", FloorArea = 200, Address = "1001 Cipő utca 1.", Persons = 
                    {
                        new Person(){PersonId = 1, Name = "Kiss János", Age = 20, Gender = "Male", BirthDate = new DateTime(2000,05,25), HouseId = 1, WorkplaceId = 1},
                        new Person(){PersonId = 4, Name = "Édes Anna", Age = 20, Gender = "Female", BirthDate = new DateTime(2000,04,02), HouseId = 1, WorkplaceId = 1}
                    }},
                new House() { HouseId = 2, Color = "Green", FloorArea = 180, Address = "1001 Cipő utca 2.", Persons =
                    {
                        new Person(){PersonId = 2, Name = "Köves Béla", Age = 30, Gender = "Male", BirthDate = new DateTime(1990,10,12), HouseId = 2, WorkplaceId = 4},
                        new Person(){PersonId = 8, Name = "Keresztes Anikó", Age = 28, Gender = "Female", BirthDate = new DateTime(1992,01,21), HouseId = 2, WorkplaceId = 2}
                    }},
                new House() { HouseId = 3, Color = "Red", FloorArea = 250, Address = "1001 Cipő utca 3." , Persons = 
                    {
                        new Person(){PersonId = 3, Name = "Gipsz Jakab", Age = 25, Gender = "Male", BirthDate = new DateTime(1995,06,15), HouseId = 3, WorkplaceId = null},
                        new Person(){PersonId = 6, Name = "Nagy Eszter", Age = 26, Gender = "Female", BirthDate = new DateTime(1994,09,09), HouseId = 3, WorkplaceId = null}
                    }},
                new House() { HouseId = 4, Color = "Cyan", FloorArea = 120, Address = "1001 Cipő utca 4.", Persons = 
                    {
                        new Person(){PersonId = 5, Name = "Erős Pista", Age = 50, Gender = "Male", BirthDate = new DateTime(1970,06,28), HouseId = 4, WorkplaceId = null}
                    }},
                new House() { HouseId = 5, Color = "Brown", FloorArea = 140, Address = "1001 Cipő utca 5.", Persons = 
                    {
                        new Person(){PersonId = 7, Name = "Domokos Dezső", Age = 60, Gender = "Male", BirthDate = new DateTime(1960,02,12), HouseId = 5, WorkplaceId = 3},
                        new Person(){PersonId = 9, Name = "Bíró Kinga", Age = 55, Gender = "Female", BirthDate = new DateTime(1965,03,18), HouseId = 5, WorkplaceId = null}
                    }},
                new House() { HouseId = 6, Color = "White", FloorArea = 165, Address = "1001 Cipő utca 6." , Persons = 
                    {
                        new Person(){PersonId = 10, Name = "Papp Tamás", Age = 22, Gender = "Male", BirthDate = new DateTime(1998,04,27), HouseId = 6, WorkplaceId = 4}
                    }}
            };
        static List<Person> persons = new List<Person>()
            {
                new Person(){PersonId = 1, Name = "Kiss János", Age = 20, Gender = "Male", BirthDate = new DateTime(2000,05,25), HouseId = 1, WorkplaceId = 1, 
                    House = new House() { HouseId = 1, Color = "Yellow", FloorArea = 200, Address = "1001 Cipő utca 1." },
                    Workplace = new Workplace() { WorkplaceId = 1, Name = "Búzási Hentes", Type = "Hentes", TelephoneNumber = "20/2836493", Address = "1001 Zokni utca 21."}},

                new Person(){PersonId = 2, Name = "Köves Béla", Age = 30, Gender = "Male", BirthDate = new DateTime(1990,10,12), HouseId = 2, WorkplaceId = 4, 
                    House = new House() { HouseId = 2, Color = "Green", FloorArea = 180, Address = "1001 Cipő utca 2."},
                    Workplace = new Workplace() { WorkplaceId = 4, Name = "Napsugár Hipermarket", Type = "Hipermarket", TelephoneNumber = "20/1249867", Address = "1001 Zokni utca 7."}},

                new Person(){PersonId = 3, Name = "Gipsz Jakab", Age = 25, Gender = "Male", BirthDate = new DateTime(1995,06,15), HouseId = 3, WorkplaceId = null,
                    House = new House() { HouseId = 3, Color = "Red", FloorArea = 250, Address = "1001 Cipő utca 3."},
                    Workplace = null},

                new Person(){PersonId = 4, Name = "Édes Anna", Age = 20, Gender = "Female", BirthDate = new DateTime(2000,04,02), HouseId = 1, WorkplaceId = 1,
                    House = new House() { HouseId = 1, Color = "Yellow", FloorArea = 200, Address = "1001 Cipő utca 1." },
                    Workplace = new Workplace() { WorkplaceId = 1, Name = "Búzási Hentes", Type = "Hentes", TelephoneNumber = "20/2836493", Address = "1001 Zokni utca 21."}},

                new Person(){PersonId = 5, Name = "Erős Pista", Age = 50, Gender = "Male", BirthDate = new DateTime(1970,06,28), HouseId = 4, WorkplaceId = null,
                    House = new House() { HouseId = 4, Color = "Cyan", FloorArea = 120, Address = "1001 Cipő utca 4."},
                    Workplace = null},

                new Person(){PersonId = 6, Name = "Nagy Eszter", Age = 26, Gender = "Female", BirthDate = new DateTime(1994,09,09), HouseId = 3, WorkplaceId = null,
                    House = new House() { HouseId = 3, Color = "Red", FloorArea = 250, Address = "1001 Cipő utca 3."},
                    Workplace = null },

                new Person(){PersonId = 7, Name = "Domokos Dezső", Age = 60, Gender = "Male", BirthDate = new DateTime(1960,02,12), HouseId = 5, WorkplaceId = 3,
                    House = new House() { HouseId = 5, Color = "Brown", FloorArea = 140, Address = "1001 Cipő utca 5."},
                    Workplace = new Workplace() { WorkplaceId = 3, Name = "Talpaló Cipészet", Type = "Cipészet", TelephoneNumber = "30/4957464", Address = "1001 Zokni utca 32."}},

                new Person(){PersonId = 8, Name = "Keresztes Anikó", Age = 28, Gender = "Female", BirthDate = new DateTime(1992,01,21), HouseId = 2, WorkplaceId = 2, 
                    House = new House() { HouseId = 2, Color = "Green", FloorArea = 180, Address = "1001 Cipő utca 2."},
                    Workplace = new Workplace() { WorkplaceId = 2, Name = "Friss Pékség", Type = "Pékség", TelephoneNumber = "70/3456224", Address = "1001 Zokni utca 12."}},

                new Person(){PersonId = 9, Name = "Bíró Kinga", Age = 55, Gender = "Female", BirthDate = new DateTime(1965,03,18), HouseId = 5, WorkplaceId = null,
                    House = new House() { HouseId = 5, Color = "Brown", FloorArea = 140, Address = "1001 Cipő utca 5."},
                    Workplace = null},

                new Person(){PersonId = 10, Name = "Papp Tamás", Age = 22, Gender = "Male", BirthDate = new DateTime(1998,04,27), HouseId = 6, WorkplaceId = 4,
                    House = new House() { HouseId = 6, Color = "White", FloorArea = 165, Address = "1001 Cipő utca 6."},
                    Workplace = new Workplace() { WorkplaceId = 4, Name = "Napsugár Hipermarket", Type = "Hipermarket", TelephoneNumber = "20/1249867", Address = "1001 Zokni utca 7."}}
            };
        static List<Workplace> workplaces = new List<Workplace>()
            {
                new Workplace() { WorkplaceId = 1, Name = "Búzási Hentes", Type = "Hentes", TelephoneNumber = "20/2836493", Address = "1001 Zokni utca 21.",
                    Persons =
                    {
                        new Person(){PersonId = 1, Name = "Kiss János", Age = 20, Gender = "Male", BirthDate = new DateTime(2000,05,25), HouseId = 1, WorkplaceId = 1},
                        new Person(){PersonId = 4, Name = "Édes Anna", Age = 20, Gender = "Female", BirthDate = new DateTime(2000,04,02), HouseId = 1, WorkplaceId = 1}
                    }},
                new Workplace() { WorkplaceId = 2, Name = "Friss Pékség", Type = "Pékség", TelephoneNumber = "70/3456224", Address = "1001 Zokni utca 12.",
                    Persons =
                    {
                        new Person(){PersonId = 8, Name = "Keresztes Anikó", Age = 28, Gender = "Female", BirthDate = new DateTime(1992,01,21), HouseId = 2, WorkplaceId = 2}
                    }},
                new Workplace() { WorkplaceId = 3, Name = "Talpaló Cipészet", Type = "Cipészet", TelephoneNumber = "30/4957464", Address = "1001 Zokni utca 32.",
                    Persons =
                    {
                        new Person(){PersonId = 7, Name = "Domokos Dezső", Age = 60, Gender = "Male", BirthDate = new DateTime(1960,02,12), HouseId = 5, WorkplaceId = 3 }
                    }},
                new Workplace() { WorkplaceId = 4, Name = "Napsugár Hipermarket", Type = "Hipermarket", TelephoneNumber = "20/1249867", Address = "1001 Zokni utca 7.",
                    Persons =
                    {
                         new Person(){PersonId = 2, Name = "Köves Béla", Age = 30, Gender = "Male", BirthDate = new DateTime(1990,10,12), HouseId = 2, WorkplaceId = 4 },
                          new Person(){PersonId = 10, Name = "Papp Tamás", Age = 22, Gender = "Male", BirthDate = new DateTime(1998,04,27), HouseId = 6, WorkplaceId = 4 }
                    }}
            };

    [SetUp]
    public void Init()
    {
            mockPersonRepo = new Mock<IRepository<Person>>();
            mockHouseRepo = new Mock<IRepository<House>>();
            mockWorkplaceRepo = new Mock<IRepository<Workplace>>();

            mockHouseRepo.Setup(m => m.ReadAll()).Returns(houses.AsQueryable());

            mockPersonRepo.Setup(m => m.ReadAll()).Returns(persons.AsQueryable());

            mockWorkplaceRepo.Setup(m => m.ReadAll()).Returns(workplaces.AsQueryable());

            personLogic = new PersonLogic(mockPersonRepo.Object);
            houseLogic = new HouseLogic(mockHouseRepo.Object);
            workplaceLogic = new WorkplaceLogic(mockWorkplaceRepo.Object);
        }

        [Test]
        public void GetPersonsWhoLiveInRedHouseTest()
        {
            var actual = personLogic.GetPersonsWhoLiveInRedHouse();
            var expected = new List<Person>()
            {
                new Person(){PersonId = 3, Name = "Gipsz Jakab", Age = 25, Gender = "Male", BirthDate = new DateTime(1995,06,15), HouseId = 3, WorkplaceId = null},
                new Person(){PersonId = 6, Name = "Nagy Eszter", Age = 26, Gender = "Female", BirthDate = new DateTime(1994,09,09), HouseId = 3, WorkplaceId = null}
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPersonsWhoWorkAtButcheryTest()
        {
            var actual = personLogic.GetPersonsWhoWorkAtButchery();
            var expected = new List<Person>()
            {
               new Person(){PersonId = 1, Name = "Kiss János", Age = 20, Gender = "Male", BirthDate = new DateTime(2000,05,25), HouseId = 1, WorkplaceId = 1 },
               new Person(){PersonId = 4, Name = "Édes Anna", Age = 20, Gender = "Female", BirthDate = new DateTime(2000,04,02), HouseId = 1, WorkplaceId = 1}
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHousesWithMostPersonsTest()
        {
            var actual = houseLogic.GetHousesWithMostPersons();
            var expected = new List<House>()
            {
                new House() { HouseId = 1, Color = "Yellow", FloorArea = 200, Address = "1001 Cipő utca 1." },
                new House() { HouseId = 2, Color = "Green", FloorArea = 180, Address = "1001 Cipő utca 2." },
                new House() { HouseId = 3, Color = "Red", FloorArea = 250, Address = "1001 Cipő utca 3." },
                new House() { HouseId = 5, Color = "Brown", FloorArea = 140, Address = "1001 Cipő utca 5." }
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetWorkplacesWithAtleast2WorkersTest()
        {
            var actual = workplaceLogic.GetWorkplacesWithAtleast2Workers();
            var expected = new List<Workplace>()
            {
                new Workplace(){WorkplaceId = 1, Name = "Búzási Hentes", Type = "Hentes", TelephoneNumber = "20/2836493", Address = "1001 Zokni utca 21.",},
                new Workplace(){WorkplaceId = 4, Name = "Napsugár Hipermarket", Type = "Hipermarket", TelephoneNumber = "20/1249867", Address = "1001 Zokni utca 7.",}
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetWorkplacesWhereOldPeopleWork()
        {
            var actual = workplaceLogic.GetWorkplacesWhereOldPeopleWork();
            var expected = new List<Workplace>()
            {
                 new Workplace() { WorkplaceId = 3, Name = "Talpaló Cipészet", Type = "Cipészet", TelephoneNumber = "30/4957464", Address = "1001 Zokni utca 32." }
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreatePersonTestWithCorrectName()
        {
            var person = new Person() { Name = "Kancsal Ede" };

            personLogic.Create(person);
            mockPersonRepo.Verify(r => r.Create(person), Times.Once);
        }

        [Test]
        public void CreatePersonTestWithInCorrectName()
        {
            var person = new Person() { Name = "" };
            try
            {
                personLogic.Create(person);
            }
            catch (Exception)
            {
            }
            mockPersonRepo.Verify(r => r.Create(person), Times.Never);
        }

        [Test]
        public void CreateHouseTestWithCorrectAddress()
        {
            var house = new House() { Address = "1001 Cipő utca 8."};
            int houseId = IdGeneratorUtil.GenerateId();

            houseLogic.Create(house, houseId);
            mockHouseRepo.Verify(r => r.Create(house), Times.Once);
        }
        [Test]
        public void CreateHouseTestWithInCorrectAddressLenght()
        {
            var house = new House() { Address = "C u.1" };
            int houseId = IdGeneratorUtil.GenerateId();
            try
            {
                houseLogic.Create(house, houseId);
            }
            catch (Exception)
            {
            }
            mockHouseRepo.Verify(r => r.Create(house), Times.Never);
        }

        [Test]
        public void CreateHouseTestWithInCorrectAddress()
        {
            var house = new House() { Address = "" };
            int houseId = IdGeneratorUtil.GenerateId();
            try
            {
                houseLogic.Create(house, houseId);
            }
            catch (Exception)
            {
            }
            mockHouseRepo.Verify(r => r.Create(house), Times.Never);
        }

        [Test]
        public void CreateWorkplaceTestWithCorrectAddress()
        {
            var workplace = new Workplace() { Address = "" };
            int workplaceId = IdGeneratorUtil.GenerateId();
            try
            {
                workplaceLogic.Create(workplace, workplaceId);
            }
            catch (Exception)
            {
            }
            mockWorkplaceRepo.Verify(r => r.Create(workplace), Times.Never);
        }

    }
}
