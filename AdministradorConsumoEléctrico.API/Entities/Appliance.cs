namespace AdministradorConsumoEléctrico.API.Entities
{
    public class Appliance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PowerWatts { get; set; } // potencia consumida en vatios
        public string Category { get; set; } // Categoría del electrodoméstico (e.g., cocina, entretenimiento, etc.)
        public DateTime CreatedAt { get; set; } // Fecha y hora de creación del electrodoméstico
        public DateTime UpdatedAt { get; set; } // Fecha y hora de la última actualización del electrodoméstico

        public virtual ICollection<MonthlyConsumption> ConsumosMensuales { get; set; }
    }
}
