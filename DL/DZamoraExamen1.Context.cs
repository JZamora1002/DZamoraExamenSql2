﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DZamoraExamenCrudSqlClientEntities : DbContext
    {
        public DZamoraExamenCrudSqlClientEntities()
            : base("name=DZamoraExamenCrudSqlClientEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
    
        public virtual ObjectResult<AutorGetAll_Result> AutorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutorGetAll_Result>("AutorGetAll");
        }
    
        public virtual ObjectResult<EditorialGetAll_Result> EditorialGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EditorialGetAll_Result>("EditorialGetAll");
        }
    
        public virtual ObjectResult<GeneroGetAll_Result> GeneroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GeneroGetAll_Result>("GeneroGetAll");
        }
    
        public virtual int LibroAdd(string nombre, Nullable<int> idAutor, Nullable<int> numeroPaginas, Nullable<System.DateTime> fechaPublicacion, Nullable<int> idEditorial, string edicion, Nullable<int> idGenero)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var edicionParameter = edicion != null ?
                new ObjectParameter("Edicion", edicion) :
                new ObjectParameter("Edicion", typeof(string));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", nombreParameter, idAutorParameter, numeroPaginasParameter, fechaPublicacionParameter, idEditorialParameter, edicionParameter, idGeneroParameter);
        }
    
        public virtual int LibroDelete(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDelete", idLibroParameter);
        }
    
        public virtual ObjectResult<LibroGetAll_Result> LibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAll_Result>("LibroGetAll");
        }
    
        public virtual ObjectResult<LibroGetById_Result> LibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetById_Result>("LibroGetById", idLibroParameter);
        }
    
        public virtual int LibroUpdate(Nullable<int> idLibro, string nombre, Nullable<int> idAutor, Nullable<int> numeroPaginas, Nullable<System.DateTime> fechaPublicacion, Nullable<int> idEditorial, string edicion, Nullable<int> idGenero)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var idEditorialParameter = idEditorial.HasValue ?
                new ObjectParameter("IdEditorial", idEditorial) :
                new ObjectParameter("IdEditorial", typeof(int));
    
            var edicionParameter = edicion != null ?
                new ObjectParameter("Edicion", edicion) :
                new ObjectParameter("Edicion", typeof(string));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroUpdate", idLibroParameter, nombreParameter, idAutorParameter, numeroPaginasParameter, fechaPublicacionParameter, idEditorialParameter, edicionParameter, idGeneroParameter);
        }
    }
}