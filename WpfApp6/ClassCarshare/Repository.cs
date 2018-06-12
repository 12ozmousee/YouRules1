using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ClassCarshare
{
   internal class Repository

    {
        public List<User> Users { get; set; }
        public List<CarShare> CarShares { get; set; }
        public List<Car> Cars { get; set; }




        public GeneralClass Load(string gb)
        {
            var ob = JsonConvert.DeserializeObject<GeneralClass>(gb);
            return ob;
        }

        public static GeneralClass Dataload()
        {

            return JsonConvert.DeserializeObject<GeneralClass>(new StreamReader(FileName).ReadToEnd());
        }

        private const string DataFolder = "Data";
        private const string FileName = "Info.json";

        private GeneralClass _GeneralClass;
		private User _authorizedUser;

        public void Save()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
            using (var sw = new StreamWriter(Path.Combine(DataFolder, FileName)))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, _GeneralClass);
                }
            }
        }

        public void RegisterUser(User user)
        {
            user.Id = _GeneralClass.Users.Count > 0 ? _GeneralClass.Users.Max(u => u.Id) + 1 : 1;
            _GeneralClass.Users.Add(user);
            Save();
        }
        public bool Authorize(string mail, string password)
        {
            var user = _GeneralClass.Users.FirstOrDefault(u => u.Email == mail && u.Password == Hash.GetHash(password));
            if (user != null)
            {
               
                _authorizedUser = user;
                return true;
            }
            return false;
        }















    }
}
