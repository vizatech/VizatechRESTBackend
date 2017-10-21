using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayerLibrary.ViewModelsRepository
{
    public class Device                           // Класс устройства Device
    {
        public long Id { get; set; }                    // Ключ устройства в таблице устройств

        public string DeviceName { get; set; }          // Имя устройства, задаваемое пользователем
        public string DeviceIcon { get; set; }          // Иконка устройства - выбирается из доступных или подгружается пользователем        public string DeviceClass { get; set; }     // Тип источника данных: IoT, SQL (ERP, CRM, XRM), Web (OpenData)

        public DateTime DateCreated { get; set; }       // Дата содания устройства
        public DateTime DateModified { get; set; }       // Дата содания устройства

        public virtual Location Address { get; set; }
        public virtual Device_Connection Connection { get; set; }       // данные соединения для данного устройства

        public virtual Owner Owner { get; set; }

        public virtual ICollection<Data_Representation> Representations { get; set; } // коллекция Представлений для данного устройства

        public string FunctionType { get; set; }        // Функциональный тип: датчика - темпертура, давление, состав воздуха и т.п.
        public bool AnalogDigitalType { get; set; }     // Тип данных устройства: on/off, 0..1024, GIS (double)
        public bool SensorActuatorType { get; set; }    // Чем это устройство является: Исполняющий элемент (актуатор) или сенсор
        public string Description { get; set; }         // Краткое описание устройства в текстовом виде для пользователя - что это устройство делает
        public decimal Accurance { get; set; }            // точность измерения данных
        public string Measurement { get; set; }         // единица измерения
        public decimal Frequency { get; set; }            // частота измерений
        public string DataSheet { get; set; }           // файл технического описания устройства
    }

    public class Device_Connection                       // класс соединения устройства
    {
        public long Id { get; set; }                        // Ключ таблицы соединений

        public string ConnectionString { get; set; }        // Строка соединения устройства с сервисом Azure
        public string DeviceKey { get; set; }               // Ключ соединения устройства с сервисом Azure
        public string HubName { get; set; }                 // Имя хаба Azure, выделенного для присоединения устройства
        public string HubSuffix { get; set; }               // Имя корневой дирекории Azure, для хаба устройства

        public virtual ICollection<Device_Declaration_Item_Sensor> SensorDeclarations { get; set; }       // коллекция параметров принимаемых от устройства данных
        public virtual ICollection<Device_Declaration_Item_Actuator> ActuatorDeclarations { get; set; }   // коллекция параметров принимаемых от устройства данных

        public virtual Device Device { get; set; }
    }

    public class Device_Declaration_Item_Sensor       // Класс описания элементов схемы принимаемых от устройства данных
    {
        public long Id { get; set; }                        // Ключ модели декларирования в таблице данных

        public string SensorParameterName { get; set; }     // Имя параметра в потоке данных, который принимается от источника данных
        public string SensorParameterType { get; set; }     // Тип параметра: boolean, integer, double, string

        public virtual Device_Connection Connection { get; set; }
        public virtual ICollection<Device_Alarm> Alarms { get; set; }
    }

    public class Device_Declaration_Item_Actuator     // Класс описания элементов схемы передавданных
    {
        public long Id { get; set; }                        // Ключ модели декларирования в таблице данных

        public string ActuatorParameterName { get; set; }   // Имя параметра в потоке данных, который передается на актуатор
        public string ActuatorParameterType { get; set; }   // Тип параметра: boolean, integer, double, string

        public virtual Device_Connection Connection { get; set; }

        public virtual ICollection<Device_Alarm> Alarms { get; set; }
    }

    public class Device_Alarm
    {
        public long Id { get; set; }

        public virtual Device_Declaration_Item_Sensor ForSensor { get; set; }    // на основании какого сенсора
        public virtual Device_Declaration_Item_Actuator ForActuator { get; set; }  // какому актуатору передается значение

        public string OperationType { get; set; }           // 'equelToValue', 'less', 'more', 'inside', 'outside', 'yesNo', 'equelToString'

        public bool ConditionOnOffValue { get; set; }       // параметр сработки по Yes|No
        public decimal ConditionTopValue { get; set; }      // верхняя граница или единственная
        public decimal ConditionBottomfValue { get; set; }  // нижняя граница - если установлена
        public string ConditionStringValue { get; set; }    // строковое значение - команда на сработку

        public bool ActuatorOnOffValue { get; set; }        // значение передаваемое актуатору Yes|No
        public decimal ActuatorDecimalValue { get; set; }   // значение, передаваемое актуатору - цифровое
        public string ActuatorStringValue { get; set; }     // верхняя граница или единственная - строковое
    }
}