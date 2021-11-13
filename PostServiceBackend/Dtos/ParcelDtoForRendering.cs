namespace PostServiceBackend.Dtos
{
    public class ParcelDtoForRendering
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public int? ParcelMachineId { get; set; }
        public string ParcelMachineCode { get; set; }
    }
}
