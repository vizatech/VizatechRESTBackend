using System;
using System.Collections.Generic;


namespace BusinessLayerLibrary.ViewModelsRepository
{
    public class User                             // Класс пользователя платформы
    {
        public long Id { get; set; }                    // Ключ в таблице пользователей

        public string Login { get; set; }               // Логин пользователя
        public string FirstName { get; set; }           // Имя пользователя
        public string SecondName { get; set; }          // Фамилия пользователя
        public string Position { get; set; }            // Должность или сфера специализации
        public string Photo { get; set; }               // Фотография пользователя
        public decimal Rating { get; set; }               // Рейтинг 

        public DateTime DateCreated { get; set; }       // Дата создания профиля пользователя
        public DateTime DateModified { get; set; }       // Дата создания профиля пользователя

        public virtual Location Address { get; set; }         // Место расположения
        public virtual User_Friends FriendsInTouch { get; set; }    // Список пользователей, которые пользуются теми же устройствами, что и текущий пользователь 
        public virtual ICollection<Owner> OwnersInTouch { get; set; }    // Список владельцев устройств, с которыми данный пользователь взаимодействует
        public virtual ICollection<Data_Representation> Representations { get; set; }  // Список Представлений, к которым данный пользователь имеет доступ

        public bool IfVisiblePhoneNumber { get; set; }  // видимость Телефонного номера
        public string PhoneNumber { get; set; }         // Телефонный номер

        public bool IfVisibleChats { get; set; }        // видимость Чатов 
        public string Skype { get; set; }               // Скайп 
        public string Telegram { get; set; }            // Телеграмм

        public bool IfVisibleWorkEmail { get; set; }    // видимость Почтового ящика 
        public string WorkEmail { get; set; }           // Почта

        public bool IfVisibleSocialNetworking { get; set; } // видимость Социальных профилей
        public string PeronalSite { get; set; }         // Ссылка на лендинг пользователя
        public string LinkToLinkedIn { get; set; }      // ссылка на профиль в ЛинкедИн
        public string LinkToFacebook { get; set; }      // ссылка на Фейсбук
        public string LinkToVkontakte { get; set; }     // ссылка на Вконтакте
        public string LinkToTwitter { get; set; }       // ссылка на Твиттер
        public string LinkToInstagram { get; set; }     // ссылка на Инстаграм

        public virtual Tokens Token { get; set; }
        public virtual Authentication Password { get; set; }
    }
    public class User_Friends
    {
        public long Id { get; set; }
        public User User { get; set; }
        public virtual ICollection<User> Friends { get; set; }
    }


    public class Tokens                           // Класс ключей доступа пользователей
    {
        public long Id { get; set; }

        public string AuthToken { get; set; }           // Ключ доступа
        public DateTime IssuedOn { get; set; }          // Метка времени доступа
        public DateTime ExpiresOn { get; set; }         // Метка времени прекращения действия токена

        public virtual User TokenForUser { get; set; }
    }

    public class Authentication
    {
        public long Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string AuthenticationMetod { get; set; }
        public bool DoubleAuthenticationOn { get; set; }
        public bool ProofEmailChange { get; set; }
        public bool ProofPasswordChange { get; set; }

        public virtual User PasswordForUser { get; set; }

    }

    public class Owner                                // Класс владельца устройства
    {
        public long Id { get; set; }

        public virtual User OwnerAsUser { get; set; }

        public string OwnerCompanyName { get; set; }        // Название фирмы или проекта владельца устройства
        public string CompanyLogo { get; set; }             // Иконка логотипа фирмы или проекта
        public virtual Location OwnerCompanyAddress { get; set; }     // Ссылка на расположение компании владельца устройства

        public DateTime DateCreated { get; set; }       // Дата создания профиля пользователя
        public DateTime DateModified { get; set; }       // Дата создания профиля пользователя

        public virtual ICollection<Device> OwnedDevices { get; set; } // Коллекция устройств, принадлежащих данному владельцу
        public virtual ICollection<User> UsersInTouch { get; set; }    // Список владельцев устройств, с которыми данный пользователь взаимодействует
    }

}