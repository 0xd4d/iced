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

#if !NO_MASM_FORMATTER && !NO_FORMATTER
using System.Collections.Generic;
using Xunit;

namespace Iced.UnitTests.Intel.FormatterTests.Masm {
	public sealed class MasmFormatterTest64_ForceMemSize_001 : FormatterTest {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(int index, InstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, MasmFormatterFactory.Create_ForceMemSize());
		public static IEnumerable<object[]> Format_Data => GetFormatData(infos, formattedStrings);

		static readonly InstructionInfo[] infos = InstructionInfos64_001.AllInfos;
		static readonly string[] formattedStrings = new string[InstructionInfos64_001.AllInfos_Length] {
			"idiv byte ptr [rax]",
			"test cx,-5AA6h",
			"test word ptr [rax],-5AA6h",
			"test ecx,3412A55Ah",
			"test dword ptr [rax],3412A55Ah",
			"test rcx,-7BED5AA6h",
			"test qword ptr [rax],-7BED5AA6h",
			"not cx",
			"not word ptr [rax]",
			"not ecx",
			"not dword ptr [rax]",
			"not rcx",
			"not qword ptr [rax]",
			"neg si",
			"neg word ptr [rax]",
			"neg esi",
			"neg dword ptr [rax]",
			"neg rsi",
			"neg qword ptr [rax]",
			"mul bp",
			"mul word ptr [rax]",
			"mul ebp",
			"mul dword ptr [rax]",
			"mul rbp",
			"mul qword ptr [rax]",
			"imul si",
			"imul word ptr [rax]",
			"imul esi",
			"imul dword ptr [rax]",
			"imul rsi",
			"imul qword ptr [rax]",
			"div di",
			"div word ptr [rax]",
			"div edi",
			"div dword ptr [rax]",
			"div rdi",
			"div qword ptr [rax]",
			"idiv ax",
			"idiv word ptr [rax]",
			"idiv eax",
			"idiv dword ptr [rax]",
			"idiv r8",
			"idiv qword ptr [rax]",
			"clc",
			"stc",
			"cli",
			"sti",
			"cld",
			"std",
			"inc cl",
			"inc byte ptr [rax]",
			"dec dh",
			"dec byte ptr [rax]",
			"inc cx",
			"inc word ptr [rax]",
			"inc ecx",
			"inc dword ptr [rax]",
			"inc rcx",
			"inc qword ptr [rax]",
			"dec si",
			"dec word ptr [rax]",
			"dec esi",
			"dec dword ptr [rax]",
			"dec rsi",
			"dec qword ptr [rax]",
			"call rcx",
			"call qword ptr [rax]",
			"call dword ptr [rax]",
			"call fword ptr [rax]",
			"call tbyte ptr [rax]",
			"jmp rsi",
			"jmp qword ptr [rax]",
			"jmp dword ptr [rax]",
			"jmp fword ptr [rax]",
			"jmp tbyte ptr [rax]",
			"push si",
			"push word ptr [rax]",
			"push rsi",
			"push qword ptr [rax]",
			"sldt cx",
			"sldt word ptr [rax]",
			"sldt ecx",
			"sldt word ptr [rax]",
			"sldt rcx",
			"sldt word ptr [rax]",
			"str dx",
			"str word ptr [rax]",
			"str edx",
			"str word ptr [rax]",
			"str rdx",
			"str word ptr [rax]",
			"lldt bx",
			"lldt word ptr [rax]",
			"lldt ebx",
			"lldt word ptr [rax]",
			"lldt rbx",
			"lldt word ptr [rax]",
			"ltr sp",
			"ltr word ptr [rax]",
			"ltr esp",
			"ltr word ptr [rax]",
			"ltr rsp",
			"ltr word ptr [rax]",
			"verr bp",
			"verr word ptr [rax]",
			"verr ebp",
			"verr word ptr [rax]",
			"verr rbp",
			"verr word ptr [rax]",
			"verw si",
			"verw word ptr [rax]",
			"verw esi",
			"verw word ptr [rax]",
			"verw rsi",
			"verw word ptr [rax]",
			"sgdt fword ptr [rax]",
			"sidt fword ptr [rax]",
			"lgdt fword ptr [rax]",
			"lidt fword ptr [rax]",
			"smsw bp",
			"smsw word ptr [rax]",
			"smsw ebp",
			"smsw word ptr [rax]",
			"smsw rbp",
			"smsw word ptr [rax]",
			"lmsw si",
			"lmsw word ptr [rax]",
			"lmsw esi",
			"lmsw word ptr [rax]",
			"lmsw rsi",
			"lmsw word ptr [rax]",
			"invlpg [rax]",
			"enclv",
			"vmcall",
			"vmlaunch",
			"vmresume",
			"vmxoff",
			"monitor rax,rcx,rdx",
			"mwait rax,rcx",
			"clac",
			"stac",
			"encls",
			"xgetbv",
			"xsetbv",
			"vmfunc",
			"xend",
			"xtest",
			"enclu",
			"rdpkru",
			"wrpkru",
			"swapgs",
			"rdtscp",
			"lar cx,si",
			"lar bx,word ptr [rax]",
			"lar ecx,esi",
			"lar ebx,word ptr [rax]",
			"lar rcx,rsi",
			"lar rbx,word ptr [rax]",
			"lsl cx,si",
			"lsl bx,word ptr [rax]",
			"lsl ecx,esi",
			"lsl ebx,word ptr [rax]",
			"lsl rcx,rsi",
			"lsl rbx,word ptr [rax]",
			"syscall",
			"clts",
			"sysret",
			"sysretq",
			"invd",
			"wbinvd",
			"ud2",
			"prefetchw byte ptr [rax]",
			"prefetchwt1 byte ptr [rax]",
			"movups xmm1,xmm5",
			"movups xmm1,xmmword ptr [rax]",
			"vmovups xmm1,xmm5",
			"vmovups xmm2,xmmword ptr [rax]",
			"vmovups ymm1,ymm5",
			"vmovups ymm2,ymmword ptr [rax]",
			"vmovups xmm2,xmm3",
			"vmovups xmm2,xmmword ptr [rax+10h]",
			"vmovups ymm2,ymm3",
			"vmovups ymm2,ymmword ptr [rax+20h]",
			"vmovups zmm2,zmm3",
			"vmovups zmm2,zmmword ptr [rax+40h]",
			"movupd xmm1,xmm5",
			"movupd xmm1,xmmword ptr [rax]",
			"vmovupd xmm1,xmm5",
			"vmovupd xmm2,xmmword ptr [rax]",
			"vmovupd ymm1,ymm5",
			"vmovupd ymm2,ymmword ptr [rax]",
			"vmovupd xmm2,xmm3",
			"vmovupd xmm2,xmmword ptr [rax+10h]",
			"vmovupd ymm2,ymm3",
			"vmovupd ymm2,ymmword ptr [rax+20h]",
			"vmovupd zmm2,zmm3",
			"vmovupd zmm2,zmmword ptr [rax+40h]",
			"movss xmm1,xmm5",
			"movss xmm1,dword ptr [rax]",
			"vmovss xmm1,xmm6,xmm5",
			"vmovss xmm2,dword ptr [rax]",
			"vmovss xmm2,xmm6,xmm3",
			"vmovss xmm2,dword ptr [rax+4]",
			"movsd xmm1,xmm5",
			"movsd xmm1,qword ptr [rax]",
			"vmovsd xmm1,xmm6,xmm5",
			"vmovsd xmm2,qword ptr [rax]",
			"vmovsd xmm2,xmm6,xmm3",
			"vmovsd xmm2,qword ptr [rax+8]",
			"movups xmm5,xmm1",
			"movups xmmword ptr [rax],xmm1",
			"vmovups xmm5,xmm1",
			"vmovups xmmword ptr [rax],xmm2",
			"vmovups ymm5,ymm1",
			"vmovups ymmword ptr [rax],ymm2",
			"vmovups xmm3,xmm2",
			"vmovups xmmword ptr [rax+10h],xmm2",
			"vmovups ymm3,ymm2",
			"vmovups ymmword ptr [rax+20h],ymm2",
			"vmovups zmm3,zmm2",
			"vmovups zmmword ptr [rax+40h],zmm2",
			"movupd xmm5,xmm1",
			"movupd xmmword ptr [rax],xmm1",
			"vmovupd xmm5,xmm1",
			"vmovupd xmmword ptr [rax],xmm2",
			"vmovupd ymm5,ymm1",
			"vmovupd ymmword ptr [rax],ymm2",
			"vmovupd xmm3,xmm2",
			"vmovupd xmmword ptr [rax+10h],xmm2",
			"vmovupd ymm3,ymm2",
			"vmovupd ymmword ptr [rax+20h],ymm2",
			"vmovupd zmm3,zmm2",
			"vmovupd zmmword ptr [rax+40h],zmm2",
			"movss xmm5,xmm1",
			"movss dword ptr [rax],xmm1",
			"vmovss xmm5,xmm6,xmm1",
			"vmovss dword ptr [rax],xmm2",
			"vmovss xmm3,xmm6,xmm2",
			"vmovss dword ptr [rax+4],xmm2",
			"movsd xmm5,xmm1",
			"movsd qword ptr [rax],xmm1",
			"vmovsd xmm5,xmm6,xmm1",
			"vmovsd qword ptr [rax],xmm2",
			"vmovsd xmm3,xmm6,xmm2",
			"vmovsd qword ptr [rax+8],xmm2",
			"movhlps xmm1,xmm5",
			"movlps xmm1,qword ptr [rax]",
			"vmovhlps xmm2,xmm6,xmm3",
			"vmovlps xmm2,xmm6,qword ptr [rax]",
			"vmovhlps xmm2,xmm6,xmm3",
			"vmovlps xmm2,xmm6,qword ptr [rax+8]",
			"movlpd xmm1,qword ptr [rax]",
			"vmovlpd xmm2,xmm6,qword ptr [rax]",
			"vmovlpd xmm2,xmm6,qword ptr [rax+8]",
			"movsldup xmm1,xmm5",
			"movsldup xmm1,xmmword ptr [rax]",
			"vmovsldup xmm1,xmm5",
			"vmovsldup xmm2,xmmword ptr [rax]",
			"vmovsldup ymm1,ymm5",
			"vmovsldup ymm2,ymmword ptr [rax]",
			"vmovsldup xmm2,xmm3",
			"vmovsldup xmm2,xmmword ptr [rax+10h]",
			"vmovsldup ymm2,ymm3",
			"vmovsldup ymm2,ymmword ptr [rax+20h]",
			"vmovsldup zmm2,zmm3",
			"vmovsldup zmm2,zmmword ptr [rax+40h]",
			"movddup xmm1,xmm5",
			"movddup xmm1,qword ptr [rax]",
			"vmovddup xmm1,xmm5",
			"vmovddup xmm2,qword ptr [rax]",
			"vmovddup ymm1,ymm5",
			"vmovddup ymm2,ymmword ptr [rax]",
			"vmovddup xmm2,xmm3",
			"vmovddup xmm2,qword ptr [rax+8]",
			"vmovddup ymm2,ymm3",
			"vmovddup ymm2,ymmword ptr [rax+20h]",
			"vmovddup zmm2,zmm3",
			"vmovddup zmm2,zmmword ptr [rax+40h]",
			"movlps qword ptr [rax],xmm1",
			"vmovlps qword ptr [rax],xmm2",
			"vmovlps qword ptr [rax+8],xmm2",
			"movlpd qword ptr [rax],xmm1",
			"vmovlpd qword ptr [rax],xmm2",
			"vmovlpd qword ptr [rax+8],xmm2",
			"unpcklps xmm1,xmm5",
			"unpcklps xmm1,xmmword ptr [rax]",
			"vunpcklps xmm2,xmm6,xmm3",
			"vunpcklps xmm2,xmm6,xmmword ptr [rax]",
			"vunpcklps ymm2,ymm6,ymm3",
			"vunpcklps ymm2,ymm6,ymmword ptr [rax]",
			"vunpcklps xmm2{k3},xmm6,xmm3",
			"vunpcklps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vunpcklps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vunpcklps ymm2{k3},ymm6,ymm3",
			"vunpcklps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vunpcklps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vunpcklps zmm2{k3},zmm6,zmm3",
			"vunpcklps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vunpcklps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"unpcklpd xmm1,xmm5",
			"unpcklpd xmm1,xmmword ptr [rax]",
			"vunpcklpd xmm2,xmm6,xmm3",
			"vunpcklpd xmm2,xmm6,xmmword ptr [rax]",
			"vunpcklpd ymm2,ymm6,ymm3",
			"vunpcklpd ymm2,ymm6,ymmword ptr [rax]",
			"vunpcklpd xmm2{k3}{z},xmm6,xmm3",
			"vunpcklpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vunpcklpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vunpcklpd ymm2{k3}{z},ymm6,ymm3",
			"vunpcklpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vunpcklpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vunpcklpd zmm2{k3}{z},zmm6,zmm3",
			"vunpcklpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vunpcklpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"unpckhps xmm1,xmm5",
			"unpckhps xmm1,xmmword ptr [rax]",
			"vunpckhps xmm2,xmm6,xmm3",
			"vunpckhps xmm2,xmm6,xmmword ptr [rax]",
			"vunpckhps ymm2,ymm6,ymm3",
			"vunpckhps ymm2,ymm6,ymmword ptr [rax]",
			"vunpckhps xmm2{k3},xmm6,xmm3",
			"vunpckhps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vunpckhps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vunpckhps ymm2{k3},ymm6,ymm3",
			"vunpckhps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vunpckhps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vunpckhps zmm2{k3},zmm6,zmm3",
			"vunpckhps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vunpckhps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"unpckhpd xmm1,xmm5",
			"unpckhpd xmm1,xmmword ptr [rax]",
			"vunpckhpd xmm2,xmm6,xmm3",
			"vunpckhpd xmm2,xmm6,xmmword ptr [rax]",
			"vunpckhpd ymm2,ymm6,ymm3",
			"vunpckhpd ymm2,ymm6,ymmword ptr [rax]",
			"vunpckhpd xmm2{k3}{z},xmm6,xmm3",
			"vunpckhpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vunpckhpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vunpckhpd ymm2{k3}{z},ymm6,ymm3",
			"vunpckhpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vunpckhpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vunpckhpd zmm2{k3}{z},zmm6,zmm3",
			"vunpckhpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vunpckhpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"movlhps xmm1,xmm5",
			"vmovlhps xmm2,xmm6,xmm3",
			"vmovlhps xmm2,xmm6,xmm3",
			"movhps xmm1,qword ptr [rax]",
			"vmovhps xmm2,xmm6,qword ptr [rax]",
			"vmovhps xmm2,xmm6,qword ptr [rax+8]",
			"movhpd xmm1,qword ptr [rax]",
			"vmovhpd xmm2,xmm6,qword ptr [rax]",
			"vmovhpd xmm2,xmm6,qword ptr [rax+8]",
			"movshdup xmm1,xmm5",
			"movshdup xmm1,xmmword ptr [rax]",
			"vmovshdup xmm1,xmm5",
			"vmovshdup xmm2,xmmword ptr [rax]",
			"vmovshdup ymm1,ymm5",
			"vmovshdup ymm2,ymmword ptr [rax]",
			"vmovshdup xmm2,xmm3",
			"vmovshdup xmm2,xmmword ptr [rax+10h]",
			"vmovshdup ymm2,ymm3",
			"vmovshdup ymm2,ymmword ptr [rax+20h]",
			"vmovshdup zmm2,zmm3",
			"vmovshdup zmm2,zmmword ptr [rax+40h]",
			"movhps qword ptr [rax],xmm1",
			"vmovhps qword ptr [rax],xmm2",
			"vmovhps qword ptr [rax+8],xmm2",
			"movhpd qword ptr [rax],xmm1",
			"vmovhpd qword ptr [rax],xmm2",
			"vmovhpd qword ptr [rax+8],xmm2",
			"prefetchnta byte ptr [rax]",
			"prefetcht0 byte ptr [rax]",
			"prefetcht1 byte ptr [rax]",
			"prefetcht2 byte ptr [rax]",
			"bndldx bnd1,qword ptr [rax]",
			"bndmov bnd1,bnd2",
			"bndmov bnd1,oword ptr [rax]",
			"bndcl bnd1,rdx",
			"bndcl bnd1,qword ptr [rax]",
			"bndcu bnd1,rdx",
			"bndcu bnd1,qword ptr [rax]",
			"bndstx qword ptr [rax],bnd1",
			"bndmov bnd2,bnd1",
			"bndmov oword ptr [rax],bnd1",
			"bndmk bnd1,qword ptr [rax]",
			"bndcn bnd1,rdx",
			"bndcn bnd1,qword ptr [rax]",
			"nop cx",
			"nop word ptr [rax]",
			"nop ecx",
			"nop dword ptr [rax]",
			"nop rcx",
			"nop qword ptr [rax]",
			"mov rsi,cr3",
			"mov rsi,dr3",
			"mov cr3,rsi",
			"mov dr3,rsi",
			"movaps xmm1,xmm5",
			"movaps xmm1,xmmword ptr [rax]",
			"vmovaps xmm1,xmm5",
			"vmovaps xmm2,xmmword ptr [rax]",
			"vmovaps ymm1,ymm5",
			"vmovaps ymm2,ymmword ptr [rax]",
			"vmovaps xmm2,xmm3",
			"vmovaps xmm2,xmmword ptr [rax+10h]",
			"vmovaps ymm2,ymm3",
			"vmovaps ymm2,ymmword ptr [rax+20h]",
			"vmovaps zmm2,zmm3",
			"vmovaps zmm2,zmmword ptr [rax+40h]",
			"movapd xmm1,xmm5",
			"movapd xmm1,xmmword ptr [rax]",
			"vmovapd xmm1,xmm5",
			"vmovapd xmm2,xmmword ptr [rax]",
			"vmovapd ymm1,ymm5",
			"vmovapd ymm2,ymmword ptr [rax]",
			"vmovapd xmm2,xmm3",
			"vmovapd xmm2,xmmword ptr [rax+10h]",
			"vmovapd ymm2,ymm3",
			"vmovapd ymm2,ymmword ptr [rax+20h]",
			"vmovapd zmm2,zmm3",
			"vmovapd zmm2,zmmword ptr [rax+40h]",
			"movaps xmm5,xmm1",
			"movaps xmmword ptr [rax],xmm1",
			"vmovaps xmm5,xmm1",
			"vmovaps xmmword ptr [rax],xmm2",
			"vmovaps ymm5,ymm1",
			"vmovaps ymmword ptr [rax],ymm2",
			"vmovaps xmm3,xmm2",
			"vmovaps xmmword ptr [rax+10h],xmm2",
			"vmovaps ymm3,ymm2",
			"vmovaps ymmword ptr [rax+20h],ymm2",
			"vmovaps zmm3,zmm2",
			"vmovaps zmmword ptr [rax+40h],zmm2",
			"movapd xmm5,xmm1",
			"movapd xmmword ptr [rax],xmm1",
			"vmovapd xmm5,xmm1",
			"vmovapd xmmword ptr [rax],xmm2",
			"vmovapd ymm5,ymm1",
			"vmovapd ymmword ptr [rax],ymm2",
			"vmovapd xmm3,xmm2",
			"vmovapd xmmword ptr [rax+10h],xmm2",
			"vmovapd ymm3,ymm2",
			"vmovapd ymmword ptr [rax+20h],ymm2",
			"vmovapd zmm3,zmm2",
			"vmovapd zmmword ptr [rax+40h],zmm2",
			"cvtpi2ps xmm1,mm5",
			"cvtpi2ps xmm1,qword ptr [rax]",
			"cvtpi2pd xmm1,mm5",
			"cvtpi2pd xmm1,qword ptr [rax]",
			"cvtsi2ss xmm1,ebp",
			"cvtsi2ss xmm1,dword ptr [rax]",
			"cvtsi2ss xmm1,rbp",
			"cvtsi2ss xmm1,qword ptr [rax]",
			"vcvtsi2ss xmm2,xmm6,ebx",
			"vcvtsi2ss xmm2,xmm6,dword ptr [rax]",
			"vcvtsi2ss xmm2,xmm6,rbx",
			"vcvtsi2ss xmm2,xmm6,qword ptr [rax]",
			"vcvtsi2ss xmm2,xmm6,ebx",
			"vcvtsi2ss xmm2,xmm6,dword ptr [rax+4]",
			"vcvtsi2ss xmm2,xmm6,rbx",
			"vcvtsi2ss xmm2,xmm6,qword ptr [rax+8]",
			"cvtsi2sd xmm1,ebp",
			"cvtsi2sd xmm1,dword ptr [rax]",
			"cvtsi2sd xmm1,rbp",
			"cvtsi2sd xmm1,qword ptr [rax]",
			"vcvtsi2sd xmm2,xmm6,ebx",
			"vcvtsi2sd xmm2,xmm6,dword ptr [rax]",
			"vcvtsi2sd xmm2,xmm6,rbx",
			"vcvtsi2sd xmm2,xmm6,qword ptr [rax]",
			"vcvtsi2sd xmm2,xmm6,ebx",
			"vcvtsi2sd xmm2,xmm6,dword ptr [rax+4]",
			"vcvtsi2sd xmm2,xmm6,rbx",
			"vcvtsi2sd xmm2,xmm6,qword ptr [rax+8]",
			"movntps xmmword ptr [rax],xmm1",
			"vmovntps xmmword ptr [rax],xmm2",
			"vmovntps ymmword ptr [rax],ymm2",
			"vmovntps xmmword ptr [rax+10h],xmm2",
			"vmovntps ymmword ptr [rax+20h],ymm2",
			"vmovntps zmmword ptr [rax+40h],zmm2",
			"movntpd xmmword ptr [rax],xmm1",
			"vmovntpd xmmword ptr [rax],xmm2",
			"vmovntpd ymmword ptr [rax],ymm2",
			"vmovntpd xmmword ptr [rax+10h],xmm2",
			"vmovntpd ymmword ptr [rax+20h],ymm2",
			"vmovntpd zmmword ptr [rax+40h],zmm2",
			"cvttps2pi mm1,xmm5",
			"cvttps2pi mm1,mmword ptr [rax]",
			"cvttpd2pi mm1,xmm5",
			"cvttpd2pi mm1,xmmword ptr [rax]",
			"cvttss2si ecx,xmm5",
			"cvttss2si ecx,dword ptr [rax]",
			"cvttss2si rcx,xmm5",
			"cvttss2si rcx,dword ptr [rax]",
			"vcvttss2si ecx,xmm5",
			"vcvttss2si edx,dword ptr [rax]",
			"vcvttss2si rcx,xmm5",
			"vcvttss2si rdx,dword ptr [rax]",
			"vcvttss2si edx,xmm3",
			"vcvttss2si edx,dword ptr [rax+4]",
			"vcvttss2si rdx,xmm3",
			"vcvttss2si rdx,dword ptr [rax+4]",
			"cvttsd2si ecx,xmm5",
			"cvttsd2si ecx,qword ptr [rax]",
			"cvttsd2si rcx,xmm5",
			"cvttsd2si rcx,qword ptr [rax]",
			"vcvttsd2si ecx,xmm5",
			"vcvttsd2si edx,qword ptr [rax]",
			"vcvttsd2si rcx,xmm5",
			"vcvttsd2si rdx,qword ptr [rax]",
			"vcvttsd2si edx,xmm3",
			"vcvttsd2si edx,qword ptr [rax+8]",
			"vcvttsd2si rdx,xmm3",
			"vcvttsd2si rdx,qword ptr [rax+8]",
			"cvtps2pi mm1,xmm5",
			"cvtps2pi mm1,mmword ptr [rax]",
			"cvtpd2pi mm1,xmm5",
			"cvtpd2pi mm1,xmmword ptr [rax]",
			"cvtss2si ecx,xmm5",
			"cvtss2si ecx,dword ptr [rax]",
			"cvtss2si rcx,xmm5",
			"cvtss2si rcx,dword ptr [rax]",
			"vcvtss2si ecx,xmm5",
			"vcvtss2si edx,dword ptr [rax]",
			"vcvtss2si rcx,xmm5",
			"vcvtss2si rdx,dword ptr [rax]",
			"vcvtss2si edx,xmm3",
			"vcvtss2si edx,dword ptr [rax+4]",
			"vcvtss2si rdx,xmm3",
			"vcvtss2si rdx,dword ptr [rax+4]",
			"cvtsd2si ecx,xmm5",
			"cvtsd2si ecx,qword ptr [rax]",
			"cvtsd2si rcx,xmm5",
			"cvtsd2si rcx,qword ptr [rax]",
			"vcvtsd2si ecx,xmm5",
			"vcvtsd2si edx,qword ptr [rax]",
			"vcvtsd2si rcx,xmm5",
			"vcvtsd2si rdx,qword ptr [rax]",
			"vcvtsd2si edx,xmm3",
			"vcvtsd2si edx,qword ptr [rax+8]",
			"vcvtsd2si rdx,xmm3",
			"vcvtsd2si rdx,qword ptr [rax+8]",
			"ucomiss xmm1,xmm5",
			"ucomiss xmm1,dword ptr [rax]",
			"vucomiss xmm2,xmm3",
			"vucomiss xmm2,dword ptr [rax]",
			"vucomiss xmm2,xmm3",
			"vucomiss xmm2,dword ptr [rax+4]",
			"ucomisd xmm1,xmm5",
			"ucomisd xmm1,qword ptr [rax]",
			"vucomisd xmm2,xmm3",
			"vucomisd xmm2,qword ptr [rax]",
			"vucomisd xmm2,xmm3",
			"vucomisd xmm2,qword ptr [rax+8]",
			"comiss xmm1,xmm5",
			"comiss xmm1,dword ptr [rax]",
			"comisd xmm1,xmm5",
			"comisd xmm1,qword ptr [rax]",
			"vcomiss xmm2,xmm3",
			"vcomiss xmm2,dword ptr [rax]",
			"vcomisd xmm2,xmm3",
			"vcomisd xmm2,qword ptr [rax]",
			"vcomiss xmm2,xmm3",
			"vcomiss xmm2,dword ptr [rax+4]",
			"vcomisd xmm2,xmm3",
			"vcomisd xmm2,qword ptr [rax+8]",
			"wrmsr",
			"rdtsc",
			"rdmsr",
			"rdpmc",
			"sysenter",
			"sysexit",
			"sysexitq",
			"getsec",
			"cmovo cx,si",
			"cmovo bx,word ptr [rax]",
			"cmovo ecx,esi",
			"cmovo ebx,dword ptr [rax]",
			"cmovo rcx,rsi",
			"cmovo rbx,qword ptr [rax]",
			"cmovno cx,si",
			"cmovno bx,word ptr [rax]",
			"cmovno ecx,esi",
			"cmovno ebx,dword ptr [rax]",
			"cmovno rcx,rsi",
			"cmovno rbx,qword ptr [rax]",
			"cmovb cx,si",
			"cmovb bx,word ptr [rax]",
			"cmovb ecx,esi",
			"cmovb ebx,dword ptr [rax]",
			"cmovb rcx,rsi",
			"cmovb rbx,qword ptr [rax]",
			"cmovae cx,si",
			"cmovae bx,word ptr [rax]",
			"cmovae ecx,esi",
			"cmovae ebx,dword ptr [rax]",
			"cmovae rcx,rsi",
			"cmovae rbx,qword ptr [rax]",
			"cmove cx,si",
			"cmove bx,word ptr [rax]",
			"cmove ecx,esi",
			"cmove ebx,dword ptr [rax]",
			"cmove rcx,rsi",
			"cmove rbx,qword ptr [rax]",
			"cmovne cx,si",
			"cmovne bx,word ptr [rax]",
			"cmovne ecx,esi",
			"cmovne ebx,dword ptr [rax]",
			"cmovne rcx,rsi",
			"cmovne rbx,qword ptr [rax]",
			"cmovbe cx,si",
			"cmovbe bx,word ptr [rax]",
			"cmovbe ecx,esi",
			"cmovbe ebx,dword ptr [rax]",
			"cmovbe rcx,rsi",
			"cmovbe rbx,qword ptr [rax]",
			"cmova cx,si",
			"cmova bx,word ptr [rax]",
			"cmova ecx,esi",
			"cmova ebx,dword ptr [rax]",
			"cmova rcx,rsi",
			"cmova rbx,qword ptr [rax]",
			"cmovs cx,si",
			"cmovs bx,word ptr [rax]",
			"cmovs ecx,esi",
			"cmovs ebx,dword ptr [rax]",
			"cmovs rcx,rsi",
			"cmovs rbx,qword ptr [rax]",
			"cmovns cx,si",
			"cmovns bx,word ptr [rax]",
			"cmovns ecx,esi",
			"cmovns ebx,dword ptr [rax]",
			"cmovns rcx,rsi",
			"cmovns rbx,qword ptr [rax]",
			"cmovp cx,si",
			"cmovp bx,word ptr [rax]",
			"cmovp ecx,esi",
			"cmovp ebx,dword ptr [rax]",
			"cmovp rcx,rsi",
			"cmovp rbx,qword ptr [rax]",
			"cmovnp cx,si",
			"cmovnp bx,word ptr [rax]",
			"cmovnp ecx,esi",
			"cmovnp ebx,dword ptr [rax]",
			"cmovnp rcx,rsi",
			"cmovnp rbx,qword ptr [rax]",
			"cmovl cx,si",
			"cmovl bx,word ptr [rax]",
			"cmovl ecx,esi",
			"cmovl ebx,dword ptr [rax]",
			"cmovl rcx,rsi",
			"cmovl rbx,qword ptr [rax]",
			"cmovge cx,si",
			"cmovge bx,word ptr [rax]",
			"cmovge ecx,esi",
			"cmovge ebx,dword ptr [rax]",
			"cmovge rcx,rsi",
			"cmovge rbx,qword ptr [rax]",
			"cmovle cx,si",
			"cmovle bx,word ptr [rax]",
			"cmovle ecx,esi",
			"cmovle ebx,dword ptr [rax]",
			"cmovle rcx,rsi",
			"cmovle rbx,qword ptr [rax]",
			"cmovg cx,si",
			"cmovg bx,word ptr [rax]",
			"cmovg ecx,esi",
			"cmovg ebx,dword ptr [rax]",
			"cmovg rcx,rsi",
			"cmovg rbx,qword ptr [rax]",
			"kandw k2,k6,k3",
			"kandq k2,k6,k3",
			"kandb k2,k6,k3",
			"kandd k2,k6,k3",
			"kandnw k2,k6,k3",
			"kandnq k2,k6,k3",
			"kandnb k2,k6,k3",
			"kandnd k2,k6,k3",
			"knotw k2,k3",
			"knotq k2,k3",
			"knotb k2,k3",
			"knotd k2,k3",
			"korw k2,k6,k3",
			"korq k2,k6,k3",
			"korb k2,k6,k3",
			"kord k2,k6,k3",
			"kxnorw k2,k6,k3",
			"kxnorq k2,k6,k3",
			"kxnorb k2,k6,k3",
			"kxnord k2,k6,k3",
			"kxorw k2,k6,k3",
			"kxorq k2,k6,k3",
			"kxorb k2,k6,k3",
			"kxord k2,k6,k3",
			"kaddw k2,k6,k3",
			"kaddq k2,k6,k3",
			"kaddb k2,k6,k3",
			"kaddd k2,k6,k3",
			"kunpckwd k2,k6,k3",
			"kunpckdq k2,k6,k3",
			"kunpckbw k2,k6,k3",
			"movmskps ecx,xmm5",
			"movmskps rcx,xmm5",
			"vmovmskps edx,xmm3",
			"vmovmskps rdx,xmm3",
			"vmovmskps edx,ymm3",
			"vmovmskps rdx,ymm3",
			"movmskpd ecx,xmm5",
			"movmskpd rcx,xmm5",
			"vmovmskpd edx,xmm3",
			"vmovmskpd rdx,xmm3",
			"vmovmskpd edx,ymm3",
			"vmovmskpd rdx,ymm3",
			"sqrtps xmm1,xmm5",
			"sqrtps xmm1,xmmword ptr [rax]",
			"vsqrtps xmm2,xmm3",
			"vsqrtps xmm2,xmmword ptr [rax]",
			"vsqrtps ymm2,ymm3",
			"vsqrtps ymm2,ymmword ptr [rax]",
			"vsqrtps xmm2{k3},xmm3",
			"vsqrtps xmm2{k3},xmmword ptr [rax+10h]",
			"vsqrtps xmm2{k5}{z},dword bcst [rax+4]",
			"vsqrtps ymm2{k3},ymm3",
			"vsqrtps ymm2{k3},ymmword ptr [rax+20h]",
			"vsqrtps ymm2{k5}{z},dword bcst [rax+4]",
			"vsqrtps zmm2{k3}{z},zmm3 {ru-sae}",
			"vsqrtps zmm2{k3},zmmword ptr [rax+40h]",
			"vsqrtps zmm2{k5}{z},dword bcst [rax+4]",
			"sqrtpd xmm1,xmm5",
			"sqrtpd xmm1,xmmword ptr [rax]",
			"vsqrtpd xmm2,xmm3",
			"vsqrtpd xmm2,xmmword ptr [rax]",
			"vsqrtpd ymm2,ymm3",
			"vsqrtpd ymm2,ymmword ptr [rax]",
			"vsqrtpd xmm2{k3}{z},xmm3",
			"vsqrtpd xmm2{k3},xmmword ptr [rax+10h]",
			"vsqrtpd xmm2{k5}{z},qword bcst [rax+8]",
			"vsqrtpd ymm2{k3}{z},ymm3",
			"vsqrtpd ymm2{k3},ymmword ptr [rax+20h]",
			"vsqrtpd ymm2{k5}{z},qword bcst [rax+8]",
			"vsqrtpd zmm2{k3}{z},zmm3 {ru-sae}",
			"vsqrtpd zmm2{k3},zmmword ptr [rax+40h]",
			"vsqrtpd zmm2{k5}{z},qword bcst [rax+8]",
			"sqrtss xmm1,xmm5",
			"sqrtss xmm1,dword ptr [rax]",
			"vsqrtss xmm2,xmm6,xmm3",
			"vsqrtss xmm2,xmm6,dword ptr [rax]",
			"vsqrtss xmm2{k3},xmm6,xmm3",
			"vsqrtss xmm2{k3},xmm6,dword ptr [rax+4]",
			"sqrtsd xmm1,xmm5",
			"sqrtsd xmm1,qword ptr [rax]",
			"vsqrtsd xmm2,xmm6,xmm3",
			"vsqrtsd xmm2,xmm6,qword ptr [rax]",
			"vsqrtsd xmm2{k3}{z},xmm6,xmm3",
			"vsqrtsd xmm2{k3},xmm6,qword ptr [rax+8]",
			"rsqrtps xmm1,xmm5",
			"rsqrtps xmm1,xmmword ptr [rax]",
			"vrsqrtps xmm2,xmm3",
			"vrsqrtps xmm2,xmmword ptr [rax]",
			"vrsqrtps ymm2,ymm3",
			"vrsqrtps ymm2,ymmword ptr [rax]",
			"rsqrtss xmm1,xmm5",
			"rsqrtss xmm1,dword ptr [rax]",
			"vrsqrtss xmm2,xmm6,xmm3",
			"vrsqrtss xmm2,xmm6,dword ptr [rax]",
			"rcpps xmm1,xmm5",
			"rcpps xmm1,xmmword ptr [rax]",
			"vrcpps xmm2,xmm3",
			"vrcpps xmm2,xmmword ptr [rax]",
			"vrcpps ymm2,ymm3",
			"vrcpps ymm2,ymmword ptr [rax]",
			"rcpss xmm1,xmm5",
			"rcpss xmm1,dword ptr [rax]",
			"vrcpss xmm2,xmm6,xmm3",
			"vrcpss xmm2,xmm6,dword ptr [rax]",
			"andps xmm1,xmm5",
			"andps xmm1,xmmword ptr [rax]",
			"vandps xmm2,xmm6,xmm3",
			"vandps xmm2,xmm6,xmmword ptr [rax]",
			"vandps ymm2,ymm6,ymm3",
			"vandps ymm2,ymm6,ymmword ptr [rax]",
			"vandps xmm2{k3},xmm6,xmm3",
			"vandps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vandps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vandps ymm2{k3},ymm6,ymm3",
			"vandps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vandps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vandps zmm2{k3},zmm6,zmm3",
			"vandps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vandps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"andpd xmm1,xmm5",
			"andpd xmm1,xmmword ptr [rax]",
			"vandpd xmm2,xmm6,xmm3",
			"vandpd xmm2,xmm6,xmmword ptr [rax]",
			"vandpd ymm2,ymm6,ymm3",
			"vandpd ymm2,ymm6,ymmword ptr [rax]",
			"vandpd xmm2{k3}{z},xmm6,xmm3",
			"vandpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vandpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vandpd ymm2{k3}{z},ymm6,ymm3",
			"vandpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vandpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vandpd zmm2{k3}{z},zmm6,zmm3",
			"vandpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vandpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"andnps xmm1,xmm5",
			"andnps xmm1,xmmword ptr [rax]",
			"vandnps xmm2,xmm6,xmm3",
			"vandnps xmm2,xmm6,xmmword ptr [rax]",
			"vandnps ymm2,ymm6,ymm3",
			"vandnps ymm2,ymm6,ymmword ptr [rax]",
			"vandnps xmm2{k3},xmm6,xmm3",
			"vandnps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vandnps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vandnps ymm2{k3},ymm6,ymm3",
			"vandnps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vandnps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vandnps zmm2{k3},zmm6,zmm3",
			"vandnps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vandnps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"andnpd xmm1,xmm5",
			"andnpd xmm1,xmmword ptr [rax]",
			"vandnpd xmm2,xmm6,xmm3",
			"vandnpd xmm2,xmm6,xmmword ptr [rax]",
			"vandnpd ymm2,ymm6,ymm3",
			"vandnpd ymm2,ymm6,ymmword ptr [rax]",
			"vandnpd xmm2{k3}{z},xmm6,xmm3",
			"vandnpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vandnpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vandnpd ymm2{k3}{z},ymm6,ymm3",
			"vandnpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vandnpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vandnpd zmm2{k3}{z},zmm6,zmm3",
			"vandnpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vandnpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"orps xmm1,xmm5",
			"orps xmm1,xmmword ptr [rax]",
			"vorps xmm2,xmm6,xmm3",
			"vorps xmm2,xmm6,xmmword ptr [rax]",
			"vorps ymm2,ymm6,ymm3",
			"vorps ymm2,ymm6,ymmword ptr [rax]",
			"vorps xmm2{k3},xmm6,xmm3",
			"vorps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vorps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vorps ymm2{k3},ymm6,ymm3",
			"vorps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vorps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vorps zmm2{k3},zmm6,zmm3",
			"vorps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vorps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"orpd xmm1,xmm5",
			"orpd xmm1,xmmword ptr [rax]",
			"vorpd xmm2,xmm6,xmm3",
			"vorpd xmm2,xmm6,xmmword ptr [rax]",
			"vorpd ymm2,ymm6,ymm3",
			"vorpd ymm2,ymm6,ymmword ptr [rax]",
			"vorpd xmm2{k3}{z},xmm6,xmm3",
			"vorpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vorpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vorpd ymm2{k3}{z},ymm6,ymm3",
			"vorpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vorpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vorpd zmm2{k3}{z},zmm6,zmm3",
			"vorpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vorpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"xorps xmm1,xmm5",
			"xorps xmm1,xmmword ptr [rax]",
			"vxorps xmm2,xmm6,xmm3",
			"vxorps xmm2,xmm6,xmmword ptr [rax]",
			"vxorps ymm2,ymm6,ymm3",
			"vxorps ymm2,ymm6,ymmword ptr [rax]",
			"vxorps xmm2{k3},xmm6,xmm3",
			"vxorps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vxorps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vxorps ymm2{k3},ymm6,ymm3",
			"vxorps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vxorps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vxorps zmm2{k3},zmm6,zmm3",
			"vxorps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vxorps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"xorpd xmm1,xmm5",
			"xorpd xmm1,xmmword ptr [rax]",
			"vxorpd xmm2,xmm6,xmm3",
			"vxorpd xmm2,xmm6,xmmword ptr [rax]",
			"vxorpd ymm2,ymm6,ymm3",
			"vxorpd ymm2,ymm6,ymmword ptr [rax]",
			"vxorpd xmm2{k3}{z},xmm6,xmm3",
			"vxorpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vxorpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vxorpd ymm2{k3}{z},ymm6,ymm3",
			"vxorpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vxorpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vxorpd zmm2{k3}{z},zmm6,zmm3",
			"vxorpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vxorpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"addps xmm1,xmm5",
			"addps xmm1,xmmword ptr [rax]",
			"vaddps xmm2,xmm6,xmm3",
			"vaddps xmm2,xmm6,xmmword ptr [rax]",
			"vaddps ymm2,ymm6,ymm3",
			"vaddps ymm2,ymm6,ymmword ptr [rax]",
			"vaddps xmm2{k3},xmm6,xmm3",
			"vaddps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vaddps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vaddps ymm2{k3},ymm6,ymm3",
			"vaddps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vaddps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vaddps zmm2{k3}{z},zmm6,zmm3 {ru-sae}",
			"vaddps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vaddps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"addpd xmm1,xmm5",
			"addpd xmm1,xmmword ptr [rax]",
			"vaddpd xmm2,xmm6,xmm3",
			"vaddpd xmm2,xmm6,xmmword ptr [rax]",
			"vaddpd ymm2,ymm6,ymm3",
			"vaddpd ymm2,ymm6,ymmword ptr [rax]",
			"vaddpd xmm2{k3}{z},xmm6,xmm3",
			"vaddpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vaddpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vaddpd ymm2{k3}{z},ymm6,ymm3",
			"vaddpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vaddpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vaddpd zmm2{k3}{z},zmm6,zmm3 {ru-sae}",
			"vaddpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vaddpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"addss xmm1,xmm5",
			"addss xmm1,dword ptr [rax]",
			"vaddss xmm2,xmm6,xmm3",
			"vaddss xmm2,xmm6,dword ptr [rax]",
			"vaddss xmm2{k3},xmm6,xmm3",
			"vaddss xmm2{k3},xmm6,dword ptr [rax+4]",
			"addsd xmm1,xmm5",
			"addsd xmm1,qword ptr [rax]",
			"vaddsd xmm2,xmm6,xmm3",
			"vaddsd xmm2,xmm6,qword ptr [rax]",
			"vaddsd xmm2{k3}{z},xmm6,xmm3",
			"vaddsd xmm2{k3},xmm6,qword ptr [rax+8]",
			"mulps xmm1,xmm5",
			"mulps xmm1,xmmword ptr [rax]",
			"vmulps xmm2,xmm6,xmm3",
			"vmulps xmm2,xmm6,xmmword ptr [rax]",
			"vmulps ymm2,ymm6,ymm3",
			"vmulps ymm2,ymm6,ymmword ptr [rax]",
			"vmulps xmm2{k3},xmm6,xmm3",
			"vmulps xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vmulps xmm2{k5}{z},xmm6,dword bcst [rax+4]",
			"vmulps ymm2{k3},ymm6,ymm3",
			"vmulps ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vmulps ymm2{k5}{z},ymm6,dword bcst [rax+4]",
			"vmulps zmm2{k3}{z},zmm6,zmm3 {ru-sae}",
			"vmulps zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vmulps zmm2{k5}{z},zmm6,dword bcst [rax+4]",
			"mulpd xmm1,xmm5",
			"mulpd xmm1,xmmword ptr [rax]",
			"vmulpd xmm2,xmm6,xmm3",
			"vmulpd xmm2,xmm6,xmmword ptr [rax]",
			"vmulpd ymm2,ymm6,ymm3",
			"vmulpd ymm2,ymm6,ymmword ptr [rax]",
			"vmulpd xmm2{k3}{z},xmm6,xmm3",
			"vmulpd xmm2{k3},xmm6,xmmword ptr [rax+10h]",
			"vmulpd xmm2{k5}{z},xmm6,qword bcst [rax+8]",
			"vmulpd ymm2{k3}{z},ymm6,ymm3",
			"vmulpd ymm2{k3},ymm6,ymmword ptr [rax+20h]",
			"vmulpd ymm2{k5}{z},ymm6,qword bcst [rax+8]",
			"vmulpd zmm2{k3}{z},zmm6,zmm3 {ru-sae}",
			"vmulpd zmm2{k3},zmm6,zmmword ptr [rax+40h]",
			"vmulpd zmm2{k5}{z},zmm6,qword bcst [rax+8]",
			"mulss xmm1,xmm5",
			"mulss xmm1,dword ptr [rax]",
			"vmulss xmm2,xmm6,xmm3",
			"vmulss xmm2,xmm6,dword ptr [rax]",
			"vmulss xmm2{k3},xmm6,xmm3",
			"vmulss xmm2{k3},xmm6,dword ptr [rax+4]",
			"mulsd xmm1,xmm5",
			"mulsd xmm1,qword ptr [rax]",
			"vmulsd xmm2,xmm6,xmm3",
			"vmulsd xmm2,xmm6,qword ptr [rax]",
			"vmulsd xmm2{k3}{z},xmm6,xmm3",
			"vmulsd xmm2{k3},xmm6,qword ptr [rax+8]",
			"cvtps2pd xmm1,xmm5",
			"cvtps2pd xmm1,qword ptr [rax]",
			"vcvtps2pd xmm1,xmm5",
			"vcvtps2pd xmm2,qword ptr [rax]",
			"vcvtps2pd ymm1,xmm5",
			"vcvtps2pd ymm2,xmmword ptr [rax]",
			"vcvtps2pd xmm2{k3},xmm3",
			"vcvtps2pd xmm2,qword ptr [rax+8]",
			"vcvtps2pd xmm2{k3}{z},dword bcst [rax+4]",
			"vcvtps2pd ymm2{k3},xmm3",
			"vcvtps2pd ymm2,xmmword ptr [rax+10h]",
			"vcvtps2pd ymm2{k3}{z},dword bcst [rax+4]",
			"vcvtps2pd zmm2{k3},ymm3",
			"vcvtps2pd zmm2,ymmword ptr [rax+20h]",
			"vcvtps2pd zmm2{k3}{z},dword bcst [rax+4]",
			"cvtpd2ps xmm1,xmm5",
			"cvtpd2ps xmm1,xmmword ptr [rax]",
			"vcvtpd2ps xmm1,xmm5",
			"vcvtpd2ps xmm2,xmmword ptr [rax]",
			"vcvtpd2ps xmm1,ymm5",
			"vcvtpd2ps xmm2,ymmword ptr [rax]",
		};
	}
}
#endif
