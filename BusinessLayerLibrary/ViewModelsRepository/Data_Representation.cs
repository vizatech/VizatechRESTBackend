namespace BusinessLayerLibrary.ViewModelsRepository
{
    using System.Collections.Generic;
    public class Data_Representation                      // Класс представления данных от устройства
    {
        public long Id { get; set; }                            // Ключ представления в таблице представлений

        public string RepresentationName { get; set; }          // Имя представления


        public virtual ICollection<Representation_Line_Item> LineItems { get; set; }  // Коллекция графиков для вывода в представлении
        public virtual ICollection<Representation_Bar_Item> BarItems { get; set; }  // Коллекция графиков для вывода в представлении

        public virtual Device RepresentationForDevice { get; set; }   // к какому источнику данных привязано данное представление

        public virtual ICollection<User> UsersAdmitted { get; set; }  // список пользователей, которым разрешен доступ к данному представлению
    }

    public class Representation_Line_Item
    {
        public long Id { get; set; }                                                // Ключ линии

        public string label { get; set; }                                           // Название графического представления линии
        public virtual Representation_Line_Canvas Canvas { get; set; }        // Ссылка на шаблон представления
        public virtual DataSet_Source DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 

        public virtual Data_Representation Representation { get; set; }       // Ссылка на представление для которого эта линия сформирована 
    }

    public class Representation_Bar_Item
    {
        public long Id { get; set; }                                                // Ключ линии

        public string label { get; set; }                                           // Название графического представления линии
        public virtual Representation_Bar_Canvas Canvas { get; set; }         // Ссылка на шаблон представления
        public virtual DataSet_Source DataSet { get; set; }                   // Ссылка на ДатаСет из которого принимаются данные для представления
        public virtual Device_Declaration_Item_Sensor DeclarationItem { get; set; }  // Ссылка на декларацию параметра, по которому строится линия 

        public virtual Data_Representation Representation { get; set; }       // Ссылка на представление для которого этот бар сформирован 
    }

    public class Representation_Line_Canvas               // Класс представления набора данных в виде линии
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде графиков

        public virtual ICollection<Representation_Line_Item> LineItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону
        public string canvasName { get; set; }                  // Название шаблона графического представления линии

        public string borderColor { get; set; }                 // Цвет линии графика
        public bool fill { get; set; }                          // Следует ли заполнять пространство под графиком
        public string backgroundColor { get; set; }             // Заполнение цветом пространства под линией графика
        public int borderWidth { get; set; }                    // Толщина линии графика

        public string pointBorderColor { get; set; }            // Цвет границы точки
        public string pointBackgroundColor { get; set; }        // Цвет заполнения точки
        public int pointBorderWidth { get; set; }               // Толщина границы точки
        public int pointRadius { get; set; }                    // Радиус точки

        public bool showLine { get; set; }                      // отображать или не отображать линию
        public bool spanGaps { get; set; }                      // заполнять или нет точки для которых значение не представлено
        public bool steppedLine { get; set; }                   // показывать ли линию частями - пошагово "false", "true", "before", "after"

        public string XAxisID { get; set; }                     // ID оси X на которую переносится набор данных 
        public string YAxisID { get; set; }                     // ID оси Y на которую переносится набор данных
        public string cubicInterpolationMode { get; set; }      // алгоритм интерполяции
        public int lineTension { get; set; }                    // извилистость линии
        public string borderCapStyle { get; set; }              // стиль перегибов линии
        public int[] borderDash { get; set; }                   // заполнение линии точками и тирели
        public int borderDashOffset { get; set; }               // ???
        public string borderJoinStyle { get; set; }             // стиль соединений линии

        public int pointHitRadius { get; set; }                 // радиус точки при клике мышкой
        public int pointHoverRadius { get; set; }               // радиус точки при наведении мышки
        public int pointHoverBorderWidth { get; set; }          // толщина границы точки при наведении мышки
        public string pointHoverBackgroundColor { get; set; }   // цвет заполнения точки при наведении мышки
        public string pointHoverBorderColor { get; set; }       // цвет границы точки при наведении мышки

        public string pointStyle { get; set; }                  // стиль точки 'circle', 'cross', 'crossRot', 'dash', 'line', 'rect', 'rectRounded', 'rectRot', 'star', 'triangle'
    }

    public class Representation_Bar_Canvas                // Класс представления набора данных в виде гистограммs
    {
        public long Id { get; set; }                            // Ключ таблицы представления данных в виде гистограмм

        public virtual ICollection<Representation_Bar_Item> BarItems { get; set; } // Ссылка на коллекцию представлений линий по данному шаблону
        public string canvasName { get; set; }                  // Название шаблона графического представления линии

        public int borderWidth { get; set; }                    // Толщина линии бара
        public string borderColor { get; set; }                 // Цвет линии бара
        public string backgroundColor { get; set; }             // Заполнение цветом пространства внутри бара
        public string borderSkipped { get; set; }               // какие края не рисовать "left", "right", "top", "bottom"

        public int HoverBorderWidth { get; set; }               // толщина границы точки при наведении мышки
        public string HoverBorderColor { get; set; }            // цвет границы точки при наведении мышки
        public string HoverBackgroundColor { get; set; }        // цвет заполнения точки при наведении мышки

        public string XAxisID { get; set; }                     // ID оси X на которую переносится набор данных 
        public string YAxisID { get; set; }                     // ID оси Y на которую переносится набор данных

        public decimal barPercentage { get; set; }              // заполнение баром пространства между соседними барами 0.9
        public decimal categoryPercentage { get; set; }         // Заполнение пространства для малых наборов данных 0.8
        public int barThickness { get; set; }                   // Толщина набора в пикселях
        public int maxBarThickness { get; set; }                // ограничение по толщине
        public bool offsetGridLines { get; set; }               // если фалс то линия сетки будет проходить по середине бара
    }
}