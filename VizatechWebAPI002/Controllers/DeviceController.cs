using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using BusinessLayerLibrary.ViewModelsRepository;
using InterfaceCRUD;

namespace VizatechWebAPI002.Controllers
{
    public class DeviceController : ApiController
    {

        private readonly IDeviceServices _deviceServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public DeviceController()
        {
            _deviceServices = new DeviceServices();
        }

        #endregion
        // GET api/values
        [SwaggerOperation("GetAll")]
        public HttpResponseMessage Get()
        {
            var dev_mods = _deviceServices.GetAllDevices();
            if (dev_mods != null)
            {
                var devices = dev_mods as List<Device> ?? dev_mods.ToList();
                if (devices.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, devices);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get(long id)
        {
            var dev_mod = _deviceServices.GetDeviceById(id);
            if (dev_mod != null)
                return Request.CreateResponse(HttpStatusCode.OK, dev_mod);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No device found for this id");
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public long Post([FromBody] Device device)
        {
            return _deviceServices.CreateDevice(device);
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public bool Put(long id, [FromBody]Device device)
        {
            if (id > 0)
            {
                return _deviceServices.UpdateDevice(id, device);
            }
            return false;
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public bool Delete(long id)
        {
            if (id > 0)
                return _deviceServices.DeleteDevice(id);
            return false;
        }
    }
}
