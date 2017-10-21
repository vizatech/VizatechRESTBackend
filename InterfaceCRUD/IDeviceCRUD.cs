using System.Collections.Generic;
using BusinessLayerLibrary.ViewModelsRepository;

namespace InterfaceCRUD

{
    /// <summary>
    /// Интерфейс взаимодействия с моделью Device 
    /// </summary>
    public interface IDeviceServices
    {
        Device GetDeviceById(long deviceId);
        IEnumerable<Device> GetAllDevices();
        long CreateDevice(Device device);
        bool UpdateDevice(long deviceId, Device device);
        bool DeleteDevice(long deviceId);
    }
}
