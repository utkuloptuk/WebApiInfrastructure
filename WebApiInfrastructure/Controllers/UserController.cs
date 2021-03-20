using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbObject;
using WebApi.Interface.DbObjects;
using WebApi.Model;
using WebApi.Model.RequestDto;
using WebApi.Model.ResponseDto;

namespace WebApiInfrastructure.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices userService;
        private readonly ILogger<UserController> logger;
        
        public UserController(IUserServices userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }
        [HttpGet]
        [Route("api/GetUser")]
        public IActionResult GetUser(GetObjectRequest req)
        {
            string methodName= System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            var result = userService.Get(req.Id);
            GetObjectResponse response = new GetObjectResponse()
            {
                FirstName = result.FirstName,
                Id = result.Id,
                IsDeleted = result.IsDeleted,
                LastName = result.LastName
            };
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok(response);
        }
        [HttpPut]
        [Route("api/AddUser")]
        public IActionResult AddUser(AddObjectRequest req)
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            userService.Add(req);
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok();
        }
        [HttpGet]
        [Route("api/GetAll")]
        public IActionResult GetAllUser()
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            var result = userService.GetAll();
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok(result);
        }
        [HttpPost]
        [Route("api/UserUpdate")]
        public IActionResult UpdateUser(UpdateObjectRequest updateObjectRequest)
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            userService.Update(updateObjectRequest);
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok();
        }
        [HttpDelete]
        [Route("api/UserDelete")]
        public IActionResult DeleteUser(DeleteObjectRequest deleteObjectRequest)
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            userService.HardDelete(deleteObjectRequest.Id);
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok();
        }
        [HttpPost]
        [Route("api/UserSoftDelete")]
        public IActionResult SoftDeleteUser(SoftDeleteObjectRequest softDeleteObjectRequest)
        {
            string methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            logger.LogInformation($@"{methodName} process is begining.");
            userService.SoftDelete(softDeleteObjectRequest);
            logger.LogInformation($@"{methodName} process is ended.");
            return Ok();
        }

    }
}
