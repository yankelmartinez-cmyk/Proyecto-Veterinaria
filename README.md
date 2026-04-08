# Proyecto-POO-Veterinaria
Proyecto Final - Grupo 5 - Sistema de Veterinaria

# Documentación API Veterinaria

## Base URL 
- Desarrollo HTTP: `http://localhost:5156`
- Desarrollo HTTPS: `https://localhost:7044`

## Recursos
- `/api/Clientes`
- `/api/Mascotas`
- `/api/Citas`
- `/api/Veterinarios`
- `/api/TiposMascota`

## Modelos
### Cliente
```json
{
  "id": 1,
  "nombre": "Daniel",
  "apellido": "Vasquez",
  "telefono": "9999-9999",
  "correo": "daniel@example.com",
  "direccion": "Tegucigalpa",
  "activo": true,
  "fechaCreacion": "2025-04-08T10:00:00"
}
```

### Mascota
```json
{
  "id": 1,
  "nombre": "Firulais",
  "fechaNacimiento": "2022-05-10T00:00:00",
  "idCliente": 1,
  "idTipoMascota": 1,
  "activo": true,
  "fechaCreacion": "2025-04-08T10:00:00"
}
```

### Cita
```json
{
  "id": 1,
  "fechaHora": "2025-04-10T10:30:00",
  "motivo": "Vacunacion",
  "diagnostico": null,
  "idMascota": 1,
  "idVeterinario": 1,
  "activo": true,
  "fechaCreacion": "2025-04-08T10:00:00"
}
```

### Veterinario
```json
{
  "id": 1,
  "nombre": "Ana",
  "apellido": "Lopez",
  "especialidad": "Cirugia",
  "telefono": "9876-5432",
  "activo": true,
  "fechaCreacion": "2025-04-08T10:00:00"
}
```

### TipoMascota
```json
{
  "id": 1,
  "nombre": "Perro",
  "descripcion": "Canino domestico",
  "activo": true,
  "fechaCreacion": "2025-04-08T10:00:00"
}
```

## Endpoints
Cada recurso tiene:
- `GET /api/<Recurso>`
- `GET /api/<Recurso>/{id}`
- `POST /api/<Recurso>`
- `PUT /api/<Recurso>/{id}`
- `DELETE /api/<Recurso>/{id}`


