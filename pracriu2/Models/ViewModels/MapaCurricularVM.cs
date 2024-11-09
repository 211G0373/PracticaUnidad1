namespace pracriu2.Models.ViewModels
{
    public class MapaCurricularVM
    {
        public string? Nombre { get; set; }
        public string? Plan { get; set; }
        public uint Creditos { get; set; }
        public byte Semestres { get; set; }
        public IEnumerable<Materias>? Materias { get; set; }
    }
}
