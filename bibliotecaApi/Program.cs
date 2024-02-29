using bibliotecaApi;
using bibliotecaApi.Modelo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<bibliotecaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("local")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseCors("cors");




///////ENPOINTS CATEGORIAS///////
app.MapGet("/API/v1/listarCategoria/{filtro}/", async (string filtro, bibliotecaContext db) =>
{
    //var filtroRequest = await request.ReadFromJsonAsync<Filtro>();
    //string filtro = filtroRequest.filtro;
    if (filtro=="all")
        return await db.categoria.ToListAsync();
    else
        return await db.categoria.Where(e => e.descripcion.ToLower().Contains(filtro)).ToListAsync();
});
app.MapGet("/API/v1/CategoriaById/{idCategoria}", async (int idCategoria, bibliotecaContext db) => db.categoria.FindAsync(idCategoria));

app.MapPost("/API/v1/agregarCategoria/", async (NuevaCategoria cat, bibliotecaContext db) =>
{
    Categoria categoria = new Categoria();
    categoria.descripcion = cat.descripcion;
    categoria.tiempoRegistro = DateTime.Now;
    categoria.activo = true;


    db.categoria.Add(categoria);
    await db.SaveChangesAsync();
    return Results.Ok(categoria.idCategoria);
});

app.MapPut("/API/v1/editarCategoria/{idCategoria}", async (int idCategoria, NuevaCategoria categoriaBody, bibliotecaContext db) =>
{
    var resultado = await db.categoria.FindAsync(idCategoria);
    if (resultado is null) return Results.NotFound();
    resultado.descripcion = categoriaBody.descripcion;
    resultado.tiempoModificacion = DateTime.Now;
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.MapPut("/API/v1/eliminarCategoria/{idCategoria}/{estado}", async (int idCategoria, bool estado, bibliotecaContext db) =>
{
    var resultado = await db.categoria.FindAsync(idCategoria);
    if (resultado is null) return Results.NotFound();
    resultado.activo = estado;
    resultado.tiempoModificacion = DateTime.Now;
    await db.SaveChangesAsync();
    return Results.NoContent();

});

///////ENPOINTS LIBROS///////

app.MapGet("/API/v1/{filtro}/", async (string filtro, bibliotecaContext db) =>
{

    if (filtro == "all")
        return await db.libro.ToListAsync();
    else
        return await db.libro.Where(e => e.titulo.ToLower().Contains(filtro)).ToListAsync();
});
app.MapGet("/API/v1/libroById/{idLibro}", async (int idCategoria, bibliotecaContext db) => db.categoria.FindAsync(idCategoria));

app.MapPost("/API/v1/agregarLibro/", async (NuevoLibro li, bibliotecaContext db) =>
{
    Libro libro = new Libro();
    libro.titulo = li.titulo;
    libro.categoriaId.idCategoria = li.categoriaId;
    libro.tiempoRegistro = DateTime.Now;
    libro.activo = true;


    db.libro.Add(libro);
    await db.SaveChangesAsync();
    return Results.Ok(libro.idLibro);
});

app.MapPut("/API/v1/editarLibro/{idLibro}", async (int idLibro, Libro categoriaBody, bibliotecaContext db) =>
{
    var resultado = await db.libro
    .FindAsync(idLibro);
    if (resultado is null) return Results.NotFound();
    resultado.titulo = categoriaBody.titulo;
    resultado.categoriaId= categoriaBody.categoriaId;
    resultado.tiempoModificacion = DateTime.Now;
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.MapPut("/API/v1/eliminarLibro/{idLibro}/{estado}", async (int idLibro, bool estado, bibliotecaContext db) =>
{
    var resultado = await db.libro.FindAsync(idLibro);
    if (resultado is null) return Results.NotFound();
    resultado.activo = estado;
    resultado.tiempoModificacion = DateTime.Now;
    await db.SaveChangesAsync();
    return Results.NoContent();

});


app.Run();
