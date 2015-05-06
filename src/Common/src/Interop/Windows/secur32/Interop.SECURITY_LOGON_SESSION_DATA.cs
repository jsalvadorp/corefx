// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SECURITY_LOGON_SESSION_DATA
    {
        internal uint Size;
        internal LUID LogonId;
        internal UNICODE_INTPTR_STRING UserName;
        internal UNICODE_INTPTR_STRING LogonDomain;
        internal UNICODE_INTPTR_STRING AuthenticationPackage;
        internal uint LogonType;
        internal uint Session;
        internal IntPtr Sid;
        internal long LogonTime;
    }
}