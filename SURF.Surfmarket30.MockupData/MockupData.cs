using SURF.Surfmarket30.Shared.Enums;
using SURF.Surfmarket30.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SURF.Surfmarket30.MockupData
{
    public class MockupData
    {
        private static MockupData _instance;
        private Random _random;

        private MockupData()
        {
            CreateMockupData();
        }

        public static MockupData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockupData();
                }
                return _instance;
            }
        }

        public List<Contract> Contracts { private set; get; }
        public List<Person> Contacts { private set; get; }
        public List<Organization> Organizations { private set; get; }
        public List<Person> Users { private set; get; }

        private void CreateMockupData()
        {
            this.Contracts = new List<Contract>();
            this.Contacts = new List<Person>();
            this.Users = new List<Person>();
            this.Organizations = new List<Organization>();

            _random = new Random();

            CreateContacts();
            CreateOrganizations();
            CreateUsers();
            CreateContracts();
        }

        private void CreateContacts()
        {
            for (int i = 1; i <= 20; i++)
            {
                var user = new Person()
                {
                    Id = i,
                    Name = "Persoon" + i.ToString().PadLeft(3, '0')
                };

                this.Contacts.Add(user);
            }
        }

        private void CreateUsers()
        {
            for (int i = 1; i <= 20; i++)
            {
                var user = new Person()
                {
                    Id = i,
                    Name = "Persoon" + i.ToString().PadLeft(3, '0')
                };

                this.Users.Add(user);
            }
        }

        private void CreateOrganizations()
        {
            for (int i = 1; i <= 10; i++)
            {
                var organization = new Organization()
                {
                    Id = i,
                    Name = "Org" + i.ToString().PadLeft(3, '0'),
                    OrganizationType = OrganizationType.Institution
                };

                this.Organizations.Add(organization);
            }
            for (int i = 11; i <= 20; i++)
            {
                var organization = new Organization()
                {
                    Id = i,
                    Name = "Org" + i.ToString().PadLeft(3, '0'),
                    OrganizationType = OrganizationType.Manufacturer
                };

                this.Organizations.Add(organization);
            }
            for (int i = 21; i <= 30; i++)
            {
                var organization = new Organization()
                {
                    Id = i,
                    Name = "Org" + i.ToString().PadLeft(3, '0'),
                    OrganizationType = OrganizationType.Supplier
                };

                this.Organizations.Add(organization);
            }
        }

        private void CreateContracts()
        {
            for (int i = 1; i <= 10; i++)
            {
                var datumStart = GetRandomDate(new DateTime(2015, 1, 1), true);

                var leverancier = GetRandomItemFromList(Organizations.Where(o => o.OrganizationType == OrganizationType.Supplier).ToList());
                var fabrikant = GetRandomItemFromList(Organizations.Where(o => o.OrganizationType == OrganizationType.Manufacturer).ToList());
                //var instelling = GetRandomItemFromList(_organizations.Where(o => o.OrganizationType == OrganizationType.Institution).ToList());

                var beheerder = GetRandomItemFromList(Contacts);
                var ondertekenaar = GetRandomItemFromList(Contacts);

                var auteur = GetRandomItemFromList(Users);
                var userBeheerder = GetRandomItemFromList(Users);

                var contract = new Contract()
                {
                    Id = i,
                    Name = "Contract" + i.ToString().PadLeft(3, '0'),
                    Status = GetRandomEnum<ContractStatus>(),
                    Revisie = _random.Next(4).ToString(),
                    DatumStart = datumStart,
                    DatumEind = GetRandomDate(datumStart, false),
                    DatumGetekend = GetRandomDate(datumStart, true),
                    ContractWaarde = _random.Next(100, 10000),
                    ContractType = GetRandomEnum<ContractType>(),
                    DocumentUrl = $"www.somewhereonthenet.com\\document{i.ToString().PadLeft(3, '0')}.pdf",
                    LeverancierId = leverancier.Id,
                    Leverancier = leverancier,
                    FabrikantId = fabrikant.Id,
                    Fabrikant = fabrikant,
                    ContactBeheerderId = beheerder.Id,
                    ContactBeheerder = beheerder,
                    ContactOndertekenaarId = beheerder.Id,
                    ContactOndertekenaar = ondertekenaar,
                    UserAuteurId = auteur.Id,
                    UserAuteur = auteur,
                    UserBeheerderId = userBeheerder.Id,
                    UserBeheerder = userBeheerder,
                    Bijlagen = new List<ContractBijlage>() { CreateRandomBaseModelItem<ContractBijlage>(i) },
                    Componenten = new List<ContractComponent>() { CreateRandomBaseModelItem<ContractComponent>(i) },
                    DocumentType​ = GetRandomEnum<DocumentType>()
                };

                Contracts.Add(contract);
            }
        }

        private T CreateRandomBaseModelItem<T>(int id) where T : IBaseModel, new()
        {
            var item = new T();
            item.Id = id;
            item.Name = "Item " + _random.Next(1000, 9999);
            return item;
        }

        private DateTime GetRandomDate(DateTime minDate, bool canBeMinDate)
        {
            var year = _random.Next(minDate.Year, 2017);
            var month = _random.Next(year == minDate.Year && !canBeMinDate ? minDate.Month : 1, 12);
            var day = _random.Next(month == minDate.Month && !canBeMinDate ? minDate.Day + 1 : 1, DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day);
        }

        private T GetRandomEnum<T>()
        {
            var statuses = Enum.GetValues(typeof(T));
            return (T)statuses.GetValue(_random.Next(statuses.Length));
        }

        private T GetRandomItemFromList<T>(List<T> list) where T : IBaseModel
        {
            var minId = list.Min(m => m.Id);
            var maxId = list.Max(m => m.Id);
            var randomId = _random.Next(minId, maxId);

            return list.FirstOrDefault(l => l.Id == randomId);
        }
    }
}
