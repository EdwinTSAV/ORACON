using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oracon.Models;
using Oracon.Repositorio;
using Oracon.Servicios;
using System.Diagnostics;

namespace Oracon.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoRepo context;
        private readonly IClaimService claim;
        public CursoController(ICursoRepo context, IClaimService claim)
        {
            this.context = context;
            this.claim = claim;
        }

        [HttpGet]
        public IActionResult Cursos()
        {
            ViewBag.Nombre = "Cursos";
            var cursos = context.GetCursos();
            return View(cursos);
        }

        [HttpGet]
        public IActionResult Detalle(int idCurso)
        {
            var curso = context.GetCurso(idCurso);
            if (curso !=null)
            {
                ViewBag.Nombre = curso.Nombre;
                return View(curso);
            }
            return RedirectToAction("Error", "Curso");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Comentario(int idCurso, string Comentario)
        {
            var curso = context.GetCurso(idCurso);
            if (User.Identity.IsAuthenticated)
            {
                claim.SetHttpContext(HttpContext);
                if (Comentario != null)
                {
                    context.SaveComentario(claim.GetLoggedUser().Id, idCurso, Comentario);
                }
            }
            ViewBag.Nombre = curso.Nombre;
            return View("Detalle", curso);
        }

        [HttpGet]
        public IActionResult Desarrollo(int idCurso)
        {
            var curso = context.GetCurso(idCurso);
            if (curso != null)
            {
                ViewBag.Nombre = curso.Nombre;
                return View(curso);
            }
            return RedirectToAction("Error", "Curso");
        }

        [HttpGet]
        public IActionResult Video(int idClase)
        {
            var video = context.GetClases(idClase);
            return Json(video);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
