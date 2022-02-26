using BackendWebApi.Context;
using BackendWebApi.Models;
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
    public class TrainingPlanController : ControllerBase
    {
        private ApplicationDbContext _appDbContext;

        public TrainingPlanController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("getalltrainings")]
        public async Task<IActionResult> GetAllTrainingPlans()
        {
            try
            {
                List<TrainingPlan> trainings = await _appDbContext.TrainingPlan.ToListAsync();
                if (trainings == null)
                    return NotFound();
                return Ok(trainings);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
