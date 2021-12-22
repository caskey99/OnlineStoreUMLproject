using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStoreUMLproject.Users
{
    class Moderator : User
    {
        public Moderator(string Login, string Password)
        {
            login = Login;
            password = Password;
            canBuy = true;
        }
    }
}
