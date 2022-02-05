using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMember _member;
        public MemberController(IMember member)
        {
            _member = member;
        }
        #region
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Members>>> GetAllMembers()
        {
            return await _member.GetAllMembers();
        }
        #endregion
        #region 
        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Members members)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _member.AddMember(members);
                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateMember([FromBody] Members members)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _member.UpdateMember(members);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
