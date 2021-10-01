using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Model;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        public UsersController() { }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var errors = Model.User.ValidateErrors(name, email, address, phone, money);
            var ResultCreateUser = new Result(isSuccess: false, errors: errors);

            if (!string.IsNullOrEmpty(errors)) return ResultCreateUser;

            var newUser = new User
            (
                    name: name
                , email: email
                , address: address
                , phone: phone
                , userType: userType
                , money: decimal.Parse(money)
            );

            var _users = GetListUsers(); 

            //Validacion si el usuario actual esta duplicado
            var isDuplicated = _users.Exists
                (
                    x =>
                            (x.Email == newUser.Email || x.Phone == newUser.Phone)
                            ||
                            (x.Name == newUser.Name && x.Address == newUser.Address)
                );

            var Message = (isDuplicated ? "User is duplicated" : "User Created");
            Debug.WriteLine(Message);
            return ResultCreateUser.SetResult(isSuccess: !isDuplicated, errors: Message);

        } // CreateUser

    } // class UsersController

} // namespace
