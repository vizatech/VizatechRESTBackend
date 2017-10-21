namespace BusinessLayerLibrary.ViewModelsRepository
{
    public class Location
    {
        public long Id { get; set; }

        public string Building { get; set; }      // Здание
        public string Street { get; set; }        // Улица, квартал
        public string State { get; set; }         // Штат или область
        public string City { get; set; }          // Город
        public string Country { get; set; }       // Страна расположения

        public string Description { get; set; } // Текстовое описание места расположения

        public string PositionX { get; set; }   // Координата по широте
        public string PositionY { get; set; }   // Координата по долготе
        public string PositionZ { get; set; }   // Координата по высоте
    }
}
