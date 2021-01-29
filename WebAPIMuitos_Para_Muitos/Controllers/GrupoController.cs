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
    public class GrupoController : ControllerBase
    {
        private readonly IWebApiRepository _repo;

        public GrupoController(IWebApiRepository repo)
        {
            _repo = repo;
        }

        //Get api/GrupoController
        [HttpGet]
        public async Task<IActionResult> GetGrupos()
        {
            try
            {
                var results = await _repo.GetGrupos();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //Get api/GrupoController/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGrupoId(int Id)
        {
            try
            {
                var results = await _repo.GetGrupoId(Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
        }

        //Post api/GrupoController
        [HttpPost]
        public async Task<IActionResult> Post(Grupo model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChagesAsync())
                {
                    return Created($"api/Grupo/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //Put api/GrupoController/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Grupo model)
        {
            try
            {
                var results = await _repo.GetGrupoId(Id);
                if (results == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChagesAsync())
                {
                    return Created($"/api/Grupo/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Sistema ! {ex.Message}");
            }
            return BadRequest();
        }

        //Delete api/GrupoController/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var results = await _repo.GetGrupoId(Id);
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
