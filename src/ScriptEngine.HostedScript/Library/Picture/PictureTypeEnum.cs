﻿/*----------------------------------------------------------
This Source Code Form is subject to the terms of the
Mozilla Public License, v.2.0. If a copy of the MPL
was not distributed with this file, You can obtain one
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

namespace ScriptEngine.HostedScript.Library.Picture
{
    [EnumerationType("ТипВнешнейКомпоненты", "AddInType")]
    public enum PictureTypeEnum
    {
        [EnumItem("Абсолютная", "Absolute")]
        Absolute,
        [EnumItem("ИзБиблиотеки", "FromLib")]
        FromLib,
        [EnumItem("Пустая", "Empty")]
        Empty,
    }
}