namespace PostServiceBackend.Dtos
{
    public class ParcelMachineGetDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public int FreeSpaces { get; set; }
    }
}
