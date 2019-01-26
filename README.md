# Parking-System-API

# Requirement Development :

- Visual Studio Code (IDE) : Optional
  (Link : https://code.visualstudio.com/download)
  
- .NET Core 2.0 SDK x64 / x86

  (Link x64 : https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.0.0-windows-x64-binaries) | Required
  
  (Link x86 : https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.0.0-windows-x86-binaries)
  
# Requirement Runtime :
 
- .NET Core 2.0 Runtime x64 / x86

  (Link x64 : https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.0.0-windows-x64-binaries)

  (Link x86 : https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-2.0.0-windows-x86-binaries)
  
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
- Masuk ke lokasi folder yang didalamnya memiliki file "Parking-System-API.csproj", contoh di "D:\\Parking-System-API\" dengan cara mengetik "cd D:\\Parking-System-API\" dan kemudian ketik "D:\\"

- 1). ketikkan "dotnet restore" pada "Command Prompt" atau "cmd.exe"
- 2). ketikkan "dotnet build" pada "Command Prompt" atau "cmd.exe"
- 3). ketikkan "dotnet run" pada "Command Prompt" atau "cmd.exe"
- Maka hasilnya akan menampilkan output seperti ini :

  Now listening on: http://localhost:5000

  Application started. Press Ctrl+C to shut down.
  
- Jika sudah berhasil, maka "API" yang akan digunakan sudah bisa digunakan.

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
  - URL : http://localhost:5000/api/parkir/Kendaraan_Keluar/{No_Slot_Parkir}
  - URL (Contoh) : http://localhost:5000/api/parkir/Kendaraan_Keluar/1
  
 2). Method GET
-
- 
