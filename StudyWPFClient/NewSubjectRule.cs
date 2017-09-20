using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudyWPFClient
{
    public class NewSubjectRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string test = "badSubject";

            if ((string)value == test)
            {
                return new ValidationResult(false, "bad subject");
            }
            else
                return new ValidationResult(true, null);
        }
    }
}
