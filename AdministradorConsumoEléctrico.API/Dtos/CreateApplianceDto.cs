namespace AdministradorConsumoEléctrico.API.Dtos
{
    public class CreateApplianceDto
    {
        public string Name { get; set; }             // Nombre del electrodoméstico
        public double PowerWatts { get; set; }       // Potencia en vatios (W)
        public string Category { get; set; }         // Categoría (ej. Cocina, Sala, etc.)
    }
}
