using System.Collections.Generic;

namespace Parking_System_API.Models
{
    public class Ruangan_Parkir
    {
        public int Baris_Ruangan { get; set; }
        public int Banyak_Slot  {get;set;}
        public List<Slot_Parkir> Daftar_Slot { get; set; }
    }
}