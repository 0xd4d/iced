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
	public sealed class GasFormatterTest64_NoSuffix_003 : FormatterTest {
		[Theory]
		[MemberData(nameof(Format_Data))]
		void Format(int index, InstructionInfo info, string formattedString) => FormatBase(index, info, formattedString, GasFormatterFactory.Create_NoSuffix());
		public static IEnumerable<object[]> Format_Data => GetFormatData(infos, formattedStrings);

		static readonly InstructionInfo[] infos = InstructionInfos64_003.AllInfos;
		static readonly string[] formattedStrings = new string[InstructionInfos64_003.AllInfos_Length] {
			"vmovdqa64 %zmm2,%zmm3",
			"vmovdqa64 %zmm2,0x40(%rax)",
			"movdqu %xmm1,%xmm5",
			"movdqu %xmm1,(%rax)",
			"vmovdqu %xmm1,%xmm5",
			"vmovdqu %xmm2,(%rax)",
			"vmovdqu %ymm1,%ymm5",
			"vmovdqu %ymm2,(%rax)",
			"vmovdqu32 %xmm2,%xmm3",
			"vmovdqu32 %xmm2,0x10(%rax)",
			"vmovdqu32 %ymm2,%ymm3",
			"vmovdqu32 %ymm2,0x20(%rax)",
			"vmovdqu32 %zmm2,%zmm3",
			"vmovdqu32 %zmm2,0x40(%rax)",
			"vmovdqu64 %xmm2,%xmm3",
			"vmovdqu64 %xmm2,0x10(%rax)",
			"vmovdqu64 %ymm2,%ymm3",
			"vmovdqu64 %ymm2,0x20(%rax)",
			"vmovdqu64 %zmm2,%zmm3",
			"vmovdqu64 %zmm2,0x40(%rax)",
			"vmovdqu8 %xmm2,%xmm3",
			"vmovdqu8 %xmm2,0x10(%rax)",
			"vmovdqu8 %ymm2,%ymm3",
			"vmovdqu8 %ymm2,0x20(%rax)",
			"vmovdqu8 %zmm2,%zmm3",
			"vmovdqu8 %zmm2,0x40(%rax)",
			"vmovdqu16 %xmm2,%xmm3",
			"vmovdqu16 %xmm2,0x10(%rax)",
			"vmovdqu16 %ymm2,%ymm3",
			"vmovdqu16 %ymm2,0x20(%rax)",
			"vmovdqu16 %zmm2,%zmm3",
			"vmovdqu16 %zmm2,0x40(%rax)",
			"jo 0x800000003412a550",
			"jno 0x800000003412a550",
			"jb 0x800000003412a550",
			"jae 0x800000003412a550",
			"je 0x800000003412a550",
			"jne 0x800000003412a550",
			"jbe 0x800000003412a550",
			"ja 0x800000003412a550",
			"js 0x800000003412a550",
			"jns 0x800000003412a550",
			"jp 0x800000003412a550",
			"jnp 0x800000003412a550",
			"jl 0x800000003412a550",
			"jge 0x800000003412a550",
			"jle 0x800000003412a550",
			"jg 0x800000003412a550",
			"seto %al",
			"setno %al",
			"setb %al",
			"setae %al",
			"sete %al",
			"setne %al",
			"setbe %al",
			"seta %al",
			"sets %al",
			"setns %al",
			"setp %al",
			"setnp %al",
			"setl %al",
			"setge %al",
			"setle %al",
			"setg %al",
			"seto (%rax)",
			"setno (%rax)",
			"setb (%rax)",
			"setae (%rax)",
			"sete (%rax)",
			"setne (%rax)",
			"setbe (%rax)",
			"seta (%rax)",
			"sets (%rax)",
			"setns (%rax)",
			"setp (%rax)",
			"setnp (%rax)",
			"setl (%rax)",
			"setge (%rax)",
			"setle (%rax)",
			"setg (%rax)",
			"kmovw %k3,%k2",
			"kmovw (%rax),%k1",
			"kmovq %k3,%k2",
			"kmovq (%rax),%k1",
			"kmovb %k3,%k2",
			"kmovb (%rax),%k1",
			"kmovd %k3,%k2",
			"kmovd (%rax),%k1",
			"kmovw %k1,(%rax)",
			"kmovq %k1,(%rax)",
			"kmovb %k1,(%rax)",
			"kmovd %k1,(%rax)",
			"kmovw %ebx,%k2",
			"kmovb %ebx,%k2",
			"kmovq %rbx,%k2",
			"kmovd %ebx,%k2",
			"kmovw %k3,%edx",
			"kmovb %k3,%edx",
			"kmovq %k3,%rdx",
			"kmovd %k3,%edx",
			"kortestw %k3,%k2",
			"kortestq %k3,%k2",
			"kortestb %k3,%k2",
			"kortestd %k3,%k2",
			"ktestw %k3,%k2",
			"ktestq %k3,%k2",
			"ktestb %k3,%k2",
			"ktestd %k3,%k2",
			"pushw %fs",
			"push %fs",
			"popw %fs",
			"pop %fs",
			"cpuid",
			"bt %cx,%si",
			"bt %bx,(%rax)",
			"bt %ecx,%esi",
			"bt %ebx,(%rax)",
			"bt %rcx,%rsi",
			"bt %rbx,(%rax)",
			"shld $0x5a,%cx,%si",
			"shld $0x5a,%bx,(%rax)",
			"shld $0x5a,%ecx,%esi",
			"shld $0x5a,%ebx,(%rax)",
			"shld $0x5a,%rcx,%rsi",
			"shld $0x5a,%rbx,(%rax)",
			"shld %cl,%cx,%si",
			"shld %cl,%bx,(%rax)",
			"shld %cl,%ecx,%esi",
			"shld %cl,%ebx,(%rax)",
			"shld %cl,%rcx,%rsi",
			"shld %cl,%rbx,(%rax)",
			"pushw %gs",
			"push %gs",
			"popw %gs",
			"pop %gs",
			"rsm",
			"bts %cx,%si",
			"bts %bx,(%rax)",
			"bts %ecx,%esi",
			"bts %ebx,(%rax)",
			"bts %rcx,%rsi",
			"bts %rbx,(%rax)",
			"shrd $0x5a,%cx,%si",
			"shrd $0x5a,%bx,(%rax)",
			"shrd $0x5a,%ecx,%esi",
			"shrd $0x5a,%ebx,(%rax)",
			"shrd $0x5a,%rcx,%rsi",
			"shrd $0x5a,%rbx,(%rax)",
			"shrd %cl,%cx,%si",
			"shrd %cl,%bx,(%rax)",
			"shrd %cl,%ecx,%esi",
			"shrd %cl,%ebx,(%rax)",
			"shrd %cl,%rcx,%rsi",
			"shrd %cl,%rbx,(%rax)",
			"fxsave (%rax)",
			"fxsave64 (%rax)",
			"rdfsbase %ebp",
			"rdfsbase %rbp",
			"fxrstor (%rax)",
			"fxrstor64 (%rax)",
			"rdgsbase %ebp",
			"rdgsbase %rbp",
			"ldmxcsr (%rax)",
			"wrfsbase %ebp",
			"wrfsbase %rbp",
			"vldmxcsr (%rax)",
			"stmxcsr (%rax)",
			"wrgsbase %ebp",
			"wrgsbase %rbp",
			"vstmxcsr (%rax)",
			"xsave (%rax)",
			"xsave64 (%rax)",
			"ptwrite %ebp",
			"ptwritel (%rax)",
			"ptwrite %rbp",
			"ptwriteq (%rax)",
			"xrstor (%rax)",
			"xrstor64 (%rax)",
			"xsaveopt (%rax)",
			"xsaveopt64 (%rax)",
			"clwb (%rax)",
			"clflush (%rax)",
			"clflushopt (%rax)",
			"lfence",
			"mfence",
			"sfence",
			"imul %si,%cx",
			"imul (%rax),%bx",
			"imul %esi,%ecx",
			"imul (%rax),%ebx",
			"imul %rsi,%rcx",
			"imul (%rax),%rbx",
			"cmpxchg %cl,%dh",
			"cmpxchg %bh,(%rax)",
			"cmpxchg %cx,%si",
			"cmpxchg %bx,(%rax)",
			"cmpxchg %ecx,%esi",
			"cmpxchg %ebx,(%rax)",
			"cmpxchg %rcx,%rsi",
			"cmpxchg %rbx,(%rax)",
			"lss (%rax),%bx",
			"lss (%rax),%ebx",
			"lss (%rax),%rbx",
			"btr %cx,%si",
			"btr %bx,(%rax)",
			"btr %ecx,%esi",
			"btr %ebx,(%rax)",
			"btr %rcx,%rsi",
			"btr %rbx,(%rax)",
			"lfs (%rax),%bx",
			"lfs (%rax),%ebx",
			"lfs (%rax),%rbx",
			"lgs (%rax),%bx",
			"lgs (%rax),%ebx",
			"lgs (%rax),%rbx",
			"movzbw %dh,%cx",
			"movzbw (%rax),%bx",
			"movzbl %dh,%ecx",
			"movzbl (%rax),%ebx",
			"movzbq %sil,%rcx",
			"movzbq (%rax),%rbx",
			"movzww %si,%cx",
			"movzww (%rax),%bx",
			"movzwl %si,%ecx",
			"movzwl (%rax),%ebx",
			"movzwq %si,%rcx",
			"movzwq (%rax),%rbx",
			"popcnt %si,%cx",
			"popcnt (%rax),%bx",
			"popcnt %esi,%ecx",
			"popcnt (%rax),%ebx",
			"popcnt %rsi,%rcx",
			"popcnt (%rax),%rbx",
			"ud1 %si,%cx",
			"ud1 (%rax),%bx",
			"ud1 %esi,%ecx",
			"ud1 (%rax),%ebx",
			"ud1 %rsi,%rcx",
			"ud1 (%rax),%rbx",
			"bt $0x5a,%bp",
			"btw $0x5a,(%rax)",
			"bt $0x5a,%ebp",
			"btl $0x5a,(%rax)",
			"bt $0x5a,%rbp",
			"btq $0x5a,(%rax)",
			"bts $0xa5,%si",
			"btsw $0xa5,(%rax)",
			"bts $0xa5,%esi",
			"btsl $0xa5,(%rax)",
			"bts $0xa5,%rsi",
			"btsq $0xa5,(%rax)",
			"btr $0x5a,%di",
			"btrw $0x5a,(%rax)",
			"btr $0x5a,%edi",
			"btrl $0x5a,(%rax)",
			"btr $0x5a,%rdi",
			"btrq $0x5a,(%rax)",
			"btc $0xa5,%ax",
			"btcw $0xa5,(%rax)",
			"btc $0xa5,%eax",
			"btcl $0xa5,(%rax)",
			"btc $0xa5,%r8",
			"btcq $0xa5,(%rax)",
			"btc %cx,%si",
			"btc %bx,(%rax)",
			"btc %ecx,%esi",
			"btc %ebx,(%rax)",
			"btc %rcx,%rsi",
			"btc %rbx,(%rax)",
			"bsf %si,%cx",
			"bsf (%rax),%bx",
			"bsf %esi,%ecx",
			"bsf (%rax),%ebx",
			"bsf %rsi,%rcx",
			"bsf (%rax),%rbx",
			"bsr %si,%cx",
			"bsr (%rax),%bx",
			"bsr %esi,%ecx",
			"bsr (%rax),%ebx",
			"bsr %rsi,%rcx",
			"bsr (%rax),%rbx",
			"movsbw %dh,%cx",
			"movsbw (%rax),%bx",
			"movsbl %dh,%ecx",
			"movsbl (%rax),%ebx",
			"movsbq %sil,%rcx",
			"movsbq (%rax),%rbx",
			"movsww %si,%cx",
			"movsww (%rax),%bx",
			"movswl %si,%ecx",
			"movswl (%rax),%ebx",
			"movswq %si,%rcx",
			"movswq (%rax),%rbx",
			"tzcnt %si,%cx",
			"tzcnt (%rax),%bx",
			"tzcnt %esi,%ecx",
			"tzcnt (%rax),%ebx",
			"tzcnt %rsi,%rcx",
			"tzcnt (%rax),%rbx",
			"lzcnt %si,%cx",
			"lzcnt (%rax),%bx",
			"lzcnt %esi,%ecx",
			"lzcnt (%rax),%ebx",
			"lzcnt %rsi,%rcx",
			"lzcnt (%rax),%rbx",
			"xadd %cl,%dh",
			"xadd %bh,(%rax)",
			"xadd %cx,%si",
			"xadd %bx,(%rax)",
			"xadd %ecx,%esi",
			"xadd %ebx,(%rax)",
			"xadd %rcx,%rsi",
			"xadd %rbx,(%rax)",
			"cmpps $0xa5,%xmm5,%xmm1",
			"cmpps $0xa5,(%rax),%xmm1",
			"vcmpps $0xa5,%xmm3,%xmm6,%xmm2",
			"vcmpps $0xa5,(%rax),%xmm6,%xmm2",
			"vcmpps $0xa5,%ymm3,%ymm6,%ymm2",
			"vcmpps $0xa5,(%rax),%ymm6,%ymm2",
			"vcmpps $0xa5,%xmm3,%xmm6,%k2{%k3}",
			"vcmpps $0xa5,0x10(%rax),%xmm6,%k2{%k3}",
			"vcmpps $0xa5,4(%rax){1to4},%xmm6,%k2{%k5}",
			"vcmpps $0xa5,%ymm3,%ymm6,%k2{%k3}",
			"vcmpps $0xa5,0x20(%rax),%ymm6,%k2{%k3}",
			"vcmpps $0xa5,4(%rax){1to8},%ymm6,%k2{%k5}",
			"vcmpps $0xa5,{sae},%zmm3,%zmm6,%k2{%k3}",
			"vcmpps $0xa5,0x40(%rax),%zmm6,%k2{%k3}",
			"vcmpps $0xa5,4(%rax){1to16},%zmm6,%k2{%k5}",
			"cmppd $0xa5,%xmm5,%xmm1",
			"cmppd $0xa5,(%rax),%xmm1",
			"vcmppd $0xa5,%xmm3,%xmm6,%xmm2",
			"vcmppd $0xa5,(%rax),%xmm6,%xmm2",
			"vcmppd $0xa5,%ymm3,%ymm6,%ymm2",
			"vcmppd $0xa5,(%rax),%ymm6,%ymm2",
			"vcmppd $0xa5,%xmm3,%xmm6,%k2{%k3}",
			"vcmppd $0xa5,0x10(%rax),%xmm6,%k2{%k3}",
			"vcmppd $0xa5,8(%rax){1to2},%xmm6,%k2{%k5}",
			"vcmppd $0xa5,%ymm3,%ymm6,%k2{%k3}",
			"vcmppd $0xa5,0x20(%rax),%ymm6,%k2{%k3}",
			"vcmppd $0xa5,8(%rax){1to4},%ymm6,%k2{%k5}",
			"vcmppd $0xa5,{sae},%zmm3,%zmm6,%k2{%k3}",
			"vcmppd $0xa5,0x40(%rax),%zmm6,%k2{%k3}",
			"vcmppd $0xa5,8(%rax){1to8},%zmm6,%k2{%k5}",
			"cmpss $0xa5,%xmm5,%xmm1",
			"cmpss $0xa5,(%rax),%xmm1",
			"vcmpss $0xa5,%xmm3,%xmm6,%xmm2",
			"vcmpss $0xa5,(%rax),%xmm6,%xmm2",
			"vcmpss $0xa5,%xmm3,%xmm6,%k2{%k3}",
			"vcmpss $0xa5,4(%rax),%xmm6,%k2{%k3}",
			"cmpsd $0xa5,%xmm5,%xmm1",
			"cmpsd $0xa5,(%rax),%xmm1",
			"vcmpsd $0xa5,%xmm3,%xmm6,%xmm2",
			"vcmpsd $0xa5,(%rax),%xmm6,%xmm2",
			"vcmpsd $0xa5,%xmm3,%xmm6,%k2{%k3}",
			"vcmpsd $0xa5,8(%rax),%xmm6,%k2{%k3}",
			"movnti %ebx,(%rax)",
			"movnti %rbx,(%rax)",
			"pinsrw $0xa5,%ebp,%mm1",
			"pinsrw $0xa5,(%rax),%mm1",
			"pinsrw $0xa5,%rbp,%mm1",
			"pinsrw $0xa5,(%rax),%mm1",
			"pinsrw $0xa5,%ebp,%xmm1",
			"pinsrw $0xa5,(%rax),%xmm1",
			"pinsrw $0xa5,%rbp,%xmm1",
			"pinsrw $0xa5,(%rax),%xmm1",
			"vpinsrw $0xa5,%ebx,%xmm6,%xmm2",
			"vpinsrw $0xa5,(%rax),%xmm6,%xmm2",
			"vpinsrw $0xa5,%rbx,%xmm6,%xmm2",
			"vpinsrw $0xa5,(%rax),%xmm6,%xmm2",
			"vpinsrw $0xa5,%ebx,%xmm6,%xmm2",
			"vpinsrw $0xa5,2(%rax),%xmm6,%xmm2",
			"vpinsrw $0xa5,%rbx,%xmm6,%xmm2",
			"vpinsrw $0xa5,2(%rax),%xmm6,%xmm2",
			"pextrw $0xa5,%mm5,%ecx",
			"pextrw $0xa5,%mm5,%rcx",
			"pextrw $0xa5,%xmm5,%ecx",
			"pextrw $0xa5,%xmm5,%rcx",
			"vpextrw $0xa5,%xmm3,%edx",
			"vpextrw $0xa5,%xmm3,%rdx",
			"vpextrw $0xa5,%xmm3,%edx",
			"vpextrw $0xa5,%xmm3,%rdx",
			"shufps $0xa5,%xmm5,%xmm1",
			"shufps $0xa5,(%rax),%xmm1",
			"vshufps $0xa5,%xmm3,%xmm6,%xmm2",
			"vshufps $0xa5,(%rax),%xmm6,%xmm2",
			"vshufps $0xa5,%ymm3,%ymm6,%ymm2",
			"vshufps $0xa5,(%rax),%ymm6,%ymm2",
			"vshufps $0xa5,%xmm3,%xmm6,%xmm2{%k3}",
			"vshufps $0xa5,0x10(%rax),%xmm6,%xmm2{%k3}",
			"vshufps $0xa5,4(%rax){1to4},%xmm6,%xmm2{%k5}{z}",
			"vshufps $0xa5,%ymm3,%ymm6,%ymm2{%k3}",
			"vshufps $0xa5,0x20(%rax),%ymm6,%ymm2{%k3}",
			"vshufps $0xa5,4(%rax){1to8},%ymm6,%ymm2{%k5}{z}",
			"vshufps $0xa5,%zmm3,%zmm6,%zmm2{%k3}",
			"vshufps $0xa5,0x40(%rax),%zmm6,%zmm2{%k3}",
			"vshufps $0xa5,4(%rax){1to16},%zmm6,%zmm2{%k5}{z}",
			"shufpd $0xa5,%xmm5,%xmm1",
			"shufpd $0xa5,(%rax),%xmm1",
			"vshufpd $0xa5,%xmm3,%xmm6,%xmm2",
			"vshufpd $0xa5,(%rax),%xmm6,%xmm2",
			"vshufpd $0xa5,%ymm3,%ymm6,%ymm2",
			"vshufpd $0xa5,(%rax),%ymm6,%ymm2",
			"vshufpd $0xa5,%xmm3,%xmm6,%xmm2{%k3}{z}",
			"vshufpd $0xa5,0x10(%rax),%xmm6,%xmm2{%k3}",
			"vshufpd $0xa5,8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vshufpd $0xa5,%ymm3,%ymm6,%ymm2{%k3}{z}",
			"vshufpd $0xa5,0x20(%rax),%ymm6,%ymm2{%k3}",
			"vshufpd $0xa5,8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vshufpd $0xa5,%zmm3,%zmm6,%zmm2{%k3}{z}",
			"vshufpd $0xa5,0x40(%rax),%zmm6,%zmm2{%k3}",
			"vshufpd $0xa5,8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"cmpxchg8b (%rax)",
			"cmpxchg16b (%rax)",
			"xrstors (%rax)",
			"xrstors64 (%rax)",
			"xsavec (%rax)",
			"xsavec64 (%rax)",
			"xsaves (%rax)",
			"xsaves64 (%rax)",
			"vmptrld (%rax)",
			"vmclear (%rax)",
			"vmxon (%rax)",
			"rdrand %dx",
			"rdrand %edx",
			"rdrand %rdx",
			"vmptrst (%rax)",
			"rdseed %dx",
			"rdseed %edx",
			"rdseed %rdx",
			"rdpid %rdx",
			"bswap %ax",
			"bswap %r8w",
			"bswap %eax",
			"bswap %r8d",
			"bswap %rax",
			"bswap %r8",
			"bswap %cx",
			"bswap %r9w",
			"bswap %ecx",
			"bswap %r9d",
			"bswap %rcx",
			"bswap %r9",
			"bswap %dx",
			"bswap %r10w",
			"bswap %edx",
			"bswap %r10d",
			"bswap %rdx",
			"bswap %r10",
			"bswap %bx",
			"bswap %r11w",
			"bswap %ebx",
			"bswap %r11d",
			"bswap %rbx",
			"bswap %r11",
			"bswap %sp",
			"bswap %r12w",
			"bswap %esp",
			"bswap %r12d",
			"bswap %rsp",
			"bswap %r12",
			"bswap %bp",
			"bswap %r13w",
			"bswap %ebp",
			"bswap %r13d",
			"bswap %rbp",
			"bswap %r13",
			"bswap %si",
			"bswap %r14w",
			"bswap %esi",
			"bswap %r14d",
			"bswap %rsi",
			"bswap %r14",
			"bswap %di",
			"bswap %r15w",
			"bswap %edi",
			"bswap %r15d",
			"bswap %rdi",
			"bswap %r15",
			"addsubpd %xmm5,%xmm1",
			"addsubpd (%rax),%xmm1",
			"vaddsubpd %xmm3,%xmm6,%xmm2",
			"vaddsubpd (%rax),%xmm6,%xmm2",
			"vaddsubpd %ymm3,%ymm6,%ymm2",
			"vaddsubpd (%rax),%ymm6,%ymm2",
			"addsubps %xmm5,%xmm1",
			"addsubps (%rax),%xmm1",
			"vaddsubps %xmm3,%xmm6,%xmm2",
			"vaddsubps (%rax),%xmm6,%xmm2",
			"vaddsubps %ymm3,%ymm6,%ymm2",
			"vaddsubps (%rax),%ymm6,%ymm2",
			"psrlw %mm5,%mm1",
			"psrlw (%rax),%mm1",
			"psrlw %xmm5,%xmm1",
			"psrlw (%rax),%xmm1",
			"vpsrlw %xmm3,%xmm6,%xmm2",
			"vpsrlw (%rax),%xmm6,%xmm2",
			"vpsrlw %xmm3,%ymm6,%ymm2",
			"vpsrlw (%rax),%ymm6,%ymm2",
			"vpsrlw %xmm3,%xmm6,%xmm2{%k3}",
			"vpsrlw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsrlw %xmm3,%ymm6,%ymm2{%k3}",
			"vpsrlw 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsrlw %xmm3,%zmm6,%zmm2{%k3}",
			"vpsrlw 0x10(%rax),%zmm6,%zmm2{%k3}",
			"psrld %mm5,%mm1",
			"psrld (%rax),%mm1",
			"psrld %xmm5,%xmm1",
			"psrld (%rax),%xmm1",
			"vpsrld %xmm3,%xmm6,%xmm2",
			"vpsrld (%rax),%xmm6,%xmm2",
			"vpsrld %xmm3,%ymm6,%ymm2",
			"vpsrld (%rax),%ymm6,%ymm2",
			"vpsrld %xmm3,%xmm6,%xmm2{%k3}",
			"vpsrld 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsrld %xmm3,%ymm6,%ymm2{%k3}",
			"vpsrld 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsrld %xmm3,%zmm6,%zmm2{%k3}",
			"vpsrld 0x10(%rax),%zmm6,%zmm2{%k3}",
			"psrlq %mm5,%mm1",
			"psrlq (%rax),%mm1",
			"psrlq %xmm5,%xmm1",
			"psrlq (%rax),%xmm1",
			"vpsrlq %xmm3,%xmm6,%xmm2",
			"vpsrlq (%rax),%xmm6,%xmm2",
			"vpsrlq %xmm3,%ymm6,%ymm2",
			"vpsrlq (%rax),%ymm6,%ymm2",
			"vpsrlq %xmm3,%xmm6,%xmm2{%k3}",
			"vpsrlq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsrlq %xmm3,%ymm6,%ymm2{%k3}",
			"vpsrlq 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsrlq %xmm3,%zmm6,%zmm2{%k3}",
			"vpsrlq 0x10(%rax),%zmm6,%zmm2{%k3}",
			"paddq %mm5,%mm1",
			"paddq (%rax),%mm1",
			"paddq %xmm5,%xmm1",
			"paddq (%rax),%xmm1",
			"vpaddq %xmm3,%xmm6,%xmm2",
			"vpaddq (%rax),%xmm6,%xmm2",
			"vpaddq %ymm3,%ymm6,%ymm2",
			"vpaddq (%rax),%ymm6,%ymm2",
			"vpaddq %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpaddq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpaddq 8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vpaddq %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpaddq 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpaddq 8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vpaddq %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpaddq 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpaddq 8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"pmullw %mm5,%mm1",
			"pmullw (%rax),%mm1",
			"pmullw %xmm5,%xmm1",
			"pmullw (%rax),%xmm1",
			"vpmullw %xmm3,%xmm6,%xmm2",
			"vpmullw (%rax),%xmm6,%xmm2",
			"vpmullw %ymm3,%ymm6,%ymm2",
			"vpmullw (%rax),%ymm6,%ymm2",
			"vpmullw %xmm3,%xmm6,%xmm2{%k3}",
			"vpmullw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpmullw %ymm3,%ymm6,%ymm2{%k3}",
			"vpmullw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpmullw %zmm3,%zmm6,%zmm2{%k3}",
			"vpmullw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"movq %xmm1,%xmm5",
			"movq %xmm1,(%rax)",
			"vmovq %xmm1,%xmm5",
			"vmovq %xmm2,(%rax)",
			"vmovq %xmm2,%xmm3",
			"vmovq %xmm2,8(%rax)",
			"movq2dq %mm5,%xmm1",
			"movdq2q %xmm5,%mm1",
			"pmovmskb %mm5,%ecx",
			"pmovmskb %mm5,%rcx",
			"pmovmskb %xmm5,%ecx",
			"pmovmskb %xmm5,%rcx",
			"vpmovmskb %xmm5,%ecx",
			"vpmovmskb %xmm5,%rcx",
			"vpmovmskb %ymm5,%ecx",
			"vpmovmskb %ymm5,%rcx",
			"psubusb %mm5,%mm1",
			"psubusb (%rax),%mm1",
			"psubusb %xmm5,%xmm1",
			"psubusb (%rax),%xmm1",
			"vpsubusb %xmm3,%xmm6,%xmm2",
			"vpsubusb (%rax),%xmm6,%xmm2",
			"vpsubusb %ymm3,%ymm6,%ymm2",
			"vpsubusb (%rax),%ymm6,%ymm2",
			"vpsubusb %xmm3,%xmm6,%xmm2{%k3}",
			"vpsubusb 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsubusb %ymm3,%ymm6,%ymm2{%k3}",
			"vpsubusb 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpsubusb %zmm3,%zmm6,%zmm2{%k3}",
			"vpsubusb 0x40(%rax),%zmm6,%zmm2{%k3}",
			"psubusw %mm5,%mm1",
			"psubusw (%rax),%mm1",
			"psubusw %xmm5,%xmm1",
			"psubusw (%rax),%xmm1",
			"vpsubusw %xmm3,%xmm6,%xmm2",
			"vpsubusw (%rax),%xmm6,%xmm2",
			"vpsubusw %ymm3,%ymm6,%ymm2",
			"vpsubusw (%rax),%ymm6,%ymm2",
			"vpsubusw %xmm3,%xmm6,%xmm2{%k3}",
			"vpsubusw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsubusw %ymm3,%ymm6,%ymm2{%k3}",
			"vpsubusw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpsubusw %zmm3,%zmm6,%zmm2{%k3}",
			"vpsubusw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pminub %mm5,%mm1",
			"pminub (%rax),%mm1",
			"pminub %xmm5,%xmm1",
			"pminub (%rax),%xmm1",
			"vpminub %xmm3,%xmm6,%xmm2",
			"vpminub (%rax),%xmm6,%xmm2",
			"vpminub %ymm3,%ymm6,%ymm2",
			"vpminub (%rax),%ymm6,%ymm2",
			"vpminub %xmm3,%xmm6,%xmm2{%k3}",
			"vpminub 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpminub %ymm3,%ymm6,%ymm2{%k3}",
			"vpminub 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpminub %zmm3,%zmm6,%zmm2{%k3}",
			"vpminub 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pand %mm5,%mm1",
			"pand (%rax),%mm1",
			"pand %xmm5,%xmm1",
			"pand (%rax),%xmm1",
			"vpand %xmm3,%xmm6,%xmm2",
			"vpand (%rax),%xmm6,%xmm2",
			"vpand %ymm3,%ymm6,%ymm2",
			"vpand (%rax),%ymm6,%ymm2",
			"vpandd %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpandd 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpandd 4(%rax){1to4},%xmm6,%xmm2{%k5}{z}",
			"vpandd %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpandd 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpandd 4(%rax){1to8},%ymm6,%ymm2{%k5}{z}",
			"vpandd %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpandd 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpandd 4(%rax){1to16},%zmm6,%zmm2{%k5}{z}",
			"vpandq %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpandq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpandq 8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vpandq %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpandq 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpandq 8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vpandq %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpandq 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpandq 8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"paddusb %mm5,%mm1",
			"paddusb (%rax),%mm1",
			"paddusb %xmm5,%xmm1",
			"paddusb (%rax),%xmm1",
			"vpaddusb %xmm3,%xmm6,%xmm2",
			"vpaddusb (%rax),%xmm6,%xmm2",
			"vpaddusb %ymm3,%ymm6,%ymm2",
			"vpaddusb (%rax),%ymm6,%ymm2",
			"vpaddusb %xmm3,%xmm6,%xmm2{%k3}",
			"vpaddusb 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpaddusb %ymm3,%ymm6,%ymm2{%k3}",
			"vpaddusb 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpaddusb %zmm3,%zmm6,%zmm2{%k3}",
			"vpaddusb 0x40(%rax),%zmm6,%zmm2{%k3}",
			"paddusw %mm5,%mm1",
			"paddusw (%rax),%mm1",
			"paddusw %xmm5,%xmm1",
			"paddusw (%rax),%xmm1",
			"vpaddusw %xmm3,%xmm6,%xmm2",
			"vpaddusw (%rax),%xmm6,%xmm2",
			"vpaddusw %ymm3,%ymm6,%ymm2",
			"vpaddusw (%rax),%ymm6,%ymm2",
			"vpaddusw %xmm3,%xmm6,%xmm2{%k3}",
			"vpaddusw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpaddusw %ymm3,%ymm6,%ymm2{%k3}",
			"vpaddusw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpaddusw %zmm3,%zmm6,%zmm2{%k3}",
			"vpaddusw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pmaxub %mm5,%mm1",
			"pmaxub (%rax),%mm1",
			"pmaxub %xmm5,%xmm1",
			"pmaxub (%rax),%xmm1",
			"vpmaxub %xmm3,%xmm6,%xmm2",
			"vpmaxub (%rax),%xmm6,%xmm2",
			"vpmaxub %ymm3,%ymm6,%ymm2",
			"vpmaxub (%rax),%ymm6,%ymm2",
			"vpmaxub %xmm3,%xmm6,%xmm2{%k3}",
			"vpmaxub 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpmaxub %ymm3,%ymm6,%ymm2{%k3}",
			"vpmaxub 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpmaxub %zmm3,%zmm6,%zmm2{%k3}",
			"vpmaxub 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pandn %mm5,%mm1",
			"pandn (%rax),%mm1",
			"pandn %xmm5,%xmm1",
			"pandn (%rax),%xmm1",
			"vpandn %xmm3,%xmm6,%xmm2",
			"vpandn (%rax),%xmm6,%xmm2",
			"vpandn %ymm3,%ymm6,%ymm2",
			"vpandn (%rax),%ymm6,%ymm2",
			"vpandnd %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpandnd 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpandnd 4(%rax){1to4},%xmm6,%xmm2{%k5}{z}",
			"vpandnd %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpandnd 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpandnd 4(%rax){1to8},%ymm6,%ymm2{%k5}{z}",
			"vpandnd %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpandnd 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpandnd 4(%rax){1to16},%zmm6,%zmm2{%k5}{z}",
			"vpandnq %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpandnq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpandnq 8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vpandnq %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpandnq 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpandnq 8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vpandnq %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpandnq 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpandnq 8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"pavgb %mm5,%mm1",
			"pavgb (%rax),%mm1",
			"pavgb %xmm5,%xmm1",
			"pavgb (%rax),%xmm1",
			"vpavgb %xmm3,%xmm6,%xmm2",
			"vpavgb (%rax),%xmm6,%xmm2",
			"vpavgb %ymm3,%ymm6,%ymm2",
			"vpavgb (%rax),%ymm6,%ymm2",
			"vpavgb %xmm3,%xmm6,%xmm2{%k3}",
			"vpavgb 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpavgb %ymm3,%ymm6,%ymm2{%k3}",
			"vpavgb 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpavgb %zmm3,%zmm6,%zmm2{%k3}",
			"vpavgb 0x40(%rax),%zmm6,%zmm2{%k3}",
			"psraw %mm5,%mm1",
			"psraw (%rax),%mm1",
			"psraw %xmm5,%xmm1",
			"psraw (%rax),%xmm1",
			"vpsraw %xmm3,%xmm6,%xmm2",
			"vpsraw (%rax),%xmm6,%xmm2",
			"vpsraw %xmm3,%ymm6,%ymm2",
			"vpsraw (%rax),%ymm6,%ymm2",
			"vpsraw %xmm3,%xmm6,%xmm2{%k3}",
			"vpsraw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsraw %xmm3,%ymm6,%ymm2{%k3}",
			"vpsraw 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsraw %xmm3,%zmm6,%zmm2{%k3}",
			"vpsraw 0x10(%rax),%zmm6,%zmm2{%k3}",
			"psrad %mm5,%mm1",
			"psrad (%rax),%mm1",
			"psrad %xmm5,%xmm1",
			"psrad (%rax),%xmm1",
			"vpsrad %xmm3,%xmm6,%xmm2",
			"vpsrad (%rax),%xmm6,%xmm2",
			"vpsrad %xmm3,%ymm6,%ymm2",
			"vpsrad (%rax),%ymm6,%ymm2",
			"vpsrad %xmm3,%xmm6,%xmm2{%k3}",
			"vpsrad 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsrad %xmm3,%ymm6,%ymm2{%k3}",
			"vpsrad 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsrad %xmm3,%zmm6,%zmm2{%k3}",
			"vpsrad 0x10(%rax),%zmm6,%zmm2{%k3}",
			"vpsraq %xmm3,%xmm6,%xmm2{%k3}",
			"vpsraq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsraq %xmm3,%ymm6,%ymm2{%k3}",
			"vpsraq 0x10(%rax),%ymm6,%ymm2{%k3}",
			"vpsraq %xmm3,%zmm6,%zmm2{%k3}",
			"vpsraq 0x10(%rax),%zmm6,%zmm2{%k3}",
			"pavgw %mm5,%mm1",
			"pavgw (%rax),%mm1",
			"pavgw %xmm5,%xmm1",
			"pavgw (%rax),%xmm1",
			"vpavgw %xmm3,%xmm6,%xmm2",
			"vpavgw (%rax),%xmm6,%xmm2",
			"vpavgw %ymm3,%ymm6,%ymm2",
			"vpavgw (%rax),%ymm6,%ymm2",
			"vpavgw %xmm3,%xmm6,%xmm2{%k3}",
			"vpavgw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpavgw %ymm3,%ymm6,%ymm2{%k3}",
			"vpavgw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpavgw %zmm3,%zmm6,%zmm2{%k3}",
			"vpavgw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pmulhuw %mm5,%mm1",
			"pmulhuw (%rax),%mm1",
			"pmulhuw %xmm5,%xmm1",
			"pmulhuw (%rax),%xmm1",
			"vpmulhuw %xmm3,%xmm6,%xmm2",
			"vpmulhuw (%rax),%xmm6,%xmm2",
			"vpmulhuw %ymm3,%ymm6,%ymm2",
			"vpmulhuw (%rax),%ymm6,%ymm2",
			"vpmulhuw %xmm3,%xmm6,%xmm2{%k3}",
			"vpmulhuw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpmulhuw %ymm3,%ymm6,%ymm2{%k3}",
			"vpmulhuw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpmulhuw %zmm3,%zmm6,%zmm2{%k3}",
			"vpmulhuw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pmulhw %mm5,%mm1",
			"pmulhw (%rax),%mm1",
			"pmulhw %xmm5,%xmm1",
			"pmulhw (%rax),%xmm1",
			"vpmulhw %xmm3,%xmm6,%xmm2",
			"vpmulhw (%rax),%xmm6,%xmm2",
			"vpmulhw %ymm3,%ymm6,%ymm2",
			"vpmulhw (%rax),%ymm6,%ymm2",
			"vpmulhw %xmm3,%xmm6,%xmm2{%k3}",
			"vpmulhw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpmulhw %ymm3,%ymm6,%ymm2{%k3}",
			"vpmulhw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpmulhw %zmm3,%zmm6,%zmm2{%k3}",
			"vpmulhw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"cvttpd2dq %xmm5,%xmm1",
			"cvttpd2dq (%rax),%xmm1",
			"vcvttpd2dq %xmm5,%xmm1",
			"vcvttpd2dqx (%rax),%xmm2",
			"vcvttpd2dq %ymm5,%xmm1",
			"vcvttpd2dqy (%rax),%xmm2",
			"vcvttpd2dq %xmm3,%xmm2{%k3}",
			"vcvttpd2dqx 0x10(%rax),%xmm2",
			"vcvttpd2dq 8(%rax){1to2},%xmm2{%k3}{z}",
			"vcvttpd2dq %ymm3,%xmm2{%k3}",
			"vcvttpd2dqy 0x20(%rax),%xmm2",
			"vcvttpd2dq 8(%rax){1to4},%xmm2{%k3}{z}",
			"vcvttpd2dq %zmm3,%ymm2{%k3}",
			"vcvttpd2dq 0x40(%rax),%ymm2",
			"vcvttpd2dq 8(%rax){1to8},%ymm2{%k3}{z}",
			"cvtdq2pd %xmm5,%xmm1",
			"cvtdq2pd (%rax),%xmm1",
			"vcvtdq2pd %xmm5,%xmm1",
			"vcvtdq2pd (%rax),%xmm2",
			"vcvtdq2pd %xmm5,%ymm1",
			"vcvtdq2pd (%rax),%ymm2",
			"vcvtdq2pd %xmm3,%xmm2{%k3}",
			"vcvtdq2pd 8(%rax),%xmm2",
			"vcvtdq2pd 4(%rax){1to2},%xmm2{%k3}{z}",
			"vcvtdq2pd %xmm3,%ymm2{%k3}",
			"vcvtdq2pd 0x10(%rax),%ymm2",
			"vcvtdq2pd 4(%rax){1to4},%ymm2{%k3}{z}",
			"vcvtdq2pd %ymm3,%zmm2{%k3}",
			"vcvtdq2pd 0x20(%rax),%zmm2",
			"vcvtdq2pd 4(%rax){1to8},%zmm2{%k3}{z}",
			"vcvtqq2pd %xmm3,%xmm2{%k3}",
			"vcvtqq2pd 0x10(%rax),%xmm2",
			"vcvtqq2pd 8(%rax){1to2},%xmm2{%k3}{z}",
			"vcvtqq2pd %ymm3,%ymm2{%k3}",
			"vcvtqq2pd 0x20(%rax),%ymm2",
			"vcvtqq2pd 8(%rax){1to4},%ymm2{%k3}{z}",
			"vcvtqq2pd %zmm3,%zmm2{%k3}",
			"vcvtqq2pd 0x40(%rax),%zmm2",
			"vcvtqq2pd 8(%rax){1to8},%zmm2{%k3}{z}",
			"cvtpd2dq %xmm5,%xmm1",
			"cvtpd2dq (%rax),%xmm1",
			"vcvtpd2dq %xmm5,%xmm1",
			"vcvtpd2dqx (%rax),%xmm2",
			"vcvtpd2dq %ymm5,%xmm1",
			"vcvtpd2dqy (%rax),%xmm2",
			"vcvtpd2dq %xmm3,%xmm2{%k3}",
			"vcvtpd2dqx 0x10(%rax),%xmm2",
			"vcvtpd2dq 8(%rax){1to2},%xmm2{%k3}{z}",
			"vcvtpd2dq %ymm3,%xmm2{%k3}",
			"vcvtpd2dqy 0x20(%rax),%xmm2",
			"vcvtpd2dq 8(%rax){1to4},%xmm2{%k3}{z}",
			"vcvtpd2dq %zmm3,%ymm2{%k3}",
			"vcvtpd2dq 0x40(%rax),%ymm2",
			"vcvtpd2dq 8(%rax){1to8},%ymm2{%k3}{z}",
			"movntq %mm1,(%rax)",
			"movntdq %xmm1,(%rax)",
			"vmovntdq %xmm2,(%rax)",
			"vmovntdq %ymm2,(%rax)",
			"vmovntdq %xmm2,0x10(%rax)",
			"vmovntdq %ymm2,0x20(%rax)",
			"vmovntdq %zmm2,0x40(%rax)",
			"psubsb %mm5,%mm1",
			"psubsb (%rax),%mm1",
			"psubsb %xmm5,%xmm1",
			"psubsb (%rax),%xmm1",
			"vpsubsb %xmm3,%xmm6,%xmm2",
			"vpsubsb (%rax),%xmm6,%xmm2",
			"vpsubsb %ymm3,%ymm6,%ymm2",
			"vpsubsb (%rax),%ymm6,%ymm2",
			"vpsubsb %xmm3,%xmm6,%xmm2{%k3}",
			"vpsubsb 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsubsb %ymm3,%ymm6,%ymm2{%k3}",
			"vpsubsb 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpsubsb %zmm3,%zmm6,%zmm2{%k3}",
			"vpsubsb 0x40(%rax),%zmm6,%zmm2{%k3}",
			"psubsw %mm5,%mm1",
			"psubsw (%rax),%mm1",
			"psubsw %xmm5,%xmm1",
			"psubsw (%rax),%xmm1",
			"vpsubsw %xmm3,%xmm6,%xmm2",
			"vpsubsw (%rax),%xmm6,%xmm2",
			"vpsubsw %ymm3,%ymm6,%ymm2",
			"vpsubsw (%rax),%ymm6,%ymm2",
			"vpsubsw %xmm3,%xmm6,%xmm2{%k3}",
			"vpsubsw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsubsw %ymm3,%ymm6,%ymm2{%k3}",
			"vpsubsw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpsubsw %zmm3,%zmm6,%zmm2{%k3}",
			"vpsubsw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pminsw %mm5,%mm1",
			"pminsw (%rax),%mm1",
			"pminsw %xmm5,%xmm1",
			"pminsw (%rax),%xmm1",
			"vpminsw %xmm3,%xmm6,%xmm2",
			"vpminsw (%rax),%xmm6,%xmm2",
			"vpminsw %ymm3,%ymm6,%ymm2",
			"vpminsw (%rax),%ymm6,%ymm2",
			"vpminsw %xmm3,%xmm6,%xmm2{%k3}",
			"vpminsw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpminsw %ymm3,%ymm6,%ymm2{%k3}",
			"vpminsw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpminsw %zmm3,%zmm6,%zmm2{%k3}",
			"vpminsw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"por %mm5,%mm1",
			"por (%rax),%mm1",
			"por %xmm5,%xmm1",
			"por (%rax),%xmm1",
			"vpor %xmm3,%xmm6,%xmm2",
			"vpor (%rax),%xmm6,%xmm2",
			"vpor %ymm3,%ymm6,%ymm2",
			"vpor (%rax),%ymm6,%ymm2",
			"vpord %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpord 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpord 4(%rax){1to4},%xmm6,%xmm2{%k5}{z}",
			"vpord %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpord 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpord 4(%rax){1to8},%ymm6,%ymm2{%k5}{z}",
			"vpord %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpord 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpord 4(%rax){1to16},%zmm6,%zmm2{%k5}{z}",
			"vporq %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vporq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vporq 8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vporq %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vporq 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vporq 8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vporq %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vporq 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vporq 8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"paddsb %mm5,%mm1",
			"paddsb (%rax),%mm1",
			"paddsb %xmm5,%xmm1",
			"paddsb (%rax),%xmm1",
			"vpaddsb %xmm3,%xmm6,%xmm2",
			"vpaddsb (%rax),%xmm6,%xmm2",
			"vpaddsb %ymm3,%ymm6,%ymm2",
			"vpaddsb (%rax),%ymm6,%ymm2",
			"vpaddsb %xmm3,%xmm6,%xmm2{%k3}",
			"vpaddsb 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpaddsb %ymm3,%ymm6,%ymm2{%k3}",
			"vpaddsb 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpaddsb %zmm3,%zmm6,%zmm2{%k3}",
			"vpaddsb 0x40(%rax),%zmm6,%zmm2{%k3}",
			"paddsw %mm5,%mm1",
			"paddsw (%rax),%mm1",
			"paddsw %xmm5,%xmm1",
			"paddsw (%rax),%xmm1",
			"vpaddsw %xmm3,%xmm6,%xmm2",
			"vpaddsw (%rax),%xmm6,%xmm2",
			"vpaddsw %ymm3,%ymm6,%ymm2",
			"vpaddsw (%rax),%ymm6,%ymm2",
			"vpaddsw %xmm3,%xmm6,%xmm2{%k3}",
			"vpaddsw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpaddsw %ymm3,%ymm6,%ymm2{%k3}",
			"vpaddsw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpaddsw %zmm3,%zmm6,%zmm2{%k3}",
			"vpaddsw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pmaxsw %mm5,%mm1",
			"pmaxsw (%rax),%mm1",
			"pmaxsw %xmm5,%xmm1",
			"pmaxsw (%rax),%xmm1",
			"vpmaxsw %xmm3,%xmm6,%xmm2",
			"vpmaxsw (%rax),%xmm6,%xmm2",
			"vpmaxsw %ymm3,%ymm6,%ymm2",
			"vpmaxsw (%rax),%ymm6,%ymm2",
			"vpmaxsw %xmm3,%xmm6,%xmm2{%k3}",
			"vpmaxsw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpmaxsw %ymm3,%ymm6,%ymm2{%k3}",
			"vpmaxsw 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpmaxsw %zmm3,%zmm6,%zmm2{%k3}",
			"vpmaxsw 0x40(%rax),%zmm6,%zmm2{%k3}",
			"pxor %mm5,%mm1",
			"pxor (%rax),%mm1",
			"pxor %xmm5,%xmm1",
			"pxor (%rax),%xmm1",
			"vpxor %xmm3,%xmm6,%xmm2",
			"vpxor (%rax),%xmm6,%xmm2",
			"vpxor %ymm3,%ymm6,%ymm2",
			"vpxor (%rax),%ymm6,%ymm2",
			"vpxord %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpxord 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpxord 4(%rax){1to4},%xmm6,%xmm2{%k5}{z}",
			"vpxord %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpxord 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpxord 4(%rax){1to8},%ymm6,%ymm2{%k5}{z}",
			"vpxord %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpxord 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpxord 4(%rax){1to16},%zmm6,%zmm2{%k5}{z}",
			"vpxorq %xmm3,%xmm6,%xmm2{%k3}{z}",
			"vpxorq 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpxorq 8(%rax){1to2},%xmm6,%xmm2{%k5}{z}",
			"vpxorq %ymm3,%ymm6,%ymm2{%k3}{z}",
			"vpxorq 0x20(%rax),%ymm6,%ymm2{%k3}",
			"vpxorq 8(%rax){1to4},%ymm6,%ymm2{%k5}{z}",
			"vpxorq %zmm3,%zmm6,%zmm2{%k3}{z}",
			"vpxorq 0x40(%rax),%zmm6,%zmm2{%k3}",
			"vpxorq 8(%rax){1to8},%zmm6,%zmm2{%k5}{z}",
			"lddqu (%rax),%xmm1",
			"vlddqu (%rax),%xmm2",
			"vlddqu (%rax),%ymm2",
			"psllw %mm5,%mm1",
			"psllw (%rax),%mm1",
			"psllw %xmm5,%xmm1",
			"psllw (%rax),%xmm1",
			"vpsllw %xmm3,%xmm6,%xmm2",
			"vpsllw (%rax),%xmm6,%xmm2",
			"vpsllw %xmm3,%ymm6,%ymm2",
			"vpsllw (%rax),%ymm6,%ymm2",
			"vpsllw %xmm3,%xmm6,%xmm2{%k3}",
			"vpsllw 0x10(%rax),%xmm6,%xmm2{%k3}",
			"vpsllw %xmm3,%ymm6,%ymm2{%k3}",
		};
	}
}
#endif
