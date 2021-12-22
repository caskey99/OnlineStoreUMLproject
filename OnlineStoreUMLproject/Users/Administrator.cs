using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStoreUMLproject.Users
{
    class Administrator : User
    {

        public Administrator(string Login, string Password)
        {
            login = Login;
            password = Password;
            canBuy = true;
        }



    }
}
