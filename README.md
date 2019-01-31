# Parking-System-API

# Requirement Development :

- Visual Studio Code (IDE) : Optional
  (Link : *[disini](https://code.visualstudio.com/download)*)
  
- [.NET Core 2.0 SDK (64-bit/32-bit) - (**Required**)](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.0-download.md)

  (Link ***[64-bit](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.0.0-windows-x64-binaries) Required***) atau 
  (Alternatif Link *[64-bit](https://download.microsoft.com/download/1/B/4/1B4DE605-8378-47A5-B01B-2C79D6C55519/dotnet-sdk-2.0.0-win-x64.zip)*)
  
  (Link *[32-bit](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.0.0-windows-x86-binaries)*) atau 
  (Alternatif Link *[32-bit](https://download.microsoft.com/download/1/B/4/1B4DE605-8378-47A5-B01B-2C79D6C55519/dotnet-sdk-2.0.0-win-x86.zip)*)
  
# Requirement Runtime :
 
- [.NET Core 2.0 Runtime (64-bit/32-bit)](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.0-download.md)

  (Link *[64-bit](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.0.0-windows-x64-binaries)*) atau 
  (Alternatif Link *[64-bit](https://download.microsoft.com/download/5/F/0/5F0362BD-7D0A-4A9D-9BF9-022C6B15B04D/dotnet-runtime-2.0.0-win-x64.zip)*)
  
  (Link *[32-bit](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.0.0-windows-x86-binaries)*) atau
  (Alternatif Link *[32-bit](https://download.microsoft.com/download/5/F/0/5F0362BD-7D0A-4A9D-9BF9-022C6B15B04D/dotnet-runtime-2.0.0-win-x86.zip)*)
    
# Setting Environment (Hanya untuk OS Windows) :
 
- Klik Kanan pada "My Computer" --> "Properties"
- Klik "Advanced system settings" --> Pilih "Tab Advanced" --> Klik "Environment Variables"
- Pilih "Path" pada "System variables" --> Tekan "Edit"
- Tambahkan "Lokasi folder" yang mengarah ke .NET Core 2.0 yang sudah di download sebelumnya, contoh 
lokasi folder "C:\\.NET Core\dotnet-sdk-2.0.0-win-x64;"
- Kemudian Tekan "Ok" sampai selesai.

# Uji coba .NET Core 2.0

- Buka "Command Prompt" atau "cmd.exe"
- Kemudian Ketik "dotnet --version", maka output yang akan ditampilkan adalah "2.0.0"

# Uji coba Project "Parking-System-API"

- Clone atau Download Project "Parking-System-API"
- Extract Project jika project di download berupa file ".zip", contoh di extract ke "D:\\Parking-System-API\"
- Buka "Command Prompt" atau "cmd.exe"
- Masuk ke lokasi folder yang didalamnya memiliki file "Parking-System-API.csproj", contoh di "D:\\Parking-System-API\" dengan cara mengetik "cd D:\\Parking-System-API\" dan kemudian ketik "D:"

- 1). ketikkan "dotnet restore" pada "Command Prompt" atau "cmd.exe"
- 2). ketikkan "dotnet build" pada "Command Prompt" atau "cmd.exe"
- 3). ketikkan "dotnet run" pada "Command Prompt" atau "cmd.exe"
- Maka hasilnya akan menampilkan output seperti ini :

  Now listening on: http://localhost:5000

  Application started. Press Ctrl+C to shut down.
  
- Jika sudah berhasil, maka "API" yang akan dijalankan sudah bisa digunakan.

# Service API yang disediakan

 1). Method POST
-
- Kendaraan Masuk : 
  -
  - URL : http://localhost:5000/api/parkir/Kendaraan_Masuk
  - JSON Body (Contoh) : 
{
	"no_Polisi": "BG 12345 CG" ,
	"warna": "Red"
}  
- Kendaraan Keluar : 
  -
  - URL : http://localhost:5000/api/parkir/Kendaraan_Keluar/{Parameter_No_Slot_Parkir}
  - URL (Contoh) : http://localhost:5000/api/parkir/Kendaraan_Keluar/1
  
 2). Method GET
-
- Buat Ruangan Parkir :
  -
  - URL : http://localhost:5000/api/parkir/Buat_Ruangan_Parkir?BanyakSlot={Parameter_Banyak_Slot}
  - URL (Contoh) : http://localhost:5000/api/parkir/Buat_Ruangan_Parkir?BanyakSlot=6
- Kendaraan Parkir Berdasarkan No Polisi :
  -
  - URL : http://localhost:5000/api/parkir/Kendaraan_Parkir_Berdasarkan_No_Polisi/{Warna}
  - URL (Contoh) : http://localhost:5000/api/parkir/Kendaraan_Parkir_Berdasarkan_No_Polisi/BG-12345-CC
- Kendaraan Parkir Berdasarkan Warna :
  -
  - URL : http://localhost:5000/api/parkir/Kendaraan_Parkir_Berdasarkan_Warna/{Parameter_No_Polisi}
  - URL (Contoh) : http://localhost:5000/api/parkir/Kendaraan_Parkir_Berdasarkan_Warna/Red
- Status Ruangan Parkir :
  -
  - URL : http://localhost:5000/api/parkir/Status_Ruangan_Parkir
- Status Ruangan Parkir Berdasarkan Baris Ruangan :
  -
  - URL : http://localhost:5000/api/parkir/Status_Ruangan_Parkir/{Parameter_Baris_Ruangan}
  - URL (Contoh) : http://localhost:5000/api/parkir/Status_Ruangan_Parkir/1
- Status Ruangan Parkir Berdasarkan Baris Ruangan dan Nomor Slot :
  -
  - URL : http://localhost:5000/api/parkir/Status_Ruangan_Parkir/{Parameter_Baris_Ruangan}/{Parameter_Nomor_Slot}
  - URL (Contoh) : http://localhost:5000/api/parkir/Status_Ruangan_Parkir/1/4
- Tampil Aktifitas Kendaraan Masuk :
  -
  - URL : http://localhost:5000/api/parkir/Tampil_Aktifitas_Kendaraan_Masuk
- Tampil Aktifitas Kendaraan Keluar :
  -
  - URL : http://localhost:5000/api/parkir/Tampil_Aktifitas_Kendaraan_Keluar
- Tampil Aktifitas Kendaraan Masuk dan Keluar :
  -
  - URL : http://localhost:5000/api/parkir/Tampil_Aktifitas_Kendaraan_Masuk_Keluar
