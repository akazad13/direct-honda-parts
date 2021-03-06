using DHP.AppService.ServiceInterfaces;
using DHP.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IAccountService _accountService;
        public UserController(
          IAccountService accountService,
          IHttpContextAccessor httpContextAccessor) : base(accountService, httpContextAccessor)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("{userId}/profile")]
        [Authorize(Policy = "RequireDashboardUser")]
        public IActionResult GetUserProfile(long userId)
        {
            return DoWorkAfterValidation(
                         () => _accountService.GetUserProfile(GetCurrentUserId(), userId, userId).Result
                            .Match<IActionResult>(
                                Ok,
                                BadRequest
                            )
                    );
        }

        [HttpPatch]
        [Route("{userId}/profile")]
        [Authorize(Policy = "RequireDashboardUser")]
        public IActionResult UpdateUserProfile(long userId, UserProfileDto profileData)
        {
            return DoWorkAfterValidation(
                         () => _accountService.UpdateUserProfile(GetCurrentUserId(), userId, profileData, userId).Result
                            .Match<IActionResult>(
                                Ok,
                                BadRequest
                            )
                    );
        }

        [HttpPatch]
        [Route("{userId}/theme")]
        [Authorize(Policy = "RequireDashboardUser")]
        public IActionResult UpdateUserTheme(long userId, UpdateThemeDto themeData)
        {
            return DoWorkAfterValidation(
                         () => _accountService.UpdateUserTheme(GetCurrentUserId(), userId, themeData.Theme, userId).Result
                            .Match<IActionResult>(
                                Ok,
                                BadRequest
                            )
                    );
        }

    }
}
