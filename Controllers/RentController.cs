using Library.Models;
using Library.Repository;
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
    public class RentController : ControllerBase
    {
        private readonly IRent _rent;
        public RentController(IRent rent)
        {
            _rent = rent;
        }
        #region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAllRents()
        {
            return await _rent.GetAllRents();
        }
        #endregion
        #region 
        [HttpPost]
        public async Task<IActionResult> AddRent([FromBody] Rent rent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _rent.AddRent(rent);
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
        #region 
        [HttpPut]
        public async Task<IActionResult> UpdateRent([FromBody] Rent rent)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _rent.UpdateRent(rent);
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
        #region delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int? Rentid)
        {
            int result = 0;
            if (Rentid == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _rent.DeleteRent(Rentid);
                if (result == 0)
                {
                    return NotFound();

                }
                return Ok(); //return Ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
