/*----------------------------------------------------------
This Source Code Form is subject to the terms of the
Mozilla Public License, v.2.0. If a copy of the MPL
was not distributed with this file, You can obtain one
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.HostedScript.Library.Binary;
using ScriptEngine.Machine;
using System;
using System.Runtime.InteropServices;

namespace ScriptEngine.HostedScript.Library.NativeApi
{


    /// <summary>
    /// Трансляция значений между IValue и tVariant из состава Native API
    /// </summary>
    class NativeApiVariant: IDisposable
    {
        private readonly IntPtr variant = IntPtr.Zero;

        public IntPtr Ptr { get { return variant; } }

        public NativeApiVariant(Int32 count = 1)
        {
            variant = NativeApiProxy.CreateVariant(count);
        }

        public void Dispose()
        { 
            if (variant != IntPtr.Zero)
                NativeApiProxy.FreeVariant(variant);
        }

        public void SetVariant(IValue value, Int32 number = 0)
        {
            switch (value.DataType)
            {
                case DataType.String:
                    String str = value.AsString();
                    NativeApiProxy.SetVariantStr(variant, number, str, str.Length);
                    break;
                case DataType.Boolean:
                    NativeApiProxy.SetVariantBool(variant, number, value.AsBoolean());
                    break;
                case DataType.Number:
                    Decimal num = value.AsNumber();
                    if (num % 1 == 0)
                        NativeApiProxy.SetVariantInt(variant, number, Convert.ToInt32(value.AsNumber()));
                    else
                        NativeApiProxy.SetVariantReal(variant, number, Convert.ToDouble(value.AsNumber()));
                    break;
                default:
                    NativeApiProxy.SetVariantEmpty(variant, number);
                    break;
            }
        }
    }
}