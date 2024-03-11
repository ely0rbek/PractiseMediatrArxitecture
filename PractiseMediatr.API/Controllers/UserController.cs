using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PractiseMediatr.API.ExternalServices;
using PractiseMediatr.Application.Mappings;
using PractiseMediatr.Application.UseCase.MediumUser.Commands;
using PractiseMediatr.Application.UseCase.MediumUser.Queries;
using PractiseMediatr.Domain.Entities;
using PractiseMediatr.Domain.Entities.DTOs;

namespace PractiseMediatr.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMediator _mediator;

        public UserController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(IFormFile picture, [FromForm] UserDTO userDTO)
        {
            try
            {
                SavePictureExternalService service = new SavePictureExternalService(_webHostEnvironment);
                string imagePath = await service.AddPictureAndGetPath(picture);
                var user = userDTO.Map<CreateUserCommand>();
                user.PicturePath = imagePath;
                await _mediator.Send(user);

                return Ok("Malumot qo'shildi");
            }
            catch
            {
                return BadRequest("Yaratishda xatolik");
            }
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet]
        public async Task<User> GetUserById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery()
            {
                Id = id
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(Guid id,UserDTO userDTO)
        {
            try
            {
                var user = userDTO.Map<UpdateUserCommand>();
                user.Id = id;
                await _mediator.Send(user);

                return Ok("Malumot o'zgartirildi.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserCommand() { Id = id });

                return Ok("Malumot o'chirildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
