using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIMuitos_Para_MuitosDomain.Models;
using WebApiMuitos_ParaMuitosRepository;

namespace WebAPIMuitos_Para_Muitos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IWebApiRepository _repo;

        public UsuarioController(IWebApiRepository repo)
        {
            _repo = repo;
        }

        //Get api/UsuarioController
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var results = await _repo.GetUsuarios();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //Get api/UsuarioController/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsuarioId(int Id)
        {
            try
            {
                var results = await _repo.GetUsuarioId(Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //Post api/UsuarioController
        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChagesAsync())
                {
                    return Created($"api/Usuario/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //Put api/UsuarioController/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Usuario model)
        {
            try
            {
                var results = await _repo.GetUsuarioId(Id);
                if (results == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChagesAsync())
                {
                    return Created($"/api/Usuario/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //Delete api/UsuarioController/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var results = await _repo.GetUsuarioId(Id);
                if (results == null) return NotFound();

                _repo.Delete(results);

                if (await _repo.SaveChagesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }
    }
}
