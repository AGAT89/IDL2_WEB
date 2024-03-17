using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDL2_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // Se crea una instancia de DbContext para interactuar con la base de datos
        _dbContext _db = new _dbContext();

        // Método HTTP GET para listar todas las personas
        [HttpGet]
        public IActionResult ListarTodo()
        {
            // Obtiene todas las personas de la base de datos y las devuelve como respuesta
            return Ok(_db.Personas.ToList());
        }

        // Método HTTP GET para obtener una persona por su ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            // Busca una persona por su ID en la base de datos y la devuelve como respuesta
            return Ok(_db.Personas.Find(id));
        }

        // Método HTTP POST para insertar una nueva persona
        [HttpPost]
        public IActionResult Insertar([FromBody] Persona request)
        {
            // Inserta una nueva persona en la base de datos y la devuelve como respuesta
            _db.Personas.Add(request);
            _db.SaveChanges();
            return Ok(request);
        }

        // Método HTTP PUT para actualizar una persona existente
        [HttpPut]
        public IActionResult Update([FromBody] Persona request)
        {
            // Actualiza la información de una persona en la base de datos y la devuelve como respuesta
            _db.Personas.Update(request);
            _db.SaveChanges();
            return Ok(request);
        }

        // Método HTTP DELETE para eliminar una persona por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Se inicializa el contador de filas afectadas
            int rowAfected = 0;
            // Se busca la persona por su ID en la base de datos
            Persona Per = _db.Personas.Find(id);

            // Si se encuentra la persona en la base de datos
            if (Per != null)
            {
                // Se elimina la persona de la base de datos
                _db.Personas.Remove(Per);
                // Se guarda el número de filas afectadas al realizar la eliminación
                rowAfected = _db.SaveChanges();
            }

            // Se devuelve un mensaje indicando el número de registros eliminados
            return Ok($"Numero de Registro Eliminado {rowAfected}");
        }
    }
}
