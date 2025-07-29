using Microsoft.AspNetCore.Mvc;
using Starcatcher.Services;
using Starcatcher.DTOs;
using Starcatcher.Contracts;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cotas")]
    public class CotaController : ControllerBase//TODO trocar os retornos para IActionResult
    {
        private readonly IService<CotaDTOExit, CotaDTOEntry, int> _service;

        public CotaController(IService<CotaDTOExit, CotaDTOEntry, int> service)
        {
            _service = service;
        }

        [HttpGet("hello")]
        public string Hello()
        {
            return "Hello World!";
        }

        [HttpPost]
        public CotaDTOExit Post([FromBody] CotaDTOEntry cota)//TODO trocar os retornos para IActionResult
        {
            return _service.Create(cota);
        }

        [HttpGet]
        public List<CotaDTOExit> GetAllCotas()//TODO trocar os retornos para IActionResult
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public CotaDTOExit GetCotaById(int id)//TODO trocar os retornos para IActionResult
        {
            return _service.GetById(id);
        }

        [HttpPut("{id}")]
        public CotaDTOExit UpdateCota(int id,[FromBody] CotaDTOEntry cotaOld)//TODO trocar os retornos para IActionResult
        {
            return _service.Update(id, cotaOld);
        }

        [HttpDelete("{id}")]
        public void DeleteCota(int id)//TODO trocar os retornos para IActionResult
        {
            _service.Delete(id);
        }
    }
}