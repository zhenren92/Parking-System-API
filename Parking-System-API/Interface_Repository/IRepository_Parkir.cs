using System.Collections.Generic;
using Parking_System_API.Models;

namespace Parking_System_API.Interface_Repository
{
    public interface IRepository_Parkir
    {
        List<Aktifitas_Parkir> Daftar_Aktifitas_Parkir {set; get;}
        List<Ruangan_Parkir> Daftar_Ruangan_Parkir {set; get;}        
    }
}