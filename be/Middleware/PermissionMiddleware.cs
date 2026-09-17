using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;

namespace THUCTAP.Middlewares
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }
            var endpoint = context.GetEndpoint();
            if (endpoint == null)
            {
                await _next(context);
                return;
            }

            var routeEndpoint = endpoint as RouteEndpoint;
            var routePattern = routeEndpoint?.RoutePattern.RawText;

            if (string.IsNullOrEmpty(routePattern))
            {
                await _next(context);
                return;
            }

            var path = "/" + routePattern;
            var method = context.Request.Method.ToUpper();

            var userIdString = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                               ?? context.User.FindFirst("userId")?.Value 
                               ?? context.User.FindFirst("id")?.Value
                               ?? context.User.FindFirst("Id")?.Value;

            if (int.TryParse(userIdString, out int userId))
            {
                var hasPermission = await dbContext.User
                    .Where(u => u.id == userId)
                    .SelectMany(u => u.group) 
                    .SelectMany(g => g.action) 
                    .AnyAsync(a => a.endpoint.ToLower() == path.ToLower() && a.method.ToUpper() == method);

                if (!hasPermission)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("{\"message\": \"Bạn không có quyền thực hiện chức năng này (Lỗi 403 Forbidden).\"}");
                    return;
                }
            }
            await _next(context);
        }
    }
}