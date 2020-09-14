using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Exceptions;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")] // api/trainings
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        readonly ITrainingService service;

        public TrainingsController(ITrainingService service)
        {
            this.service = service;
        }

        //api/trainings
        public async Task<IActionResult> GetTrainings()
        {
            var trainings = await service.GetTrainings();
            return Ok(trainings);
        }
        //api/trainings/101
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTraining(int id)
        {
            try
            {
                return Ok( await service.GetTraining(id));
            }
            catch (TrainingNotFoundException nfex)
            {
                return NotFound(nfex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        [HttpGet("{title}")]
        //api/trainings/.NET/FSD Program
        public async Task<IActionResult> GetTraining(string title)
        {
            try
            {
                return Ok(await service.GetTraining(title));
            }
            catch (TrainingNotFoundException nfex)
            {
                return NotFound(nfex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        //api/trainings
        [HttpPost]
        public async Task<IActionResult> PostTraining([FromBody]Training training)
        {
            try
            {
                await service.AddTraining(training);
                return Created("api/trainings", training);
            }
            catch(DuplicateTrainingTitleExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        //api/trainings
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(int id, Training training)
        {
            try
            {
                return Ok(await service.Update(id,training));
            }
            catch (TrainingNotFoundException nfex)
            {
                return NotFound(nfex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            try
            {
                return Ok(await service.Delete(id));
            }
            catch (TrainingNotFoundException nfex)
            {
                return NotFound(nfex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

    }
}
