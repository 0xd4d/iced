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
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Iced.Intel.MasmFormatterInternal;

namespace Iced.Intel {
	/// <summary>
	/// Masm formatter options
	/// </summary>
	public sealed class MasmFormatterOptions : FormatterOptions {
		/// <summary>
		/// Add a DS segment override even if it's not present. Used if it's 16/32-bit code and mem op is a displ, eg. 'mov eax,[12345678]' vs 'mov eax,ds:[12345678]'
		/// </summary>
		public bool AddDsPrefix32 { get; set; } = true;

		/// <summary>
		/// Show symbols in brackets, eg. '[ecx+symbol]' vs 'symbol[ecx]' and '[symbol]' vs 'symbol'
		/// </summary>
		public bool SymbolDisplInBrackets { get; set; } = true;

		/// <summary>
		/// Show displacements in brackets, eg. '[ecx+1234h]' vs '1234h[ecx]'
		/// </summary>
		public bool DisplInBrackets { get; set; } = true;

		/// <summary>
		/// Constructor
		/// </summary>
		public MasmFormatterOptions() {
			HexSuffix = "h";
			OctalSuffix = "o";
			BinarySuffix = "b";
		}
	}

	/// <summary>
	/// Masm formatter
	/// </summary>
	public sealed class MasmFormatter : Formatter {
		/// <summary>
		/// Gets the formatter options, see also <see cref="MasmOptions"/>
		/// </summary>
		public override FormatterOptions Options => options;

		/// <summary>
		/// Gets the masm formatter options
		/// </summary>
		public MasmFormatterOptions MasmOptions => options;

		readonly MasmFormatterOptions options;
		readonly ISymbolResolver symbolResolver;
		readonly IFormatterOptionsProvider optionsProvider;
		readonly string[] allRegisters;
		readonly InstrInfo[] instrInfos;
		readonly MemorySizes.Info[] allMemorySizes;
		readonly NumberFormatter numberFormatter;

		/// <summary>
		/// Constructor
		/// </summary>
		public MasmFormatter() : this(new MasmFormatterOptions()) { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options">Formatter options</param>
		/// <param name="symbolResolver">Symbol resolver or null</param>
		/// <param name="optionsProvider">Operand options provider or null</param>
		public MasmFormatter(MasmFormatterOptions options, ISymbolResolver symbolResolver = null, IFormatterOptionsProvider optionsProvider = null) {
			if (options == null)
				ThrowHelper.ThrowArgumentNullException_options();
			this.options = options;
			this.symbolResolver = symbolResolver;
			this.optionsProvider = optionsProvider;
			allRegisters = Registers.AllRegisters;
			instrInfos = InstrInfos.AllInfos;
			allMemorySizes = MemorySizes.AllMemorySizes;
			numberFormatter = new NumberFormatter(options);
		}

		/// <summary>
		/// Formats the mnemonic and any prefixes
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="output">Output</param>
		/// <param name="options">Options</param>
		public override void FormatMnemonic(ref Instruction instruction, FormatterOutput output, FormatMnemonicOptions options) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(this.options, ref instruction, out var opInfo);
			int column = 0;
			FormatMnemonic(ref instruction, output, ref opInfo, ref column, options);
		}

		/// <summary>
		/// Gets the number of operands that will be formatted. A formatter can add and remove operands
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <returns></returns>
		public override int GetOperandCount(ref Instruction instruction) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);
			return opInfo.OpCount;
		}

#if !NO_INSTR_INFO
		/// <summary>
		/// Returns the operand access but only if it's an operand added by the formatter. If it's an
		/// operand that is part of <see cref="Instruction"/>, you should call eg.
		/// <see cref="Instruction.GetInfo()"/> or <see cref="InstructionInfoFactory.GetInfo(ref Instruction)"/>.
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="operand">Operand number, 0-based. This is a formatter operand and isn't necessarily the same as an instruction operand.
		/// See <see cref="GetOperandCount(ref Instruction)"/></param>
		/// <param name="access">Updated with operand access if successful</param>
		/// <returns></returns>
		public override bool TryGetOpAccess(ref Instruction instruction, int operand, out OpAccess access) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);
			return opInfo.TryGetOpAccess(operand, out access);
		}
