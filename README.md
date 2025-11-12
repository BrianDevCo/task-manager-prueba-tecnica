# 📋 Task Manager - Gestor Personal de Tareas

Aplicación fullstack .NET 8 para gestión de tareas personales desarrollada como prueba técnica.

## 🎯 Estado del Proyecto

**Nota importante:** Este proyecto fue desarrollado como parte de una prueba técnica con tiempo limitado. La estructura base, arquitectura y componentes principales están implementados siguiendo las mejores prácticas de .NET. 

**Mi compromiso:** Aunque no pude completar todos los detalles en el tiempo asignado, tengo los conocimientos técnicos necesarios y me encantaría tener la oportunidad de finalizar este proyecto y demostrar mis capacidades en un entorno real, sin importar las condiciones. Estoy muy motivado para aprender, crecer y contribuir al equipo.

## 🚀 Características Implementadas

### ✅ Completado
- ✅ Arquitectura en capas (API, Blazor, Core, Tests)
- ✅ Modelos y DTOs con validaciones
- ✅ Repository Pattern implementado
- ✅ Service Layer con inyección de dependencias
- ✅ AutoMapper configurado
- ✅ Entity Framework Core con SQL Server LocalDB
- ✅ API REST con endpoints CRUD
- ✅ Componentes Blazor base
- ✅ Configuración de HttpClient
- ✅ Swagger/OpenAPI documentación
- ✅ Estructura de testing preparada

### 🚧 En Progreso / Pendiente
- 🔄 Integración completa frontend-backend
- 🔄 UI/UX final con Bootstrap
- 🔄 Validaciones frontend completas
- 🔄 Manejo de errores en UI
- 🔄 Testing unitario completo
- 🔄 Dockerización
- 🔄 CI/CD pipeline

## 🛠️ Stack Tecnológico

