using System.Collections.Generic;
using Parking_System_API.Interface_Repository;

namespace Parking_System_API.Models
{
    public class Repository_Parkir : IRepository_Parkir
    {
        public List<Aktifitas_Parkir> Daftar_Aktifitas_Parkir { get; set; }
        public List<Ruangan_Parkir> Daftar_Ruangan_Parkir { get; set; }
    }
}