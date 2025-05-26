using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Entities_Helper;
public enum PaymentType
{
    Cash = 1,         // دفع نقدي
    CreditCard = 2,   // بطاقة ائتمان
    DebitCard = 3,    // بطاقة خصم مباشر
    Insurance = 4,    // تغطية تأمينية
    Wallet = 5,       // محفظة إلكترونية (زي فودافون كاش)   
}
