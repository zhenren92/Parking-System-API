using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_System_API.Interface_Repository;
using Parking_System_API.Interfaces;
using Parking_System_API.Models;

namespace Parking_System_API.Models_Action
{
    public class Aktifitas_Parkir_Action : IAktifitas_Parkir
    {        
        public async Task<object> Buat_Aktifitas(Aktifitas_Parkir aktifitas_Parkir, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                Repository_Parkir.Daftar_Aktifitas_Parkir.Add(aktifitas_Parkir);
                obj = aktifitas_Parkir;
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Keluar(int Nomor_Slot, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Aktifitas_Parkir.Exists(x => x.Slot_Parkir.Nomor_Slot == Nomor_Slot) == true)
                {
                    object Temp_parkir = await new Ruangan_Parkir_Action().Kendaraan_Keluar(Nomor_Slot, Repository_Parkir);

                    if (Temp_parkir.GetType() == typeof(Slot_Parkir))
                    {
                        Aktifitas_Parkir item = Repository_Parkir.Daftar_Aktifitas_Parkir.Find(x => x.Slot_Parkir.Nomor_Slot == Nomor_Slot);

                        item.Waktu_Keluar = DateTime.Now;
                        item.Slot_Parkir.Status_Slot = false;
                        item.Lama_Parkir = item.Waktu_Keluar - item.Waktu_Masuk;

                        obj = new Message_Object {Message = "Kendaraan sudah keluar pada slot parkir " + Nomor_Slot};                            

                        if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count == 0)
                        {
                            obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                        }
                    }
                    else
                    {
                        obj = Temp_parkir;
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Aktifitas kendaraan masuk tidak ditemukan untuk slot parkir " + Nomor_Slot};
                }

                if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count == 0)
                {
                    obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Masuk(Kendaraan kendaraan, Repository_Parkir Repository_Parkir)
        {
            object obj = new object() ;

            try
            {
                object Temp_parkir = await new Ruangan_Parkir_Action().Kendaraan_Masuk(kendaraan, Repository_Parkir);

                if (Temp_parkir.GetType() == typeof(Slot_Parkir))
                {
                    int No_Aktifitas = Repository_Parkir.Daftar_Aktifitas_Parkir.Count;
                    Slot_Parkir Slot_Parkir = Temp_parkir as Slot_Parkir;

                    Aktifitas_Parkir Temp_Aktifitas = new Aktifitas_Parkir()
                                                        {
                                                            No_Aktifitas = No_Aktifitas ,
                                                            Waktu_Masuk = DateTime.Now,
                                                            Slot_Parkir = new Slot_Parkir 
                                                            {
                                                                Kendaraan = new Kendaraan 
                                                                {
                                                                    No_Polisi = Slot_Parkir.Kendaraan.No_Polisi ,
                                                                    Warna = Slot_Parkir.Kendaraan.Warna
                                                                } ,
                                                                Nomor_Slot = Slot_Parkir.Nomor_Slot ,
                                                                Status_Slot = Slot_Parkir.Status_Slot                                                                
                                                            }
                                                        };

                    Repository_Parkir.Daftar_Aktifitas_Parkir.Add(Temp_Aktifitas);
                    obj = Temp_Aktifitas;
                }
                else
                {
                    obj = Temp_parkir;
                }        

                // if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count == 0)
                // {
                //     obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                // }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Tampil_Aktifitas_Kendaraan_Keluar(Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count != 0)
                {
                    if (Repository_Parkir.Daftar_Aktifitas_Parkir.Exists(x => (x.Waktu_Masuk != DateTime.MinValue) && (x.Waktu_Keluar != DateTime.MinValue)) == true)
                    {
                        obj = Repository_Parkir.Daftar_Aktifitas_Parkir.FindAll(x => (x.Waktu_Masuk != DateTime.MinValue) && (x.Waktu_Keluar != DateTime.MinValue));
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Tampil_Aktifitas_Kendaraan_Masuk(Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count != 0)
                {
                    if (Repository_Parkir.Daftar_Aktifitas_Parkir.Exists(x => x.Waktu_Masuk != DateTime.MinValue) == true)
                    {
                        obj = Repository_Parkir.Daftar_Aktifitas_Parkir.FindAll(x => (x.Waktu_Masuk != DateTime.MinValue) && (x.Waktu_Keluar == DateTime.MinValue));
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Tampil_Aktifitas_Kendaraan_Masuk_Keluar(Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Aktifitas_Parkir.Count != 0)
                {
                    obj = Repository_Parkir.Daftar_Aktifitas_Parkir;
                }
                else
                {
                    obj = new Message_Object {Message = "Tidak ada aktifitas kendaraan sama sekali"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }
    }
}