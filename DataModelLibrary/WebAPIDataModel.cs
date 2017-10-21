using System.Data.Entity;
using DataModelLibrary.ModelsRepository;

namespace DataModelLibrary
{
    public class WebAPIDataModel : DbContext
    {
        public WebAPIDataModel()
            : base("Server=tcp:vizatechserver.database.windows.net,1433;Initial Catalog=vizatechdbmain;Persist Security Info=False;User ID=adminlogin;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30")
        {
//          Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebAPIDataModel, Migrations.Configuration>());
//          Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebAPIDataModel>());
//          Database.SetInitializer(new DropCreateDatabaseAlways<WebAPIDataModel>());
//          Database.SetInitializer(new CreateDatabaseIfNotExists<WebAPIDataModel>());
          Database.SetInitializer<WebAPIDataModel>(null);
        }

        #region Объявление Наборов данных
            public virtual DbSet<Authentication_Model> Athenticators { get; set; }
            public virtual DbSet<Tokens_Model> Tokens { get; set; }

            public virtual DbSet<Location_Model> Locations { get; set; }

            public virtual DbSet<User_Model> Users { get; set; }
            public virtual DbSet<Owner_Model> Owners { get; set; }

            public virtual DbSet<User_Model_FriendsForUser> UsersFriends { get; set; }
            public virtual DbSet<User_Model_OwnersForUser> UsersSuppliers { get; set; }
            public virtual DbSet<Owner_Model_CustomersForOwner> OwnersCustomers { get; set; }
            public virtual DbSet<Owner_Model_DevicesForOwner> OwnersDevices { get; set; }

            public virtual DbSet<Device_Model> Devices { get; set; }
            public virtual DbSet<Device_Model_Declaration_Item_Sensor> Sensors { get; set; }
            public virtual DbSet<Device_Model_Declaration_Item_Actuator> Actuators { get; set; }
            public virtual DbSet<Device_Model_Alarm> Alarms { get; set; }

            public virtual DbSet<Representation_Model_Line_Canvas> LineCanvases { get; set; }
            public virtual DbSet<Representation_Model_Bar_Canvas> BarCanvases { get; set; }
            public virtual DbSet<Representation_Model_Pie_Canvas> PieCanvases { get; set; }
            public virtual DbSet<Representation_Model_Polar_Canvas> PolarCanvases { get; set; }
            public virtual DbSet<Representation_Model_Radar_Canvas> RadarCanvases { get; set; }
            public virtual DbSet<Representation_Model_Bubble_Canvas> BubbleCanvases { get; set; }

            public virtual DbSet<Representation_Model_Line_Item> Lines { get; set; }
            public virtual DbSet<Representation_Model_Bar_Item> Bars { get; set; }
            public virtual DbSet<Representation_Model_Pie_Item> Pies { get; set; }
            public virtual DbSet<Representation_Model_Radar_Item> Radars { get; set; }
            public virtual DbSet<Representation_Model_Polar_Item> Polars { get; set; }
            public virtual DbSet<Representation_Model_Bubble_Item> Bubbles { get; set; }

            public virtual DbSet<Representation_Model_UsersAdmitted> AdmittedUsers { get; set; }

            public virtual DbSet<Data_Representation_Model> Representations { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /// <summary>
            /// FluentAPI - мапирование объектов Data Access Layer на базу данных Azure.SQL
            /// </summary>

            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(8, 4));

            #region мапирование Devices

            modelBuilder.Entity<Device_Model>().HasKey<long>(p => p.Id);
                modelBuilder.Entity<Device_Model>().Property(p => p.DeviceName).IsRequired();
                modelBuilder.Entity<Device_Model>().Property(p => p.DeviceIcon).IsOptional();
                modelBuilder.Entity<Device_Model>().Property(p => p.DateCreated).IsOptional().HasColumnType("DateTime2");
                modelBuilder.Entity<Device_Model>().Property(p => p.DateModified).IsOptional().HasColumnType("DateTime2");

