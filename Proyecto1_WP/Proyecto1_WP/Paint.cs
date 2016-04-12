using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace Proyecto1_WP
{
    public class Paint:NotificationEnableObject
    {
        public Paint()
        {
            WidthLine = 5;
        }
        private SolidColorBrush colorBinding;

        public SolidColorBrush ColorBinding
        {
            get {
                if (colorBinding == null)
                {
                    colorBinding = new SolidColorBrush(Colors.DarkGray);
                }
                return colorBinding; }
            set { colorBinding = value;

            ColorString=GetKnownColorName(colorBinding.Color);
            OnPropertyChanged();
            }
        }
        private int aColor;

        public int AColor
        {
            get { return aColor; }
            set { aColor = value;
            ChengeColorFromARGB();
            OnPropertyChanged();
            }
        }

        private int rColor;
        public int RColor
        {
            get { return rColor; }
            set { rColor = value;
            ChengeColorFromARGB();
            OnPropertyChanged();
            }
        }

        private int gColor;

        public int GColor
        {
            get { return gColor; }
            set { gColor = value;
            ChengeColorFromARGB();
            OnPropertyChanged();
            }
        }

        private int bColor;

        public int BColor
        {
            get { return bColor; }
            set { bColor = value;
            ChengeColorFromARGB();
            OnPropertyChanged();
            }
        }

        private void ChengeColorFromARGB()
        {
            var solid = new SolidColorBrush(
                Color.FromArgb(
                System.Convert.ToByte(AColor),
                System.Convert.ToByte(RColor),
                System.Convert.ToByte(GColor),
                System.Convert.ToByte(BColor)));
            ColorBinding = solid;
        }
        private string hexadecimal;

        public string Hexadecimal
        {
            get { return hexadecimal; }
            set { hexadecimal = value;
            setValueRGB();
            OnPropertyChanged();
            }
        }
        private void setValueRGB()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Hexadecimal, @"[#]([0-9]|[a-f]|[A-F]){8}\b"))
            {
                AColor = int.Parse(Hexadecimal.Substring(1, 2), NumberStyles.HexNumber);
                RColor = int.Parse(Hexadecimal.Substring(3, 2), NumberStyles.HexNumber);
                GColor = int.Parse(Hexadecimal.Substring(5, 2), NumberStyles.HexNumber);
                BColor = int.Parse(Hexadecimal.Substring(7, 2), NumberStyles.HexNumber);
            }
        }

        private string colorString;

        public string ColorString
        {
            get { return colorString; }
            set { colorString = value;
            OnPropertyChanged();
            }
        }

        private SolidColorBrush colorBack;

        public SolidColorBrush ColorBack
        {
            get {
                if (colorBack == null)
                {
                    colorBack = new SolidColorBrush(Colors.Green);
                } return colorBack;
            }
            set { colorBack = value;
            OnPropertyChanged();
            }
        }
        private SolidColorBrush colorLin;

        public SolidColorBrush ColorLine
        {
            get {
                if (colorLin == null)
                {
                    colorLin = new SolidColorBrush(Colors.White);
                }
                return colorLin; }
            set { colorLin = value;
            OnPropertyChanged();
            }
        }

        private int widtLine;

        public int WidthLine
        {
            get { return widtLine; }
            set { widtLine = value;
            OnPropertyChanged();
            }
        }


        private ActionCommand setColorLineCommand;
        public ActionCommand SetColorLineCommand
        {
            get
            {
                if (setColorLineCommand == null)
                {
                    setColorLineCommand = new ActionCommand(() =>
                    {
                        ColorLine = ColorBinding;
                    });
                }
                return setColorLineCommand;
            }
            set { setColorLineCommand = value; }
        }
        private ActionCommand setColorBackgroundCommand;
        public ActionCommand SetColorBackgroundCommand
        {
            get
            {
                if (setColorBackgroundCommand == null)
                {
                    setColorBackgroundCommand = new ActionCommand(() =>
                    {
                        ColorBack = ColorBinding;
                    });
                }
                return setColorBackgroundCommand;
            }
            set { setColorBackgroundCommand = value; }
        }

        public static string GetKnownColorName(Color clr)
        {
            Color clrKnownColor;

            //Use reflection to get all known colors
            Type ColorType = typeof(System.Windows.Media.Colors);
            PropertyInfo[] arrPiColors = ColorType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            //Iterate over all known colors, convert each to a <Color> and then compare
            //that color to the passed color.
            foreach (PropertyInfo pi in arrPiColors)
            {
                clrKnownColor = (Color)pi.GetValue(null, null);
                if (clrKnownColor == clr) return pi.Name;
            }

            return clr.ToString();
        }

    }
}
