using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IDbService _service;
        public  StudentsController(IDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
           if(orderBy == "lastname"){
                return Ok(_service.GetStudents().OrderBy(s => s.LastName));
            }
            return Ok(_service.GetStudents());

            //var s = HttpContext.Request;
            //return $"Alllas, Anna sortowanie={orderBy}";
            // var service = new MockDbService();
        }


        [HttpGet("{id:int}")]
        public IActionResult GetStundet(int id)
        {
            if(id == 1)
            {
                return Ok("Kowalski");
            }else if(id ==2)
            {
                return Ok("Malewski");
            }
            return NotFound("Not found");
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 2000)}";

            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Ąktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }
}