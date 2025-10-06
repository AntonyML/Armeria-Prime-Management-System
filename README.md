# Sistema de Gestión de Armería - ProyectoFinalPROG3

Sistema de gestión empresarial desarrollado en **C# .NET Framework 4.7.2** con **Windows Forms** para el manejo integral de una armería. El sistema permite la administración de inventario, clientes, proveedores, facturación y control de usuarios.

## 📋 Descripción

Este proyecto implementa un sistema completo de gestión para armería "Armería Prime", incluyendo:

- **Gestión de Inventario**: Control completo de artículos, líneas, marcas y unidades
- **Gestión de Clientes**: Administración de base de datos de clientes
- **Gestión de Proveedores**: Control de proveedores y sus productos
- **Sistema de Facturación**: Generación de cotizaciones y facturas
- **Control de Usuarios**: Sistema de autenticación y autorización
- **Auditoría**: Registro de actividades del sistema
- **Entrada/Salida de Inventario**: Control de movimientos de stock

## 🏗️ Arquitectura del Sistema

```
ProyectoFinalPROG3/
├── Buscadores/              # Formularios de búsqueda
│   ├── Busca_Articulo.cs
│   ├── Busca_Cliente.cs
│   ├── Busca_Facturador.cs
│   ├── Busca_Linea.cs
│   ├── Busca_Marca.cs
│   ├── Busca_Proveedor.cs
│   ├── Busca_Unidad.cs
│   └── Busca_Vendedor.cs
├── Clases/                  # Lógica de negocio
│   └── dbconeccion.cs
├── Properties/              # Configuración del proyecto
│   └── AssemblyInfo.cs
├── bin/                     # Archivos ejecutables (ignorado por git)
├── obj/                     # Archivos temporales (ignorado por git)
├── 1_login.cs              # Formulario de login principal
├── articulos.cs            # Gestión de artículos
├── clientes.cs             # Gestión de clientes
├── Cotizacion.cs           # Sistema de cotizaciones
├── Entrada_Salida.cs       # Control de inventario
├── facturador.cs           # Sistema de facturación
├── App.config              # Configuración de la aplicación
└── [Otros formularios...]
```

## 🖥️ Tecnologías Utilizadas

- **.NET Framework 4.7.2** - Plataforma de desarrollo
- **C#** - Lenguaje de programación principal
- **Windows Forms** - Interfaz gráfica de usuario
- **PostgreSQL** - Base de datos principal
- **Npgsql** - Conector para PostgreSQL
- **MaterialSkin** - UI Framework para diseño moderno
- **Visual Studio** - IDE de desarrollo

## 📊 Base de Datos

El sistema utiliza **PostgreSQL** como motor de base de datos principal:

- **Base de datos**: `armeria prime`
- **Puerto**: 5432 (por defecto)
- **Servidor**: localhost

### Tablas principales:
- `usuarios` - Control de acceso al sistema
- `articulos` - Inventario de productos
- `clientes` - Base de datos de clientes
- `proveedores` - Gestión de proveedores
- `facturas` - Registro de ventas
- `cotizaciones` - Cotizaciones generadas
- `auditoria` - Log de actividades del sistema

## 🚀 Instalación

### Prerrequisitos

1. **Microsoft Visual Studio 2017** o superior
2. **.NET Framework 4.7.2** o superior
3. **PostgreSQL 12** o superior
4. **Windows 10/11** o Windows Server

### Pasos de instalación

