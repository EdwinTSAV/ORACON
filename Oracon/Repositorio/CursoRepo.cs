using Microsoft.EntityFrameworkCore;
using Oracon.Maps;
using Oracon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Oracon.Repositorio
{
    public interface ICursoRepo
    {
        List<Curso> GetCursos();
        Curso GetCurso(int idCurso);
        Clases GetClases(int idClase);
        void SaveComentario(int idUsuario, int idCurso, string Comentario);
    }
    public class CursoRepo : ICursoRepo
    {
        private readonly Oracon_Context context;
        public CursoRepo(Oracon_Context context)
        {
            this.context = context;
        }

        public List<Curso> GetCursos()
        {
            return context.Cursos.
                Include(o => o.Docente).
                Include(o => o.Categoria).
                ToList();
        }

        public Curso GetCurso(int idCurso)
        {
            context.Modulos.Include(o => o.Clases).ToList();
            context.Usuarios.ToList();
            return context.Cursos.
                Where(o => o.Id == idCurso).
                Include(o => o.Docente).
                Include(o => o.Aprendizajes).
                Include(o => o.Categoria).
                Include(o => o.Modulos).
                Include(o => o.Comentarios).
                FirstOrDefault();
        }

        public void SaveComentario(int idUsuario, int idCurso, string Comentario)
        {
            ComentarioCurso comentario = new ComentarioCurso();
            comentario.IdCurso = idCurso;
            comentario.IdUsuario = idUsuario;
            comentario.Comentario = Comentario;
            context.Add(comentario);
            context.SaveChanges();
        }

        public Clases GetClases(int idClase)
        {
            return context.Clases.Where(o => o.Id == idClase).
                Include(o => o.Recursos).
                FirstOrDefault();
        }
    }
}
