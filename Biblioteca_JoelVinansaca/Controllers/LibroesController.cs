using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_JoelVinansaca.Context;
using Biblioteca_JoelVinansaca.Models;
using Biblioteca_JoelVinansaca.DTO;

namespace Biblioteca_JoelVinansaca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroesController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LibroesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibrosDTO>>> GetLibros()
        {
            var result = await _context.Libros.ToListAsync();
            return convierteaDTOLibros(result);
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibrosDTO>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return convierteaDTOLibro(libro);
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, LibrosDTO libro)
        {
            var response = transformaDTOaLibro(libro);
            if (id != response.IdLibros)
            {
                return BadRequest();
            }

            _context.Entry(response).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(LibrosDTO libro)
        {
            var response = transformaDTOaLibro(libro);
            _context.Libros.Add(response);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibroExists(libro.IdLibros))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibro", new { id = libro.IdLibros }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private ActionResult<IEnumerable<LibrosDTO>> convierteaDTOLibros(List<Libro> list)
        {
            List<LibrosDTO> result = new List<LibrosDTO>();
            for (int i = 0; i < list.Count; i++)
            {
                LibrosDTO obj = new LibrosDTO();
                var item = list[i];
                obj.IdLibros = item.IdLibros;
                obj.Nombre = item.Nombre;
                obj.IdCategoria = item.IdCategoria;
                obj.IdAutor = item.IdAutor;
                obj.IdEditorial = item.IdEditorial;
                result.Add(obj);
            }
            return result;
        }

        private LibrosDTO convierteaDTOLibro(Libro libro)
        {
            LibrosDTO obj = new LibrosDTO
            {
                IdLibros = libro.IdLibros,
                Nombre = libro.Nombre,
                IdCategoria = libro.IdCategoria,
                IdAutor = libro.IdAutor,
                IdEditorial = libro.IdEditorial,
            };
            return obj;
        }

        private Libro transformaDTOaLibro(LibrosDTO libro)
        {
            Libro obj = new Libro();
            obj.IdLibros = libro.IdLibros;
            obj.Nombre = libro.Nombre;
            obj.IdCategoria = libro.IdCategoria;
            obj.IdAutor = libro.IdAutor;
            obj.IdEditorial = libro.IdEditorial;
            obj.Estado = "A";

            return obj;
        }
        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibros == id);
        }
    }
}
