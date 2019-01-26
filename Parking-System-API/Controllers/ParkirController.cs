using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Parking_System_API.Models;
using Parking_System_API.Models_Action;

namespace Parking_System_API.Controllers
{
    [Route("api/Parkir")]
    public class ParkirController : Controller
    {
        public readonly IOptions<Repository_Parkir> _Repository_Parkir;

        public ParkirController(IOptions<Repository_Parkir> Repository_Parkir)
        {
            if (Repository_Parkir.Value.Daftar_Aktifitas_Parkir == null)
            {
                Repository_Parkir.Value.Daftar_Aktifitas_Parkir = new List<Aktifitas_Parkir>();
            }

            if (Repository_Parkir.Value.Daftar_Ruangan_Parkir == null)
            {
                Repository_Parkir.Value.Daftar_Ruangan_Parkir = new List<Ruangan_Parkir>();
            }

            _Repository_Parkir = Repository_Parkir;
        }

        [HttpGet("Buat_Ruangan_Parkir")]
        public async Task<IActionResult> Buat_Ruangan_Parkir(int BanyakSlot)
        {
            object obj = new object();

            try
            {
                if (BanyakSlot != 0)
                {
                    obj = await new Ruangan_Parkir_Action().Buat_Ruangan_Parkir(BanyakSlot, _Repository_Parkir.Value);
                }   
                else
                {
                    obj = new Message_Object {Message = "Slot tidak boleh kosong"};
                }             
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);
        }
    
        [HttpPost("Kendaraan_Masuk")]
        public async Task<IActionResult> Kendaraan_Masuk([FromBody] Kendaraan kendaraaan)
        {
            object obj = new object();

            try
            {
                obj = await new Aktifitas_Parkir_Action().Kendaraan_Masuk(kendaraaan, _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpPost("Kendaraan_Keluar/{No_Slot}")]
        public async Task<IActionResult> Kendaraan_Keluar(int No_Slot)
        {
            object obj = new object();

            try
            {
                obj = await new Aktifitas_Parkir_Action().Kendaraan_Keluar(No_Slot, _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpGet("Kendaraan_Parkir_Berdasarkan_No_Polisi/{No_Polisi}")]
        public async Task<IActionResult> Kendaraan_Parkir_Berdasarkan_No_Polisi(string No_Polisi)
        {
            object obj = new object();

            try
            {
                obj = await new Ruangan_Parkir_Action().Kendaraan_Parkir_Berdasarkan_No_Polisi(No_Polisi, _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpGet("Kendaraan_Parkir_Berdasarkan_Warna/{warna}")]
        public async Task<IActionResult> Kendaraan_Parkir_Berdasarkan_Warna(string warna)
        {
            object obj = new object();

            try
            {
                obj = await new Ruangan_Parkir_Action().Kendaraan_Parkir_Berdasarkan_Warna(warna, _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpGet("Status_Ruangan_Parkir")]
        public async Task<IActionResult> Status_Ruangan_Parkir()
        {
            object obj = new object();

            try
            {
                obj = await new Ruangan_Parkir_Action().Status_Ruangan_Parkir(_Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);
        }

        [HttpGet("Status_Ruangan_Parkir/{Baris_Ruangan}")]
        public async Task<IActionResult> Status_Ruangan_Parkir(int Baris_Ruangan)
        {
            object obj = new object();

            try
            {
                obj = await new Ruangan_Parkir_Action().Status_Ruangan_Parkir(Baris_Ruangan , _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpGet("Status_Ruangan_Parkir/{Baris_Ruangan}/{Nomor_Slot}")]
        public async Task<IActionResult> Status_Ruangan_Parkir(int Baris_Ruangan, int Nomor_Slot)
        {
            object obj = new object();

            try
            {
                obj = await new Ruangan_Parkir_Action().Status_Ruangan_Parkir(Baris_Ruangan, Nomor_Slot , _Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }
    
        [HttpGet("Tampil_Aktifitas_Kendaraan_Keluar")]
        public async Task<IActionResult> Tampil_Aktifitas_Kendaraan_Keluar()
        {
            object obj = new object();

            try
            {
                obj = await new Aktifitas_Parkir_Action().Tampil_Aktifitas_Kendaraan_Keluar(_Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

        [HttpGet("Tampil_Aktifitas_Kendaraan_Masuk")]
        public async Task<IActionResult> Tampil_Aktifitas_Kendaraan_Masuk()
        {
            object obj = new object();

            try
            {
                obj = await new Aktifitas_Parkir_Action().Tampil_Aktifitas_Kendaraan_Masuk(_Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }

       [HttpGet("Tampil_Aktifitas_Kendaraan_Masuk_Keluar")]
        public async Task<IActionResult> Tampil_Aktifitas_Kendaraan_Masuk_Keluar()
        {
            object obj = new object();

            try
            {
                obj = await new Aktifitas_Parkir_Action().Tampil_Aktifitas_Kendaraan_Masuk_Keluar(_Repository_Parkir.Value);
            }
            catch (System.Exception ex)
            {                
                obj = new Message_Object {Message = ex.ToString()};
            }

            return Ok((obj == null) ? null : obj);     
        }
    }
}
