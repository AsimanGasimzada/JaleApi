using Jale_Xanm.Models;
using Jale_Xanm.Repositories.Interfaces;
using Jale_Xanm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jale_Xanm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService _service;
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentService service, IStudentRepository studentRepository)
        {
            _service = service;
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _service.GetAllAsync();

            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _service.CreateAsync(student);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]Student student)
        {
            await _service.UpdateAsync(student);
            return Ok();
        }
    }
}
