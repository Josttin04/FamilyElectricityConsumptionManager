namespace AdministradorConsumoEléctrico.API.Entities
{
    public class MonthlyConsumption
    {
        public int Id { get; set; }

        public int ApplianceId { get; set; }
        public virtual Appliance Appliance { get; set; }

        public int Mes { get; set; }
        public int Año { get; set; }

        public double HorasUsoPorDía { get; set; }
        public double DiasUso { get; set; }

        public double ConsumoTotalKWh { get; set; }
        public double CostoEstimado { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relación uno a muchos con consumo mensual

    }
}
