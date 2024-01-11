
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendWithFrontend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll () 
        {
            var result = await _context.Teachers.ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetById(int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x=>x.id==id);
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacher(TeacherDto teacher)
        {
            Teacher teacher1 = new Teacher() 
            { 
                phone = teacher.phone,
                specialization = teacher.specialization,
                address = teacher.address,
                dateOfBirth = teacher.dateOfBirth,
                dateOfRegister = teacher.dateOfRegister,
                description = teacher.description,
                email = teacher.email,
                name = teacher.name,
                telegramUserName = teacher.telegramUserName,
            };
            try
            {
                await _context.Teachers.AddAsync(teacher1);
                await _context.SaveChangesAsync();
                return Ok(teacher);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacher(TeacherDto teacher,int Id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.id == Id);

            result.phone = teacher.phone;
            result.specialization = teacher.specialization;
            result.address = teacher.address;
            result.dateOfBirth = teacher.dateOfBirth;
            result.dateOfRegister = teacher.dateOfRegister;
            result.description = teacher.description;
            result.email = teacher.email;
            result.name = teacher.name;
            result.telegramUserName = teacher.telegramUserName;
            
            try
            {
                _context.Teachers.Update(result);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(x => x.id == id);
            try
            {
                _context.Teachers.Remove(result);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
