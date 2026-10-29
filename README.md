# ClaroTestBackend - API REST

Backend desarrollado en .NET 10 bajo los principios de Clean Architecture. Funciona como un servicio proxy desacoplado entre clientes frontend y la API externa.

---

## Requisitos Previos

* **SDK de .NET:** Version 10.0 o superior.
* **IDE / Editor:**
  * **Visual Studio 2026** con la carga de trabajo *ASP.NET y desarrollo web*. (.NET 10 no es compatible con Visual Studio 2022 ni versiones anteriores).
  * Opcionalmente: Visual Studio Code, JetBrains Rider o terminal con .NET CLI.

---

## Estructura de la Solucion

* `ClaroTestBackend.Core.Domain`: Entidades base y contratos de repositorio.
* `ClaroTestBackend.Core.Application`: Logica de aplicacion, DTOs y contratos de servicios.
* `ClaroTestBackend.Infrastructure.Persistence`: Implementacion de repositorios mediante clientes HTTP tipados hacia la API externa.
* `ClaroTestBackend.API`: Controladores Web API, configuracion de pipeline, CORS y OpenAPI.

---

## Configuracion

La URL base de la API externa se encuentra configurada en `ClaroTestBackend.API/appsettings.json`:

```json
{
  "ExternalApi": {
    "BaseUrl": "[https://fakerestapi.azurewebsites.net/](https://fakerestapi.azurewebsites.net/)"
  }
}
```

---

## Instrucciones de Ejecucion

### Opcion 1: Desde Visual Studio 2026

1. Abrir la solucion `ClaroTestBackend.sln` con Visual Studio 2026.
2. En el Explorador de Soluciones, hacer clic derecho sobre el proyecto `ClaroTestBackend.API` y seleccionar **Establecer como proyecto de inicio**.
3. En la barra de herramientas superior, seleccionar el perfil de ejecucion deseado (`https` o `http`).
4. Presionar `F5` (con depuracion) o `Ctrl + F5` (sin depuracion).
5. El servicio iniciara en los puertos configurados:
   * **HTTP:** `http://localhost:5228`
   * **HTTPS:** `https://localhost:7054`

---

### Opcion 2: Desde .NET CLI (Consola / Terminal)

1. Abrir una terminal en el directorio raiz de la solucion.
2. Restaurar dependencias del proyecto:
   ```bash
   dotnet restore
   ```
3. Compilar la solucion:
   ```bash
   dotnet build
   ```
4. Iniciar la Web API:
   ```bash
   dotnet run --launch-profile https --project ClaroTestBackend.API/ClaroTestBackend.API.csproj
   ```
5. La consola mostrara las rutas locales activas listas para recibir peticiones:
   * `http://localhost:5228`
   * `https://localhost:7054`

---

## Endpoints Disponibles

### Libros (Books)

| Metodo | Endpoint | Descripcion |
| :--- | :--- | :--- |
| `GET` | `/api/books` | Listar todos los libros |
| `GET` | `/api/books/{id}` | Obtener un libro por ID |
| `POST` | `/api/books` | Registrar un nuevo libro |
| `PUT` | `/api/books/{id}` | Actualizar un libro existente |
| `DELETE` | `/api/books/{id}` | Eliminar un libro |

### Autores (Authors)

| Metodo | Endpoint | Descripcion |
| :--- | :--- | :--- |
| `GET` | `/api/authors` | Listar todos los autores |
| `GET` | `/api/authors/{id}` | Obtener un autor por ID |
| `POST` | `/api/authors` | Registrar un nuevo autor |
| `PUT` | `/api/authors/{id}` | Actualizar un autor existente |
| `DELETE` | `/api/authors/{id}` | Eliminar un autor |

---

## Pruebas de Endpoints

Dentro del proyecto `ClaroTestBackend.API` se incluye el archivo `ClaroTestBackend.API.http` con ejemplos predefinidos para ejecutar y validar cada una de las operaciones CRUD directamente desde el editor de codigo.