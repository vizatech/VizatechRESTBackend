namespace DataModelLibrary.ModelsRepository
{
    using System;
    using System.Collections.Generic;
    public class Device_Model                               // Класс устройства Device
    {
        public long Id { get; set; }                        // Ключ устройства в таблице устройств

        public virtual Owner_Model Owner { get; set; }                  // владелец устройства
        public virtual Location_Model Address { get; set; }             // адрес размещения устройства
        public virtual ICollection<Data_Representation_Model> Representations { get; set; } // коллекция представлений для данного устройства

        public string DeviceName { get; set; }              // Имя устройства, задаваемое пользователем
        public string DeviceIcon { get; set; }              // Иконка устройства - выбирается из доступных или подгружается пользователем        public string DeviceClass { get; set; }     // Тип источника данных: IoT, SQL (ERP, CRM, XRM), Web (OpenData)
       
        public DateTime DateCreated { get; set; }           // Дата содания устройства//
        public DateTime DateModified { get; set; }          // Дата содания устройства

        public string FunctionType { get; set; }            // Функциональный тип: датчика - темпертура, давление, состав воздуха и т.п.
        public bool SensorActuatorType { get; set; }        // Чем это устройство является: Исполняющий элемент (актуатор) или сенсор
        public bool AnalogDigitalType { get; set; }         // Тип данных устройства: on/off, 0..1024, GIS (double)
        public string Description { get; set; }             // Краткое описание устройства в текстовом виде для пользователя - что это устройство делает
        public decimal Accurance { get; set; }              // точность измерения данных
        public string Measurement { get; set; }             // единица измерения
        public decimal Frequency { get; set; }              // частота измерений раз в час
        public string UtitsForFrequency { get; set; }       // единица частоты измерений
        public string DataSheet { get; set; }               // файл технического описания устройства

        public string ConnectionString { get; set; }        // Строка соединения устройства с сервисом Azure
        public string DeviceKey { get; set; }               // Ключ соединения устройства с сервисом Azure
        public string HubName { get; set; }                 // Имя хаба Azure, выделенного для присоединения устройства
        public string HubSuffix { get; set; }               // Имя корневой дирекории Azure, для хаба устройства

//        public virtual ICollection<Device_Model_Declaration_Item_Sensor> SensorDeclarations { get; set; }       // коллекция параметров принимаемых от устройства данных
//        public virtual ICollection<Device_Model_Declaration_Item_Actuator> ActuatorDeclarations { get; set; }   // коллекция параметров принимаемых от устройства данных
    }

    public class Device_Model_Declaration_Item_Sensor       // Класс описания элементов схемы принимаемых от устройства данных
    {
        public long Id { get; set; }                        // Ключ модели декларирования в таблице данных

        public virtual Device_Model SensorForDevice { get; set; }

        public virtual ICollection<Device_Model_Alarm> Alarms { get; set; }

        public string SensorParameterName { get; set; }     // Имя параметра в потоке данных, который принимается от источника данных
        public string SensorParameterType { get; set; }     // Тип параметра: boolean, integer, double, string
    }

    public class Device_Model_Declaration_Item_Actuator     // Класс описания элементов схемы передавданных
    {
        public long Id { get; set; }                        // Ключ модели декларирования в таблице данных

        public virtual Device_Model ActuatorForDevice { get; set; }

        public virtual ICollection<Device_Model_Alarm> Alarms { get; set; }

        public string ActuatorParameterName { get; set; }   // Имя параметра в потоке данных, который передается на актуатор
        public string ActuatorParameterType { get; set; }   // Тип параметра: boolean, integer, double, string
    }

    public class Device_Model_Alarm
    {
        public long Id { get; set; }

        public string AlarmName { get; set; } 

        public virtual Device_Model_Declaration_Item_Sensor AlarmFromSensor { get; set; }    // на основании какого сенсора
        public virtual Device_Model_Declaration_Item_Actuator AlarmForActuator { get; set; }  // какому актуатору передается значение

        public string ActuationType { get; set; }           // 'Digital value', 'Yes/No', 'Mobile notification', 'Publication in social network', 'Email notification', 'SMS notification', 'News feed notification'
        public string ConditionType { get; set; }           // 'Equel to value', 'Less then value', 'More then value', 'Value is inside the borders', 'Value is outside the borders', 'Yes/No trigger', 'Equel to string'

        public bool ConditionOnOffValue { get; set; }       // параметр сработки по Yes|No
        public decimal ConditionTopValue { get; set; }      // верхняя граница или единственная
        public decimal ConditionBottomfValue { get; set; }  // нижняя граница - если установлена
        public string ConditionStringValue { get; set; }    // строковое значение - команда на сработку

        public bool ActuatorOnOffValue { get; set; }        // значение передаваемое актуатору Yes|No
        public decimal ActuatorDecimalValue { get; set; }   // значение, передаваемое актуатору - цифровое
        public string ActuatorStringValue { get; set; }     // верхняя граница или единственная - строковое
    }
}