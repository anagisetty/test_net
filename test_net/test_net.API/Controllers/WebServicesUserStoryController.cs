using Test_Net.API.Controllers;
using Test_Net.DTO;
using Test_Net.Service;
using Microsoft.AspNetCore.Mvc;

namespace Test_Net.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebServicesUserStoryController : ControllerBase
    {
        private readonly WebServicesUserStoryService _userStoryService;

        public WebServicesUserStoryController(WebServicesUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WebServicesUserStory>> GetAll()
        {
            return Ok(_userStoryService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<WebServicesUserStory> GetById(int id)
        {
            var story = _userStoryService.GetById(id);
            if (story == null)
            {
                return NotFound();
            }
            return Ok(story);
        }

        [HttpPost]
        public ActionResult<WebServicesUserStory> Create(WebServicesUserStory story)
        {
            _userStoryService.Create(story);
            return Ok(story);
        }

        [HttpPut]
        public ActionResult<WebServicesUserStory> Update(WebServicesUserStory story)
        {
            _userStoryService.Update(story);
            return Ok(story);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userStoryService.Delete(id);
            return NoContent();
        }

    }
}