namespace DataModelLibrary.ModelsRepository
{
    using System;
    using System.Collections.Generic;

    public class Data_Representation_Model                      // Класс представления данных от устройства
    {
        public long Id { get; set; }                            // Ключ представления в таблице представлений

        public string RepresentationName { get; set; }          // Имя представления

        public virtual Device_Model RepresentationForDevice { get; set; }   // к какому источнику данных привязано данное представление

        public virtual ICollection<Representation_Model_Line_Item> LineItems { get; set; }  // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Model_Bar_Item> BarItems { get; set; }    // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Model_Pie_Item> PieItems { get; set; }    // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Model_Polar_Item> PolarItems { get; set; }    // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Model_Radar_Item> RadarItems { get; set; }    // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Model_Bubble_Item> BubbleItems { get; set; }    // Коллекция графиков для вывода в представлении

        public virtual ICollection<Representation_Model_UsersAdmitted> UsersAdmitted { get; set; }  // список пользователей, которым разрешен доступ к данному представлению
    }

    public class Representation_Model_UsersAdmitted
    {
        public long Id { get; set; }

        public virtual Data_Representation_Model Representation { get; set; }

        public DateTime IssuedOn { get; set; }          // Метка времени доступа
        public DateTime ExpiresOn { get; set; }         // Метка времени прекращения действия токена
        public virtual User_Model UserAdmitted { get; set; }  // список пользователей, которым разрешен доступ к данному представлению
    }

    public class Representation_Model_Line_Item
    {
        public long Id { get; set; }                                                        // Ключ линии

        public virtual Data_Representation_Model Representation { get; set; }               // Ссылка на представление для которого это линия сформирована 

        public string Label { get; set; }                                                   // Название графического представления линии
        public virtual Representation_Model_Line_Canvas Canvas { get; set; }                // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                           // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }   // Ссылка на декларацию параметра, по которому строится линия 
    }

    public class Representation_Model_Bar_Item
    {
        public long Id { get; set; }                                                // Ключ гистограммы

        public virtual Data_Representation_Model Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 

        public string Label { get; set; }                                           // Название графического представления гистограммы
        public virtual Representation_Model_Bar_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 
    }

    public class Representation_Model_Radar_Item
    {
        public long Id { get; set; }                                                // Ключ гистограммы

        public virtual Data_Representation_Model Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 

        public string Label { get; set; }                                           // Название графического представления гистограммы
        public virtual Representation_Model_Radar_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 
    }
    public class Representation_Model_Pie_Item
    {
        public long Id { get; set; }                                                // Ключ гистограммы

        public virtual Data_Representation_Model Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 

        public string Label { get; set; }                                           // Название графического представления гистограммы
        public virtual Representation_Model_Pie_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 
    }
    public class Representation_Model_Polar_Item
    {
        public long Id { get; set; }                                                // Ключ гистограммы

        public virtual Data_Representation_Model Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 

        public string Label { get; set; }                                           // Название графического представления гистограммы
        public virtual Representation_Model_Polar_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 
    }
    public class Representation_Model_Bubble_Item
    {
        public long Id { get; set; }                                                // Ключ гистограммы

        public virtual Data_Representation_Model Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 

        public string Label { get; set; }                                           // Название графического представления гистограммы
        public virtual Representation_Model_Bubble_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source_Model DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Model_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 
    }
    public class Representation_Model_Line_Canvas               // Класс представления набора данных в виде линии
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде графиков

        //        public virtual ICollection<Representation_Model_Line_Item> LineItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления линии

        public string BorderColor { get; set; }                 // Цвет линии графика
        public bool Fill { get; set; }                          // Следует ли заполнять пространство под графиком
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства под линией графика
        public int BorderWidth { get; set; }                    // Толщина линии графика

        public string PointBorderColor { get; set; }            // Цвет границы точки
        public string PointBackgroundColor { get; set; }        // Цвет заполнения точки
        public int PointBorderWidth { get; set; }               // Толщина границы точки
        public int PointRadius { get; set; }                    // Радиус точки

        public bool ShowLine { get; set; }                      // отображать или не отображать линию
        public bool SpanGaps { get; set; }                      // заполнять или нет точки для которых значение не представлено
        public bool SteppedLine { get; set; }                   // показывать ли линию частями - пошагово "false", "true", "before", "after"

        public string XAxisID { get; set; }                     // ID оси X на которую переносится набор данных 
        public string YAxisID { get; set; }                     // ID оси Y на которую переносится набор данных
        public string CubicInterpolationMode { get; set; }      // алгоритм интерполяции
        public int LineTension { get; set; }                    // извилистость линии
        public string BorderCapStyle { get; set; }              // стиль перегибов линии
        public string BorderDash { get; set; }                   // заполнение линии точками и тире
        public int BorderDashOffset { get; set; }               // ???
        public string BorderJoinStyle { get; set; }             // стиль соединений линии

        public int PointHitRadius { get; set; }                 // радиус точки при клике мышкой
        public int PointHoverRadius { get; set; }               // радиус точки при наведении мышки
        public int PointHoverBorderWidth { get; set; }          // толщина границы точки при наведении мышки
        public string PointHoverBackgroundColor { get; set; }   // цвет заполнения точки при наведении мышки
        public string PointHoverBorderColor { get; set; }       // цвет границы точки при наведении мышки