1. **Clonar el repositorio:**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd ProyectoFinalPROG3
   ```

2. **Configurar PostgreSQL:**
   - Instalar PostgreSQL
   - Crear base de datos `armeria prime`
   - Restaurar backup desde `Base de datos/`
   - Configurar usuario `postgres` con contraseña

3. **Configurar cadena de conexión:**
   ```csharp
   // En el archivo de conexión, actualizar:
   Server=localhost; Port=5432; User Id=postgres; Password=TU_PASSWORD; Database=armeria prime
   ```

4. **Abrir el proyecto:**
   - Abrir `ProyectoFinalPROG3.sln` en Visual Studio
   - Restaurar paquetes NuGet automáticamente
   - Compilar el proyecto

5. **Ejecutar la aplicación:**
   - Presionar F5 o hacer clic en "Iniciar"

## 💻 Uso del Sistema

### Inicio de Sesión

1. Ejecutar la aplicación
2. Ingresar usuario y contraseña válidos
3. El sistema validará contra la base de datos PostgreSQL

### Módulos Principales

#### 📦 Gestión de Artículos
- **Artículos**: CRUD completo de productos
- **Líneas**: Clasificación por líneas de productos
- **Marcas**: Gestión de marcas
- **Unidades**: Control de unidades de medida
- **Proveedores**: Artículos por proveedor

#### 👥 Gestión de Clientes
- Registro completo de clientes
- Búsqueda avanzada
- Historial de transacciones

#### 💼 Sistema de Ventas
- **Cotizaciones**: Generar cotizaciones
- **Facturas**: Emisión de facturas
- **Control de inventario**: Entrada y salida

#### 🔍 Búsquedas
El sistema incluye buscadores especializados para:
- Artículos (con filtros avanzados)
- Clientes
- Proveedores
- Vendedores
- Líneas y marcas

## 🔧 Configuración

### Base de Datos

La configuración de base de datos se encuentra en los archivos de conexión. Para cambiar la configuración:

```csharp
// Ejemplo de cadena de conexión
string connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=tu_password; Database=armeria prime";
```

### Dependencias

El proyecto utiliza las siguientes dependencias NuGet:
- `Npgsql` - Conector PostgreSQL
- `MaterialSkin` - Componentes de UI

## 📝 Características Principales

### ✅ Funcionalidades Implementadas

- [x] Sistema de autenticación de usuarios
- [x] Gestión completa de inventario
- [x] Administración de clientes y proveedores
- [x] Sistema de cotizaciones
- [x] Facturación
- [x] Control de entrada/salida de productos
- [x] Búsquedas avanzadas
- [x] Interfaz moderna con MaterialSkin
- [x] Auditoría del sistema

### 🔄 Funcionalidades Futuras

- [ ] Reportes avanzados
- [ ] Backup automático
- [ ] Integración con sistemas de pago
- [ ] API REST para integración externa
- [ ] Versión web

## 🛠️ Desarrollo

### Estructura del Código

El proyecto sigue patrones de desarrollo de Windows Forms:

- **Formularios principales**: Interfaz de usuario
- **Clases de negocio**: Lógica de la aplicación
- **Conexión a BD**: Gestión de datos
- **Buscadores**: Formularios especializados de búsqueda

### Contribuir al Proyecto

1. Fork del repositorio
2. Crear rama para nueva funcionalidad
3. Implementar cambios con pruebas
4. Commit con mensajes descriptivos
5. Pull Request para revisión

## 📋 Requisitos del Sistema

### Mínimos
- **OS**: Windows 10
- **RAM**: 4 GB
- **Procesador**: Intel Core i3 o equivalente
- **.NET**: Framework 4.7.2
- **Base de Datos**: PostgreSQL 12+

### Recomendados
- **OS**: Windows 11
- **RAM**: 8 GB o más
- **Procesador**: Intel Core i5 o superior
- **SSD**: Para mejor rendimiento
- **Base de Datos**: PostgreSQL 14+

## 🐛 Solución de Problemas

### Error de Conexión a BD
```
Verificar:
- PostgreSQL está ejecutándose
- Base de datos 'armeria prime' existe
- Credenciales correctas
- Puerto 5432 disponible
```

### Error de Dependencias
```
En Visual Studio:
- Tools > NuGet Package Manager > Package Manager Console
- Execute: Update-Package -reinstall
```

### Error de .NET Framework
```
- Verificar versión instalada de .NET Framework
- Instalar .NET Framework 4.7.2 o superior
```

## 📄 Licencia


## 👥 Equipo de Desarrollo

- **Desarrollador Principal**: Antony Monge López


## 📞 Soporte

Para soporte técnico o preguntas sobre el proyecto:
- **Email**: ANTONY.MONGELOPEZ@ucr.ac.cr

---
