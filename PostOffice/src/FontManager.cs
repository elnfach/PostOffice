using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.src
{
    internal static class FontManager
    {
        static Font font;
        static FontManager() {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("font\\Alegreya\\static\\Alegreya-Black.ttf"); // файл шрифта
            FontFamily family = fontCollection.Families[0];
            // Создаём шрифт и используем далее
            font = new Font(family, 15);
        }

        public static Font GetFont()
        {
            return font;
        }
    }
}
