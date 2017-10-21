namespace DataModelLibrary.ModelsRepository
{
    using System;
    using System.Collections.Generic;

    public class Authentication_Model
    {
        public long Id { get; set; }

        public virtual User_Model AuthenticationForUser { get; set; }

        public virtual ICollection<Tokens_Model> Tokens { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string AuthenticationMetod { get; set; }
        public bool DoubleAuthenticationOn { get; set; }
        public bool ProofEmailChange { get; set; }
        public bool ProofPasswordChange { get; set; }

        public DateTime AuthenticationCreated { get; set; }
        public DateTime AuthenticationModified { get; set; }
    }

    public class Tokens_Model                           // Класс ключей доступа пользователей
    {
        public long Id { get; set; }

        public virtual Authentication_Model AuthenticationModel { get; set; }

        public string AuthToken { get; set; }           // Ключ доступа
        public DateTime IssuedOn { get; set; }          // Метка времени доступа
        public DateTime ExpiresOn { get; set; }         // Метка времени прекращения действия токена
    }
}
