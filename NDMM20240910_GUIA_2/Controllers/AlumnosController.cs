using NDMM20240910_GUIA_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NDMM20240910_GUIA_2.Controllers
{

    //Controlador de la api//

    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase

    {

        //Listar alumnos//

        static List<Alumno> alumnos = new List<Alumno>();


        //Obtener alumnos y retornarlos//

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        //Obtener id//

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            return alumno;
        }

        //Agregar alumno //

        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        //Verificar si el alumno existe por medio del id y si este no existe no retornar nada//

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                existingAlumno.Matricula = alumno.Matricula;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //Eliminar alumno por id// 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
