using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Genero = new ML.Genero();
            libro.Editorial = new ML.Editorial();

            ML.Result result = new ML.Result();
            ML.Result resultAutores = new ML.Result();
            ML.Result resultGenero = new ML.Result();
            ML.Result resultEditorial = new ML.Result();

            resultAutores = BL.Autor.GetAll();
            resultEditorial = BL.Editorial.GetAll();
            resultGenero = BL.Genero.GetAll();

            result = BL.Libro.GetAllEF();
            if (result.Correct == true)
            {
                libro.Libros = result.Objects;
                libro.Autor.Autores = resultAutores.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
            }
            else
            {
                ViewBag.Message = "OCURRIO UN ERROR INESPERADO: " + result.ErrorMessage;
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Genero = new ML.Genero();
            libro.Editorial = new ML.Editorial();

            ML.Result result = new ML.Result();
            ML.Result resultAutores = new ML.Result();
            ML.Result resultGenero = new ML.Result();
            ML.Result resultEditorial = new ML.Result();

            resultAutores = BL.Autor.GetAll();
            resultEditorial = BL.Editorial.GetAll();
            resultGenero = BL.Genero.GetAll();

            if (IdLibro == null)
            {
                libro.Autor.Autores = resultAutores.Objects;
                libro.Genero.Generos = resultGenero.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                return View(libro);
            }
            else
            {
                libro.IdLibro = IdLibro.Value;
                result = BL.Libro.GetByIdEF(libro);
                if (result.Correct == true)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.Autores = resultAutores.Objects;
                    libro.Genero.Generos = resultGenero.Objects;
                    libro.Editorial.Editoriales = resultEditorial.Objects;
                }
                else
                {
                    ViewBag.Message = "OCURRIO UN ERROR INESPERADO: " + result.ErrorMessage;
                }
            }

            return View(libro);
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            if (libro.IdLibro == 0)
            {
                result = BL.Libro.AddEF(libro);
                if (result.Correct == true)
                {
                    ViewBag.Message = "El Libro Fue Registrado Con Exito";
                }
                else
                {
                    ViewBag.Message = "El Libro NO Fue Registrado Con Exito";
                }
            }
            else
            {
                result = BL.Libro.UpdateEF(libro);
                if (result.Correct == true)
                {
                    ViewBag.Message = "El Libro Fue Actualizado Con Exito";
                }
                else
                {
                    ViewBag.Message = "El Libro NO Fue Actualizado Con Exito";
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            ML.Libro libro = new ML.Libro();
            if (IdLibro == 0)
            {
                ViewBag.Message = "Error Ocurrido Al ELiminar";
            }
            else
            {
                libro.IdLibro = IdLibro;
                result = BL.Libro.DeleteEF(libro);
                if (result.Correct == true)
                {
                    ViewBag.Message = "El Libro Fue Eliminado Con Exito";
                }
                else
                {
                    ViewBag.Message = "El Libro NO Fue Eliminado Con Exito";
                }
            }
            return PartialView("Modal");
        }


    }
}