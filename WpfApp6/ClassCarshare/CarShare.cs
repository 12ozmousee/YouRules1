using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCarshare
{
    public class CarShare
    {
        public string Company { get; set; }
        public List<Car> Cars { get; set; }
        public int MinimalAge { get; set; }
        public int MinimalLisence {get;set;}
        public string AdditionalInfo { get; set; }
    }
}
