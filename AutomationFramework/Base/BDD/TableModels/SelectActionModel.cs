using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.BDD.TableModels
{
    public class SelectActionModel
    {
        public string Action { get; set; }
        public string Reason { get; set; }
        public string EffectiveDate { get; set; }
        public string SendBrokerEmail { get; set; }
    }
}
