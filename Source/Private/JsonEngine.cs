using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    //need to fix
    class JsonEngine
    {
        static string json = @"{ 'name': 'Admin' }{ 'name': 'Publisher' }";
        IList<Role> roles = new List<Role>();

        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        reader.SupportMultipleContent = true;

while (true)
{
    if (!reader.Read())
    {
        break;
    }

    JsonSerializer serializer = new JsonSerializer();
        Role role = serializer.Deserialize<Role>(reader);

        roles.Add(role);
}

foreach (Role role in roles)
{
    Console.WriteLine(role.Name);
}
    }


    public class Role
    {
        public string Name { get; set; }
    }
}
