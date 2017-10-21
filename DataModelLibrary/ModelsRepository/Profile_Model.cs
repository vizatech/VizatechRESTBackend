namespace DataModelLibrary.ModelsRepository
{
    using System;
    using System.Collections.Generic;

    public class User_Model                             // Класс пользователя платформы
    {
        public long Id { get; set; }                    // Ключ в таблице пользователей

        public virtual Authentication_Model Authentication { get; set; }
        public virtual Location_Model Address { get; set; }         // Место расположения
        public virtual Owner_Model IsOwner { get; set; }
        public virtual User_Model_FriendsForUser FriendsInTouch { get; set; }    // Список пользователей, которые пользуются теми же устройствами, что и текущий пользователь 
        public virtual User_Model_OwnersForUser OwnersInTouch { get; set; }    // Список владельцев устройств, с которыми данный пользователь взаимодействует
        public virtual ICollection<Representation_Model_UsersAdmitted> AllowedRepresentations { get; set; }  // Список Представлений, к которым данный пользователь имеет доступ

        public string FirstName { get; set; }           // Имя пользователя
        public string SecondName { get; set; }          // Фамилия пользователя
        public string Position { get; set; }            // Должность или сфера специализации
        public string Photo { get; set; }               // Фотография пользователя
        public string Icon { get; set; }                // Иконка пользователя
        public decimal Rating { get; set; }             // Рейтинг 

        public DateTime DateCreated { get; set; }       // Дата создания профиля пользователя
        public DateTime DateModified { get; set; }       // Дата создания профиля пользователя

        public bool IfVisiblePhoneNumber { get; set; }  // видимость Телефонного номера
        public string PhoneNumber { get; set; }         // Телефонный номер

        public bool IfVisibleChats { get; set; }        // видимость Чатов 
        public string Skype { get; set; }               // Скайп 
        public string Telegram { get; set; }            // Телеграмм

        public bool IfVisibleWorkEmail { get; set; }    // видимость Почтового ящика 
        public string WorkEmail { get; set; }           // Почта

        public bool IfVisibleSocialNetworking { get; set; } // видимость Социальных профилей
        public string PersonalSite { get; set; }         // Ссылка на лендинг пользователя
        public string LinkToLinkedIn { get; set; }      // ссылка на профиль в ЛинкедИн
        public string LinkToFacebook { get; set; }      // ссылка на Фейсбук
        public string LinkToVkontakte { get; set; }     // ссылка на Вконтакте
        public string LinkToTwitter { get; set; }       // ссылка на Твиттер
        public string LinkToInstagram { get; set; }     // ссылка на Инстаграм
    }

    public class Owner_Model                                // Класс владельца устройства
    {
        public long Id { get; set; }

        public virtual User_Model OwnerAsUser { get; set; }

        public string OwnerCompanyName { get; set; }        // Название фирмы или проекта владельца устройства
        public string CompanyLogo { get; set; }             // Иконка логотипа фирмы или проекта
        public virtual Location_Model OwnerCompanyAddress { get; set; }     // Ссылка на расположение компании владельца устройства
        public DateTime DateCreated { get; set; }           // Дата содания устройства//
        public DateTime DateModified { get; set; }          // Дата содания устройства

        public virtual Owner_Model_DevicesForOwner Devices { get; set; }        // Коллекция устройств, принадлежащих данному владельцу
        public virtual Owner_Model_CustomersForOwner Customers { get; set; }    // Список владельцев устройств, с которыми данный пользователь взаимодействует
    }

    public class Owner_Model_CustomersForOwner
    {
        public long Id { get; set; }
        public virtual Owner_Model Owner { get; set; }
        public virtual ICollection<User_Model> Customers { get; set; }
    }

    public class Owner_Model_DevicesForOwner
    {
        public long Id { get; set; }
        public virtual Owner_Model Owner { get; set; }
        public virtual ICollection<Device_Model> Devices { get; set; }
    }

    public class User_Model_FriendsForUser
    {
        public long Id { get; set; }
        public virtual User_Model User { get; set; }
        public virtual ICollection<User_Model> Friends { get; set; }
    }

    public class User_Model_OwnersForUser
    {
        public long Id { get; set; }
        public virtual User_Model User { get; set; }
        public virtual ICollection<Owner_Model> Owners { get; set; }
    }
}