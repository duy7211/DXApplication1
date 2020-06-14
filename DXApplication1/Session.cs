using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    public static class Session
    {
        private static string id;
        private static string username;

        public static string Id { get => id; set => id = value; }
        public static string Username { get => username; set => username = value; }
    }
}
