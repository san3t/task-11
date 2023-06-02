using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using BackendApi.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Просмотр всех пользователей
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        /// <summary>
        /// Поиск пользователя по ID
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _userService.GetById(id);
            var response = new GetUserResponse() 
            {
                Id = result.Id,
                FirstName = result.FirstName,
                UserEmail = result.UserEmail,
                UserRole = result.UserRole,
                UserPassword = result.UserPassword
            };

            return Ok(response);
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "firstname" : "Иван",
        /// "user_mail" : "example@gmail.com",
        /// "user_role" : "admin",
        /// "user_password" : "123456"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userD = new CustomUser()
            {
                FirstName = request.FirstName,
                UserEmail = request.UserEmail,
                UserRole = request.UserRole,
                UserPassword = request.UserPassword

            };

            await _userService.Create(userD);
            return Ok();
        }


        /// <summary>
        /// Изменение существующего пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CustomUser user)
        {
            await _userService.Update(user);
            return Ok();
        }


        /// <summary>
        /// Удаление существующего пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
