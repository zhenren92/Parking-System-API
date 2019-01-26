using System;

namespace Parking_System_API.Models
{
    public class Aktifitas_Parkir
    {
        public int No_Aktifitas { get; set; }
        public Slot_Parkir Slot_Parkir { get; set; }
        public DateTime Waktu_Masuk { get; set; }
        public DateTime Waktu_Keluar { get; set; }
        public TimeSpan Lama_Parkir { get; set; }
    }
}