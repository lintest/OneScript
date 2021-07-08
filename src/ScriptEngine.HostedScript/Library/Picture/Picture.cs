/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.Machine.Contexts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEngine.HostedScript.Library.Picture
{
    /// <summary>
    /// Объект для работы с данными в табличном виде. 
    /// Представляет из себя коллекцию строк с заранее заданной структурой.
    /// </summary>
    [ContextClass("Картинка", "Picture")]
    class Picture
    {
        private Image _image = null;

        public Picture() { }

        public Picture(String filename)
        {
            _image = Image.FromFile(filename);
        }

        public Picture(Stream stream)
        {
            _image = Image.FromStream(stream);
        }

        [ScriptConstructor]
        public static Picture Constructor()
        {
            return new Picture();
        }

        [ContextProperty("Вид", "Type")]
        public PictureTypeEnum Type
        {
            get { return _image == null ? PictureTypeEnum.Empty : PictureTypeEnum.Absolute; }
        }
    }
}
