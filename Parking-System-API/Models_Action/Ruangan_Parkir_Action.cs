using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_System_API.Interface_Repository;
using Parking_System_API.Interfaces;
using Parking_System_API.Models;

namespace Parking_System_API.Models_Action
{
    public class Ruangan_Parkir_Action : IRuangan_Parkir
    {
        public async Task<object> Buat_Ruangan_Parkir(int Banyak_Slot, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                List<Slot_Parkir> Temp_Slot = new List<Slot_Parkir>();                

                int Baris_Ruangan = ((Repository_Parkir.Daftar_Ruangan_Parkir != null) ? Repository_Parkir.Daftar_Ruangan_Parkir.Count : 0)  + 1;

                for (int i = 1 * Baris_Ruangan; i <= Banyak_Slot * Baris_Ruangan; i++)
                {
                    Temp_Slot.Add(new Slot_Parkir() 
                                {
                                    Nomor_Slot = i, 
                                    Status_Slot = false
                                }
                                );
                }

                if (Repository_Parkir.Daftar_Ruangan_Parkir == null)
                {
                    Repository_Parkir.Daftar_Ruangan_Parkir = new List<Ruangan_Parkir>();
                }

                Repository_Parkir.Daftar_Ruangan_Parkir.Add(new Ruangan_Parkir 
                                                                {
                                                                    Banyak_Slot = Banyak_Slot ,
                                                                    Baris_Ruangan = Baris_Ruangan ,
                                                                    Daftar_Slot = Temp_Slot
                                                                }
                                                            );

                obj = new Message_Object {Message = "Berhasil membuat "+ Banyak_Slot +" slot pada baris ruangan parkir ke " + Baris_Ruangan};
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Keluar(int No_Slot, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                foreach (var item in Repository_Parkir.Daftar_Ruangan_Parkir)
                {
                    if (item.Daftar_Slot.Exists(x => (x.Nomor_Slot == No_Slot) && (x.Status_Slot == true)))
                    {
                        item.Daftar_Slot.Find(x => x.Nomor_Slot == No_Slot).Kendaraan = null;
                        item.Daftar_Slot.Find(x => x.Nomor_Slot == No_Slot).Status_Slot = false;

                        obj = item.Daftar_Slot.Find(x => x.Nomor_Slot == No_Slot);

                        break;
                    }
                    else
                    {
                        obj = new Message_Object {Message = "Tidak ada kendaraan pada slot parkir nomor " + No_Slot};
                    }
                }

                if (Repository_Parkir.Daftar_Ruangan_Parkir.Count == 0)
                {
                    obj = new Message_Object {Message = "Ruangan parkir belum ada sama sekali, harap dibuat terlebih dahulu"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Masuk(Kendaraan kendaraaan, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                bool Status_Add = false;

                if (kendaraaan != null)
                {
                    if ((kendaraaan.No_Polisi == null) || (kendaraaan.Warna == null))
                    {
                        obj = new Message_Object {Message = "Kendaraan yang akan masuk tidak memiliki data yang lengkap"};
                        return obj;
                    }
                }

                foreach (var item in Repository_Parkir.Daftar_Ruangan_Parkir)
                {
                    if (item.Daftar_Slot.Exists(x => (x.Kendaraan != null)))
                    {
                        if (item.Daftar_Slot.Exists(x => (x.Kendaraan != null) && (x.Kendaraan.No_Polisi == kendaraaan.No_Polisi)))
                        {
                            obj = new Message_Object {Message = "Kendaraan dengan no polisi " + kendaraaan.No_Polisi + " masih ada dalam parkir"};
                            break;
                        }
                    }

                    if (item.Daftar_Slot.Exists(x => (x.Status_Slot == false)))
                    {
                        item.Daftar_Slot.Find(x => x.Status_Slot == false).Kendaraan = kendaraaan;
                        item.Daftar_Slot.Find(x => x.Status_Slot == false).Status_Slot = true;

                        obj = item.Daftar_Slot.Find(x => x.Kendaraan.No_Polisi == kendaraaan.No_Polisi);
                        Status_Add = true;
                        break;
                    }
                }      

                if (Repository_Parkir.Daftar_Ruangan_Parkir.Count != 0)
                {
                    if (Status_Add == false)
                    {
                        if (Repository_Parkir.Daftar_Ruangan_Parkir.FindAll(x => x.Daftar_Slot.Exists(y => y.Status_Slot == false) == true).Count == 0)
                        {
                            obj = new Message_Object {Message = "Semua Ruangan parkir sudah penuh, kendaraan tidak bisa masuk."};   
                        }
                    }                  
                }
                else
                {
                    obj = new Message_Object {Message = "Ruangan parkir belum ada sama sekali, harap dibuat terlebih dahulu."};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Parkir_Berdasarkan_No_Polisi(string No_Polisi, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Ruangan_Parkir.Count != 0)
                {
                    bool Status_Find = false;

                    foreach (var item in Repository_Parkir.Daftar_Ruangan_Parkir)
                    {
                        if (item.Daftar_Slot.Exists(x => x.Kendaraan != null))
                        {
                            if (item.Daftar_Slot.Exists(x => (x.Kendaraan != null) && (x.Kendaraan.No_Polisi == No_Polisi)))
                            {
                                obj = item.Daftar_Slot.Find(x => x.Kendaraan.No_Polisi.ToLower() == No_Polisi.ToLower());
                                Status_Find = true;
                                break;
                            }                            
                        }
                    }

                    if (Status_Find == false)
                    {
                        obj = new Message_Object {Message = "Kendaraan parkir berdasarkan nomor polisi " + No_Polisi + " tidak ditemukan pada slot parkir."};
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Ruangan parkir belum ada sama sekali, harap dibuat terlebih dahulu"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Kendaraan_Parkir_Berdasarkan_Warna(string warna, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Ruangan_Parkir.Count != 0)
                {
                    List<Slot_Parkir> obj_temp = new List<Slot_Parkir>();

                    foreach (var item in Repository_Parkir.Daftar_Ruangan_Parkir)
                    {
                        if (item.Daftar_Slot.Exists(x => x.Kendaraan != null) == true)
                        {
                            if (item.Daftar_Slot.Exists(x => (x.Kendaraan != null) && (x.Kendaraan.Warna == warna)) == true)
                            {
                                obj_temp.Add(item.Daftar_Slot.Find(x => (x.Kendaraan != null) && (x.Kendaraan.Warna.ToLower() == warna.ToLower())));
                            }
                        }
                    }

                    if (obj_temp.Count != 0)
                    {
                        obj = obj_temp;
                    }
                    else
                    {
                        obj = new Message_Object {Message = "Kendaraan berdasarkan warna " + warna + " tidak ditemukan"};
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Ruangan parkir belum ada sama sekali, harap dibuat terlebih dahulu"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Status_Ruangan_Parkir(Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                obj = Repository_Parkir.Daftar_Ruangan_Parkir;
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Status_Ruangan_Parkir(int Baris_Ruangan, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Ruangan_Parkir.Count != 0)
                {
                    if (Repository_Parkir.Daftar_Ruangan_Parkir.Exists(x => x.Baris_Ruangan == Baris_Ruangan) == true)
                    {
                        obj = Repository_Parkir.Daftar_Ruangan_Parkir.FindAll(x => x.Baris_Ruangan == Baris_Ruangan);
                    }
                    else
                    {
                        obj = new Message_Object {Message = "Baris ruangan " + Baris_Ruangan + " yang anda masukaan tidak ditemukan"};
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Ruangan parkir belum ada sama sekali, harap dibuat terlebih dahulu"};
                }
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return obj;
        }

        public async Task<object> Status_Ruangan_Parkir(int Baris_Ruangan, int Nomor_Slot, Repository_Parkir Repository_Parkir)
        {
            object obj = new object();

            try
            {
                if (Repository_Parkir.Daftar_Ruangan_Parkir.Exists(x => x.Baris_Ruangan == Baris_Ruangan) == true)
                {
                    List<Ruangan_Parkir> obj_temp = new List<Ruangan_Parkir>();

                    foreach (var item in Repository_Parkir.Daftar_Ruangan_Parkir.FindAll(x => x.Baris_Ruangan == Baris_Ruangan))
                    {
                        if (item.Daftar_Slot.Exists(x => (x.Nomor_Slot == Nomor_Slot)) == true)
                        {
                            Ruangan_Parkir Temp_Item = new Ruangan_Parkir() 
                                                        {
                                                            Daftar_Slot = item.Daftar_Slot,
                                                            Banyak_Slot = item.Banyak_Slot ,
                                                            Baris_Ruangan = item.Baris_Ruangan
                                                        };
                            Temp_Item.Daftar_Slot = Temp_Item.Daftar_Slot.FindAll(x => x.Nomor_Slot == Nomor_Slot);

                            obj_temp.Add(Temp_Item);
                        }
                    }

                    if (obj_temp.Count != 0)
                    {
                        obj = obj_temp;
                    }
                    else
                    {
                        obj = new Message_Object {Message = "Baris ruangan " + Baris_Ruangan + " dan nomor slot "+ Nomor_Slot +" yang anda masukaan tidak ditemukan"};
                    }
                }
                else
                {
                    obj = new Message_Object {Message = "Baris ruangan " + Baris_Ruangan + " yang anda masukaan tidak ditemukan"};
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