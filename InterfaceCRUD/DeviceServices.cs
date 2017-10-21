using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessLayerLibrary.ViewModelsRepository;
using DataModelLibrary.ModelsRepository;
using DataModelLibrary.TransactionRepository;

namespace InterfaceCRUD
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class DeviceServices:IDeviceServices
    {
        private readonly TransactionsDataBase _transactionDB;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public DeviceServices()
        {
            _transactionDB = new TransactionsDataBase();
        }

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Device GetDeviceById(long deviceId)
        {
            Device_Model dev_mod_src = _transactionDB.DeviceRepository.GetByID(deviceId);
            if (dev_mod_src != null)
            {
                var config_Device_Model = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Device_Model, Device>()
                            .ForMember(dest => dest.Owner, opts => opts.Ignore())
                            .ForMember(dest => dest.Representations, opts => opts.Ignore());
                        cfg.CreateMap<Location_Model, Location>();
                    });
                //config_Device_Model.AssertConfigurationIsValid();
                var mapper_device = config_Device_Model.CreateMapper();

                Device device = mapper_device.Map<Device>(dev_mod_src);
                return device;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAllDevices()
        {
            IEnumerable<Device_Model> dev_list = _transactionDB.DeviceRepository.GetAll().ToList();

            if (dev_list.Any())
            {
                var config_Device_Model = new MapperConfiguration(
                            cfg =>
                            {
                                    cfg.CreateMap<Device_Model, Device>()
                                        .ForMember(dest => dest.Owner, opts => opts.Ignore())
                                        .ForMember(dest => dest.Representations, opts => opts.Ignore());
                                    cfg.CreateMap<Location_Model, Location>();
                            });
                var mapper_device = config_Device_Model.CreateMapper();

                IList<Device> devices = new List<Device>();
                foreach (Device_Model dev in dev_list)
                {
                    devices.Add(mapper_device.Map<Device>(dev));
                }

                return devices;
            }
            return null;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public long CreateDevice(Device device)
        {
            using (var scope = new TransactionScope())
            {
                if (device != null)
                {
                    var config_Device_Model = new MapperConfiguration(
                                cfg =>
                                {
                                    cfg.CreateMap<Device, Device_Model>()
                                            .ForMember(dest => dest.DateCreated, opts => opts.UseValue(System.DateTime.Now))
                                            .ForMember(dest => dest.DateModified, opts => opts.UseValue(System.DateTime.Now));

                                    cfg.CreateMap<Owner, Owner_Model>();
//                                            .ForMember(dest => dest.OwnedDevices, opts => opts.Ignore())
//                                            .ForMember(dest => dest.UsersInTouch, opts => opts.Ignore());
                                    
                                    cfg.CreateMap<Location, Location_Model>();

//                                    cfg.CreateMap<Device_Connection, Device_Model_Connection_Item>()
//                                            .ForMember(dest => dest.Device, opts => opts.Ignore());
//                                        cfg.CreateMap<Device_Declaration_Item_Sensor, Device_Model_Declaration_Item_Sensor>()
//                                                .ForMember(dest => dest.Connection, opts => opts.Ignore());
//                                        cfg.CreateMap<Device_Declaration_Item_Actuator, Device_Model_Declaration_Item_Actuator>()
//                                                .ForMember(dest => dest.Connection, opts => opts.Ignore());
                                            cfg.CreateMap<Device_Alarm, Device_Model_Alarm>();

                                    cfg.CreateMap<Data_Representation, Data_Representation_Model>()
                                           .ForMember(dest => dest.RepresentationForDevice, opts => opts.Ignore());
                                        cfg.CreateMap<Representation_Line_Item, Representation_Model_Line_Item>()
                                               .ForMember(dest => dest.Representation, opts => opts.Ignore());
                                        cfg.CreateMap<Representation_Bar_Item, Representation_Model_Bar_Item>()
                                               .ForMember(dest => dest.Representation, opts => opts.Ignore());
                                        cfg.CreateMap<DataSet_Source, DataSet_Source_Model>();
                                        cfg.CreateMap<User, User_Model>()
                                                .ForMember(dest => dest.Address, opts => opts.Ignore())
//                                                .ForMember(dest => dest.Token, opts => opts.Ignore())
//                                                .ForMember(dest => dest.Password, opts => opts.Ignore())
//                                                .ForMember(dest => dest.Representations, opts => opts.Ignore())
//                                                .ForMember(dest => dest.FriendsInTouch, opts => opts.Ignore())
                                                .ForMember(dest => dest.OwnersInTouch, opts => opts.Ignore());
                                });
                    var mapper_device = config_Device_Model.CreateMapper();

                    Device_Model dev_mod = mapper_device.Map<Device_Model>(device);
                    _transactionDB.DeviceRepository.Insert(dev_mod);
                    _transactionDB.Save();
                    scope.Complete();
                    return dev_mod.Id;
                };
                return 0;
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public bool UpdateDevice(long deviceId, Device device)
        {
            var success = false;
            if (device != null)
            {
                using (var scope = new TransactionScope())
                {
                    var dev_mod = _transactionDB.DeviceRepository.GetByID(deviceId);
                    if (dev_mod != null)
                    {
                        dev_mod.DeviceName = device.DeviceName;
                        _transactionDB.DeviceRepository.Update(dev_mod);
                        _transactionDB.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public bool DeleteDevice(long deviceId)
        {
            var success = false;
            if (deviceId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var device = _transactionDB.DeviceRepository.GetByID(deviceId);
                    if (device != null)
                    {

                        _transactionDB.DeviceRepository.Delete(device);
                        _transactionDB.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
