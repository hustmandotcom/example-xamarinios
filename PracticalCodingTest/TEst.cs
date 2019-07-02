using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace PracticalCodingTest.Application
{
    class TEst : UITextFieldDelegate
    {
        public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
        {
            return base.ShouldChangeCharacters(textField, range, replacementString);
        }
    }
}