                    modelBuilder.Entity<Device_Model>().Property(p => p.FunctionType).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.AnalogDigitalType).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.SensorActuatorType).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.Description).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.Accurance).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.Measurement).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.Frequency).IsOptional();
                    modelBuilder.Entity<Device_Model>().Property(p => p.DataSheet).IsOptional();

            // связи 1 -> 0|1 на Owner_Model
            modelBuilder.Entity<Device_Model>().HasOptional<Owner_Model>(p => p.Owner);

            // связи 1 -> 0|1 c Location_Model
            modelBuilder.Entity<Device_Model>().HasOptional<Location_Model>(p => p.Address);

            // связи 1 -> (many) на Data_Representation_Model
            modelBuilder.Entity<Device_Model>().HasMany<Data_Representation_Model>(p => p.Representations).WithRequired(d => d.RepresentationForDevice);
            #endregion

            #region мапирование Connections
            // модель декларирования Connection
                modelBuilder.Entity<Device_Model>().Property(p => p.ConnectionString).IsOptional();
                modelBuilder.Entity<Device_Model>().Property(p => p.DeviceKey).IsOptional();
                modelBuilder.Entity<Device_Model>().Property(p => p.HubName).IsOptional();
                modelBuilder.Entity<Device_Model>().Property(p => p.HubSuffix).IsOptional();

                // связи 1 -> (many) на коллекцию Sensor
//                modelBuilder.Entity<Device_Model>().HasMany<Device_Model_Declaration_Item_Sensor>(p => p.SensorDeclarations);
                // связи 1 -> (many) на коллекцию Actuator