#endif

		/// <summary>
		/// Converts a formatter operand index to an instruction operand index. Returns -1 if it's an operand added by the formatter
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="operand">Operand number, 0-based. This is a formatter operand and isn't necessarily the same as an instruction operand.
		/// See <see cref="GetOperandCount(ref Instruction)"/></param>
		/// <returns></returns>
		public override int GetInstructionOperand(ref Instruction instruction, int operand) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);
			return opInfo.GetInstructionIndex(operand);
		}

		/// <summary>
		/// Converts an instruction operand index to a formatter operand index. Returns -1 if the instruction operand isn't used by the formatter
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="instructionOperand">Instruction operand</param>
		/// <returns></returns>
		public override int GetFormatterOperand(ref Instruction instruction, int instructionOperand) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);
			return opInfo.GetOperandIndex(instructionOperand);
		}

		/// <summary>
		/// Formats an operand. This is a formatter operand and not necessarily a real instruction operand.
		/// A formatter can add and remove operands.
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="output">Output</param>
		/// <param name="operand">Operand number, 0-based. This is a formatter operand and isn't necessarily the same as an instruction operand.
		/// See <see cref="GetOperandCount(ref Instruction)"/></param>
		public override void FormatOperand(ref Instruction instruction, FormatterOutput output, int operand) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);

			if ((uint)operand >= (uint)opInfo.OpCount)
				ThrowHelper.ThrowArgumentOutOfRangeException_operand();
			FormatOperand(ref instruction, output, ref opInfo, operand);
		}

		/// <summary>
		/// Formats an operand separator
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="output">Output</param>
		public override void FormatOperandSeparator(ref Instruction instruction, FormatterOutput output) {
			output.Write(",", FormatterOutputTextKind.Punctuation);
			if (options.SpaceAfterOperandSeparator)
				output.Write(" ", FormatterOutputTextKind.Text);
		}

		/// <summary>
		/// Formats all operands
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="output">Output</param>
		public override void FormatAllOperands(ref Instruction instruction, FormatterOutput output) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);
			FormatOperands(ref instruction, output, ref opInfo);
		}

		/// <summary>
		/// Formats the whole instruction: prefixes, mnemonic, operands
		/// </summary>
		/// <param name="instruction">Instruction</param>
		/// <param name="output">Output</param>
		public override void Format(ref Instruction instruction, FormatterOutput output) {
			Debug.Assert((uint)instruction.Code < (uint)instrInfos.Length);
			var instrInfo = instrInfos[(int)instruction.Code];
			instrInfo.GetOpInfo(options, ref instruction, out var opInfo);

			int column = 0;
			FormatMnemonic(ref instruction, output, ref opInfo, ref column, FormatMnemonicOptions.None);

			if (opInfo.OpCount != 0) {
				FormatterUtils.AddTabs(output, column, options.FirstOperandCharIndex, options.TabSize);
				FormatOperands(ref instruction, output, ref opInfo);
			}
		}

		void FormatMnemonic(ref Instruction instruction, FormatterOutput output, ref InstrOpInfo opInfo, ref int column, FormatMnemonicOptions mnemonicOptions) {
			bool needSpace = false;
			if ((mnemonicOptions & FormatMnemonicOptions.NoPrefixes) == 0) {
				var prefixSeg = instruction.SegmentPrefix;
				bool hasNoTrackPrefix = prefixSeg == Register.DS && FormatterUtils.IsNoTrackPrefixBranch(instruction.Code);
				if (!hasNoTrackPrefix && prefixSeg != Register.None && ShowSegmentPrefix(ref opInfo))
					FormatPrefix(output, ref column, allRegisters[(int)prefixSeg], ref needSpace);

				if (instruction.HasXacquirePrefix)
					FormatPrefix(output, ref column, "xacquire", ref needSpace);
				if (instruction.HasXreleasePrefix)
					FormatPrefix(output, ref column, "xrelease", ref needSpace);
				if (instruction.HasLockPrefix)
					FormatPrefix(output, ref column, "lock", ref needSpace);

				if ((opInfo.Flags & InstrOpInfoFlags.JccNotTaken) != 0)
					FormatPrefix(output, ref column, "hnt", ref needSpace);
				else if ((opInfo.Flags & InstrOpInfoFlags.JccTaken) != 0)
					FormatPrefix(output, ref column, "ht", ref needSpace);

				bool hasBnd = (opInfo.Flags & InstrOpInfoFlags.BndPrefix) != 0;
				if (instruction.HasRepePrefix)
					FormatPrefix(output, ref column, FormatterUtils.IsRepeOrRepneInstruction(instruction.Code) ? "repe" : "rep", ref needSpace);
				if (instruction.HasRepnePrefix && !hasBnd)
					FormatPrefix(output, ref column, "repne", ref needSpace);

				if (hasNoTrackPrefix)
					FormatPrefix(output, ref column, "notrack", ref needSpace);

				if (hasBnd)
					FormatPrefix(output, ref column, "bnd", ref needSpace);
			}

			if ((mnemonicOptions & FormatMnemonicOptions.NoMnemonic) == 0) {
				if (needSpace) {
					output.Write(" ", FormatterOutputTextKind.Text);
					column++;
				}
				var mnemonic = opInfo.Mnemonic;
				if (options.UpperCaseMnemonics || options.UpperCaseAll)
					mnemonic = mnemonic.ToUpperInvariant();
				output.Write(mnemonic, FormatterOutputTextKind.Mnemonic);
				column += mnemonic.Length;
			}
		}

		bool ShowSegmentPrefix(ref InstrOpInfo opInfo) {
			if ((opInfo.Flags & (InstrOpInfoFlags.JccNotTaken | InstrOpInfoFlags.JccTaken)) != 0)
				return false;
			for (int i = 0; i < opInfo.OpCount; i++) {
				switch (opInfo.GetOpKind(i)) {
				case InstrOpKind.Register:
				case InstrOpKind.NearBranch16:
				case InstrOpKind.NearBranch32:
				case InstrOpKind.NearBranch64:
				case InstrOpKind.FarBranch16:
				case InstrOpKind.FarBranch32:
				case InstrOpKind.ExtraImmediate8_Value3:
				case InstrOpKind.Immediate8:
				case InstrOpKind.Immediate8_2nd:
				case InstrOpKind.Immediate16:
				case InstrOpKind.Immediate32:
				case InstrOpKind.Immediate64:
				case InstrOpKind.Immediate8to16:
				case InstrOpKind.Immediate8to32:
				case InstrOpKind.Immediate8to64:
				case InstrOpKind.Immediate32to64:
				case InstrOpKind.MemoryESDI:
				case InstrOpKind.MemoryESEDI:
				case InstrOpKind.MemoryESRDI:
					break;

				case InstrOpKind.MemorySegSI:
				case InstrOpKind.MemorySegESI:
				case InstrOpKind.MemorySegRSI:
				case InstrOpKind.MemorySegDI:
				case InstrOpKind.MemorySegEDI:
				case InstrOpKind.MemorySegRDI:
				case InstrOpKind.Memory64:
				case InstrOpKind.Memory:
					return false;

				default:
					throw new InvalidOperationException();
				}
			}
			return true;
		}

		void FormatPrefix(FormatterOutput output, ref int column, string prefix, ref bool needSpace) {
			if (needSpace) {
				column++;
				output.Write(" ", FormatterOutputTextKind.Text);
			}
			if (options.UpperCasePrefixes || options.UpperCaseAll)
				prefix = prefix.ToUpperInvariant();
			output.Write(prefix, FormatterOutputTextKind.Prefix);
			column += prefix.Length;
			needSpace = true;
		}

		void FormatOperands(ref Instruction instruction, FormatterOutput output, ref InstrOpInfo opInfo) {
			for (int i = 0; i < opInfo.OpCount; i++) {
				if (i > 0) {
					output.Write(",", FormatterOutputTextKind.Punctuation);
					if (options.SpaceAfterOperandSeparator)
						output.Write(" ", FormatterOutputTextKind.Text);
				}
				FormatOperand(ref instruction, output, ref opInfo, i);
			}
		}

		void FormatOperand(ref Instruction instruction, FormatterOutput output, ref InstrOpInfo opInfo, int operand) {
			Debug.Assert((uint)operand < (uint)opInfo.OpCount);

			output.OnOperand(operand, begin: true);

			string s;
			FormatterFlowControl flowControl;
			byte imm8;
			ushort imm16;
			uint imm32;
			ulong imm64;
			int immSize;
			int instructionOperand;
			NumberFormattingOptions numberOptions;
			SymbolResult symbol;
			ISymbolResolver symbolResolver;
			FormatterOperandOptions operandOptions;
			const string offsetKeyword = "offset";
			var opKind = opInfo.GetOpKind(operand);
			switch (opKind) {
			case InstrOpKind.Register:
				FormatRegister(output, opInfo.GetOpRegister(operand));
				break;

			case InstrOpKind.NearBranch16:
			case InstrOpKind.NearBranch32:
			case InstrOpKind.NearBranch64:
				if (opKind == InstrOpKind.NearBranch64) {
					immSize = 8;
					imm64 = instruction.NearBranch64;
				}
				else if (opKind == InstrOpKind.NearBranch32) {
					immSize = 4;
					imm64 = instruction.NearBranch32;
				}
				else {
					immSize = 2;
					imm64 = instruction.NearBranch16;
				}
				numberOptions = NumberFormattingOptions.CreateBranch(options);
				operandOptions = options.ShowBranchSize ? FormatterOperandOptions.None : FormatterOperandOptions.NoBranchSize;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, imm64, immSize, out symbol)) {
					FormatFlowControl(output, FormatterUtils.GetFlowControl(ref instruction), operandOptions);
					output.Write(numberFormatter, numberOptions, imm64, symbol, options.ShowSymbolAddress);
				}
				else {
					flowControl = FormatterUtils.GetFlowControl(ref instruction);
					FormatFlowControl(output, flowControl, operandOptions);
					if (opKind == InstrOpKind.NearBranch32)
						s = numberFormatter.FormatUInt32(numberOptions, instruction.NearBranch32, numberOptions.LeadingZeroes);
					else if (opKind == InstrOpKind.NearBranch64)
						s = numberFormatter.FormatUInt64(numberOptions, instruction.NearBranch64, numberOptions.LeadingZeroes);
					else
						s = numberFormatter.FormatUInt16(numberOptions, instruction.NearBranch16, numberOptions.LeadingZeroes);
					output.Write(s, FormatterUtils.IsCall(flowControl) ? FormatterOutputTextKind.FunctionAddress : FormatterOutputTextKind.LabelAddress);
				}
				break;

			case InstrOpKind.FarBranch16:
			case InstrOpKind.FarBranch32:
				if (opKind == InstrOpKind.FarBranch32) {
					immSize = 4;
					imm64 = instruction.FarBranch32;
				}
				else {
					immSize = 2;
					imm64 = instruction.FarBranch16;
				}
				numberOptions = NumberFormattingOptions.CreateBranch(options);
				operandOptions = options.ShowBranchSize ? FormatterOperandOptions.None : FormatterOperandOptions.NoBranchSize;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, (uint)imm64, immSize, out symbol)) {
					FormatFlowControl(output, FormatterUtils.GetFlowControl(ref instruction), operandOptions);
					Debug.Assert(operand + 1 == 1);
					if (!symbolResolver.TryGetSymbol(operand + 1, instructionOperand, ref instruction, instruction.FarBranchSelector, 2, out var selectorSymbol)) {
						s = numberFormatter.FormatUInt16(numberOptions, instruction.FarBranchSelector, numberOptions.LeadingZeroes);
						output.Write(s, FormatterOutputTextKind.SelectorValue);
					}
					else
						output.Write(numberFormatter, numberOptions, instruction.FarBranchSelector, selectorSymbol, options.ShowSymbolAddress);
					output.Write(":", FormatterOutputTextKind.Punctuation);
					output.Write(numberFormatter, numberOptions, imm64, symbol, options.ShowSymbolAddress);
				}
				else {
					flowControl = FormatterUtils.GetFlowControl(ref instruction);
					FormatFlowControl(output, flowControl, operandOptions);
					s = numberFormatter.FormatUInt16(numberOptions, instruction.FarBranchSelector, numberOptions.LeadingZeroes);
					output.Write(s, FormatterOutputTextKind.SelectorValue);
					output.Write(":", FormatterOutputTextKind.Punctuation);
					if (opKind == InstrOpKind.FarBranch32)
						s = numberFormatter.FormatUInt32(numberOptions, instruction.FarBranch32, numberOptions.LeadingZeroes);
					else
						s = numberFormatter.FormatUInt16(numberOptions, instruction.FarBranch16, numberOptions.LeadingZeroes);
					output.Write(s, FormatterUtils.IsCall(flowControl) ? FormatterOutputTextKind.FunctionAddress : FormatterOutputTextKind.LabelAddress);
				}
				break;

			case InstrOpKind.Immediate8:
			case InstrOpKind.Immediate8_2nd:
			case InstrOpKind.ExtraImmediate8_Value3:
				if (opKind == InstrOpKind.Immediate8)
					imm8 = instruction.Immediate8;
				else if (opKind == InstrOpKind.ExtraImmediate8_Value3)
					imm8 = 3;
				else
					imm8 = instruction.Immediate8_2nd;
				numberOptions = NumberFormattingOptions.CreateImmediate(options);
				operandOptions = FormatterOperandOptions.None;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, imm8, 1, out symbol)) {
					if ((symbol.Flags & SymbolFlags.Relative) == 0) {
						FormatKeyword(output, offsetKeyword);
						output.Write(" ", FormatterOutputTextKind.Text);
					}
					output.Write(numberFormatter, numberOptions, imm8, symbol, options.ShowSymbolAddress);
				}
				else {
					if (numberOptions.SignedNumber && (sbyte)imm8 < 0) {
						output.Write("-", FormatterOutputTextKind.Operator);
						imm8 = (byte)-(sbyte)imm8;
					}
					s = numberFormatter.FormatUInt8(numberOptions, imm8);
					output.Write(s, FormatterOutputTextKind.Number);
				}
				break;

			case InstrOpKind.Immediate16:
			case InstrOpKind.Immediate8to16:
				if (opKind == InstrOpKind.Immediate16)
					imm16 = instruction.Immediate16;
				else
					imm16 = (ushort)instruction.Immediate8to16;
				numberOptions = NumberFormattingOptions.CreateImmediate(options);
				operandOptions = FormatterOperandOptions.None;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, imm16, 2, out symbol)) {
					if ((symbol.Flags & SymbolFlags.Relative) == 0) {
						FormatKeyword(output, offsetKeyword);
						output.Write(" ", FormatterOutputTextKind.Text);
					}
					output.Write(numberFormatter, numberOptions, imm16, symbol, options.ShowSymbolAddress);
				}
				else {
					if (numberOptions.SignedNumber && (short)imm16 < 0) {
						output.Write("-", FormatterOutputTextKind.Operator);
						imm16 = (ushort)-(short)imm16;
					}
					s = numberFormatter.FormatUInt16(numberOptions, imm16);
					output.Write(s, FormatterOutputTextKind.Number);
				}
				break;

			case InstrOpKind.Immediate32:
			case InstrOpKind.Immediate8to32:
				if (opKind == InstrOpKind.Immediate32)
					imm32 = instruction.Immediate32;
				else
					imm32 = (uint)instruction.Immediate8to32;
				numberOptions = NumberFormattingOptions.CreateImmediate(options);
				operandOptions = FormatterOperandOptions.None;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, imm32, 4, out symbol)) {
					if ((symbol.Flags & SymbolFlags.Relative) == 0) {
						FormatKeyword(output, offsetKeyword);
						output.Write(" ", FormatterOutputTextKind.Text);
					}
					output.Write(numberFormatter, numberOptions, imm32, symbol, options.ShowSymbolAddress);
				}
				else {
					if (numberOptions.SignedNumber && (int)imm32 < 0) {
						output.Write("-", FormatterOutputTextKind.Operator);
						imm32 = (uint)-(int)imm32;
					}
					s = numberFormatter.FormatUInt32(numberOptions, imm32);
					output.Write(s, FormatterOutputTextKind.Number);
				}
				break;

			case InstrOpKind.Immediate64:
			case InstrOpKind.Immediate8to64:
			case InstrOpKind.Immediate32to64:
				if (opKind == InstrOpKind.Immediate32to64)
					imm64 = (ulong)instruction.Immediate32to64;
				else if (opKind == InstrOpKind.Immediate8to64)
					imm64 = (ulong)instruction.Immediate8to64;
				else
					imm64 = instruction.Immediate64;
				numberOptions = NumberFormattingOptions.CreateImmediate(options);
				operandOptions = FormatterOperandOptions.None;
				instructionOperand = opInfo.GetInstructionIndex(operand);
				optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instruction, ref operandOptions, ref numberOptions);
				if ((symbolResolver = this.symbolResolver) != null && symbolResolver.TryGetSymbol(operand, instructionOperand, ref instruction, imm64, 8, out symbol)) {
					if ((symbol.Flags & SymbolFlags.Relative) == 0) {
						FormatKeyword(output, offsetKeyword);
						output.Write(" ", FormatterOutputTextKind.Text);
					}
					output.Write(numberFormatter, numberOptions, imm64, symbol, options.ShowSymbolAddress);
				}
				else {
					if (numberOptions.SignedNumber && (long)imm64 < 0) {
						output.Write("-", FormatterOutputTextKind.Operator);
						imm64 = (ulong)-(long)imm64;
					}
					s = numberFormatter.FormatUInt64(numberOptions, imm64);
					output.Write(s, FormatterOutputTextKind.Number);
				}
				break;

			case InstrOpKind.MemorySegSI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.SI, Register.None, 0, 0, 0, 2, opInfo.Flags);
				break;

			case InstrOpKind.MemorySegESI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.ESI, Register.None, 0, 0, 0, 4, opInfo.Flags);
				break;

			case InstrOpKind.MemorySegRSI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.RSI, Register.None, 0, 0, 0, 8, opInfo.Flags);
				break;

			case InstrOpKind.MemorySegDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.DI, Register.None, 0, 0, 0, 2, opInfo.Flags);
				break;

			case InstrOpKind.MemorySegEDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.EDI, Register.None, 0, 0, 0, 4, opInfo.Flags);
				break;

			case InstrOpKind.MemorySegRDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.RDI, Register.None, 0, 0, 0, 8, opInfo.Flags);
				break;

			case InstrOpKind.MemoryESDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, Register.ES, Register.DI, Register.None, 0, 0, 0, 2, opInfo.Flags);
				break;

			case InstrOpKind.MemoryESEDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, Register.ES, Register.EDI, Register.None, 0, 0, 0, 4, opInfo.Flags);
				break;

			case InstrOpKind.MemoryESRDI:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, Register.ES, Register.RDI, Register.None, 0, 0, 0, 8, opInfo.Flags);
				break;

			case InstrOpKind.Memory64:
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, Register.None, Register.None, 0, 8, (long)instruction.MemoryAddress64, 8, opInfo.Flags);
				break;

			case InstrOpKind.Memory:
				int displSize = instruction.MemoryDisplSize;
				var baseReg = instruction.MemoryBase;
				var indexReg = instruction.MemoryIndex;
				int addrSize = InstructionUtils.GetAddressSizeInBytes(baseReg, indexReg, displSize, instruction.CodeSize);
				long displ;
				if (addrSize == 8)
					displ = (int)instruction.MemoryDisplacement;
				else
					displ = instruction.MemoryDisplacement;
				if ((opInfo.Flags & InstrOpInfoFlags.IgnoreIndexReg) != 0)
					indexReg = Register.None;
				FormatMemory(output, ref instruction, operand, opInfo.GetInstructionIndex(operand), instruction.MemorySize, instruction.SegmentPrefix, instruction.MemorySegment, baseReg, indexReg, instruction.InternalMemoryIndexScale, displSize, displ, addrSize, opInfo.Flags);
				break;

			default:
				throw new InvalidOperationException();
			}

			if (operand == 0 && instruction.HasOpMask) {
				output.Write("{", FormatterOutputTextKind.Punctuation);
				FormatRegister(output, instruction.OpMask);
				output.Write("}", FormatterOutputTextKind.Punctuation);
				if (instruction.ZeroingMasking)
					FormatEvexMisc(output, "z");
			}
			if (operand + 1 == opInfo.OpCount) {
				var rc = instruction.RoundingControl;
				if (rc != RoundingControl.None) {
					Debug.Assert((int)RoundingControl.None == 0);
					Debug.Assert((int)RoundingControl.RoundToNearest == 1);
					Debug.Assert((int)RoundingControl.RoundDown == 2);
					Debug.Assert((int)RoundingControl.RoundUp == 3);
					Debug.Assert((int)RoundingControl.RoundTowardZero == 4);
					var text = rcStrings[(int)rc];
					if (text != null) {
						output.Write(" ", FormatterOutputTextKind.Text);
						FormatEvexMisc(output, text);
					}
				}
				else if (instruction.SuppressAllExceptions) {
					output.Write(" ", FormatterOutputTextKind.Text);
					FormatEvexMisc(output, "sae");
				}
			}

			output.OnOperand(operand, begin: false);
		}
		static readonly string[] rcStrings = new string[] {
			null,
			"rn-sae",
			"rd-sae",
			"ru-sae",
			"rz-sae",
		};

		void FormatEvexMisc(FormatterOutput output, string text) {
			if (options.UpperCaseOther || options.UpperCaseAll)
				text = text.ToUpperInvariant();
			output.Write("{", FormatterOutputTextKind.Punctuation);
			output.Write(text, FormatterOutputTextKind.Text);
			output.Write("}", FormatterOutputTextKind.Punctuation);
		}

		[MethodImpl(MethodImplOptions2.AggressiveInlining)]
		string ToString(Register reg) {
			Debug.Assert((uint)reg < (uint)allRegisters.Length);
			var regStr = allRegisters[(int)reg];
			if (options.UpperCaseRegisters || options.UpperCaseAll)
				regStr = regStr.ToUpperInvariant();
			return regStr;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void FormatRegister(FormatterOutput output, Register reg) =>
			output.Write(ToString(reg), FormatterOutputTextKind.Register);

		static readonly string[] scaleNumbers = new string[4] {
			"1", "2", "4", "8",
		};

		void FormatMemory(FormatterOutput output, ref Instruction instr, int operand, int instructionOperand, MemorySize memSize, Register segOverride, Register segReg, Register baseReg, Register indexReg, int scale, int displSize, long displ, int addrSize, InstrOpInfoFlags flags) {
			Debug.Assert((uint)scale < (uint)scaleNumbers.Length);
			Debug.Assert(InstructionUtils.GetAddressSizeInBytes(baseReg, indexReg, displSize, instr.CodeSize) == addrSize);

			var numberOptions = NumberFormattingOptions.CreateDisplacement(options);
			SymbolResult symbol;
			bool useSymbol;

			var operandOptions = (FormatterOperandOptions)((uint)options.MemorySizeOptions << (int)FormatterOperandOptions.MemorySizeShift);
			if (options.RipRelativeAddresses)
				operandOptions |= FormatterOperandOptions.RipRelativeAddresses;
			optionsProvider?.GetOperandOptions(operand, instructionOperand, ref instr, ref operandOptions, ref numberOptions);

			ulong absAddr;
			if (baseReg == Register.RIP) {
				absAddr = (ulong)((long)instr.NextIP + (int)displ);
				if ((operandOptions & FormatterOperandOptions.RipRelativeAddresses) == 0) {
					Debug.Assert(indexReg == Register.None);
					baseReg = Register.None;
					displ = (long)absAddr;
					displSize = 8;
				}
			}
			else if (baseReg == Register.EIP) {
				absAddr = instr.NextIP32 + (uint)displ;
				if ((operandOptions & FormatterOperandOptions.RipRelativeAddresses) == 0) {
					Debug.Assert(indexReg == Register.None);
					baseReg = Register.None;
					displ = (long)absAddr;
					displSize = 4;
				}
			}
			else
				absAddr = (ulong)displ;

			var symbolResolver = this.symbolResolver;
			if (symbolResolver != null)
				useSymbol = symbolResolver.TryGetSymbol(operand, instructionOperand, ref instr, absAddr, addrSize, out symbol);
			else {
				useSymbol = false;
				symbol = default;
			}

			bool useScale = scale != 0 || options.AlwaysShowScale;
			if (!useScale) {
				// [rsi] = base reg, [rsi*1] = index reg
				if (baseReg == Register.None)
					useScale = true;
			}
			if (addrSize == 16)
				useScale = false;

			CodeSize codeSize;
			bool is1632 = ((codeSize = instr.CodeSize) == CodeSize.Code16 || codeSize == CodeSize.Code32);
			bool hasMemReg = baseReg != Register.None || indexReg != Register.None;
			bool displInBrackets = useSymbol ? options.SymbolDisplInBrackets : options.DisplInBrackets;
			if ((!is1632 && !hasMemReg && !useSymbol) || (is1632 && !hasMemReg && !useSymbol && !options.AddDsPrefix32 && segOverride == Register.None))
				displInBrackets = true;
			bool needBrackets = hasMemReg || displInBrackets;

			FormatMemorySize(output, ref instr, ref symbol, memSize, flags, operandOptions, useSymbol);

			if (options.AlwaysShowSegmentRegister || segOverride != Register.None ||
				(is1632 && !hasMemReg && !useSymbol && options.AddDsPrefix32)) {
				FormatRegister(output, segReg);
				output.Write(":", FormatterOutputTextKind.Punctuation);
			}
			if (!displInBrackets)
				FormatMemoryDispl(output, symbol, ref numberOptions, absAddr, displ, displSize, addrSize, useSymbol, needPlus: false, forceDispl: !hasMemReg);
			if (needBrackets) {
				output.Write("[", FormatterOutputTextKind.Punctuation);
				if (options.SpaceAfterMemoryBracket)
					output.Write(" ", FormatterOutputTextKind.Text);
			}

			bool needPlus = false;
			if (baseReg != Register.None) {
				FormatRegister(output, baseReg);
				needPlus = true;
			}

			if (indexReg != Register.None) {
				if (needPlus) {
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					output.Write("+", FormatterOutputTextKind.Operator);
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
				}
				needPlus = true;

				if (!useScale)
					FormatRegister(output, indexReg);
				else if (options.ScaleBeforeIndex) {
					output.Write(scaleNumbers[scale], FormatterOutputTextKind.Number);
					if (options.SpaceBetweenMemoryMulOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					output.Write("*", FormatterOutputTextKind.Operator);
					if (options.SpaceBetweenMemoryMulOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					FormatRegister(output, indexReg);
				}
				else {
					FormatRegister(output, indexReg);
					if (options.SpaceBetweenMemoryMulOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					output.Write("*", FormatterOutputTextKind.Operator);
					if (options.SpaceBetweenMemoryMulOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					output.Write(scaleNumbers[scale], FormatterOutputTextKind.Number);
				}
			}

			if (displInBrackets)
				FormatMemoryDispl(output, symbol, ref numberOptions, absAddr, displ, displSize, addrSize, useSymbol, needPlus, forceDispl: !needPlus);

			if (needBrackets) {
				if (options.SpaceAfterMemoryBracket)
					output.Write(" ", FormatterOutputTextKind.Text);
				output.Write("]", FormatterOutputTextKind.Punctuation);
			}
		}

		void FormatMemoryDispl(FormatterOutput output, in SymbolResult symbol, ref NumberFormattingOptions numberOptions, ulong absAddr, long displ, int displSize, int addrSize, bool useSymbol, bool needPlus, bool forceDispl) {
			if (useSymbol) {
				if (needPlus) {
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
					if ((symbol.Flags & SymbolFlags.Signed) != 0)
						output.Write("-", FormatterOutputTextKind.Operator);
					else
						output.Write("+", FormatterOutputTextKind.Operator);
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
				}
				else if ((symbol.Flags & SymbolFlags.Signed) != 0)
					output.Write("-", FormatterOutputTextKind.Operator);

				output.Write(numberFormatter, numberOptions, absAddr, symbol, options.ShowSymbolAddress, false, options.SpaceBetweenMemoryAddOperators);
			}
			else if (forceDispl || (displSize != 0 && (options.ShowZeroDisplacements || displ != 0))) {
				if (needPlus) {
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);

					if (addrSize == 4) {
						if (!numberOptions.SignedNumber)
							output.Write("+", FormatterOutputTextKind.Operator);
						else if ((int)displ < 0) {
							output.Write("-", FormatterOutputTextKind.Operator);
							displ = (uint)-(int)displ;
						}
						else
							output.Write("+", FormatterOutputTextKind.Operator);
						if (numberOptions.SignExtendImmediate) {
							Debug.Assert(displSize <= 4);
							displSize = 4;
						}
					}
					else if (addrSize == 8) {
						if (!numberOptions.SignedNumber)
							output.Write("+", FormatterOutputTextKind.Operator);
						else if (displ < 0) {
							output.Write("-", FormatterOutputTextKind.Operator);
							displ = -displ;
						}
						else
							output.Write("+", FormatterOutputTextKind.Operator);
						if (numberOptions.SignExtendImmediate) {
							Debug.Assert(displSize <= 8);
							displSize = 8;
						}
					}
					else {
						Debug.Assert(addrSize == 2);
						if (!numberOptions.SignedNumber)
							output.Write("+", FormatterOutputTextKind.Operator);
						else if ((short)displ < 0) {
							output.Write("-", FormatterOutputTextKind.Operator);
							displ = (ushort)-(short)displ;
						}
						else
							output.Write("+", FormatterOutputTextKind.Operator);
						if (numberOptions.SignExtendImmediate) {
							Debug.Assert(displSize <= 2);
							displSize = 2;
						}
					}
					if (options.SpaceBetweenMemoryAddOperators)
						output.Write(" ", FormatterOutputTextKind.Text);
				}

				string s;
				if (displSize <= 1 && (ulong)displ <= byte.MaxValue)
					s = numberFormatter.FormatUInt8(numberOptions, (byte)displ);
				else if (displSize <= 2 && (ulong)displ <= ushort.MaxValue)
					s = numberFormatter.FormatUInt16(numberOptions, (ushort)displ);
				else if (displSize <= 4 && (ulong)displ <= uint.MaxValue)
					s = numberFormatter.FormatUInt32(numberOptions, (uint)displ);
				else if (displSize <= 8)
					s = numberFormatter.FormatUInt64(numberOptions, (ulong)displ);
				else
					throw new InvalidOperationException();
				output.Write(s, FormatterOutputTextKind.Number);
			}
		}

		void FormatMemorySize(FormatterOutput output, ref Instruction instr, ref SymbolResult symbol, MemorySize memSize, InstrOpInfoFlags flags, FormatterOperandOptions operandOptions, bool useSymbol) {
			var memSizeOptions = (MemorySizeOptions)(((uint)operandOptions >> (int)FormatterOperandOptions.MemorySizeShift) & ((uint)FormatterOperandOptions.MemorySizeMask >> (int)FormatterOperandOptions.MemorySizeShift));
			if (memSizeOptions == MemorySizeOptions.Never)
				return;

			var memType = flags & InstrOpInfoFlags.MemSize_Mask;
			if (memType == InstrOpInfoFlags.MemSize_Nothing)
				return;

			Debug.Assert((uint)memSize < (uint)allMemorySizes.Length);
			var memInfo = allMemorySizes[(int)memSize];
			var memSizeStrings = memInfo.names;

			switch (memInfo.size) {
			case 0:
				if (memType == InstrOpInfoFlags.MemSize_DwordOrQword) {
					if (instr.CodeSize == CodeSize.Code16 || instr.CodeSize == CodeSize.Code32)
						memSizeStrings = MemorySizes.dword_ptr;
					else
						memSizeStrings = MemorySizes.qword_ptr;
				}
				break;

			case 8:
				if (memType == InstrOpInfoFlags.MemSize_Mmx)
					memSizeStrings = MemorySizes.mmword_ptr;
				break;

			case 16:
				if (memType == InstrOpInfoFlags.MemSize_Normal)
					memSizeStrings = MemorySizes.oword_ptr;
				break;
			}

			if (memType == InstrOpInfoFlags.MemSize_XmmwordPtr)
				memSizeStrings = MemorySizes.xmmword_ptr;

			if (memSizeOptions == MemorySizeOptions.Default) {
				if (useSymbol && symbol.HasSymbolSize) {
					if (IsSameMemSize(memSizeStrings, memInfo.isBroadcast, ref symbol))
						return;
				}
				else if ((flags & InstrOpInfoFlags.ShowNoMemSize_ForceSize) == 0 && !memInfo.isBroadcast)
					return;
			}
			else if (memSizeOptions == MemorySizeOptions.Minimum) {
				if (useSymbol && symbol.HasSymbolSize) {
					if (IsSameMemSize(memSizeStrings, memInfo.isBroadcast, ref symbol))
						return;
				}
				if ((flags & InstrOpInfoFlags.ShowMinMemSize_ForceSize) == 0 && !memInfo.isBroadcast)
					return;
			}
			else
				Debug.Assert(memSizeOptions == MemorySizeOptions.Always);

			foreach (string name in memSizeStrings) {
				FormatKeyword(output, name);
				output.Write(" ", FormatterOutputTextKind.Text);
			}
		}

		bool IsSameMemSize(string[] memSizeStrings, bool isBroadcast, ref SymbolResult symbol) {
			if (isBroadcast)
				return false;
			Debug.Assert((uint)symbol.SymbolSize < (uint)allMemorySizes.Length);
			var symbolMemInfo = allMemorySizes[(int)symbol.SymbolSize];
			if (symbolMemInfo.isBroadcast)
				return false;
			var symbolMemSizeStrings = symbolMemInfo.names;
			return IsSameMemSize(memSizeStrings, symbolMemSizeStrings);
		}

		static bool IsSameMemSize(string[] a, string[] b) {
			if (a == b)
				return true;
			if (a.Length != b.Length)
				return false;
			for (int i = 0; i < a.Length; i++) {
				if (a[i] != b[i])
					return false;
			}
			return true;
		}

		void FormatKeyword(FormatterOutput output, string keyword) {
			if (options.UpperCaseKeywords || options.UpperCaseAll)
				keyword = keyword.ToUpperInvariant();
			output.Write(keyword, FormatterOutputTextKind.Keyword);
		}

		void FormatFlowControl(FormatterOutput output, FormatterFlowControl kind, FormatterOperandOptions operandOptions) {
			if ((operandOptions & FormatterOperandOptions.NoBranchSize) != 0)
				return;

			switch (kind) {
			case FormatterFlowControl.AlwaysShortBranch:
				break;

			case FormatterFlowControl.ShortBranch:
				FormatKeyword(output, "short");
				output.Write(" ", FormatterOutputTextKind.Text);
				break;

			case FormatterFlowControl.NearBranch:
				FormatKeyword(output, "near");
				output.Write(" ", FormatterOutputTextKind.Text);
				FormatKeyword(output, "ptr");
				output.Write(" ", FormatterOutputTextKind.Text);
				break;

			case FormatterFlowControl.NearCall:
				break;

			case FormatterFlowControl.FarBranch:
			case FormatterFlowControl.FarCall:
				FormatKeyword(output, "far");
				output.Write(" ", FormatterOutputTextKind.Text);
				FormatKeyword(output, "ptr");
				output.Write(" ", FormatterOutputTextKind.Text);
				break;

			case FormatterFlowControl.Xbegin:
				break;

			default:
				throw new ArgumentOutOfRangeException(nameof(kind));
			}
		}

		/// <summary>
		/// Formats a register
		/// </summary>
		/// <param name="register">Register</param>
		/// <returns></returns>
		public override string Format(Register register) => ToString(register);

		/// <summary>
		/// Formats a <see cref="sbyte"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatInt8(sbyte value, in NumberFormattingOptions numberOptions) {
			if (value < 0)
				return "-" + numberFormatter.FormatUInt8(numberOptions, (byte)-value);
			else
				return numberFormatter.FormatUInt8(numberOptions, (byte)value);
		}

		/// <summary>
		/// Formats a <see cref="short"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatInt16(short value, in NumberFormattingOptions numberOptions) {
			if (value < 0)
				return "-" + numberFormatter.FormatUInt16(numberOptions, (ushort)-value);
			else
				return numberFormatter.FormatUInt16(numberOptions, (ushort)value);
		}

		/// <summary>
		/// Formats a <see cref="int"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatInt32(int value, in NumberFormattingOptions numberOptions) {
			if (value < 0)
				return "-" + numberFormatter.FormatUInt32(numberOptions, (uint)-value);
			else
				return numberFormatter.FormatUInt32(numberOptions, (uint)value);
		}

		/// <summary>
		/// Formats a <see cref="long"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatInt64(long value, in NumberFormattingOptions numberOptions) {
			if (value < 0)
				return "-" + numberFormatter.FormatUInt64(numberOptions, (ulong)-value);
			else
				return numberFormatter.FormatUInt64(numberOptions, (ulong)value);
		}

		/// <summary>
		/// Formats a <see cref="byte"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatUInt8(byte value, in NumberFormattingOptions numberOptions) =>
			numberFormatter.FormatUInt8(numberOptions, value);

		/// <summary>
		/// Formats a <see cref="ushort"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatUInt16(ushort value, in NumberFormattingOptions numberOptions) =>
			numberFormatter.FormatUInt16(numberOptions, value);

		/// <summary>
		/// Formats a <see cref="uint"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatUInt32(uint value, in NumberFormattingOptions numberOptions) =>
			numberFormatter.FormatUInt32(numberOptions, value);

		/// <summary>
		/// Formats a <see cref="ulong"/>
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="numberOptions">Options</param>
		/// <returns></returns>
		public override string FormatUInt64(ulong value, in NumberFormattingOptions numberOptions) =>
			numberFormatter.FormatUInt64(numberOptions, value);
	}
}
#endif
