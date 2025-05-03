
# API de Gestión de Usuarios

Este proyecto es una API REST desarrollada en **.NET 8** y C# con una arquitectura basada en:

- ✅ Arquitectura Limpia (Clean Architecture)
- ✅ DDD (Domain-Driven Design)
- ✅ Principios SOLID
- ✅ CQRS y MediatR
- ✅ Simulación de envío de correos
- ✅ Swagger UI para pruebas
- ✅ Persistencia en archivo plano `usuarios.json`

---

## 📁 Estructura del Proyecto

```
src/
│
├── API/                      # Proyecto WebAPI (punto de entrada)
│   └── Controllers/          # Controladores de la API
│   └── Program.cs
│
├── Application/             # Capa de Aplicación
│   ├── Commands/            # Comandos CQRS
│   ├── Queries/             # Consultas CQRS
│   ├── DTOs/                # Objetos de transferencia de datos
│   └── Interfaces/          # Interfaces de servicios (ej. IEmailService)
│   ├── Handlers/            # Manejadores CQRS de MediatR para comandos y consultas
│
├── Domain/                  # Capa de Dominio
│   ├── Entities/            # Entidades del dominio
│   └── Interfaces/          # Interfaces del repositorio
│
├── Infrastructure/          # Infraestructura
│   └── Repositories/        # Repositorio de usuarios basado en archivo JSON
│   └── Services/            # Servicio falso de envío de email
│   └── Persistence/usuarios.json
```

---

## ▶️ Requisitos Previos

- Visual Studio 2022 o superior
- .NET 8 SDK instalado
- MediatR (paquete `MediatR`)
- Swashbuckle.AspNetCore (para Swagger)

---

## 🚀 Instrucciones para Ejecutar

1. **Clona el repositorio o abre la solución en Visual Studio 2022.**

2. **Establece como proyecto de inicio**: `API`.

3. Asegúrate de que el archivo `usuarios.json` esté en la ruta:

   ```
   src/Infrastructure/Persistence/usuarios.json
   ```

   Ejemplo de contenido:
   ```json
   [
     {
       "id": "a3b2c1d0-e5f4-6789-abcd-ef1234567890",
       "nombre": "Juan Pérez",
       "email": "juan.perez@ejemplo.com"
     },
     {
       "id": "b2c3d4e5-f6a7-8901-bcde-fa2345678901",
       "nombre": "María Gómez",
       "email": "maria.gomez@ejemplo.com"
     }
   ]
   ```

4. **Ejecuta la solución** (Ctrl + F5 o botón "Start").

5. Abre tu navegador en:

   ```
   https://localhost:PORT/swagger
   ```

   > Reemplaza `PORT` con el puerto especificado en tu archivo `launchSettings.json`.

---

## 🛠️ Endpoints Disponibles

| Método | Ruta                | Descripción                          |
|--------|---------------------|--------------------------------------|
| GET    | /api/usuarios       | Obtener todos los usuarios           |
| GET    | /api/usuarios/{id}  | Obtener un usuario por ID (Pendiente)|
| POST   | /api/usuarios       | Crear un nuevo usuario               |
| PUT    | /api/usuarios/{id}  | Actualizar un usuario existente      |
| DELETE | /api/usuarios/{id}  | Eliminar un usuario existente        |

---

## 📧 Envío de Correo (Simulado)

Al crear un usuario, se simula el envío de un correo electrónico. Este comportamiento está implementado en `FakeEmailService` y solo se muestra en consola o logs.

---

## 🔐 Notas Técnicas

- Toda la lógica de negocio reside en `Application` y `Domain`.
- `Infrastructure` accede a `usuarios.json` y provee persistencia básica.
- Se utilizan `Handlers` para manejar comandos y consultas con MediatR.
- Swagger se habilita automáticamente en modo `Development` (https://localhost:7015/swagger).

---

## 📄 Licencia

MIT - Puedes usar este código para fines educativos o profesionales.

---
