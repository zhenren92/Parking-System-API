using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_System_API.Models;

namespace Parking_System_API.Interfaces
{
    public interface IAktifitas_Parkir
    {
        Task<object> Buat_Aktifitas(Aktifitas_Parkir aktifitas_Parkir, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Masuk(Kendaraan kendaraan, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Keluar(int Nomor_Slot, Repository_Parkir Repository_Parkir);
        Task<object> Tampil_Aktifitas_Kendaraan_Masuk_Keluar(Repository_Parkir Repository_Parkir);
        Task<object> Tampil_Aktifitas_Kendaraan_Masuk(Repository_Parkir Repository_Parkir);
        Task<object> Tampil_Aktifitas_Kendaraan_Keluar(Repository_Parkir Repository_Parkir);
    }
}