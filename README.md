# PlataformaStreaming

API desarrollada con ASP.NET Core .NET 10, Entity Framework Core y PostgreSQL.

## Integrantes y tablas trabajadas

| Integrante | Tabla |
| --- | --- |
| Marco Antonio Arias Girón | `Usuarios` |
| Emanuel Rafael Kilibarda Rocha | `Videos` |
| Abraham Andres Valeriano Mamani | `Categorias` |

## Cómo ejecutar el proyecto

Requisitos: Docker y Docker Compose.

1. Desde la raíz del proyecto, crea el archivo local de variables de entorno:

   ```bash
   cp .env.example .env
   ```

2. En `.env`, cambia `POSTGRES_PASSWORD` por una contraseña propia.
3. Construye y levanta la API y PostgreSQL:

   ```bash
   docker compose --env-file .env -f contructor.yml up -d --build
   ```

4. Comprueba el estado de los servicios:

   ```bash
   docker compose --env-file .env -f contructor.yml ps
   ```

La documentación interactiva de la API queda disponible en <http://localhost:8085/scalar/v1>.

Para detener los servicios:

```bash
docker compose --env-file .env -f contructor.yml down
```

`.env` contiene configuración local y no se debe publicar. El archivo `.gitignore` lo excluye del repositorio.