//                modelBuilder.Entity<Device_Model>().HasMany<Device_Model_Declaration_Item_Actuator>(p => p.ActuatorDeclarations);

                // модель декларирования полей для отображения Sensor
                modelBuilder.Entity<Device_Model_Declaration_Item_Sensor>().HasKey<long>(p => p.Id);

                        // связи 1 -> 0|1 c Device_Model
                        modelBuilder.Entity<Device_Model_Declaration_Item_Sensor>().HasOptional<Device_Model>(p => p.SensorForDevice);

                        // связи 1 -> (many) на Data_Model_Alarm
                        modelBuilder.Entity<Device_Model_Declaration_Item_Sensor>().HasMany<Device_Model_Alarm>(p => p.Alarms).WithOptional(d => d.AlarmFromSensor);

                        modelBuilder.Entity<Device_Model_Declaration_Item_Sensor>().Property(p => p.SensorParameterName).IsOptional();
                        modelBuilder.Entity<Device_Model_Declaration_Item_Sensor>().Property(p => p.SensorParameterType).IsOptional();

                // модель декларирования полей для отображения Actuator
                modelBuilder.Entity<Device_Model_Declaration_Item_Actuator>().HasKey<long>(p => p.Id);

                        // связи 1 -> 0|1 c Device_Model
                        modelBuilder.Entity<Device_Model_Declaration_Item_Actuator>().HasOptional<Device_Model>(p => p.ActuatorForDevice);

                        // связи 1 -> (many) на Data_Model_Alarm
                        modelBuilder.Entity<Device_Model_Declaration_Item_Actuator>().HasMany<Device_Model_Alarm>(p => p.Alarms).WithOptional(d => d.AlarmForActuator);

                        modelBuilder.Entity<Device_Model_Declaration_Item_Actuator>().Property(p => p.ActuatorParameterName).IsOptional();
                        modelBuilder.Entity<Device_Model_Declaration_Item_Actuator>().Property(p => p.ActuatorParameterType).IsOptional();
            #endregion

            #region мапирование Alarms

            // модель декларирования Device_Model_Alarm
            modelBuilder.Entity<Device_Model_Alarm>().HasKey<long>(p => p.Id);

                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.AlarmName).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ActuationType).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ConditionType).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ActuatorOnOffValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ActuatorDecimalValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ActuatorStringValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ConditionOnOffValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ConditionTopValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ConditionBottomfValue).IsOptional();
                        modelBuilder.Entity<Device_Model_Alarm>().Property(p => p.ConditionStringValue).IsOptional();
            #endregion

            #region мапирование Locations

            modelBuilder.Entity<Location_Model>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Location_Model>().Property(p => p.Country).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.State).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.Region).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.City).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.Street).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.Building).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.Description).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.PositionX).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.PositionY).IsOptional();
                    modelBuilder.Entity<Location_Model>().Property(p => p.PositionZ).IsOptional();
            #endregion

            #region мапирование Representations

            modelBuilder.Entity<Data_Representation_Model>().HasKey<long>(p => p.Id);

                modelBuilder.Entity<Data_Representation_Model>().Property(p => p.RepresentationName).IsOptional();

                // связи 1 -> (many) на Data_Representation_Model для Линий
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Line_Item>(p => p.LineItems).WithOptional(d => d.Representation);

                // связи 1 -> (many) на Data_Representation_Model для Гистограмм
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Bar_Item>(p => p.BarItems).WithOptional(d => d.Representation);

                // связи 1 -> (many) на Data_Representation_Model для Radar
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Radar_Item>(p => p.RadarItems).WithOptional(d => d.Representation);

                // связи 1 -> (many) на Data_Representation_Model для круговых диаграмм
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Pie_Item>(p => p.PieItems).WithOptional(d => d.Representation);

                // связи 1 -> (many) на Data_Representation_Model для полярных диаграмм
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Polar_Item>(p => p.PolarItems).WithOptional(d => d.Representation);

                // связи 1 -> (many) на Data_Representation_Model для пузырьковыъ диаграмм
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_Bubble_Item>(p => p.BubbleItems).WithOptional(d => d.Representation);

                // связи 1 -> 1 на коллекцию пользователей, для которых разрешено данное представление
                modelBuilder.Entity<Data_Representation_Model>().HasMany<Representation_Model_UsersAdmitted>(p => p.UsersAdmitted).WithOptional(d => d.Representation);

                    // мапирование Representation_Model_UsersAdmitted
                    modelBuilder.Entity<Representation_Model_UsersAdmitted>().HasKey<long>(p => p.Id);

                        modelBuilder.Entity<Representation_Model_UsersAdmitted>().Property(p => p.IssuedOn).IsOptional().HasColumnType("DateTime2");
                        modelBuilder.Entity<Representation_Model_UsersAdmitted>().Property(p => p.ExpiresOn).IsOptional().HasColumnType("DateTime2");

                        // связи 1 -> (many) на коллекцию пользователей, для которых разрешено данное представление
                        modelBuilder.Entity<Representation_Model_UsersAdmitted>().HasOptional<User_Model>(p => p.UserAdmitted).WithMany(d => d.AllowedRepresentations);

            #endregion

            #region мапирование Коллекций представлений

            // мапирование Линейного представления
            modelBuilder.Entity<Representation_Model_Line_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Line_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> (many) от шаблона лини на Представление линии
                    modelBuilder.Entity<Representation_Model_Line_Item>().HasOptional<Representation_Model_Line_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Line_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Line_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);

            // мапирование Гистограммного представления
            modelBuilder.Entity<Representation_Model_Bar_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Bar_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> (many) от шаблона на Представление гистограмм
                    modelBuilder.Entity<Representation_Model_Bar_Item>().HasOptional<Representation_Model_Bar_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Bar_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Bar_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);

            // мапирование Radar представления
            modelBuilder.Entity<Representation_Model_Radar_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Radar_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> (many) от шаблона на Представление гистограмм
                    modelBuilder.Entity<Representation_Model_Radar_Item>().HasOptional<Representation_Model_Radar_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Radar_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Radar_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);

            // мапирование представления круговой диаграммы
            modelBuilder.Entity<Representation_Model_Pie_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Pie_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> (many) от шаблона на Представление гистограмм
                    modelBuilder.Entity<Representation_Model_Pie_Item>().HasOptional<Representation_Model_Pie_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Pie_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Pie_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);

            // мапирование Polar представления
            modelBuilder.Entity<Representation_Model_Polar_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Polar_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> 1 от шаблона на Представление гистограмм
                    modelBuilder.Entity<Representation_Model_Polar_Item>().HasOptional<Representation_Model_Polar_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Polar_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Polar_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);

            // мапирование Пузырькового представления
            modelBuilder.Entity<Representation_Model_Bubble_Item>().HasKey<long>(p => p.Id);
                    modelBuilder.Entity<Representation_Model_Bubble_Item>().Property(p => p.Label).IsOptional();

                    // связи 1 -> 0|1 от шаблона на Представление гистограмм
                    modelBuilder.Entity<Representation_Model_Bubble_Item>().HasOptional<Representation_Model_Bubble_Canvas>(p => p.Canvas);

                    // связи 1 -> 0|1 c Источником набора данных
                    modelBuilder.Entity<Representation_Model_Bubble_Item>().HasOptional<DataSet_Source_Model>(p => p.DataSet);

                    // связи 1 -> 0|1 c конкретным Свойством набора данных 
                    modelBuilder.Entity<Representation_Model_Bubble_Item>().HasOptional<Device_Model_Declaration_Item_Sensor>(p => p.DeclarationItem);
            #endregion

            #region мапирование Шаблонов представлений

            // мапирование Шаблона линии

            modelBuilder.Entity<Representation_Model_Line_Canvas>().HasKey<long>(p => p.Id);
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.CanvasName).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.Fill).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BackgroundColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderWidth).IsOptional();

                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointBorderColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointBackgroundColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointBorderWidth).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointRadius).IsOptional();

                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.ShowLine).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.SpanGaps).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.SteppedLine).IsOptional();

                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.XAxisID).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.XAxisID).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.CubicInterpolationMode).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.LineTension).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderCapStyle).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderDash).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderDashOffset).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.BorderJoinStyle).IsOptional();

                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointHitRadius).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointHoverRadius).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointHoverBorderWidth).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointHoverBackgroundColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointHoverBorderColor).IsOptional();

                modelBuilder.Entity<Representation_Model_Line_Canvas>().Property(p => p.PointStyle).IsOptional();

            // мапирование Шаблона гистограммы

            modelBuilder.Entity<Representation_Model_Bar_Canvas>().HasKey<long>(p => p.Id);
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.CanvasName).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BorderWidth).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BorderColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BackgroundColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BorderSkipped).IsOptional();

                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.HoverBorderWidth).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.HoverBackgroundColor).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.HoverBorderColor).IsOptional();

                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.XAxisID).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.XAxisID).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BarPercentage).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.CategoryPercentage).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.BarThickness).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.MaxBarThickness).IsOptional();
                modelBuilder.Entity<Representation_Model_Bar_Canvas>().Property(p => p.OffsetGridLines).IsOptional();

            // мапирование Шаблона Radar

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().HasKey<long>(p => p.Id);
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.CanvasName).IsOptional();

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderDash).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderDashOffset).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderCapStyle).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BorderJoinStyle).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.BackgroundColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.Fill).IsOptional();

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.LineTension).IsOptional();

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointBorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointBackgroundColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointBorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointRadius).IsOptional();

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointStyle).IsOptional();

            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointHitRadius).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointHoverRadius).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointHoverBorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointHoverBackgroundColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Radar_Canvas>().Property(p => p.PointHoverBorderColor).IsOptional();

            // мапирование Шаблона круговой гистограммы

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().HasKey<long>(p => p.Id);

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.CanvasName).IsOptional();

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.BorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.BorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.BackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.HoverBorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.HoverBorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.HoverBackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.CutoutPercentage).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.Rotation).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.Сircumference).IsOptional();

            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.AnimateRotate).IsOptional();
            modelBuilder.Entity<Representation_Model_Pie_Canvas>().Property(p => p.AnimateScale).IsOptional();

            // мапирование Шаблона полярной гистограммы

            modelBuilder.Entity<Representation_Model_Polar_Canvas>().HasKey<long>(p => p.Id);

            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.CanvasName).IsOptional();

            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.BorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.BorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.BackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.HoverBorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.HoverBorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.HoverBackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.StartAngle).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.AnimateRotate).IsOptional();
            modelBuilder.Entity<Representation_Model_Polar_Canvas>().Property(p => p.AnimateScale).IsOptional();

            // мапирование Шаблона пузырьковой гистограммы

            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().HasKey<long>(p => p.Id);

            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.CanvasName).IsOptional();

            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.BorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.BorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.BackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.HoverBorderWidth).IsOptional();
            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.HoverBorderColor).IsOptional();
            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.HoverBackgroundColor).IsOptional();

            modelBuilder.Entity<Representation_Model_Bubble_Canvas>().Property(p => p.HoverRadius).IsOptional();
            #endregion

            #region мапирование DataSet_Sources

            modelBuilder.Entity<DataSet_Source_Model>().HasKey<long>(p => p.Id);
                        modelBuilder.Entity<DataSet_Source_Model>().Property(p => p.TableStorageName).IsOptional();
                        modelBuilder.Entity<DataSet_Source_Model>().Property(p => p.AccountKey).IsOptional();
                        modelBuilder.Entity<DataSet_Source_Model>().Property(p => p.AccountName).IsOptional();
            #endregion

            #region мапирование Users

            modelBuilder.Entity<User_Model>().HasKey<long>(p => p.Id);

                // связи 1 -> 0|1 c Location_Model
                modelBuilder.Entity<User_Model>().HasOptional(p => p.Address);

                // связи 1 -> (many) c коллекцией Friends
                modelBuilder.Entity<User_Model>().HasOptional<User_Model_FriendsForUser>(p => p.FriendsInTouch).WithRequired(d => d.User);
                    modelBuilder.Entity<User_Model_FriendsForUser>().HasKey<long>(p => p.Id);
                        modelBuilder.Entity<User_Model_FriendsForUser>().HasMany<User_Model>(p => p.Friends);

                // связи 1 -> (many) c коллекцией Owners
                modelBuilder.Entity<User_Model>().HasOptional<User_Model_OwnersForUser>(p => p.OwnersInTouch).WithRequired(d => d.User);
                    modelBuilder.Entity<User_Model_OwnersForUser>().HasKey<long>(p => p.Id);
                        modelBuilder.Entity<User_Model_OwnersForUser>().HasMany<Owner_Model>(p => p.Owners);

                // связи 1 -> 0|1 на Owner_Model если пользователь имеет такой статус
                modelBuilder.Entity<User_Model>().HasOptional<Owner_Model>(p => p.IsOwner).WithRequired(d => d.OwnerAsUser);

                // связи 1 -> 0|1 на Authentication_Model
                modelBuilder.Entity<User_Model>().HasRequired<Authentication_Model>(p => p.Authentication).WithOptional(d => d.AuthenticationForUser);

                modelBuilder.Entity<User_Model>().Property(p => p.FirstName).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.SecondName).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Position).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Photo).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Icon).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Rating).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.DateCreated).IsOptional().HasColumnType("DateTime2");
                modelBuilder.Entity<User_Model>().Property(p => p.DateModified).IsOptional().HasColumnType("DateTime2");

                modelBuilder.Entity<User_Model>().Property(p => p.IfVisiblePhoneNumber).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.PhoneNumber).IsOptional();

                modelBuilder.Entity<User_Model>().Property(p => p.IfVisibleChats).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Skype).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.Telegram).IsOptional();

                modelBuilder.Entity<User_Model>().Property(p => p.IfVisibleWorkEmail).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.WorkEmail).IsOptional();

                modelBuilder.Entity<User_Model>().Property(p => p.IfVisibleSocialNetworking).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.PersonalSite).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.LinkToLinkedIn).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.LinkToFacebook).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.LinkToVkontakte).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.LinkToTwitter).IsOptional();
                modelBuilder.Entity<User_Model>().Property(p => p.LinkToInstagram).IsOptional();
            #endregion

            #region мапирование Авторизации
            // мапирование Authentication_Model
            modelBuilder.Entity<Authentication_Model>().HasKey<long>(p => p.Id);

                modelBuilder.Entity<Authentication_Model>().Property(p => p.Login).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.Password).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.EMail).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.AuthenticationMetod).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.DoubleAuthenticationOn).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.ProofEmailChange).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.ProofPasswordChange).IsOptional();
                modelBuilder.Entity<Authentication_Model>().Property(p => p.AuthenticationCreated).IsOptional().HasColumnType("DateTime2");
                modelBuilder.Entity<Authentication_Model>().Property(p => p.AuthenticationModified).IsOptional().HasColumnType("DateTime2");

                // связи 1 -> (many) c Token_Model
                modelBuilder.Entity<Authentication_Model>().HasMany<Tokens_Model>(p => p.Tokens).WithRequired(d => d.AuthenticationModel);

                    // мапирование Tokens_Model
                    modelBuilder.Entity<Tokens_Model>().HasKey<long>(p => p.Id);

