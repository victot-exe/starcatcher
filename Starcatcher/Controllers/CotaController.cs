using Microsoft.AspNetCore.Mvc;
using Starcatcher.Services;
using Starcatcher.DTOs;

namespace Starcatcher.Controllers
{
    [ApiController]
    [Route("cotas")]
    public class CotaController : ControllerBase//TODO trocar os retornos para IActionResult
    {
        private readonly CotaService _service;

        public CotaController(CotaService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }

        [HttpPost]
        public CotaDTOExit Post(CotaDTOEntry cota)//TODO trocar os retornos para IActionResult
        {
            return _service.Create(cota);
        }

        [HttpGet]
        public List<CotaDTOExit> GetAllCotas()//TODO trocar os retornos para IActionResult
        {
            return _service.GetAll();
        }

        [HttpGet]
        public CotaDTOExit GetCotaById(int id)//TODO trocar os retornos para IActionResult
        {
            return _service.GetById(id);
        }

        [HttpPut]
        public CotaDTOExit UpdateCota(int id, CotaDTOEntry cotaOld)//TODO trocar os retornos para IActionResult
        {
            return _service.Update(id, cotaOld);
        }

        [HttpDelete]
        public void DeleteCota(int id)//TODO trocar os retornos para IActionResult
        {
            _service.Delete(id);
        }


    }
}