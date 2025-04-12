# AdminUsuariosApi - Prueba Técnica

Este proyecto es una API en .NET 9 con Entity Framework Core para gestionar usuarios, departamentos y cargos.

## 🚀 Tecnologías

- .NET SDK **9.0.100**
- Node.js **v20.13.1**
- Entity Framework Core
- SQL Server
- React
- React Material (para los componentes de la interfaz)

## ⚙️ Pasos para ejecutar el proyecto

Asegúrate de reemplazar TU_SERVIDOR, TU_BASE_DE_DATOS, TU_USUARIO y TU_CONTRASEÑA con los valores correctos de tu servidor SQL Server.
En el archivo appsettings.json

```bash
# 1. Restaurar paquetes
dotnet restore

# 2. Generar migraciones si no existen
dotnet ef migrations add SeedData

# 3. Aplicar migraciones y poblar datos
dotnet ef database update

# 4. Ejecutar la API
dotnet run



# 1. Ir a la carpeta del frontend
cd AdminUsuariosFrontend

# 2. Instalar las dependencias
npm install

# 3. Ejecutar la aplicación en modo desarrollo
npm run dev





