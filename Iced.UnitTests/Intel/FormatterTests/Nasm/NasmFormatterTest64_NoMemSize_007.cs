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

#if !NO_NASM_FORMATTER && !NO_FORMATTER
using System.Collections.Generic;
using Xunit;

namespace Iced.UnitTests.Intel.FormatterTests.Nasm {
	public sealed class NasmFormatterTest64_NoMemSize_007 : FormatterTest {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(int index, InstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, NasmFormatterFactory.Create_NoMemSize());
		public static IEnumerable<object[]> Format_Data => GetFormatData(infos, formattedStrings);

		static readonly InstructionInfo[] infos = InstructionInfos64_007.AllInfos;
		static readonly string[] formattedStrings = new string[InstructionInfos64_007.AllInfos_Length] {
			"a32 mov [fs:0x78563412],al",
			"mov [qword fs:0xf0debc9a78563412],ax",
			"a32 mov [fs:0x78563412],ax",
			"mov [qword fs:0xf0debc9a78563412],eax",
			"a32 mov [fs:0x78563412],eax",
			"mov [qword fs:0xf0debc9a78563412],rax",
			"a32 mov [fs:0x78563412],rax",
			"vcvtsi2ss xmm18,xmm14,{rn-sae},ebx",
			"vcvtsi2ss xmm18,xmm14,{rn-sae},rbx",
			"vcvtsi2sd xmm18,xmm14,{rn-sae},rbx",
			"vcvttss2si edx,xmm11,{sae}",
			"vcvttss2si rdx,xmm11,{sae}",
			"vcvttsd2si edx,xmm11,{sae}",
			"vcvttsd2si rdx,xmm11,{sae}",
			"vcvtss2si edx,xmm11,{rn-sae}",
			"vcvtss2si rdx,xmm11,{rn-sae}",
			"vcvtsd2si edx,xmm11,{rn-sae}",
			"vcvtsd2si rdx,xmm11,{rn-sae}",
			"vucomiss xmm18,xmm3,{sae}",
			"vucomisd xmm18,xmm3,{sae}",
			"vcomiss xmm18,xmm3,{sae}",
			"vcomisd xmm18,xmm3,{sae}",
			"vsqrtss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vsqrtsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vaddss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vaddsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vmulss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vmulsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vcvtps2pd zmm2{k3}{z},ymm3,{sae}",
			"vcvtpd2ps ymm2{k3}{z},zmm3,{rn-sae}",
			"vcvtss2sd xmm18{k3}{z},xmm14,xmm3,{sae}",
			"vcvtsd2ss xmm18{k3}{z},xmm14,xmm3,{rn-sae}",
			"vcvtdq2ps zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtqq2ps ymm2{k3}{z},zmm3,{rn-sae}",
			"vcvtps2dq zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvttps2dq zmm2{k3}{z},zmm3,{sae}",
			"vsubss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vsubsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vminss xmm2{k3}{z},xmm6,xmm3,{sae}",
			"vminsd xmm2{k3},xmm6,xmm3,{sae}",
			"vdivss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vdivsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vmaxss xmm2{k3}{z},xmm6,xmm3,{sae}",
			"vmaxsd xmm2{k3},xmm6,xmm3,{sae}",
			"vcvttps2udq zmm2{k3}{z},zmm3,{sae}",
			"vcvttpd2udq ymm2{k3}{z},zmm3,{sae}",
			"vcvttps2uqq zmm2{k3}{z},ymm3,{sae}",
			"vcvttpd2uqq zmm2{k3}{z},zmm3,{sae}",
			"vcvttss2usi edx,xmm11,{sae}",
			"vcvttss2usi rdx,xmm11,{sae}",
			"vcvttsd2usi edx,xmm11,{sae}",
			"vcvttsd2usi rdx,xmm11,{sae}",
			"vcvtps2udq zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtpd2udq ymm2{k3}{z},zmm3,{rn-sae}",
			"vcvtps2uqq zmm2{k3}{z},ymm3,{rn-sae}",
			"vcvtpd2uqq zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtss2usi edx,xmm11,{rn-sae}",
			"vcvtss2usi rdx,xmm11,{rn-sae}",
			"vcvtsd2usi edx,xmm11,{rn-sae}",
			"vcvtsd2usi rdx,xmm11,{rn-sae}",
			"vcvttps2qq zmm2{k3}{z},ymm3,{sae}",
			"vcvttpd2qq zmm2{k3}{z},zmm3,{sae}",
			"vcvtuqq2pd zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtudq2ps zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtuqq2ps ymm2{k3}{z},zmm3,{rn-sae}",
			"vcvtps2qq zmm2{k3}{z},ymm3,{rn-sae}",
			"vcvtpd2qq zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtusi2ss xmm18,xmm14,{rn-sae},ebx",
			"vcvtusi2ss xmm18,xmm14,{rn-sae},rbx",
			"vcvtusi2sd xmm18,xmm14,{rn-sae},rbx",
			"vcmpss k2{k3},xmm6,xmm3,{sae},0xa5",
			"vcmpsd k2{k3},xmm6,xmm3,{sae},0xa5",
			"vcvttpd2dq ymm2{k3}{z},zmm3,{sae}",
			"vcvtqq2pd zmm2{k3}{z},zmm3,{rn-sae}",
			"vcvtpd2dq ymm2{k3}{z},zmm3,{rn-sae}",
			"vscalefss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vscalefsd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vgetexpps zmm2{k3}{z},zmm3,{sae}",
			"vgetexppd zmm2{k3}{z},zmm3,{sae}",
			"vgetexpss xmm2{k3}{z},xmm6,xmm3,{sae}",
			"vgetexpsd xmm2{k3},xmm6,xmm3,{sae}",
			"vfmadd132ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmadd132sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub132ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub132sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd132ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd132sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub132ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub132sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmadd213ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmadd213sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub213ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub213sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd213ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd213sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub213ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub213sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmadd231ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmadd231sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub231ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfmsub231sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd231ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmadd231sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub231ss xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vfnmsub231sd xmm2{k3},xmm6,xmm3,{rz-sae}",
			"vexp2ps zmm2{k3}{z},zmm3,{sae}",
			"vexp2pd zmm2{k3}{z},zmm3,{sae}",
			"vrcp28ps zmm2{k3}{z},zmm3,{sae}",
			"vrcp28pd zmm2{k3}{z},zmm3,{sae}",
			"vrcp28ss xmm2{k3}{z},xmm6,xmm3,{sae}",
			"vrcp28sd xmm2{k3},xmm6,xmm3,{sae}",
			"vrsqrt28ps zmm2{k3}{z},zmm3,{sae}",
			"vrsqrt28pd zmm2{k3}{z},zmm3,{sae}",
			"vrsqrt28ss xmm2{k3}{z},xmm6,xmm3,{sae}",
			"vrsqrt28sd xmm2{k3},xmm6,xmm3,{sae}",
			"vrndscaleps zmm2{k3}{z},zmm3,{sae},0xa5",
			"vrndscalepd zmm2{k3}{z},zmm3,{sae},0xa5",
			"vrndscaless xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"vrndscalesd xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"vgetmantps zmm2{k3}{z},zmm3,{sae},0xa5",
			"vgetmantpd zmm2{k3}{z},zmm3,{sae},0xa5",
			"vgetmantss xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"vgetmantsd xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"vrangess xmm2{k3}{z},xmm6,xmm3,{sae},0xa5",
			"vrangesd xmm2{k3},xmm6,xmm3,{sae},0xa5",
			"vfixupimmss xmm2{k3}{z},xmm6,xmm3,{sae},0xa5",
			"vfixupimmsd xmm2{k3},xmm6,xmm3,{sae},0xa5",
			"vreduceps zmm2{k3}{z},zmm3,{sae},0xa5",
			"vreducepd zmm2{k3}{z},zmm3,{sae},0xa5",
			"vreducess xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"vreducesd xmm18{k3},xmm14,xmm3,{sae},0xa5",
			"mov eax,es",
			"mov eax,cs",
			"mov eax,ss",
			"mov eax,ds",
			"mov eax,fs",
			"mov eax,gs",
			"mov al,cl",
			"mov dl,bl",
			"mov ah,ch",
			"mov dh,bh",
			"mov spl,bpl",
			"mov sil,dil",
			"mov r8b,r9b",
			"mov r10b,r11b",
			"mov r12b,r13b",
			"mov r14b,r15b",
			"mov ax,cx",
			"mov dx,bx",
			"mov sp,bp",
			"mov si,di",
			"mov r8w,r9w",
			"mov r10w,r11w",
			"mov r12w,r13w",
			"mov r14w,r15w",
			"mov eax,ecx",
			"mov edx,ebx",
			"mov esp,ebp",
			"mov esi,edi",
			"mov r8d,r9d",
			"mov r10d,r11d",
			"mov r12d,r13d",
			"mov r14d,r15d",
			"mov rax,rcx",
			"mov rdx,rbx",
			"mov rsp,rbp",
			"mov rsi,rdi",
			"mov r8,r9",
			"mov r10,r11",
			"mov r12,r13",
			"mov r14,r15",
			"fadd st0",
			"fadd st1",
			"fadd st2",
			"fadd st3",
			"fadd st4",
			"fadd st5",
			"fadd st6",
			"fadd st7",
			"mov rax,cr0",
			"mov rax,cr1",
			"mov rax,cr2",
			"mov rax,cr3",
			"mov rax,cr4",
			"mov rax,cr5",
			"mov rax,cr6",
			"mov rax,cr7",
			"mov rax,cr8",
			"mov rax,cr9",
			"mov rax,cr10",
			"mov rax,cr11",
			"mov rax,cr12",
			"mov rax,cr13",
			"mov rax,cr14",
			"mov rax,cr15",
			"mov rax,dr0",
			"mov rax,dr1",
			"mov rax,dr2",
			"mov rax,dr3",
			"mov rax,dr4",
			"mov rax,dr5",
			"mov rax,dr6",
			"mov rax,dr7",
			"mov rax,dr8",
			"mov rax,dr9",
			"mov rax,dr10",
			"mov rax,dr11",
			"mov rax,dr12",
			"mov rax,dr13",
			"mov rax,dr14",
			"mov rax,dr15",
			"movq mm0,mm1",
			"movq mm2,mm3",
			"movq mm4,mm5",
			"movq mm6,mm7",
			"vmovups xmm0{k1},xmm1",
			"vmovups xmm2{k1},xmm3",
			"vmovups xmm4{k1},xmm5",
			"vmovups xmm6{k1},xmm7",
			"vmovups xmm8{k1},xmm9",
			"vmovups xmm10{k1},xmm11",
			"vmovups xmm12{k1},xmm13",
			"vmovups xmm14{k1},xmm15",
			"vmovups xmm16{k1},xmm17",
			"vmovups xmm18{k1},xmm19",
			"vmovups xmm20{k1},xmm21",
			"vmovups xmm22{k1},xmm23",
			"vmovups xmm24{k1},xmm25",
			"vmovups xmm26{k1},xmm27",
			"vmovups xmm28{k1},xmm29",
			"vmovups xmm30{k1},xmm31",
			"vmovups ymm0{k1},ymm1",
			"vmovups ymm2{k1},ymm3",
			"vmovups ymm4{k1},ymm5",
			"vmovups ymm6{k1},ymm7",
			"vmovups ymm8{k1},ymm9",
			"vmovups ymm10{k1},ymm11",
			"vmovups ymm12{k1},ymm13",
			"vmovups ymm14{k1},ymm15",
			"vmovups ymm16{k1},ymm17",
			"vmovups ymm18{k1},ymm19",
			"vmovups ymm20{k1},ymm21",
			"vmovups ymm22{k1},ymm23",
			"vmovups ymm24{k1},ymm25",
			"vmovups ymm26{k1},ymm27",
			"vmovups ymm28{k1},ymm29",
			"vmovups ymm30{k1},ymm31",
			"vmovups zmm0{k1},zmm1",
			"vmovups zmm2{k1},zmm3",
			"vmovups zmm4{k1},zmm5",
			"vmovups zmm6{k1},zmm7",
			"vmovups zmm8{k1},zmm9",
			"vmovups zmm10{k1},zmm11",
			"vmovups zmm12{k1},zmm13",
			"vmovups zmm14{k1},zmm15",
			"vmovups zmm16{k1},zmm17",
			"vmovups zmm18{k1},zmm19",
			"vmovups zmm20{k1},zmm21",
			"vmovups zmm22{k1},zmm23",
			"vmovups zmm24{k1},zmm25",
			"vmovups zmm26{k1},zmm27",
			"vmovups zmm28{k1},zmm29",
			"vmovups zmm30{k1},zmm31",
			"knotw k0,k1",
			"knotw k2,k3",
			"knotw k4,k5",
			"knotw k6,k7",
			"bndcn bnd0,rax",
			"bndcn bnd1,rax",
			"bndcn bnd2,rax",
			"bndcn bnd3,rax",
			"mov cl,[rax]",
			"mov cl,[rax-0x12]",
			"mov cl,[rax-0x12345678]",
			"mov cl,[rip-0x12345678]",
			"mov cl,[eip-0x12345678]",
			"mov cl,[rax+0x12]",
			"mov cl,[rax+0x12345678]",
			"mov cl,[rip+0x12345678]",
			"mov cl,[eip+0x12345678]",
			"mov cl,[rax+rcx]",
			"mov cl,[rax+rcx*2]",
			"mov cl,[rax+rcx*4]",
			"mov cl,[rax+rcx*8]",
			"mov cl,[rax+rcx-0x12]",
			"mov cl,[rax+rcx*2-0x12]",
			"mov cl,[rax+rcx*4-0x12]",
			"mov cl,[rax+rcx*8-0x12]",
			"mov cl,[rax+rcx+0x12]",
			"mov cl,[rax+rcx*2+0x12]",
			"mov cl,[rax+rcx*4+0x12]",
			"mov cl,[rax+rcx*8+0x12]",
			"mov cl,[rax+rcx-0x12345678]",
			"mov cl,[rax+rcx*2-0x12345678]",
			"mov cl,[rax+rcx*4-0x12345678]",
			"mov cl,[rax+rcx*8-0x12345678]",
			"mov cl,[rax+rcx+0x12345678]",
			"mov cl,[rax+rcx*2+0x12345678]",
			"mov cl,[rax+rcx*4+0x12345678]",
			"mov cl,[rax+rcx*8+0x12345678]",
			"mov cl,[rcx*1-0x12345678]",
			"mov cl,[rbp+rcx*2-0x12]",
			"mov cl,[rbp+rcx*4-0x12345678]",
			"mov cl,[rcx*8-0x12345678]",
			"mov cl,[rcx*1+0x12345678]",
			"mov cl,[rbp+rcx*2+0x12]",
			"mov cl,[rbp+rcx*4+0x12345678]",
			"mov cl,[rcx*8+0x12345678]",
			"mov cl,[fs:rax]",
			"mov cl,[fs:rax-0x12]",
			"mov cl,[fs:rax-0x12345678]",
			"mov cl,[fs:rip-0x12345678]",
			"mov cl,[fs:eip-0x12345678]",
			"mov cl,[fs:rax+0x12]",
			"mov cl,[fs:rax+0x12345678]",
			"mov cl,[fs:rip+0x12345678]",
			"mov cl,[fs:eip+0x12345678]",
			"mov cl,[fs:rax+rcx]",
			"mov cl,[fs:rax+rcx*2]",
			"mov cl,[fs:rax+rcx*4]",
			"mov cl,[fs:rax+rcx*8]",
			"mov cl,[fs:rax+rcx-0x12]",
			"mov cl,[fs:rax+rcx*2-0x12]",
			"mov cl,[fs:rax+rcx*4-0x12]",
			"mov cl,[fs:rax+rcx*8-0x12]",
			"mov cl,[fs:rax+rcx+0x12]",
			"mov cl,[fs:rax+rcx*2+0x12]",
			"mov cl,[fs:rax+rcx*4+0x12]",
			"mov cl,[fs:rax+rcx*8+0x12]",
			"mov cl,[fs:rax+rcx-0x12345678]",
			"mov cl,[fs:rax+rcx*2-0x12345678]",
			"mov cl,[fs:rax+rcx*4-0x12345678]",
			"mov cl,[fs:rax+rcx*8-0x12345678]",
			"mov cl,[fs:rax+rcx+0x12345678]",
			"mov cl,[fs:rax+rcx*2+0x12345678]",
			"mov cl,[fs:rax+rcx*4+0x12345678]",
			"mov cl,[fs:rax+rcx*8+0x12345678]",
			"mov cl,[fs:rcx*1-0x12345678]",
			"mov cl,[fs:rbp+rcx*2-0x12]",
			"mov cl,[fs:rbp+rcx*4-0x12345678]",
			"mov cl,[fs:rcx*8-0x12345678]",
			"mov cl,[fs:rcx*1+0x12345678]",
			"mov cl,[fs:rbp+rcx*2+0x12]",
			"mov cl,[fs:rbp+rcx*4+0x12345678]",
			"mov cl,[fs:rcx*8+0x12345678]",
			"vsqrtss xmm2{k3}{z},xmm6,xmm3,{rn-sae}",
			"vsqrtss xmm2{k3}{z},xmm6,xmm3,{rd-sae}",
			"vsqrtss xmm2{k3}{z},xmm6,xmm3,{ru-sae}",
			"vsqrtss xmm2{k3}{z},xmm6,xmm3,{rz-sae}",
			"a32 vmrun",
			"vmrun",
			"vmmcall",
			"a32 vmload",
			"vmload",
			"a32 vmsave",
			"vmsave",
			"stgi",
			"clgi",
			"skinit",
			"invlpga eax,ecx",
			"invlpga rax,ecx",
			"a32 monitorx",
			"monitorx",
			"mwaitx",
			"a32 clzero",
			"clzero",
			"prefetch [rax]",
			"prefetch-r3 [rax]",
			"prefetch-r4 [rax]",
			"prefetch-r5 [rax]",
			"prefetch-r6 [rax]",
			"prefetch-r7 [rax]",
			"femms",
			"movntss [rax],xmm1",
			"movntsd [rax],xmm1",
			"extrq xmm1,0xa5,0xfd",
			"insertq xmm2,xmm1,0xa5,0xfd",
			"extrq xmm2,xmm1",
			"insertq xmm2,xmm1",
			"vpermil2ps xmm2,xmm6,xmm3,xmm4,0",
			"vpermil2ps xmm2,xmm6,[rax],xmm4,1",
			"vpermil2ps ymm2,ymm6,ymm3,ymm5,0",
			"vpermil2ps ymm2,ymm6,[rax],ymm5,2",
			"vpermil2ps xmm2,xmm6,xmm4,xmm3,0",
			"vpermil2ps xmm2,xmm6,xmm4,[rax],1",
			"vpermil2ps ymm2,ymm6,ymm5,ymm3,0",
			"vpermil2ps ymm2,ymm6,ymm5,[rax],2",
			"vpermil2pd xmm2,xmm6,xmm3,xmm4,0",
			"vpermil2pd xmm2,xmm6,[rax],xmm4,1",
			"vpermil2pd ymm2,ymm6,ymm3,ymm5,0",
			"vpermil2pd ymm2,ymm6,[rax],ymm5,2",
			"vpermil2pd xmm2,xmm6,xmm4,xmm3,0",
			"vpermil2pd xmm2,xmm6,xmm4,[rax],1",
			"vpermil2pd ymm2,ymm6,ymm5,ymm3,0",
			"vpermil2pd ymm2,ymm6,ymm5,[rax],2",
			"vfmaddsubps xmm2,xmm6,xmm3,xmm4",
			"vfmaddsubps xmm2,xmm6,[rax],xmm4",
			"vfmaddsubps ymm2,ymm6,ymm3,ymm5",
			"vfmaddsubps ymm2,ymm6,[rax],ymm5",
			"vfmaddsubps xmm2,xmm6,xmm4,xmm3",
			"vfmaddsubps xmm2,xmm6,xmm4,[rax]",
			"vfmaddsubps ymm2,ymm6,ymm5,ymm3",
			"vfmaddsubps ymm2,ymm6,ymm5,[rax]",
			"vfmaddsubpd xmm2,xmm6,xmm3,xmm4",
			"vfmaddsubpd xmm2,xmm6,[rax],xmm4",
			"vfmaddsubpd ymm2,ymm6,ymm3,ymm5",
			"vfmaddsubpd ymm2,ymm6,[rax],ymm5",
			"vfmaddsubpd xmm2,xmm6,xmm4,xmm3",
			"vfmaddsubpd xmm2,xmm6,xmm4,[rax]",
			"vfmaddsubpd ymm2,ymm6,ymm5,ymm3",
			"vfmaddsubpd ymm2,ymm6,ymm5,[rax]",
			"vfmsubaddps xmm2,xmm6,xmm3,xmm4",
			"vfmsubaddps xmm2,xmm6,[rax],xmm4",
			"vfmsubaddps ymm2,ymm6,ymm3,ymm5",
			"vfmsubaddps ymm2,ymm6,[rax],ymm5",
			"vfmsubaddps xmm2,xmm6,xmm4,xmm3",
			"vfmsubaddps xmm2,xmm6,xmm4,[rax]",
			"vfmsubaddps ymm2,ymm6,ymm5,ymm3",
			"vfmsubaddps ymm2,ymm6,ymm5,[rax]",
			"vfmsubaddpd xmm2,xmm6,xmm3,xmm4",
			"vfmsubaddpd xmm2,xmm6,[rax],xmm4",
			"vfmsubaddpd ymm2,ymm6,ymm3,ymm5",
			"vfmsubaddpd ymm2,ymm6,[rax],ymm5",
			"vfmsubaddpd xmm2,xmm6,xmm4,xmm3",
			"vfmsubaddpd xmm2,xmm6,xmm4,[rax]",
			"vfmsubaddpd ymm2,ymm6,ymm5,ymm3",
			"vfmsubaddpd ymm2,ymm6,ymm5,[rax]",
			"vfmaddps xmm2,xmm6,xmm3,xmm4",
			"vfmaddps xmm2,xmm6,[rax],xmm4",
			"vfmaddps ymm2,ymm6,ymm3,ymm5",
			"vfmaddps ymm2,ymm6,[rax],ymm5",
			"vfmaddps xmm2,xmm6,xmm4,xmm3",
			"vfmaddps xmm2,xmm6,xmm4,[rax]",
			"vfmaddps ymm2,ymm6,ymm5,ymm3",
			"vfmaddps ymm2,ymm6,ymm5,[rax]",
			"vfmaddpd xmm2,xmm6,xmm3,xmm4",
			"vfmaddpd xmm2,xmm6,[rax],xmm4",
			"vfmaddpd ymm2,ymm6,ymm3,ymm5",
			"vfmaddpd ymm2,ymm6,[rax],ymm5",
			"vfmaddpd xmm2,xmm6,xmm4,xmm3",
			"vfmaddpd xmm2,xmm6,xmm4,[rax]",
			"vfmaddpd ymm2,ymm6,ymm5,ymm3",
			"vfmaddpd ymm2,ymm6,ymm5,[rax]",
			"vfmaddss xmm2,xmm6,xmm3,xmm4",
			"vfmaddss xmm2,xmm6,[rax],xmm4",
			"vfmaddss xmm2,xmm6,xmm4,xmm3",
			"vfmaddss xmm2,xmm6,xmm4,[rax]",
			"vfmaddsd xmm2,xmm6,xmm3,xmm4",
			"vfmaddsd xmm2,xmm6,[rax],xmm4",
			"vfmaddsd xmm2,xmm6,xmm4,xmm3",
			"vfmaddsd xmm2,xmm6,xmm4,[rax]",
			"vfmsubps xmm2,xmm6,xmm3,xmm4",
			"vfmsubps xmm2,xmm6,[rax],xmm4",
			"vfmsubps ymm2,ymm6,ymm3,ymm5",
			"vfmsubps ymm2,ymm6,[rax],ymm5",
			"vfmsubps xmm2,xmm6,xmm4,xmm3",
			"vfmsubps xmm2,xmm6,xmm4,[rax]",
			"vfmsubps ymm2,ymm6,ymm5,ymm3",
			"vfmsubps ymm2,ymm6,ymm5,[rax]",
			"vfmsubpd xmm2,xmm6,xmm3,xmm4",
			"vfmsubpd xmm2,xmm6,[rax],xmm4",
			"vfmsubpd ymm2,ymm6,ymm3,ymm5",
			"vfmsubpd ymm2,ymm6,[rax],ymm5",
			"vfmsubpd xmm2,xmm6,xmm4,xmm3",
			"vfmsubpd xmm2,xmm6,xmm4,[rax]",
			"vfmsubpd ymm2,ymm6,ymm5,ymm3",
			"vfmsubpd ymm2,ymm6,ymm5,[rax]",
			"vfmsubss xmm2,xmm6,xmm3,xmm4",
			"vfmsubss xmm2,xmm6,[rax],xmm4",
			"vfmsubss xmm2,xmm6,xmm4,xmm3",
			"vfmsubss xmm2,xmm6,xmm4,[rax]",
			"vfmsubsd xmm2,xmm6,xmm3,xmm4",
			"vfmsubsd xmm2,xmm6,[rax],xmm4",
			"vfmsubsd xmm2,xmm6,xmm4,xmm3",
			"vfmsubsd xmm2,xmm6,xmm4,[rax]",
			"vfnmaddps xmm2,xmm6,xmm3,xmm4",
			"vfnmaddps xmm2,xmm6,[rax],xmm4",
			"vfnmaddps ymm2,ymm6,ymm3,ymm5",
			"vfnmaddps ymm2,ymm6,[rax],ymm5",
			"vfnmaddps xmm2,xmm6,xmm4,xmm3",
			"vfnmaddps xmm2,xmm6,xmm4,[rax]",
			"vfnmaddps ymm2,ymm6,ymm5,ymm3",
			"vfnmaddps ymm2,ymm6,ymm5,[rax]",
			"vfnmaddpd xmm2,xmm6,xmm3,xmm4",
			"vfnmaddpd xmm2,xmm6,[rax],xmm4",
			"vfnmaddpd ymm2,ymm6,ymm3,ymm5",
			"vfnmaddpd ymm2,ymm6,[rax],ymm5",
			"vfnmaddpd xmm2,xmm6,xmm4,xmm3",
			"vfnmaddpd xmm2,xmm6,xmm4,[rax]",
			"vfnmaddpd ymm2,ymm6,ymm5,ymm3",
			"vfnmaddpd ymm2,ymm6,ymm5,[rax]",
			"vfnmaddss xmm2,xmm6,xmm3,xmm4",
			"vfnmaddss xmm2,xmm6,[rax],xmm4",
			"vfnmaddss xmm2,xmm6,xmm4,xmm3",
			"vfnmaddss xmm2,xmm6,xmm4,[rax]",
			"vfnmaddsd xmm2,xmm6,xmm3,xmm4",
			"vfnmaddsd xmm2,xmm6,[rax],xmm4",
			"vfnmaddsd xmm2,xmm6,xmm4,xmm3",
			"vfnmaddsd xmm2,xmm6,xmm4,[rax]",
			"vfnmsubps xmm2,xmm6,xmm3,xmm4",
			"vfnmsubps xmm2,xmm6,[rax],xmm4",
			"vfnmsubps ymm2,ymm6,ymm3,ymm5",
			"vfnmsubps ymm2,ymm6,[rax],ymm5",
			"vfnmsubps xmm2,xmm6,xmm4,xmm3",
			"vfnmsubps xmm2,xmm6,xmm4,[rax]",
			"vfnmsubps ymm2,ymm6,ymm5,ymm3",
			"vfnmsubps ymm2,ymm6,ymm5,[rax]",
			"vfnmsubpd xmm2,xmm6,xmm3,xmm4",
			"vfnmsubpd xmm2,xmm6,[rax],xmm4",
			"vfnmsubpd ymm2,ymm6,ymm3,ymm5",
			"vfnmsubpd ymm2,ymm6,[rax],ymm5",
			"vfnmsubpd xmm2,xmm6,xmm4,xmm3",
			"vfnmsubpd xmm2,xmm6,xmm4,[rax]",
			"vfnmsubpd ymm2,ymm6,ymm5,ymm3",
			"vfnmsubpd ymm2,ymm6,ymm5,[rax]",
			"vfnmsubss xmm2,xmm6,xmm3,xmm4",
			"vfnmsubss xmm2,xmm6,[rax],xmm4",
			"vfnmsubss xmm2,xmm6,xmm4,xmm3",
			"vfnmsubss xmm2,xmm6,xmm4,[rax]",
			"vfnmsubsd xmm2,xmm6,xmm3,xmm4",
			"vfnmsubsd xmm2,xmm6,[rax],xmm4",
			"vfnmsubsd xmm2,xmm6,xmm4,xmm3",
			"vfnmsubsd xmm2,xmm6,xmm4,[rax]",
			"vpmacssww xmm2,xmm6,xmm3,xmm4",
			"vpmacssww xmm2,xmm6,[rax],xmm4",
			"vpmacsswd xmm2,xmm6,xmm3,xmm4",
			"vpmacsswd xmm2,xmm6,[rax],xmm4",
			"vpmacssdql xmm2,xmm6,xmm3,xmm4",
			"vpmacssdql xmm2,xmm6,[rax],xmm4",
			"vpmacssdd xmm2,xmm6,xmm3,xmm4",
			"vpmacssdd xmm2,xmm6,[rax],xmm4",
			"vpmacssdqh xmm2,xmm6,xmm3,xmm4",
			"vpmacssdqh xmm2,xmm6,[rax],xmm4",
			"vpmacsww xmm2,xmm6,xmm3,xmm4",
			"vpmacsww xmm2,xmm6,[rax],xmm4",
			"vpmacswd xmm2,xmm6,xmm3,xmm4",
			"vpmacswd xmm2,xmm6,[rax],xmm4",
			"vpmacsdql xmm2,xmm6,xmm3,xmm4",
			"vpmacsdql xmm2,xmm6,[rax],xmm4",
			"vpmacsdd xmm2,xmm6,xmm3,xmm4",
			"vpmacsdd xmm2,xmm6,[rax],xmm4",
			"vpmacsdqh xmm2,xmm6,xmm3,xmm4",
			"vpmacsdqh xmm2,xmm6,[rax],xmm4",
			"vpcmov xmm2,xmm6,xmm3,xmm4",
			"vpcmov xmm2,xmm6,[rax],xmm4",
			"vpcmov ymm2,ymm6,ymm3,ymm5",
			"vpcmov ymm2,ymm6,[rax],ymm5",
			"vpcmov xmm2,xmm6,xmm4,xmm3",
			"vpcmov xmm2,xmm6,xmm4,[rax]",
			"vpcmov ymm2,ymm6,ymm5,ymm3",
			"vpcmov ymm2,ymm6,ymm5,[rax]",
			"vpperm xmm2,xmm6,xmm3,xmm4",
			"vpperm xmm2,xmm6,[rax],xmm4",
			"vpperm xmm2,xmm6,xmm4,xmm3",
			"vpperm xmm2,xmm6,xmm4,[rax]",
			"vpmadcsswd xmm2,xmm6,xmm3,xmm4",
			"vpmadcsswd xmm2,xmm6,[rax],xmm4",
			"vpmadcswd xmm2,xmm6,xmm3,xmm4",
			"vpmadcswd xmm2,xmm6,[rax],xmm4",
			"vprotb xmm2,xmm3,0xa5",
			"vprotb xmm2,[rax],0xa5",
			"vprotw xmm2,xmm3,0xa5",
			"vprotw xmm2,[rax],0xa5",
			"vprotd xmm2,xmm3,0xa5",
			"vprotd xmm2,[rax],0xa5",
			"vprotq xmm2,xmm3,0xa5",
			"vprotq xmm2,[rax],0xa5",
			"vpcomb xmm2,xmm6,xmm3,0xa5",
			"vpcomb xmm2,xmm6,[rax],0xa5",
			"vpcomw xmm2,xmm6,xmm3,0xa5",
			"vpcomw xmm2,xmm6,[rax],0xa5",
			"vpcomd xmm2,xmm6,xmm3,0xa5",
			"vpcomd xmm2,xmm6,[rax],0xa5",
			"vpcomq xmm2,xmm6,xmm3,0xa5",
			"vpcomq xmm2,xmm6,[rax],0xa5",
			"vpcomub xmm2,xmm6,xmm3,0xa5",
			"vpcomub xmm2,xmm6,[rax],0xa5",
			"vpcomuw xmm2,xmm6,xmm3,0xa5",
			"vpcomuw xmm2,xmm6,[rax],0xa5",
			"vpcomud xmm2,xmm6,xmm3,0xa5",
			"vpcomud xmm2,xmm6,[rax],0xa5",
			"vpcomuq xmm2,xmm6,xmm3,0xa5",
			"vpcomuq xmm2,xmm6,[rax],0xa5",
			"blcfill esi,ebx",
			"blcfill esi,[rax]",
			"blcfill rsi,rbx",
			"blcfill rsi,[rax]",
			"blsfill esi,ebx",
			"blsfill esi,[rax]",
			"blsfill rsi,rbx",
			"blsfill rsi,[rax]",
			"blcs esi,ebx",
			"blcs esi,[rax]",
			"blcs rsi,rbx",
			"blcs rsi,[rax]",
			"tzmsk esi,ebx",
			"tzmsk esi,[rax]",
			"tzmsk rsi,rbx",
			"tzmsk rsi,[rax]",
			"blcic esi,ebx",
			"blcic esi,[rax]",
			"blcic rsi,rbx",
			"blcic rsi,[rax]",
			"blsic esi,ebx",
			"blsic esi,[rax]",
			"blsic rsi,rbx",
			"blsic rsi,[rax]",
			"t1mskc esi,ebx",
			"t1mskc esi,[rax]",
			"t1mskc rsi,rbx",
			"t1mskc rsi,[rax]",
			"blcmsk esi,ebx",
			"blcmsk esi,[rax]",
			"blcmsk rsi,rbx",
			"blcmsk rsi,[rax]",
			"blci esi,ebx",
			"blci esi,[rax]",
			"blci rsi,rbx",
			"blci rsi,[rax]",
			"llwpcb ebx",
			"llwpcb rbx",
			"slwpcb ebx",
			"slwpcb rbx",
			"vfrczps xmm1,xmm5",
			"vfrczps xmm2,[rax]",
			"vfrczps ymm1,ymm5",
			"vfrczps ymm2,[rax]",
			"vfrczpd xmm1,xmm5",
			"vfrczpd xmm2,[rax]",
			"vfrczpd ymm1,ymm5",
			"vfrczpd ymm2,[rax]",
			"vfrczss xmm1,xmm5",
			"vfrczss xmm2,[rax]",
			"vfrczsd xmm1,xmm5",
			"vfrczsd xmm2,[rax]",
			"vprotb xmm2,xmm3,xmm6",
			"vprotb xmm2,[rax],xmm6",
			"vprotb xmm2,xmm6,xmm3",
			"vprotb xmm2,xmm6,[rax]",
			"vprotw xmm2,xmm3,xmm6",
			"vprotw xmm2,[rax],xmm6",
			"vprotw xmm2,xmm6,xmm3",
			"vprotw xmm2,xmm6,[rax]",
			"vprotd xmm2,xmm3,xmm6",
			"vprotd xmm2,[rax],xmm6",
			"vprotd xmm2,xmm6,xmm3",
			"vprotd xmm2,xmm6,[rax]",
			"vprotq xmm2,xmm3,xmm6",
			"vprotq xmm2,[rax],xmm6",
			"vprotq xmm2,xmm6,xmm3",
			"vprotq xmm2,xmm6,[rax]",
			"vpshlb xmm2,xmm3,xmm6",
			"vpshlb xmm2,[rax],xmm6",
			"vpshlb xmm2,xmm6,xmm3",
			"vpshlb xmm2,xmm6,[rax]",
			"vpshlw xmm2,xmm3,xmm6",
			"vpshlw xmm2,[rax],xmm6",
			"vpshlw xmm2,xmm6,xmm3",
			"vpshlw xmm2,xmm6,[rax]",
			"vpshld xmm2,xmm3,xmm6",
			"vpshld xmm2,[rax],xmm6",
			"vpshld xmm2,xmm6,xmm3",
			"vpshld xmm2,xmm6,[rax]",
			"vpshlq xmm2,xmm3,xmm6",
			"vpshlq xmm2,[rax],xmm6",
			"vpshlq xmm2,xmm6,xmm3",
			"vpshlq xmm2,xmm6,[rax]",
			"vpshab xmm2,xmm3,xmm6",
			"vpshab xmm2,[rax],xmm6",
			"vpshab xmm2,xmm6,xmm3",
			"vpshab xmm2,xmm6,[rax]",
			"vpshaw xmm2,xmm3,xmm6",
			"vpshaw xmm2,[rax],xmm6",
			"vpshaw xmm2,xmm6,xmm3",
			"vpshaw xmm2,xmm6,[rax]",
			"vpshad xmm2,xmm3,xmm6",
			"vpshad xmm2,[rax],xmm6",
			"vpshad xmm2,xmm6,xmm3",
			"vpshad xmm2,xmm6,[rax]",
			"vpshaq xmm2,xmm3,xmm6",
			"vpshaq xmm2,[rax],xmm6",
			"vpshaq xmm2,xmm6,xmm3",
			"vpshaq xmm2,xmm6,[rax]",
			"vphaddbw xmm1,xmm5",
			"vphaddbw xmm2,[rax]",
			"vphaddbd xmm1,xmm5",
			"vphaddbd xmm2,[rax]",
			"vphaddbq xmm1,xmm5",
			"vphaddbq xmm2,[rax]",
			"vphaddwd xmm1,xmm5",
			"vphaddwd xmm2,[rax]",
			"vphaddwq xmm1,xmm5",
			"vphaddwq xmm2,[rax]",
			"vphadddq xmm1,xmm5",
			"vphadddq xmm2,[rax]",
			"vphaddubw xmm1,xmm5",
			"vphaddubw xmm2,[rax]",
			"vphaddubd xmm1,xmm5",
			"vphaddubd xmm2,[rax]",
			"vphaddubq xmm1,xmm5",
			"vphaddubq xmm2,[rax]",
			"vphadduwd xmm1,xmm5",
			"vphadduwd xmm2,[rax]",
			"vphadduwq xmm1,xmm5",
			"vphadduwq xmm2,[rax]",
			"vphaddudq xmm1,xmm5",
			"vphaddudq xmm2,[rax]",
			"vphsubbw xmm1,xmm5",
			"vphsubbw xmm2,[rax]",
			"vphsubwd xmm1,xmm5",
			"vphsubwd xmm2,[rax]",
			"vphsubdq xmm1,xmm5",
			"vphsubdq xmm2,[rax]",
			"bextr edx,ebx,0xa55a1234",
			"bextr edx,[rax],0x34125aa5",
			"bextr rdx,rbx,0xa55a1234",
			"bextr rdx,[rax],0xa55a1234",
			"lwpins esi,ebx,0xa55a1234",
			"lwpins esi,[rax],0xa55a1234",
			"lwpins rsi,ebx,0xa55a1234",
			"lwpins rsi,[rax],0xa55a1234",
			"lwpval esi,ebx,0xa55a1234",
			"lwpval esi,[rax],0xa55a1234",
			"lwpval rsi,ebx,0xa55a1234",
			"lwpval rsi,[rax],0xa55a1234",
			"pi2fw mm1,mm5",
			"pi2fw mm1,[rax-0x5aa5edcc]",
			"pi2fd mm1,mm5",
			"pi2fd mm1,[rax-0x5aa5edcc]",
			"pf2iw mm1,mm5",
			"pf2iw mm1,[rax-0x5aa5edcc]",
			"pf2id mm1,mm5",
			"pf2id mm1,[rax-0x5aa5edcc]",
			"pfrcpv mm1,mm5",
			"pfrcpv mm1,[rax-0x5aa5edcc]",
			"pfrsqrtv mm1,mm5",
			"pfrsqrtv mm1,[rax-0x5aa5edcc]",
			"pfnacc mm1,mm5",
			"pfnacc mm1,[rax-0x5aa5edcc]",
			"pfpnacc mm1,mm5",
			"pfpnacc mm1,[rax-0x5aa5edcc]",
			"pfcmpge mm1,mm5",
			"pfcmpge mm1,[rax-0x5aa5edcc]",
			"pfmin mm1,mm5",
			"pfmin mm1,[rax-0x5aa5edcc]",
			"pfrcp mm1,mm5",
			"pfrcp mm1,[rax-0x5aa5edcc]",
			"pfrsqrt mm1,mm5",
			"pfrsqrt mm1,[rax-0x5aa5edcc]",
			"pfsub mm1,mm5",
			"pfsub mm1,[rax-0x5aa5edcc]",
			"pfadd mm1,mm5",
			"pfadd mm1,[rax-0x5aa5edcc]",
			"pfcmpgt mm1,mm5",
			"pfcmpgt mm1,[rax-0x5aa5edcc]",
			"pfmax mm1,mm5",
			"pfmax mm1,[rax-0x5aa5edcc]",
			"pfrcpit1 mm1,mm5",
			"pfrcpit1 mm1,[rax-0x5aa5edcc]",
			"pfrsqit1 mm1,mm5",
			"pfrsqit1 mm1,[rax-0x5aa5edcc]",
			"pfsubr mm1,mm5",
			"pfsubr mm1,[rax-0x5aa5edcc]",
			"pfacc mm1,mm5",
			"pfacc mm1,[rax-0x5aa5edcc]",
			"pfcmpeq mm1,mm5",
			"pfcmpeq mm1,[rax-0x5aa5edcc]",
			"pfmul mm1,mm5",
			"pfmul mm1,[rax-0x5aa5edcc]",
			"pfrcpit2 mm1,mm5",
			"pfrcpit2 mm1,[rax-0x5aa5edcc]",
			"pmulhrwa mm1,mm5",
			"pmulhrwa mm1,[rax-0x5aa5edcc]",
			"pswapd mm1,mm5",
			"pswapd mm1,[rax-0x5aa5edcc]",
			"pavgusb mm1,mm5",
			"pavgusb mm1,[rax-0x5aa5edcc]",
			"sal bh,0x5a",
			"sal byte [rax],0x5a",
			"sal di,0x5a",
			"sal word [rax],0x5a",
			"sal edi,0x5a",
			"sal dword [rax],0x5a",
			"sal rdi,0x5a",
			"sal qword [rax],0x5a",
			"sal bh,1",
			"sal byte [rax],1",
			"sal di,1",
			"sal word [rax],1",
			"sal edi,1",
			"sal dword [rax],1",
			"sal rdi,1",
			"sal qword [rax],1",
			"sal bh,cl",
			"sal byte [rax],cl",
			"sal di,cl",
			"sal word [rax],cl",
			"sal edi,cl",
			"sal dword [rax],cl",
			"sal rdi,cl",
			"sal qword [rax],cl",
			"fstpnce st3",
			"fneni",
			"fndisi",
			"fnsetpm",
			"fcom st3",
			"fcomp st3",
			"fxch st3",
			"fcomp st3",
			"ffreep st3",
			"fxch st3",
			"fstp st3",
			"fstp st3",
			"test dh,0xa5",
			"test byte [rax],0xa5",
			"test si,0x5aa5",
			"test word [rax],0x5aa5",
			"test esi,0xab895aa5",
			"test dword [rax],0xab895aa5",
			"test rsi,0xffffffffab895aa5",
			"test qword [rax],0xffffffffab895aa5",
			"rstorssp [rax]",
			"pconfig",
			"setssbsy",
			"saveprevssp",
			"wbnoinvd",
			"cl1invmb",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"reserved-nop si,cx",
			"reserved-nop [rax],bx",
			"reserved-nop esi,ecx",
			"reserved-nop [rax],ebx",
			"reserved-nop rsi,rcx",
			"reserved-nop [rax],rbx",
			"cldemote [rax]",
			"rdsspd ecx",
			"rdsspq rcx",
			"endbr64",
			"endbr32",
			"incsspd ebp",
			"incsspq rbp",
			"tpause ebp",
			"tpause rbp",
			"clrssbsy [rax]",
			"umonitor ebp",
			"umonitor rbp",
			"umwait ebp",
			"umwait rbp",
			"lfence",
			"lfence",
			"lfence",
			"lfence",
			"lfence",
			"lfence",
			"lfence",
			"mfence",
			"mfence",
			"mfence",
			"mfence",
			"mfence",
			"mfence",
			"mfence",
			"sfence",
			"sfence",
			"sfence",
			"sfence",
			"sfence",
			"sfence",
			"sfence",
			"pcommit",
			"vpdpbusd xmm18{k3},xmm14,xmm3",
			"vpdpbusd xmm2,xmm6,[rax+0x10]",
			"vpdpbusd xmm2{k5}{z},xmm6,[rax+4]{1to4}",
			"vpdpbusd ymm18{k3},ymm14,ymm3",
			"vpdpbusd ymm2{k3},ymm6,[rax+0x20]",
			"vpdpbusd ymm2{k5}{z},ymm6,[rax+4]{1to8}",
			"vpdpbusd zmm2{k3}{z},zmm6,zmm3",
			"vpdpbusd zmm2,zmm6,[rax+0x40]",
			"vpdpbusd zmm2{k5}{z},zmm6,[rax+4]{1to16}",
			"vpdpbusds xmm18{k3},xmm14,xmm3",
			"vpdpbusds xmm2,xmm6,[rax+0x10]",
			"vpdpbusds xmm2{k5}{z},xmm6,[rax+4]{1to4}",
			"vpdpbusds ymm18{k3},ymm14,ymm3",
			"vpdpbusds ymm2{k3},ymm6,[rax+0x20]",
			"vpdpbusds ymm2{k5}{z},ymm6,[rax+4]{1to8}",
			"vpdpbusds zmm2{k3}{z},zmm6,zmm3",
			"vpdpbusds zmm2,zmm6,[rax+0x40]",
			"vpdpbusds zmm2{k5}{z},zmm6,[rax+4]{1to16}",
			"vpdpwssd xmm18{k3},xmm14,xmm3",
			"vpdpwssd xmm2,xmm6,[rax+0x10]",
			"vpdpwssd xmm2{k5}{z},xmm6,[rax+4]{1to4}",
			"vpdpwssd ymm18{k3},ymm14,ymm3",
			"vpdpwssd ymm2{k3},ymm6,[rax+0x20]",
			"vpdpwssd ymm2{k5}{z},ymm6,[rax+4]{1to8}",
			"vpdpwssd zmm2{k3}{z},zmm6,zmm3",
			"vpdpwssd zmm2,zmm6,[rax+0x40]",
			"vpdpwssd zmm2{k5}{z},zmm6,[rax+4]{1to16}",
			"vpdpwssds xmm18{k3},xmm14,xmm3",
			"vpdpwssds xmm2,xmm6,[rax+0x10]",
			"vpdpwssds xmm2{k5}{z},xmm6,[rax+4]{1to4}",
			"vpdpwssds ymm18{k3},ymm14,ymm3",
			"vpdpwssds ymm2{k3},ymm6,[rax+0x20]",
			"vpdpwssds ymm2{k5}{z},ymm6,[rax+4]{1to8}",
			"vpdpwssds zmm2{k3}{z},zmm6,zmm3",
			"vpdpwssds zmm2,zmm6,[rax+0x40]",
			"vpdpwssds zmm2{k5}{z},zmm6,[rax+4]{1to16}",
			"vpopcntb xmm2,xmm3",
			"vpopcntb xmm2,[rax+0x10]",
			"vpopcntb ymm2{k3},ymm3",
			"vpopcntb ymm2{k3}{z},[rax+0x20]",
			"vpopcntb zmm10{k3}{z},zmm19",
			"vpopcntb zmm2{k3}{z},[rax+0x40]",
			"vpopcntw xmm2,xmm3",
			"vpopcntw xmm2,[rax+0x10]",
			"vpopcntw ymm2{k3},ymm3",
			"vpopcntw ymm2{k3}{z},[rax+0x20]",
			"vpopcntw zmm10{k3}{z},zmm19",
			"vpopcntw zmm2{k3}{z},[rax+0x40]",
			"vpopcntd xmm18{k3},xmm3",
			"vpopcntd xmm2,[rax+0x10]",
			"vpopcntd xmm2{k5}{z},[rax+4]{1to4}",
			"vpopcntd ymm18{k3},ymm3",
			"vpopcntd ymm2{k3},[rax+0x20]",
			"vpopcntd ymm2{k5}{z},[rax+4]{1to8}",
			"vpopcntd zmm2{k3}{z},zmm3",
			"vpopcntd zmm2,[rax+0x40]",
			"vpopcntd zmm2{k5}{z},[rax+4]{1to16}",
			"vpopcntq xmm18{k3},xmm3",
			"vpopcntq xmm2,[rax+0x10]",
			"vpopcntq xmm2{k5}{z},[rax+8]{1to2}",
			"vpopcntq ymm18{k3},ymm3",
			"vpopcntq ymm2{k3},[rax+0x20]",
			"vpopcntq ymm2{k5}{z},[rax+8]{1to4}",
			"vpopcntq zmm2{k3}{z},zmm3",
			"vpopcntq zmm2,[rax+0x40]",
			"vpopcntq zmm2{k5}{z},[rax+8]{1to8}",
			"vpexpandb xmm2,xmm3",
			"vpexpandb xmm2,[rax+1]",
			"vpexpandb ymm2{k3},ymm3",
			"vpexpandb ymm2{k3}{z},[rax+1]",
			"vpexpandb zmm10{k3}{z},zmm19",
			"vpexpandb zmm2{k3}{z},[rax+1]",
			"vpexpandw xmm2,xmm3",
			"vpexpandw xmm2,[rax+2]",
			"vpexpandw ymm2{k3},ymm3",
			"vpexpandw ymm2{k3}{z},[rax+2]",
			"vpexpandw zmm10{k3}{z},zmm19",
			"vpexpandw zmm2{k3}{z},[rax+2]",
			"vpcompressb xmm3,xmm2",
			"vpcompressb [rax+1],xmm2",
			"vpcompressb ymm3{k3},ymm2",
			"vpcompressb [rax+1]{k3},ymm2",
		};
	}
}
#endif
