using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDL2_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        _dbContext _db = new _dbContext();

        [HttpGet]
        public IActionResult ListarTodo()
        {
            //select * from persona
            return Ok(_db.Personas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            //select * from persona where id = {id}
            return Ok(_db.Personas.Find(id));
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Persona request )
        {
            //insert  into personas (declaro todos los campos) ==> ingreso todos los valores
            _db.Personas.Add(request);
            _db.SaveChanges();
            return Ok(request);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Persona request)
        {
            //update persona set nombre = request.nombre, apellido_paterno = request.ApellidoPaterno where id = request.id
            _db.Personas.Update(request);
            _db.SaveChanges();
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int rowAfected = 0;
            Persona Per = _db.Personas.Find(id);

            if (Per != null)
            {
                _db.Personas.Remove(Per);
                rowAfected = _db.SaveChanges();
            }

            return Ok($"Numero de Registro Eliminado {rowAfected}");
        }


    }
}
