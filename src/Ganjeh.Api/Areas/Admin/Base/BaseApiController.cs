using Ganjeh.Api.Base;
using Ganjeh.Api.Filters.UserVerification;
using Ganjeh.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ganjeh.Api.Areas.Admin.Base
{
    [Area(nameof(RoleEnum.Admin))]
    [UserVerification(RoleEnum.Admin)]
    public class AdminApiController : BaseApiController
    {

    }
}