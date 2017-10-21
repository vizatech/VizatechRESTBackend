using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModelLibrary.ModelsRepository;
using DataModelLibrary.RESTRepository;

namespace DataModelLibrary.TransactionRepository
{
    /// <summary>
    /// Класс обеспечения транзакций к БД
    /// </summary>
    public class TransactionsDataBase : IDisposable
    {
        #region Закрытые свойства

        private WebAPIDataModel _context = null;
        private GenericRepository<User_Model> _userRepository;
        private GenericRepository<Device_Model> _deviceRepository;
        private GenericRepository<Owner_Model> _ownerRepository;
        #endregion

        public TransactionsDataBase()
        {
            _context = new WebAPIDataModel();
        }

        #region Открытые свойства

        /// <summary>
        /// Get/Set методы для библиотеки устройств или источников данных
        /// </summary>
        public GenericRepository<Device_Model> DeviceRepository
        {
            get
            {
                if (this._deviceRepository == null)
                    this._deviceRepository = new GenericRepository<Device_Model>(_context);
                return _deviceRepository;
            }
        }

        /// <summary>
        /// Get/Set методы для библиотеки аутентификации пользователя
        /// </summary>
        public GenericRepository<User_Model> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User_Model>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set методы для библиотеки токенов аутентификации
        /// </summary>
        public GenericRepository<Owner_Model> TokenRepository
        {
            get
            {
                if (this._ownerRepository == null)
                    this._ownerRepository = new GenericRepository<Owner_Model>(_context);
                return _ownerRepository;
            }
        }
        #endregion

        #region Открытые методы
        /// <summary>
        /// Save метод
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
//               System.IO.File.AppendAllLines(@"C:\temp\errors.txt", outputLines);
//                Console.WriteLine(outputLines);

                throw e;
            }

        }

        #endregion

        #region Внедрение интерфейса высвобождения IDiosposable

        #region закрытый признак высвобождения
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Защищенный виртуальный метод высвобождения
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("TransactionsDataBase is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Полный метод высвобождения
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}