using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.BDD.TableModels
{
    public class BrokerScreen1Model
    {
        #region Insured Details
        public string InsuredType { get; set; }
        public string Country { get; set; }
        public string OverrideApplicantDetails { get; set; }
        public string InsuredName { get; set; }
        public string OverrideIndustry { get; set; }
        public string ChooseInsured { get; set; }
        #endregion

        #region Broker Details
        public string Broker { get; set; }
        #endregion

        #region Policy Details
        public string InceptionDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Currency { get; set; }
        public string QuotableCoverage1 { get; set; }
        #endregion
    }
}
