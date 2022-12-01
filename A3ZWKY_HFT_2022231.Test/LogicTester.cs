using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;

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

        [SetUp]
        public void Init()
        {
            mockPersonRepo = new Mock<IRepository<Person>>();
            mockHouseRepo = new Mock<IRepository<House>>();
            mockWorkplaceRepo = new Mock<IRepository<Workplace>>();
            personLogic = new PersonLogic(mockPersonRepo.Object, mockHouseRepo.Object, mockWorkplaceRepo.Object);
            houseLogic = new HouseLogic(mockHouseRepo.Object);
            workplaceLogic = new WorkplaceLogic(mockWorkplaceRepo.Object);
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
