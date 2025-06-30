namespace AdministradorConsumoEléctrico.API.Dtos
{
    public class UpdateApplianceDto
    {
        public int Id { get; set; }                  // ID del electrodoméstico a modificar
        public string Name { get; set; }             // Nombre actualizado
        public double PowerWatts { get; set; }       // Potencia actualizada
        public string Category { get; set; }         // Categoría actualizada
    }
}
