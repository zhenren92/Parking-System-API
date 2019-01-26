namespace Parking_System_API.Models
{
    public class Slot_Parkir
    {
        public int Nomor_Slot { get; set; }
        public Kendaraan Kendaraan { get; set; }
        public bool Status_Slot { get; set; }
    }
}