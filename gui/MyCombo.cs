using System;
using AppKit;
using Foundation;
using System.Collections.Generic;

namespace gui
{
    public class MyCombo : NSComboBoxDataSource
    {
        readonly List<string> source;

        public MyCombo(List<string> source)
        {
            this.source = source;
        }





        public override string CompletedString(NSComboBox comboBox, string uncompletedString)
        {
            return source.Find(n => n.StartsWith(uncompletedString, StringComparison.InvariantCultureIgnoreCase));
        }

        public override nint IndexOfItem(NSComboBox comboBox, string value)
        {
            return source.FindIndex(n => n.Equals(value, StringComparison.InvariantCultureIgnoreCase));
        }

        public override nint ItemCount(NSComboBox comboBox)
        {
            return source.Count;
        }

        public override NSObject ObjectValueForItem(NSComboBox comboBox, nint index)
        {
            return NSString.FromObject(source[(int)index]);
        }


    }
}
