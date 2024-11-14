using ASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly DevContext _devContext;

        public LoginAPIController(DevContext devContext)
        {
            this._devContext = devContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TblUser>>> GetUser()
        {
            var data = await _devContext.TblUsers.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TblUser>>> GetUserById(int id)
        {
            var users = await _devContext.TblUsers.Where(x => x.Id == id).ToListAsync();
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                return users;
            }

        }
        [HttpPost]
        public async Task<ActionResult<TblUser>> CreateUser(TblUser tblUser)
        {
            await _devContext.TblUsers.AddAsync(tblUser);
            await _devContext.SaveChangesAsync();
            return Ok(tblUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblUser>> UpdateUser(int id, TblUser tblUser)
        {
            if (id != tblUser.Id)
            {
                return BadRequest();
            }
            _devContext.Entry(tblUser).State = EntityState.Modified;
            await _devContext.SaveChangesAsync();
            return Ok(tblUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUser>> DeleteUser(int id)
        {
           var user = await _devContext.TblUsers.FindAsync(id);
            if (user == null) { 
            return NotFound();
            }
            _devContext.TblUsers.Remove(user);
            await _devContext.SaveChangesAsync();
            return Ok(user);
        }
    }
}
