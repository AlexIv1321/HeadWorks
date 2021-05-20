using Microsoft.AspNetCore.Mvc;
using System;

namespace HeadWorksDragonFight.Extensions
{
    public static class ContollerBaseExtensions
    {
        public static Guid GetUserId(this ControllerBase controller)
        {
            return Guid.Parse(controller.User.Identity.Name);
        }
    }
}
