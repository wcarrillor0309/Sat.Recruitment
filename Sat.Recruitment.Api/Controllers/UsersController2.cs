using System.Collections.Generic;
using System.IO;
using Sat.Recruitment.Model;

namespace Sat.Recruitment.Api.Controllers
{
    public partial class UsersController
    {
        /// <summary>
        /// Read the flat file of the users
        /// </summary>
        /// <returns>flat file user list</returns>
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        private List<User> GetListUsers()
        {
            var users = new List<User>();

            using (var reader = ReadUsersFromFile())
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    (
                        name: line.Split(',')[0].ToString(),
                        email: line.Split(',')[1].ToString(),
                        address: line.Split(',')[3].ToString(),
                        phone: line.Split(',')[2].ToString(),
                        userType: line.Split(',')[4].ToString(),
                        money: decimal.Parse(line.Split(',')[5].ToString())
                    );

                    users.Add(user);
                }
            } 
            return users;
        }
    }
}
