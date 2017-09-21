using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudyWPFClient.ViewModels.ValidationRules
{
    public class NewSubjectRule : ValidationRule
    {
        public Wrapper subjectsWrapper { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string test = "badSubject";

            //if ((string)value == test)
            //{
            //    return new ValidationResult(false, "bad subject");
            //}
            //else
            //    return new ValidationResult(true, null);

            //if (subjectsWrapper.UniqueSubjects == null)
            //{
            //    return new ValidationResult(false, "bad subject");
            //}
            //else
            //    return new ValidationResult(true, null);

            if (subjectsWrapper.UniqueSubjects.Contains((string)value))
            {
                return new ValidationResult(false, "bad subject");
            }
            else
                return new ValidationResult(true, null);
        }
    }

    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty UniqueSubjectsProperty;

        static Wrapper()
        {
            UniqueSubjectsProperty = DependencyProperty.Register(
                "UniqueSubjects",
                typeof(IList<string>),
                typeof(Wrapper),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }

        public IList<string> UniqueSubjects
        {
            get { return (IList<string>)base.GetValue(UniqueSubjectsProperty); }
            set { base.SetValue(UniqueSubjectsProperty, value); }
        }
    }
}
