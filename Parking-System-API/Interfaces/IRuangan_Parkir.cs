using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_System_API.Interface_Repository;
using Parking_System_API.Models;

namespace Parking_System_API.Interfaces
{
    public interface IRuangan_Parkir
    {
        Task<object> Buat_Ruangan_Parkir(int Banyak_Slot, Repository_Parkir Repository_Parkir);
        Task<object> Status_Ruangan_Parkir(Repository_Parkir Repository_Parkir);
        Task<object> Status_Ruangan_Parkir(int Baris_Ruangan, Repository_Parkir Repository_Parkir);
        Task<object> Status_Ruangan_Parkir(int Baris_Ruangan, int Nomor_Slot, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Parkir_Berdasarkan_Warna(string warna, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Parkir_Berdasarkan_No_Polisi(string No_Polisi, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Masuk(Kendaraan kendaraaan, Repository_Parkir Repository_Parkir);
        Task<object> Kendaraan_Keluar(int No_Slot, Repository_Parkir Repository_Parkir);
    }
}