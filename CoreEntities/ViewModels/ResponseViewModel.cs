using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.ViewModels
{
 public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public object Obj { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public string CompanyId { get; set; }
    }

 public class StripeResponseViewModel
 {
     public bool IsSuccess { get; set; }
     public object Obj { get; set; }
     public IEnumerable<string> Errors { get; set; }
     public string ErrorMessage { get; set; }
     public string SuccessMessage { get; set; }
     public string SubscriptionId { get; set; }

     public string StripetransactionId { get; set; }
     public string StripeChargeId { get; set; }
 }
}
