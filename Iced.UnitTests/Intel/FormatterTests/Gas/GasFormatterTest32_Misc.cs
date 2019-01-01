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

#if !NO_GAS_FORMATTER && !NO_FORMATTER
using System.Collections.Generic;
using Xunit;

namespace Iced.UnitTests.Intel.FormatterTests.Gas {
	public sealed class GasFormatterTest32_Misc : FormatterTest {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(int index, InstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, GasFormatterFactory.Create());
		public static IEnumerable<object[]> Format_Data => GetFormatData(infos, formattedStrings);

		static readonly InstructionInfo[] infos = InstructionInfos32_Misc.AllInfos;
		static readonly string[] formattedStrings = new string[InstructionInfos32_Misc.AllInfos_Length] {
			"jo,pn 0x7ffffff3",
			"jno,pn 0x7ffffff3",
			"jb,pn 0x7ffffff3",
			"jae,pn 0x7ffffff3",
			"je,pn 0x7ffffff3",
			"jne,pn 0x7ffffff3",
			"jbe,pn 0x7ffffff3",
			"ja,pn 0x7ffffff3",
			"js,pn 0x7ffffff3",
			"jns,pn 0x7ffffff3",
			"jp,pn 0x7ffffff3",
			"jnp,pn 0x7ffffff3",
			"jl,pn 0x7ffffff3",
			"jge,pn 0x7ffffff3",
			"jle,pn 0x7ffffff3",
			"jg,pn 0x7ffffff3",
			"jo,pt 0x7ffffff3",
			"jno,pt 0x7ffffff3",
			"jb,pt 0x7ffffff3",
			"jae,pt 0x7ffffff3",
			"je,pt 0x7ffffff3",
			"jne,pt 0x7ffffff3",
			"jbe,pt 0x7ffffff3",
			"ja,pt 0x7ffffff3",
			"js,pt 0x7ffffff3",
			"jns,pt 0x7ffffff3",
			"jp,pt 0x7ffffff3",
			"jnp,pt 0x7ffffff3",
			"jl,pt 0x7ffffff3",
			"jge,pt 0x7ffffff3",
			"jle,pt 0x7ffffff3",
			"jg,pt 0x7ffffff3",
			"jo,pn 0x7ffffff7",
			"jno,pn 0x7ffffff7",
			"jb,pn 0x7ffffff7",
			"jae,pn 0x7ffffff7",
			"je,pn 0x7ffffff7",
			"jne,pn 0x7ffffff7",
			"jbe,pn 0x7ffffff7",
			"ja,pn 0x7ffffff7",
			"js,pn 0x7ffffff7",
			"jns,pn 0x7ffffff7",
			"jp,pn 0x7ffffff7",
			"jnp,pn 0x7ffffff7",
			"jl,pn 0x7ffffff7",
			"jge,pn 0x7ffffff7",
			"jle,pn 0x7ffffff7",
			"jg,pn 0x7ffffff7",
			"jo,pt 0x7ffffff7",
			"jno,pt 0x7ffffff7",
			"jb,pt 0x7ffffff7",
			"jae,pt 0x7ffffff7",
			"je,pt 0x7ffffff7",
			"jne,pt 0x7ffffff7",
			"jbe,pt 0x7ffffff7",
			"ja,pt 0x7ffffff7",
			"js,pt 0x7ffffff7",
			"jns,pt 0x7ffffff7",
			"jp,pt 0x7ffffff7",
			"jnp,pt 0x7ffffff7",
			"jl,pt 0x7ffffff7",
			"jge,pt 0x7ffffff7",
			"jle,pt 0x7ffffff7",
			"jg,pt 0x7ffffff7",
			"bnd jo 0x7ffffff3",
			"bnd jno 0x7ffffff3",
			"bnd jb 0x7ffffff3",
			"bnd jae 0x7ffffff3",
			"bnd je 0x7ffffff3",
			"bnd jne 0x7ffffff3",
			"bnd jbe 0x7ffffff3",
			"bnd ja 0x7ffffff3",
			"bnd js 0x7ffffff3",
			"bnd jns 0x7ffffff3",
			"bnd jp 0x7ffffff3",
			"bnd jnp 0x7ffffff3",
			"bnd jl 0x7ffffff3",
			"bnd jge 0x7ffffff3",
			"bnd jle 0x7ffffff3",
			"bnd jg 0x7ffffff3",
			"bnd jo 0x7ffffff7",
			"bnd jno 0x7ffffff7",
			"bnd jb 0x7ffffff7",
			"bnd jae 0x7ffffff7",
			"bnd je 0x7ffffff7",
			"bnd jne 0x7ffffff7",
			"bnd jbe 0x7ffffff7",
			"bnd ja 0x7ffffff7",
			"bnd js 0x7ffffff7",
			"bnd jns 0x7ffffff7",
			"bnd jp 0x7ffffff7",
			"bnd jnp 0x7ffffff7",
			"bnd jl 0x7ffffff7",
			"bnd jge 0x7ffffff7",
			"bnd jle 0x7ffffff7",
			"bnd jg 0x7ffffff7",
			"bnd jmp 0x7ffffff6",
			"bnd jmpl *(%eax)",
			"bnd jmp *%eax",
			"bnd call 0x7ffffff6",
			"bnd calll *(%eax)",
			"bnd call *%eax",
			"bnd ret $0",
			"bnd ret",
			"notrack calll *%ds:(%eax)",
			"notrack calll *%ds:0x11(%ebp)",
			"notrack call *%ecx",
			"notrack jmpl *%ds:(%eax)",
			"notrack jmpl *%ds:0x11(%ebp)",
			"notrack jmp *%ecx",
			"notrack bnd call *%ecx",
			"notrack calll *%ds:(%eax)",
			"calll *%fs:(%eax)",
			"notrack bnd jmp *%ecx",
			"notrack jmpl *%ds:(%eax)",
			"jmpl *%fs:(%eax)",
		};
	}
}
#endif