//                    modelBuilder.Entity<Tokens_Model>().HasRequired<Authentication_Model>(p => p.AuthenticationModel).WithMany(d => d.Tokens);
//                
                    modelBuilder.Entity<Tokens_Model>().Property(p => p.AuthToken).IsOptional();
                    modelBuilder.Entity<Tokens_Model>().Property(p => p.IssuedOn).IsOptional().HasColumnType("DateTime2");
                    modelBuilder.Entity<Tokens_Model>().Property(p => p.ExpiresOn).IsOptional().HasColumnType("DateTime2");
            #endregion

            #region мапирование Owners

            modelBuilder.Entity<Owner_Model>().HasKey<long>(p => p.Id);

                modelBuilder.Entity<Owner_Model>().Property(p => p.OwnerCompanyName).IsOptional();
                modelBuilder.Entity<Owner_Model>().Property(p => p.CompanyLogo).IsOptional();

                // связи 1 -> 0|1 c Location_Model
                modelBuilder.Entity<Owner_Model>().HasOptional(p => p.OwnerCompanyAddress);

                modelBuilder.Entity<Owner_Model>().Property(p => p.DateCreated).IsOptional().HasColumnType("DateTime2");
                modelBuilder.Entity<Owner_Model>().Property(p => p.DateModified).IsOptional().HasColumnType("DateTime2");

                // связи на список Устройств
                modelBuilder.Entity<Owner_Model>().HasOptional<Owner_Model_DevicesForOwner>(p => p.Devices).WithRequired(d => d.Owner);
                    modelBuilder.Entity<Owner_Model_DevicesForOwner>().HasKey<long>(p => p.Id);
                        modelBuilder.Entity<Owner_Model_DevicesForOwner>().HasMany<Device_Model>(p => p.Devices);

                // связи на список Клиентов
                modelBuilder.Entity<Owner_Model>().HasOptional<Owner_Model_CustomersForOwner>(p => p.Customers).WithRequired(d => d.Owner);
                    modelBuilder.Entity<Owner_Model_CustomersForOwner>().HasKey<long>(p => p.Id);
                        modelBuilder.Entity<Owner_Model_CustomersForOwner>().HasMany<User_Model>(p => p.Customers);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }


}