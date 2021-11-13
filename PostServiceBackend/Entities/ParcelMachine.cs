using System.Collections.Generic;

namespace PostServiceBackend.Entities
{
    public class ParcelMachine
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
