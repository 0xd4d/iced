/*
Copyright (C) 2018-2019 de4dot@gmail.com

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#if !NO_INSTR_INFO
using System;

namespace Iced.Intel {
	/// <summary>
	/// RFLAGS bits supported by the instruction info code
	/// </summary>
	[Flags]
	public enum RflagsBits {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		None	= 0,
		OF		= 0x00000001,
		SF		= 0x00000002,
		ZF		= 0x00000004,
		AF		= 0x00000008,
		CF		= 0x00000010,
		PF		= 0x00000020,
		DF		= 0x00000040,
		IF		= 0x00000080,
		AC		= 0x00000100,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}
}
#endif