        public string PointStyle { get; set; }                  // стиль точки 'circle', 'cross', 'crossRot', 'dash', 'line', 'rect', 'rectRounded', 'rectRot', 'star', 'triangle'
    }

    public class Representation_Model_Bar_Canvas                // Класс представления набора данных в виде гистограммs
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде гистограмм

        //        public virtual ICollection<Representation_Model_Bar_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления линии

        public int BorderWidth { get; set; }                    // Толщина линии бара
        public string BorderColor { get; set; }                 // Цвет линии бара
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства внутри бара
        public string BorderSkipped { get; set; }               // какие края не рисовать "left", "right", "top", "bottom"

        public int HoverBorderWidth { get; set; }               // толщина границы точки при наведении мышки
        public string HoverBorderColor { get; set; }            // цвет границы точки при наведении мышки
        public string HoverBackgroundColor { get; set; }        // цвет заполнения точки при наведении мышки

        public string XAxisID { get; set; }                     // ID оси X на которую переносится набор данных 
        public string YAxisID { get; set; }                     // ID оси Y на которую переносится набор данных

        public decimal BarPercentage { get; set; }              // заполнение баром пространства между соседними барами 0.9
        public decimal CategoryPercentage { get; set; }         // Заполнение пространства для малых наборов данных 0.8
        public int BarThickness { get; set; }                   // Толщина набора в пикселях
        public int MaxBarThickness { get; set; }                // ограничение по толщине
        public bool OffsetGridLines { get; set; }               // если фэлс то линия сетки будет проходить по середине бара
    }

    public class Representation_Model_Radar_Canvas              // Класс представления набора данных в виде радара
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде радара

        //        public virtual ICollection<Representation_Model_Radar_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления линии

        public int BorderWidth { get; set; }                    // Толщина линии бара
        public string BorderColor { get; set; }                 // Цвет линии бара
        public int BorderDash { get; set; }                     // Длина и прерывистость линий
        public int BorderDashOffset { get; set; }               // Заполнение 
        public string BorderCapStyle { get; set; }              // Стиль заголовков линий
        public string BorderJoinStyle { get; set; }             // Стлиль соединения линий
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства внутри линии
        public bool Fill { get; set; }                          // Следует ли заполнять пространство под линией

        public int LineTension { get; set; }                    // напряжение кривой Безье

        public string PointBorderColor { get; set; }            // Цвет границы точки
        public string PointBackgroundColor { get; set; }        // Цвет заполнения точки
        public int PointBorderWidth { get; set; }               // Толщина границы точки
        public int PointRadius { get; set; }                    // Радиус точки    }

        public string PointStyle { get; set; }                  // стиль точки 'circle', 'cross', 'crossRot', 'dash', 'line', 'rect', 'rectRounded', 'rectRot', 'star', 'triangle'

        public int PointHitRadius { get; set; }                 // радиус точки при клике мышкой
        public int PointHoverRadius { get; set; }               // радиус точки при наведении мышки
        public int PointHoverBorderWidth { get; set; }          // толщина границы точки при наведении мышки
        public string PointHoverBackgroundColor { get; set; }   // цвет заполнения точки при наведении мышки
        public string PointHoverBorderColor { get; set; }       // цвет границы точки при наведении мышки
    }

    public class Representation_Model_Pie_Canvas              // Класс представления набора данных в виде круговой диаграммы
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде круговой диаграммы

        //        public virtual ICollection<Representation_Model_Pie_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления диаграммы

        public int BorderWidth { get; set; }                    // Толщина линии бара
        public string BorderColor { get; set; }                 // Цвет линии бара
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства внутри линии

        public int HoverBorderWidth { get; set; }           // толщина границы при наведении мышки
        public string HoverBackgroundColor { get; set; }    // цвет заполнения при наведении мышки
        public string HoverBorderColor { get; set; }        // цвет границы при наведении мышки

        public int CutoutPercentage { get; set; }           // процент диаграммы вырезанной из середины
        public int Rotation { get; set; }                   // начальный угол от которого рисуются дуги
        public int Сircumference { get; set; }              // угол, в котором развертываются дуги

        public bool AnimateRotate { get; set; }             // развертывание чарта анимируется по кругу
        public bool AnimateScale { get; set; }             // развертывание чарта анимируется от центра
    }

    public class Representation_Model_Polar_Canvas              // Класс представления набора данных в виде полярной диаграммы
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде полярной диаграммы

        //        public virtual ICollection<Representation_Model_Polar_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления диаграммы

        public int BorderWidth { get; set; }                    // Толщина линии бара
        public string BorderColor { get; set; }                 // Цвет линии бара
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства внутри линии

        public int HoverBorderWidth { get; set; }           // толщина границы при наведении мышки
        public string HoverBackgroundColor { get; set; }    // цвет заполнения при наведении мышки
        public string HoverBorderColor { get; set; }        // цвет границы при наведении мышки

        public int StartAngle { get; set; }                   // начальный угол от которого рисуются дуги
        public bool AnimateRotate { get; set; }             // развертывание чарта анимируется по кругу
        public bool AnimateScale { get; set; }             // развертывание чарта анимируется от центра
    }

    public class Representation_Model_Bubble_Canvas              // Класс представления набора данных в виде пузырьковой диаграммы
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде пузырьковой диаграммы

        //        public virtual ICollection<Representation_Model_Bubble_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону

        public string CanvasName { get; set; }                  // Название шаблона графического представления линии

        public int BorderWidth { get; set; }                    // Толщина линии бара
        public string BorderColor { get; set; }                 // Цвет линии бара
        public string BackgroundColor { get; set; }             // Заполнение цветом пространства внутри линии

        public int HoverBorderWidth { get; set; }               // толщина границы при наведении мышки
        public string HoverBackgroundColor { get; set; }        // цвет заполнения при наведении мышки
        public string HoverBorderColor { get; set; }            // цвет границы при наведении мышки
        public int HoverRadius { get; set; }                    // радиус при наведении мышки
    }
}