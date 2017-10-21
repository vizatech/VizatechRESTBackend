namespace DataModelLibrary.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using ModelsRepository;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIDataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataModelLibrary.WebAPIDataModel";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebAPIDataModel context)
        {

        #region автозаполнение Аутентификаторов

            context.Athenticators.AddOrUpdate(p => new
            {
                p.Login
            }, new Authentication_Model() { Login = "nazar", Password = "12345678", EMail = "nazar.syngaivskyi@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "andrii", Password = "12345678", EMail = "andrii.syngaivskyi@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "alexandra", Password = "12345678", EMail = "user1.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "taras", Password = "12345678", EMail = "user2.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "ivonna", Password = "12345678", EMail = "user3.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "nataliya", Password = "12345678", EMail = "user4.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "sergey", Password = "12345678", EMail = "user5.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "vladislav", Password = "12345678", EMail = "user6.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "tatyana", Password = "12345678", EMail = "user7.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            }, new Authentication_Model() { Login = "helen", Password = "12345678", EMail = "user8.vizatech@gmail.com", AuthenticationMetod = "Trusted", DoubleAuthenticationOn = false, ProofEmailChange = true, ProofPasswordChange = true, AuthenticationCreated = System.DateTime.UtcNow, AuthenticationModified = System.DateTime.UtcNow
            });
            context.SaveChanges();

            context.Tokens.AddOrUpdate(p => new
            {
                p.AuthToken
            }, new Tokens_Model() { AuthToken = "uiy35t8oiu45hogh8h4goigoi8", IssuedOn = System.DateTime.UtcNow.AddHours(1), ExpiresOn = System.DateTime.UtcNow.AddHours(1).AddMonths(3), AuthenticationModel = context.Athenticators.Find(1)
            }, new Tokens_Model() { AuthToken = "ljhvljvlk;kh 89-98y 98y9 8", IssuedOn = System.DateTime.UtcNow.AddHours(2), ExpiresOn = System.DateTime.UtcNow.AddHours(2).AddMonths(3), AuthenticationModel = context.Athenticators.Find(2)
            }, new Tokens_Model() { AuthToken = "afjvsidfuvhsidfuiupfiufpia", IssuedOn = System.DateTime.UtcNow.AddHours(3), ExpiresOn = System.DateTime.UtcNow.AddHours(3).AddMonths(3), AuthenticationModel = context.Athenticators.Find(3)
            }, new Tokens_Model() { AuthToken = "[w094jg-8vj aijvaivjopsijr", IssuedOn = System.DateTime.UtcNow.AddHours(4), ExpiresOn = System.DateTime.UtcNow.AddHours(4).AddMonths(3), AuthenticationModel = context.Athenticators.Find(4)
            }, new Tokens_Model() { AuthToken = "2mokb0r9fijw9merij99jibopd", IssuedOn = System.DateTime.UtcNow.AddHours(5), ExpiresOn = System.DateTime.UtcNow.AddHours(5).AddMonths(3), AuthenticationModel = context.Athenticators.Find(5)
            }, new Tokens_Model() { AuthToken = "kjnpjervposifvposidjfoj[oi", IssuedOn = System.DateTime.UtcNow.AddHours(6), ExpiresOn = System.DateTime.UtcNow.AddHours(6).AddMonths(3), AuthenticationModel = context.Athenticators.Find(6)
            }, new Tokens_Model() { AuthToken = "mjdspfovijwmp89548mgoiwjre", IssuedOn = System.DateTime.UtcNow.AddHours(7), ExpiresOn = System.DateTime.UtcNow.AddHours(7).AddMonths(3), AuthenticationModel = context.Athenticators.Find(7)
            }, new Tokens_Model() { AuthToken = ";lkms;ovisjp8egwmijvoijoii", IssuedOn = System.DateTime.UtcNow.AddHours(8), ExpiresOn = System.DateTime.UtcNow.AddHours(8).AddMonths(3), AuthenticationModel = context.Athenticators.Find(7)
            }, new Tokens_Model() { AuthToken = "aslkmdf;w4iogoisdprij9m099", IssuedOn = System.DateTime.UtcNow.AddHours(9), ExpiresOn = System.DateTime.UtcNow.AddHours(9).AddMonths(3), AuthenticationModel = context.Athenticators.Find(1)
            }, new Tokens_Model() { AuthToken = "ms;feivoijtvoisjb[srijt0i0", IssuedOn = System.DateTime.UtcNow.AddHours(10), ExpiresOn = System.DateTime.UtcNow.AddHours(10).AddMonths(3), AuthenticationModel = context.Athenticators.Find(1)
            });
            context.SaveChanges();
        #endregion

        #region автозаполнение Адресов
            context.Locations.AddOrUpdate(p => new
            {
                p.Country, p.State, p.Region, p.City, p.Street, p.Building
            }, new Location_Model() { Country = "Ukraine", State = "Kharkivska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(1).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Lvivska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(2).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Ternopilska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(3).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Kyivska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(4).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Donetska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(5).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Mykolaivska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(6).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Jytomyrska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(7).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Odeska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(8).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Poltavska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(9).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Zaporizka", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = context.Athenticators.Find(10).Login + " is living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Rivnenska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "the Owner is working here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Dniprovska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "the Owner is working here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Cherkaska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Luganska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Ivano-Frankivska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Zakarpatska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Hersonska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Sumska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Vinytska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            }, new Location_Model() { Country = "Ukraine", State = "Khmelnytska", Region = "Balakleevskyi", City = "Korotich", Street = "Cosmotautov", Building = "44", Description = "I am living here", PositionX = "13:24:15:36", PositionY = "52:34:45:25", PositionZ = "65:26:65:46"
            });
            context.SaveChanges();
        #endregion 

        #region автозаполнение профилей Пользователей
            context.Users.AddOrUpdate(p => new
            {
                p.FirstName, p.SecondName
            }, new User_Model() { Authentication = context.Athenticators.Find(1), Address = context.Locations.Find(1), FirstName = "Nazar", SecondName = "Syngaivskyi", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-6000-170", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(2), Address = context.Locations.Find(2), FirstName = "Andriy", SecondName = "Syngaivskyi", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(3), Address = context.Locations.Find(3), FirstName = "Taras", SecondName = "Syngaivskyi", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(4), Address = context.Locations.Find(4), FirstName = "Kyril", SecondName = "Syngaivskyi", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(5), Address = context.Locations.Find(5), FirstName = "Timur", SecondName = "Syngaivskyi", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(6), Address = context.Locations.Find(6), FirstName = "Olena", SecondName = "Syngaivska", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(7), Address = context.Locations.Find(1), FirstName = "Alexandra", SecondName = "Syngaivska", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(8), Address = context.Locations.Find(1), FirstName = "Nataliya", SecondName = "Syngaivska", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(9), Address = context.Locations.Find(7), FirstName = "Victoriya", SecondName = "Syngaivska", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            }, new User_Model() { Authentication = context.Athenticators.Find(10), Address = context.Locations.Find(7), FirstName = "Ivonna", SecondName = "Syngaivska", Position = "C# .NET Developer", Photo = "URL to picture of user", Icon = "URL to icin of user", Rating = 77.2m, DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                  IfVisiblePhoneNumber = true, PhoneNumber = "099-110-44-66", IfVisibleChats = true, Skype = "skype", Telegram = "Telegram", IfVisibleWorkEmail = true, WorkEmail = "workemail", IfVisibleSocialNetworking = true, PersonalSite = "https:\\www.vizatech.com"
            });
            context.SaveChanges();
        #endregion

        #region автозаполнение профилей Owners
            context.Owners.AddOrUpdate(p => new
            {
                p.OwnerCompanyName
            }, new Owner_Model() { OwnerAsUser = context.Users.Find(1), OwnerCompanyName = "Viz-a-tech", CompanyLogo = "URL to company logo", OwnerCompanyAddress = context.Locations.Find(11), DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow
            }, new Owner_Model() { OwnerAsUser = context.Users.Find(2), OwnerCompanyName = "Lithium", CompanyLogo = "URL to company logo", OwnerCompanyAddress = context.Locations.Find(12), DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow
            }, new Owner_Model() { OwnerAsUser = context.Users.Find(3), OwnerCompanyName = "Newton", CompanyLogo = "URL to company logo", OwnerCompanyAddress = context.Locations.Find(13), DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow
            });
            context.SaveChanges();
        #endregion

        #region автозаполнение Devicess
            context.Devices.AddOrUpdate(p => new
            {
                p.DeviceName
            }, new Device_Model() { Owner = context.Owners.Find(1), Address = context.Locations.Find(14), DeviceName = "Temperature sensor on Air 0001", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "Temperature", SensorActuatorType = true, AnalogDigitalType = true, Description = "Температурный сенсор обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.5m, Measurement = "C", Frequency = 6m, UtitsForFrequency = "1/hour", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = "kjhgi6iryfukg68cvuyglviu", HubName = "devicehub0001", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(1), Address = context.Locations.Find(15), DeviceName = "Humidity sensor on Air 0001", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "Air Humidity", SensorActuatorType = true, AnalogDigitalType = true, Description = "Сенсор влажности воздуха обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.5m, Measurement = "%", Frequency = 4m, UtitsForFrequency = "1/hour", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = "лорываш8н4пдлрытд8щтщзшу", HubName = "devicehub0002", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(1), Address = context.Locations.Find(16), DeviceName = "Humidity sensor on Soil 0001", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "Soil Humidity", SensorActuatorType = true, AnalogDigitalType = true, Description = "Сенсор влажности почвы обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.5m, Measurement = "%", Frequency = 4m, UtitsForFrequency = "1/hour", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = ";ihsdng8954ngiosddf;mgb;", HubName = "devicehub0003", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(2), Address = context.Locations.Find(17), DeviceName = "Pressure sensor on watering machine", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "Pressure", SensorActuatorType = true, AnalogDigitalType = true, Description = "Сенсор давления в системе полива обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.1m, Measurement = "atm", Frequency = 6.0m, UtitsForFrequency = "1/min", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = ";lkjds98429phtj;oiwejpo8", HubName = "devicehub0004", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(2), Address = context.Locations.Find(18), DeviceName = "Automatic watering machine switch", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "SolenoidActuator", SensorActuatorType = false, AnalogDigitalType = false, Description = "Актуатор включения/отключения подачи воды обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 1m, Measurement = "Bool", Frequency = 1.0m, UtitsForFrequency = "1/sec", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = ".jkzns9823ywj23o4jpowiug", HubName = "devicehub0005", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(2), Address = context.Locations.Find(19), DeviceName = "Automatic watering machine regulator", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "AnalogRegulator", SensorActuatorType = false, AnalogDigitalType = true, Description = "Актуатор плавного регулирования подачи воды обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.1m, Measurement = "0...1023", Frequency = 1.0m, UtitsForFrequency = "1/sec", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = "-9w83jvklmdfs/zx,n98w34w", HubName = "devicehub0006", HubSuffix = "vizatech.azure.com"
            }, new Device_Model() { Owner = context.Owners.Find(2), Address = context.Locations.Find(20), DeviceName = "Watering counter", DeviceIcon = "URL to icon for device", DateCreated = System.DateTime.UtcNow, DateModified = System.DateTime.UtcNow,
                                    FunctionType = "WateringCounter", SensorActuatorType = true, AnalogDigitalType = true, Description = "Счетчик расхода воды обладает такими-то основынми характеристиками и такими-то ограничениями по применению",
                                    Accurance = 0.01m, Measurement = "L/min", Frequency = 10m, UtitsForFrequency = "1/sec", DataSheet = "URL to datasheet for device",
                                    ConnectionString = "Connection string",
                                    DeviceKey = ",m.xzn983w44;kljxncv;lkn", HubName = "devicehub0007", HubSuffix = "vizatech.azure.com"
            });
            context.SaveChanges();

            context.Sensors.AddOrUpdate(p => new
            {
                p.SensorParameterName
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Temperature1 in system 1", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(1) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Temperature2 in system 1", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(1) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Energy_low in system 1", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(1) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Air_humidity in system 2", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(2) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Soil_humidity 1 in system 3", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(3) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Soil_humidity 2 in system 3", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(3) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Soil_humidity 3 in system 3", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(3) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Pressure_absolute in system 4", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(4) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Pressure_differencial in system 4", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(4) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Is_sleeping in system 4", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(4) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Current in system 5", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(5) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Energy_low in system 5", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(5) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Energy_low in system 6", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(6) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "System 6 is closed", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(6) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Counter_static in system 7", SensorParameterType = "decimal", SensorForDevice = context.Devices.Find(7) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Counter_dinamic in system 7", SensorParameterType = "decimal ", SensorForDevice = context.Devices.Find(7) 
            }, new Device_Model_Declaration_Item_Sensor() { SensorParameterName = "Energy_low2 in system 7", SensorParameterType = "bool", SensorForDevice = context.Devices.Find(7) 
            });

            context.Actuators.AddOrUpdate(p => new
            {
                p.ActuatorParameterName
            }, new Device_Model_Declaration_Item_Actuator() { ActuatorParameterName = "switch_on for system 5", ActuatorParameterType = "bool", ActuatorForDevice = context.Devices.Find(5) 
            }, new Device_Model_Declaration_Item_Actuator() { ActuatorParameterName = "open_degree for system 6", ActuatorParameterType = "decimal", ActuatorForDevice = context.Devices.Find(6) 
            });
            context.SaveChanges();

            context.Alarms.AddOrUpdate(p => new
            {
                p.AlarmName
            }, new Device_Model_Alarm() { AlarmName = "Watering solenoid On", AlarmFromSensor = context.Sensors.Find(6), AlarmForActuator = context.Actuators.Find(1), ConditionBottomfValue = 20.0m, ActuatorOnOffValue = true, ConditionType = "Less then value", ActuationType = "Yes/No"
            }, new Device_Model_Alarm() { AlarmName = "Watering flow On", AlarmFromSensor = context.Sensors.Find(6), AlarmForActuator = context.Actuators.Find(4), ConditionBottomfValue = 10.0m, ActuatorDecimalValue = 70.0m, ConditionType = "Less then value", ActuationType = "Digital value"
            }, new Device_Model_Alarm() { AlarmName = "Watering flow Off", AlarmFromSensor = context.Sensors.Find(6), AlarmForActuator = context.Actuators.Find(4), ConditionBottomfValue = 60.0m, ActuatorDecimalValue = 0.0m, ConditionType = "More then value", ActuationType = "Digital value"
            }, new Device_Model_Alarm() { AlarmName = "Watering solenoid Off", AlarmFromSensor = context.Sensors.Find(6), AlarmForActuator = context.Actuators.Find(1), ConditionBottomfValue = 60.5m, ActuatorOnOffValue = false, ConditionType = "More then value", ActuationType = "Yes/No"
            });
            context.SaveChanges();
        #endregion

        #region автозаполнение профилей Canvas for Representations
            context.LineCanvases.AddOrUpdate(p => new
            {
                p.CanvasName
            }, new Representation_Model_Line_Canvas() { CanvasName = "LineCanvas-01", BorderColor = "", Fill = false, BackgroundColor ="", BorderWidth = 1,
            });
            context.SaveChanges();

        #endregion


            base.Seed(context);
        }
    }
}
