//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.Mvc;
//using THUCTAP.Interfaces;
//using THUCTAP.ViewModels;
//using System;

//namespace THUCTAP.Endpoints
//{
//    public static class UserEndpoints
//    {
//        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
//        {
//            var group = app.MapGroup("/api/User")
//                           .WithTags("User Accounts")
//                           .RequireAuthorization();

//            group.MapPost("/", async (UserCreateRequest request, IUserService userService, ITokenService tokenService) =>
//            {
//                var createdUser = await userService.CreateUserAsync(request);
//                var token = tokenService.GenerateToken(createdUser);

//                return Results.Ok(new
//                {
//                    Message = "Thêm người dùng thành công",
//                    Data = createdUser,
//                    Token = token
//                });
//            });

//            group.MapPut("/{id}", async (int id, UserCreateRequest request, IUserService userService) =>
//            {
//                var updatedUser = await userService.UpdateUserAsync(id, request);

//                if (updatedUser == null)
//                {
//                    return Results.NotFound(new { Message = "Không tìm thấy người dùng này!" });
//                }

//                return Results.Ok(new { Message = "Cập nhật tài khoản thành công!", Data = updatedUser });
//            });

//            group.MapDelete("/{id}", async (int id, IUserService userService) =>
//            {
//                var isDeleted = await userService.DeleteUserAsync(id);

//                if (!isDeleted)
//                {
//                    return Results.NotFound(new { Message = "Không tìm thấy người dùng để xóa!" });
//                }

//                return Results.Ok(new { Message = "Xóa tài khoản thành công!" });
//            });

//            group.MapGet("/", async ([AsParameters] UserFilterRequest filter, IUserService userService) =>
//            {
//                var users = await userService.GetAllUsersAsync(filter);

//                return Results.Ok(new
//                {
//                    message = "Lấy danh sách người dùng thành công!",
//                    data = users
//                });
//            });

//            group.MapGet("/departments", async (IUserService userService) =>
//            {
//                try
//                {
//                    var departments = await userService.GetAllDepartmentsAsync();
//                    return Results.Ok(new
//                    {
//                        message = "Lấy danh sách phòng ban thành công!",
//                        data = departments
//                    });
//                }
//                catch (Exception ex)
//                {
//                    return Results.BadRequest(new { message = ex.Message });
//                }
//            });
//        }
//    }
//}