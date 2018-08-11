using System;
using System.Runtime.InteropServices;
using System.Reflection;

using NVGColor = System.Numerics.Vector4;
using NVGVertex = System.Numerics.Vector4;
using System.Text;

namespace NanoVG {
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NanoVGContext {
		public IntPtr Handle;
	}

	public static unsafe partial class NVG {
		internal const string FuncPrefix = "nvg";
		internal const string LibName = "nanovg";
		internal const CallingConvention CConv = CallingConvention.Cdecl;

		// May or may not exist
		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateGL3Glew))]
		public static extern NanoVGContext CreateGL3Glew(int Flags);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateInternal))]
		public static extern NanoVGContext CreateInternal(IntPtr Params);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(DeleteInternal))]
		public static extern void DeleteInternal(NanoVGContext Ctx);

		public static float Text(this NanoVGContext Ctx, float x, float y, string Str, string End) {
			return Text(Ctx, x, y, StrToUTF8(Str), StrToUTF8(End));
		}

		public static int CreateFont(this NanoVGContext Ctx, string name, string filename) {
			return CreateFont(Ctx, StrToUTF8(name), StrToUTF8(filename));
		}

		public static void FontFace(this NanoVGContext Ctx, string font) {
			FontFace(Ctx, StrToUTF8(font));
		}

		#region AUTO_GENERATED
		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(BeginFrame))]
		public static extern void BeginFrame(this NanoVGContext Ctx, float windowWidth, float windowHeight, float devicePixelRatio);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CancelFrame))]
		public static extern void CancelFrame(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(EndFrame))]
		public static extern void EndFrame(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(GlobalCompositeOperation))]
		public static extern void GlobalCompositeOperation(this NanoVGContext Ctx, int op);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(GlobalCompositeBlendFunc))]
		public static extern void GlobalCompositeBlendFunc(this NanoVGContext Ctx, int sfactor, int dfactor);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(GlobalCompositeBlendFuncSeparate))]
		public static extern void GlobalCompositeBlendFuncSeparate(this NanoVGContext Ctx, int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RGB))]
		public static extern NVGColor RGB(byte r, byte g, byte b);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RGBf))]
		public static extern NVGColor RGBf(float r, float g, float b);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RGBA))]
		public static extern NVGColor RGBA(byte r, byte g, byte b, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RGBAf))]
		public static extern NVGColor RGBAf(float r, float g, float b, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(LerpRGBA))]
		public static extern NVGColor LerpRGBA(NVGColor c0, NVGColor c1, float u);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransRGBA))]
		public static extern NVGColor TransRGBA(NVGColor c0, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransRGBAf))]
		public static extern NVGColor TransRGBAf(NVGColor c0, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(HSL))]
		public static extern NVGColor HSL(float h, float s, float l);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(HSLA))]
		public static extern NVGColor HSLA(float h, float s, float l, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Save))]
		public static extern void Save(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Restore))]
		public static extern void Restore(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Reset))]
		public static extern void Reset(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ShapeAntiAlias))]
		public static extern void ShapeAntiAlias(this NanoVGContext Ctx, int enabled);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(StrokeColor))]
		public static extern void StrokeColor(this NanoVGContext Ctx, NVGColor color);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(StrokePaint))]
		public static extern void StrokePaint(this NanoVGContext Ctx, NVGPaint paint);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FillColor))]
		public static extern void FillColor(this NanoVGContext Ctx, NVGColor color);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FillPaint))]
		public static extern void FillPaint(this NanoVGContext Ctx, NVGPaint paint);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(MiterLimit))]
		public static extern void MiterLimit(this NanoVGContext Ctx, float limit);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(StrokeWidth))]
		public static extern void StrokeWidth(this NanoVGContext Ctx, float size);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(LineCap))]
		public static extern void LineCap(this NanoVGContext Ctx, int cap);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(LineJoin))]
		public static extern void LineJoin(this NanoVGContext Ctx, int join);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(GlobalAlpha))]
		public static extern void GlobalAlpha(this NanoVGContext Ctx, float alpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ResetTransform))]
		public static extern void ResetTransform(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Transform))]
		public static extern void Transform(this NanoVGContext Ctx, float a, float b, float c, float d, float e, float f);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Translate))]
		public static extern void Translate(this NanoVGContext Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Rotate))]
		public static extern void Rotate(this NanoVGContext Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(SkewX))]
		public static extern void SkewX(this NanoVGContext Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(SkewY))]
		public static extern void SkewY(this NanoVGContext Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Scale))]
		public static extern void Scale(this NanoVGContext Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CurrentTransform))]
		public static extern void CurrentTransform(this NanoVGContext Ctx, float* xform);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformIdentity))]
		public static extern void TransformIdentity(float* dst);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformTranslate))]
		public static extern void TransformTranslate(float* dst, float tx, float ty);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformScale))]
		public static extern void TransformScale(float* dst, float sx, float sy);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformRotate))]
		public static extern void TransformRotate(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformSkewX))]
		public static extern void TransformSkewX(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformSkewY))]
		public static extern void TransformSkewY(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformMultiply))]
		public static extern void TransformMultiply(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformPremultiply))]
		public static extern void TransformPremultiply(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformInverse))]
		public static extern int TransformInverse(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TransformPoint))]
		public static extern void TransformPoint(float* dstx, float* dsty, float* xform, float srcx, float srcy);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(DegToRad))]
		public static extern float DegToRad(float deg);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RadToDeg))]
		public static extern float RadToDeg(float rad);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateImage))]
		public static extern int CreateImage(this NanoVGContext Ctx, byte[] filename, int imageFlags);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateImageMem))]
		public static extern int CreateImageMem(this NanoVGContext Ctx, int imageFlags, byte* data, int ndata);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateImageRGBA))]
		public static extern int CreateImageRGBA(this NanoVGContext Ctx, int w, int h, int imageFlags, byte* data);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(UpdateImage))]
		public static extern void UpdateImage(this NanoVGContext Ctx, int image, byte* data);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ImageSize))]
		public static extern void ImageSize(this NanoVGContext Ctx, int image, int* w, int* h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(DeleteImage))]
		public static extern void DeleteImage(this NanoVGContext Ctx, int image);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(LinearGradient))]
		public static extern NVGPaint LinearGradient(this NanoVGContext Ctx, float sx, float sy, float ex, float ey, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(BoxGradient))]
		public static extern NVGPaint BoxGradient(this NanoVGContext Ctx, float x, float y, float w, float h, float r, float f, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RadialGradient))]
		public static extern NVGPaint RadialGradient(this NanoVGContext Ctx, float cx, float cy, float inr, float outr, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ImagePattern))]
		public static extern NVGPaint ImagePattern(this NanoVGContext Ctx, float ox, float oy, float ex, float ey, float angle, int image, float alpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Scissor))]
		public static extern void Scissor(this NanoVGContext Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(IntersectScissor))]
		public static extern void IntersectScissor(this NanoVGContext Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ResetScissor))]
		public static extern void ResetScissor(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(BeginPath))]
		public static extern void BeginPath(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(MoveTo))]
		public static extern void MoveTo(this NanoVGContext Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(LineTo))]
		public static extern void LineTo(this NanoVGContext Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(BezierTo))]
		public static extern void BezierTo(this NanoVGContext Ctx, float c1x, float c1y, float c2x, float c2y, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(QuadTo))]
		public static extern void QuadTo(this NanoVGContext Ctx, float cx, float cy, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ArcTo))]
		public static extern void ArcTo(this NanoVGContext Ctx, float x1, float y1, float x2, float y2, float radius);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(ClosePath))]
		public static extern void ClosePath(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(PathWinding))]
		public static extern void PathWinding(this NanoVGContext Ctx, NVGSolidity dir);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Arc))]
		public static extern void Arc(this NanoVGContext Ctx, float cx, float cy, float r, float a0, float a1, NVGWinding dir);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Rect))]
		public static extern void Rect(this NanoVGContext Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RoundedRect))]
		public static extern void RoundedRect(this NanoVGContext Ctx, float x, float y, float w, float h, float r);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(RoundedRectVarying))]
		public static extern void RoundedRectVarying(this NanoVGContext Ctx, float x, float y, float w, float h, float radTopLeft, float radTopRight, float radBottomRight, float radBottomLeft);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Ellipse))]
		public static extern void Ellipse(this NanoVGContext Ctx, float cx, float cy, float rx, float ry);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Circle))]
		public static extern void Circle(this NanoVGContext Ctx, float cx, float cy, float r);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Fill))]
		public static extern void Fill(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Stroke))]
		public static extern void Stroke(this NanoVGContext Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateFont))]
		public static extern int CreateFont(this NanoVGContext Ctx, byte[] name, byte[] filename);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(CreateFontMem))]
		public static extern int CreateFontMem(this NanoVGContext Ctx, byte[] name, byte* data, int ndata, int freeData);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FindFont))]
		public static extern int FindFont(this NanoVGContext Ctx, byte[] name);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(AddFallbackFontId))]
		public static extern int AddFallbackFontId(this NanoVGContext Ctx, int baseFont, int fallbackFont);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(AddFallbackFont))]
		public static extern int AddFallbackFont(this NanoVGContext Ctx, byte[] baseFont, byte[] fallbackFont);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FontSize))]
		public static extern void FontSize(this NanoVGContext Ctx, float size);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FontBlur))]
		public static extern void FontBlur(this NanoVGContext Ctx, float blur);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextLetterSpacing))]
		public static extern void TextLetterSpacing(this NanoVGContext Ctx, float spacing);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextLineHeight))]
		public static extern void TextLineHeight(this NanoVGContext Ctx, float lineHeight);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextAlign))]
		public static extern void TextAlign(this NanoVGContext Ctx, NVGAlign align);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FontFaceId))]
		public static extern void FontFaceId(this NanoVGContext Ctx, int font);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(FontFace))]
		public static extern void FontFace(this NanoVGContext Ctx, byte[] font);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(Text))]
		public static extern float Text(this NanoVGContext Ctx, float x, float y, byte[] Str, byte[] end);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextBox))]
		public static extern void TextBox(this NanoVGContext Ctx, float x, float y, float breakRowWidth, byte[] Str, byte[] end);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextBounds))]
		public static extern float TextBounds(this NanoVGContext Ctx, float x, float y, byte[] Str, byte[] end, float* bounds);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextBoxBounds))]
		public static extern void TextBoxBounds(this NanoVGContext Ctx, float x, float y, float breakRowWidth, byte[] Str, byte[] end, float* bounds);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextGlyphPositions))]
		public static extern int TextGlyphPositions(this NanoVGContext Ctx, float x, float y, byte[] Str, byte[] end, /* NVGglyphPosition* */ IntPtr positions, int maxPositions);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextMetrics))]
		public static extern void TextMetrics(this NanoVGContext Ctx, float* ascender, float* descender, float* lineh);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = FuncPrefix + nameof(TextBreakLines))]
		public static extern int TextBreakLines(this NanoVGContext Ctx, byte[] Str, byte[] end, float breakRowWidth, /*NVGtextRow* */ IntPtr rows, int maxRows);

		#endregion
	}

	public static unsafe partial class NVG {
		[DllImport("kernel32")]
		static extern bool SetDllDirectory(string PathName);

		public static void SetLibraryDirectory(string x86 = "x86", string x64 = "x64") {
			if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
				if (IntPtr.Size == 8)
					SetDllDirectory(x64);
				else
					SetDllDirectory(x86);
			}

			// TODO: non-windows stuff
		}

		public static NanoVGContext CreateContext(NVGParameters ParamsImpl, IntPtr? UserPtr = null, bool EdgeAntiAlias = true) {
			object NvgParamsObj = new NVGparams();

			Type ImplType = ParamsImpl.GetType();
			FieldInfo[] Fields = typeof(NVGparams).GetFields();

			// Convert all interface methods to delegates and populate the struct
			foreach (var Field in Fields) {
				FuncPtrAttribute FuncPtr;

				// If it's not a function pointer (delegate) field, continue
				if ((FuncPtr = Field.GetCustomAttribute<FuncPtrAttribute>()) == null)
					continue;

				string ImplMethodName = char.ToUpper(Field.Name[0]) + Field.Name.Substring(1);
				MethodInfo ImplMethod = ImplType.GetMethod(ImplMethodName);

				Delegate D = Delegate.CreateDelegate(FuncPtr.DelegateType, ParamsImpl, ImplMethod);
				GCHandle.Alloc(D);

				Field.SetValue(NvgParamsObj, Marshal.GetFunctionPointerForDelegate(D));
			}

			NVGparams NvgParams = (NVGparams)NvgParamsObj;
			NvgParams.EdgeAntiAlias = EdgeAntiAlias ? 1 : 0;
			NvgParams.UserPtr = UserPtr ?? IntPtr.Zero;

			// Fix if changes
			// nvgCreateInternal copies the struct, so i don't need to keep the pointer to the object
			GCHandle NvgParamsHandle = GCHandle.Alloc(NvgParams, GCHandleType.Pinned);
			NanoVGContext Ctx = CreateInternal(NvgParamsHandle.AddrOfPinnedObject());
			NvgParamsHandle.Free();
			return Ctx;
		}

		static byte[] StrToUTF8(string Str) {
			if (Str == null)
				return null;

			return Encoding.UTF8.GetBytes(Str);
		}
	}
}