var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policity =>
    {
        policity
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Endpoint de prueba inicial
app.MapGet("/", () =>
{
    return "API Sistema de Gestión de Tienda de Ropa funcionando";
});

// Endpoint para la información general de la empresa (Inicio)
app.MapGet("/api/empresa", () =>
{
    return Results.Ok(new
    {
        Nombre = "Urban Style - Tienda de Ropa",
        Descripcion = "Las mejores tendencias en moda urbana, ropa casual y accesorios de alta calidad.",
        Telefono = "+51 987 654 321",
        Ubicacion = "Av. Real 456, Huancayo",
        HorarioAtencion = "Lunes a Sábado de 09:00 AM a 09:00 PM"
    });
});

// Endpoint Recurso Principal: Catálogo de Productos (Ropa)
app.MapGet("/api/ropa", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID = 1,
            Nombre = "Polo Oversize Black",
            Categoria = "Polos",
            Marca = "Nike",
            Talla = "M",
            Precio = 89.90,
            Stock = 15,
            Descuento = 10,
            Imagen = "https://images.unsplash.com/photo-1521572267360-ee0c2909d518?w=500",
            Codigo = "POL-001",
            Genero = "Unisex",
            Color = "Negro",
            Material = "100% Algodón Reactivo",
            Temporada = "Verano",
            Descripcion = "Polo de corte holgado estilo urbano, tela fresca y suave al tacto."
        },
        new
        {
            ID = 2,
            Nombre = "Jean Slim Fit Denim",
            Categoria = "Pantalones",
            Marca = "Adidas",
            Talla = "30",
            Precio = 129.00,
            Stock = 10,
            Descuento = 0,
            Imagen = "https://images.unsplash.com/photo-1542272604-780c36856842?w=500",
            Codigo = "JEA-002",
            Genero = "Hombre",
            Color = "Azul Clásico",
            Material = "Denim Elastizado",
            Temporada = "Atemporal",
            Descripcion = "Jean entallado con alta flexibilidad para máxima comodidad durante todo el día."
        },
        new
        {
            ID = 3,
            Nombre = "Casaca Impermeable Urban",
            Categoria = "Casacas",
            Marca = "Puma",
            Talla = "L",
            Precio = 199.50,
            Stock = 8,
            Descuento = 20,
            Imagen = "https://images.unsplash.com/photo-1551028719-00167b16eac5?w=500",
            Codigo = "CAS-003",
            Genero = "Unisex",
            Color = "Rojo / Negro",
            Material = "Poliéster Repelente al Agua",
            Temporada = "Invierno",
            Descripcion = "Casaca acolchada térmica ideal para bajas temperaturas y días lluviosos."
        },
        new
        {
            ID = 4,
            Nombre = "Polera Hoodie Streetwear",
            Categoria = "Poleras",
            Marca = "Nike",
            Talla = "S",
            Precio = 149.90,
            Stock = 12,
            Descuento = 15,
            Imagen = "https://images.unsplash.com/photo-1556905055-8f358a7a47b2?w=500",
            Codigo = "POL-004",
            Genero = "Mujer",
            Color = "Blanco",
            Material = "Algodón Perchado",
            Temporada = "Otoño / Invierno",
            Descripcion = "Polera con capucha con bolsillo canguro frontal y diseño moderno."
        }
    });
});

// Endpoint Recurso 2: Categorías de ropa
app.MapGet("/api/categorias", () =>
{
    return Results.Ok(new[]
    {
        new { ID = 1, Nombre = "Polos", Descripcion = "Polos urbanos, casuales y de vestir" },
        new { ID = 2, Nombre = "Pantalones", Descripcion = "Jeans, joggers y pantalones de vestir" },
        new { ID = 3, Nombre = "Casacas", Descripcion = "Casacas impermeables, cortavientos y casacas de cuero" },
        new { ID = 4, Nombre = "Poleras", Descripcion = "Poleras con capucha y poleras cerradas" }
    });
});

// Endpoint Recurso 3: Marcas disponibles
app.MapGet("/api/marcas", () =>
{
    return Results.Ok(new[]
    {
        new { ID = 1, Nombre = "Nike", PaisOrigen = "EE.UU." },
        new { ID = 2, Nombre = "Adidas", PaisOrigen = "Alemania" },
        new { ID = 3, Nombre = "Puma", PaisOrigen = "Alemania" }
    });
});

// Endpoint Recurso 4: Promociones activas
app.MapGet("/api/promociones", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID = 1,
            Titulo = "Descuento de Temporada",
            Descripcion = "Hasta 20% OFF en casacas e indumentaria de invierno.",
            CodigoDescuento = "INVIERNO20"
        },
        new
        {
            ID = 2,
            Titulo = "Envío Gratis",
            Descripcion = "Por compras superiores a S/ 200 a todo Huancayo.",
            CodigoDescuento = "ENVIOGRATIS"
        }
    });
});

var port = Environment.GetEnvironmentVariable("Port") ?? "10000";

app.Run();