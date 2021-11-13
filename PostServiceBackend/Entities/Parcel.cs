namespace PostServiceBackend.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public int? ParcelMachineId { get; set; }
    }
}
