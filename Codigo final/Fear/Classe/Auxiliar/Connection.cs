
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fear
{
    public static class Connection
    {

        public static string PathConnection()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=C:\Users\guilherme.rfernande3\source\repos\Fear\BD_FEAR.mdf; Integrated Security = true; Connect Timeout = 30"; 
        }


    }
}
