using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Enums
{
    public static class RoleTypes
    {
        public static string Admin { get; } = "Admin";
        public static string Manager { get; } = "Manager";
        public static string Visitor { get; } = "Visitor";
    }
}
