using BackendWebApi.Context;
using BackendWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TeamInfoController : ControllerBase
    {
        private ApplicationDbContext _appDbContext;

        public TeamInfoController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("getallteaminfo")]
        public async Task<IActionResult> GetAllTeamInfo()
        {
            try
            {
                List<TeamInfo> members = await _appDbContext.TeamInfo.ToListAsync();
                if (members == null)
                    return NotFound();
                return Ok(members);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
