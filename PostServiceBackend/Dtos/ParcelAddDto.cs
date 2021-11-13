namespace PostServiceBackend.Dtos
{
    public class ParcelAddDto
    {
        public decimal Weight { get; set; }
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public int? ParcelMachineId { get; set; }
    }
}
