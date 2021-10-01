﻿namespace Sat.Recruitment.Model
{
    public sealed partial class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public decimal Money { get; set; }

        /// <summary>
        /// Constructor generico no permitido en este proyecto
        /// </summary>
        private User() { }

        public User
        (
              string name
            , string email
            , string address
            , string phone
            , string userType
            , decimal money
        )
        {
            Name = name;
            Email = NormalizeEmail(email);
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = getMoneyFromUserType(money);
        }

    }
} 
