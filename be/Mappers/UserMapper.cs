using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserCreateRequest request)
        {
            return new User
            {
                userName = request.userName,
                userCode = request.userCode,
                email = request.email,
                password = request.password, 
                department = request.department,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateUser(this User user, UserCreateRequest request)
        {
            user.userName = request.userName;
            user.userCode = request.userCode;
            user.email = request.email;
            user.department = request.department;
            user.updatedAt = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(request.password))
            {
                user.password = request.password;
            }
        }
    }
}