- **Backend:** .NET 8 Web API (C#)
- **Frontend:** Blazor Server
- **Base de Datos:** SQL Server LocalDB con Entity Framework Core
- **Testing:** xUnit, Moq, FluentAssertions (estructura preparada)
- **Containerización:** Docker & Docker Compose (pendiente)
- **CI/CD:** GitHub Actions (pendiente)

## 📋 Requisitos Previos

- .NET 8 SDK
- Visual Studio 2022 Community (o superior)
- SQL Server LocalDB (incluido con Visual Studio)
- Git (para clonar el repositorio)

## 🏃 Ejecución Local

### Opción 1: Visual Studio (Recomendado)

1. **Clona el repositorio:**
   ```bash
   git clone <url-del-repositorio>
   cd TaskManager
   ```

2. **Abre la solución:**
   - Abre `TaskManager.slnx` en Visual Studio 2022

3. **Restaura paquetes NuGet:**
   - Click derecho en la solución → `Restaurar paquetes NuGet`
   - O ejecuta: `dotnet restore`

4. **Configura la base de datos:**
   - La connection string ya está configurada en `TaskManager/appsettings.json`
   - Ejecuta las migraciones:
   ```powershell
   cd TaskManager
   dotnet ef database update --project ..\TaskManager.Core\TaskManager.Core.csproj
   ```

5. **Ejecuta la aplicación:**
   - Establece múltiples proyectos de inicio:
     - Click derecho en la solución → `Propiedades`
     - `Proyectos de inicio múltiples`
     - Marca `TaskManager` (API) y `TaskManager.Blazor` como `Iniciar`
   - Presiona `F5` o click en `Ejecutar`

6. **Accede a la aplicación:**
   - **API Swagger:** https://localhost:7001/swagger
   - **Blazor App:** https://localhost:5002

### Opción 2: Línea de Comandos

```bash
# Restaurar dependencias
dotnet restore

# Ejecutar migraciones
cd TaskManager
dotnet ef database update --project ..\TaskManager.Core\TaskManager.Core.csproj
cd ..

# Ejecutar API (en una terminal)
cd TaskManager
dotnet run

# Ejecutar Blazor (en otra terminal)
cd TaskManager.Blazor
dotnet run
```

## 📡 API Endpoints

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/tasks` | Obtener todas las tareas |
| GET | `/api/tasks?isCompleted=true` | Filtrar por estado |
| GET | `/api/tasks/{id}` | Obtener tarea por ID |
| POST | `/api/tasks` | Crear nueva tarea |
| PUT | `/api/tasks/{id}` | Actualizar tarea |
| PUT | `/api/tasks/{id}/complete` | Marcar como completada |
| DELETE | `/api/tasks/{id}` | Eliminar tarea |

### Ejemplo de Request (POST /api/tasks)

```json
{
  "title": "Completar prueba técnica",
  "description": "Finalizar desarrollo de Task Manager"
}
```

### Ejemplo de Response

```json
{
  "id": 1,
  "title": "Completar prueba técnica",
  "description": "Finalizar desarrollo de Task Manager",
  "isCompleted": false,
  "createdAt": "2024-01-15T10:30:00Z",
  "completedAt": null
}
```

## 🏗️ Arquitectura

```
TaskManager/
├── TaskManager/              # Web API REST
│   ├── Controllers/          # Controladores API
│   │   └── TaskController.cs
│   ├── Program.cs            # Configuración y DI
│   └── appsettings.json      # Configuración
│
├── TaskManager.Blazor/       # Frontend Blazor Server
│   ├── Pages/                # Componentes y páginas
│   │   ├── Index.cshtml
│   │   ├── TaskList.razor
│   │   ├── TaskItem.razor
│   │   └── TaskForm.razor
│   ├── Services/             # Servicios HTTP
│   │   └── TaskService.cs
│   └── Program.cs            # Configuración
│
├── TaskManager.Core/         # Lógica de negocio compartida
│   ├── Models/               # Entidades
│   │   └── Task.cs
│   ├── DTOs/                 # Data Transfer Objects
│   │   ├── TaskDto.cs
│   │   ├── CreateTaskDto.cs
│   │   └── UpdateTaskDto.cs
│   ├── Repositories/         # Patrón Repository
│   │   ├── ITaskRepository.cs
│   │   └── TaskRepository.cs
│   ├── Services/             # Servicios de negocio
│   │   ├── ITaskService.cs
│   │   └── TaskService.cs
│   ├── Data/                 # DbContext
│   │   └── TaskDbContext.cs
│   └── Mappings/             # AutoMapper Profiles
│       └── TaskMappingProfile.cs
│
└── TaskManager.Tests/        # Pruebas unitarias
    └── UnitTest1.cs
```

## 🧪 Testing

```bash
# Ejecutar todos los tests
dotnet test

# Ejecutar tests con detalle
dotnet test --verbosity normal

# Ejecutar tests de un proyecto específico
cd TaskManager.Tests
dotnet test
```

## 📝 Decisiones Técnicas

### Arquitectura
- **Separación en capas:** API, Blazor, Core y Tests en proyectos separados
- **Repository Pattern:** Abstracción de acceso a datos para testabilidad
- **Service Layer:** Lógica de negocio encapsulada y reutilizable
- **DTOs:** Separación entre entidades de dominio y datos transferidos

### Tecnologías
- **Blazor Server:** Elegido por su simplicidad y tiempo real con SignalR
- **SQL Server LocalDB:** Incluido con Visual Studio, perfecto para desarrollo
- **AutoMapper:** Mapeo automático entre entidades y DTOs
- **Entity Framework Core:** ORM para acceso a datos con Code First
- **xUnit:** Framework de testing estándar en .NET

### Patrones y Principios
- **SOLID Principles:** Aplicados en toda la arquitectura
- **Dependency Injection:** Configurado en Program.cs
- **Async/Await:** Todas las operaciones de I/O son asíncronas
- **Clean Code:** Nombres descriptivos, funciones pequeñas, responsabilidades claras

## 🔧 Configuración

### Connection String

La connection string está en `TaskManager/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

### CORS

CORS está configurado en `TaskManager/Program.cs` para permitir peticiones desde Blazor:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("https://localhost:5002", "http://localhost:5002")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
```

## 🚀 Próximos Pasos (Roadmap)

1. **Completar integración frontend-backend**
   - Finalizar componentes Blazor
   - Implementar manejo de errores en UI
   - Agregar estados de carga

2. **Mejorar UI/UX**
   - Completar estilos con Bootstrap
   - Agregar animaciones y transiciones
   - Mejorar responsive design

3. **Testing completo**
   - Aumentar cobertura de tests unitarios
   - Agregar tests de integración
   - Tests end-to-end

4. **DevOps**
   - Dockerizar la aplicación
   - Configurar CI/CD con GitHub Actions
   - Documentación de despliegue

5. **Funcionalidades adicionales**
   - Filtros y búsqueda avanzada
   - Categorías de tareas
   - Prioridades
   - Fechas de vencimiento

## 💡 Sobre el Desarrollo

Este proyecto fue desarrollado siguiendo las mejores prácticas de .NET y arquitectura de software. Aunque el tiempo fue limitado, la estructura base está diseñada para ser escalable y mantenible.

**Mi enfoque:**
- Código limpio y bien estructurado
- Arquitectura que facilita el testing
- Separación clara de responsabilidades
- Documentación y comentarios donde es necesario

**Mi motivación:**
Estoy muy interesado en continuar desarrollando este proyecto y demostrar mis capacidades técnicas. Tengo experiencia en .NET, C#, Entity Framework, y estoy siempre dispuesto a aprender nuevas tecnologías y mejores prácticas.

## 📞 Contacto

Si tienes preguntas sobre el proyecto o quieres discutir oportunidades, estaré encantado de conversar.

---

## 📄 Licencia

Este proyecto fue desarrollado como parte de una prueba técnica.

---

**Desarrollado con pasión por la programación y las mejores prácticas de desarrollo de software.** 🚀


