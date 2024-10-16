using api.Dtos.Auth;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                // first_name = userModel.first_name,
                // last_name = userModel.first_name,
                // email = userModel.email,
                // phone = userModel.phone,
                orders = userModel.orders
            };
        }

        public static User ToUserFromCreateUser(this CreateUserDto userBody)
        {
            return new User
            {
                // first_name = userBody.first_name,
                // last_name = userBody.first_name,
                // password = userBody.password,
                // email = userBody.email,
                // phone = userBody.phone,
            };
        }
    }
}
