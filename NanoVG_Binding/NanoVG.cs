using System;
using System.Runtime.InteropServices;
using System.Reflection;

using NVGColor = System.Numerics.Vector4;
using NVGVertex = System.Numerics.Vector4;
using System.Text;

namespace NanoVG {
	public static unsafe partial class NVG {
		internal const string LibName = "nanovg";
		internal const CallingConvention CConv = CallingConvention.Cdecl;

		// May or may not exist
		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateGL3Glew))]
		public static extern IntPtr CreateGL3Glew(int Flags);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateInternal))]
		public static extern IntPtr CreateInternal(IntPtr Params);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(DeleteInternal))]
		public static extern void DeleteInternal(IntPtr Ctx);

		// Auto generated below

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(BeginFrame))]
		public static extern void BeginFrame(IntPtr Ctx, float windowWidth, float windowHeight, float devicePixelRatio);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CancelFrame))]
		public static extern void CancelFrame(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(EndFrame))]
		public static extern void EndFrame(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(GlobalCompositeOperation))]
		public static extern void GlobalCompositeOperation(IntPtr Ctx, int op);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(GlobalCompositeBlendFunc))]
		public static extern void GlobalCompositeBlendFunc(IntPtr Ctx, int sfactor, int dfactor);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(GlobalCompositeBlendFuncSeparate))]
		public static extern void GlobalCompositeBlendFuncSeparate(IntPtr Ctx, int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RGB))]
		public static extern NVGColor RGB(byte r, byte g, byte b);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RGBf))]
		public static extern NVGColor RGBf(float r, float g, float b);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RGBA))]
		public static extern NVGColor RGBA(byte r, byte g, byte b, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RGBAf))]
		public static extern NVGColor RGBAf(float r, float g, float b, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(LerpRGBA))]
		public static extern NVGColor LerpRGBA(NVGColor c0, NVGColor c1, float u);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransRGBA))]
		public static extern NVGColor TransRGBA(NVGColor c0, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransRGBAf))]
		public static extern NVGColor TransRGBAf(NVGColor c0, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(HSL))]
		public static extern NVGColor HSL(float h, float s, float l);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(HSLA))]
		public static extern NVGColor HSLA(float h, float s, float l, byte a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Save))]
		public static extern void Save(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Restore))]
		public static extern void Restore(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Reset))]
		public static extern void Reset(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ShapeAntiAlias))]
		public static extern void ShapeAntiAlias(IntPtr Ctx, int enabled);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(StrokeColor))]
		public static extern void StrokeColor(IntPtr Ctx, NVGColor color);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(StrokePaint))]
		public static extern void StrokePaint(IntPtr Ctx, NVGPaint paint);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FillColor))]
		public static extern void FillColor(IntPtr Ctx, NVGColor color);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FillPaint))]
		public static extern void FillPaint(IntPtr Ctx, NVGPaint paint);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(MiterLimit))]
		public static extern void MiterLimit(IntPtr Ctx, float limit);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(StrokeWidth))]
		public static extern void StrokeWidth(IntPtr Ctx, float size);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(LineCap))]
		public static extern void LineCap(IntPtr Ctx, int cap);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(LineJoin))]
		public static extern void LineJoin(IntPtr Ctx, int join);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(GlobalAlpha))]
		public static extern void GlobalAlpha(IntPtr Ctx, float alpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ResetTransform))]
		public static extern void ResetTransform(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Transform))]
		public static extern void Transform(IntPtr Ctx, float a, float b, float c, float d, float e, float f);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Translate))]
		public static extern void Translate(IntPtr Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Rotate))]
		public static extern void Rotate(IntPtr Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(SkewX))]
		public static extern void SkewX(IntPtr Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(SkewY))]
		public static extern void SkewY(IntPtr Ctx, float angle);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Scale))]
		public static extern void Scale(IntPtr Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CurrentTransform))]
		public static extern void CurrentTransform(IntPtr Ctx, float* xform);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformIdentity))]
		public static extern void TransformIdentity(float* dst);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformTranslate))]
		public static extern void TransformTranslate(float* dst, float tx, float ty);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformScale))]
		public static extern void TransformScale(float* dst, float sx, float sy);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformRotate))]
		public static extern void TransformRotate(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformSkewX))]
		public static extern void TransformSkewX(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformSkewY))]
		public static extern void TransformSkewY(float* dst, float a);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformMultiply))]
		public static extern void TransformMultiply(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformPremultiply))]
		public static extern void TransformPremultiply(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformInverse))]
		public static extern int TransformInverse(float* dst, float* src);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TransformPoint))]
		public static extern void TransformPoint(float* dstx, float* dsty, float* xform, float srcx, float srcy);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(DegToRad))]
		public static extern float DegToRad(float deg);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RadToDeg))]
		public static extern float RadToDeg(float rad);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateImage))]
		public static extern int CreateImage(IntPtr Ctx, string filename, int imageFlags);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateImageMem))]
		public static extern int CreateImageMem(IntPtr Ctx, int imageFlags, byte* data, int ndata);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateImageRGBA))]
		public static extern int CreateImageRGBA(IntPtr Ctx, int w, int h, int imageFlags, byte* data);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(UpdateImage))]
		public static extern void UpdateImage(IntPtr Ctx, int image, byte* data);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ImageSize))]
		public static extern void ImageSize(IntPtr Ctx, int image, int* w, int* h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(DeleteImage))]
		public static extern void DeleteImage(IntPtr Ctx, int image);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(LinearGradient))]
		public static extern NVGPaint LinearGradient(IntPtr Ctx, float sx, float sy, float ex, float ey, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(BoxGradient))]
		public static extern NVGPaint BoxGradient(IntPtr Ctx, float x, float y, float w, float h, float r, float f, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RadialGradient))]
		public static extern NVGPaint RadialGradient(IntPtr Ctx, float cx, float cy, float inr, float outr, NVGColor icol, NVGColor ocol);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ImagePattern))]
		public static extern NVGPaint ImagePattern(IntPtr Ctx, float ox, float oy, float ex, float ey, float angle, int image, float alpha);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Scissor))]
		public static extern void Scissor(IntPtr Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(IntersectScissor))]
		public static extern void IntersectScissor(IntPtr Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ResetScissor))]
		public static extern void ResetScissor(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(BeginPath))]
		public static extern void BeginPath(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(MoveTo))]
		public static extern void MoveTo(IntPtr Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(LineTo))]
		public static extern void LineTo(IntPtr Ctx, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(BezierTo))]
		public static extern void BezierTo(IntPtr Ctx, float c1x, float c1y, float c2x, float c2y, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(QuadTo))]
		public static extern void QuadTo(IntPtr Ctx, float cx, float cy, float x, float y);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ArcTo))]
		public static extern void ArcTo(IntPtr Ctx, float x1, float y1, float x2, float y2, float radius);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(ClosePath))]
		public static extern void ClosePath(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(PathWinding))]
		public static extern void PathWinding(IntPtr Ctx, NVGSolidity dir);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Arc))]
		public static extern void Arc(IntPtr Ctx, float cx, float cy, float r, float a0, float a1, NVGWinding dir);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Rect))]
		public static extern void Rect(IntPtr Ctx, float x, float y, float w, float h);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RoundedRect))]
		public static extern void RoundedRect(IntPtr Ctx, float x, float y, float w, float h, float r);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(RoundedRectVarying))]
		public static extern void RoundedRectVarying(IntPtr Ctx, float x, float y, float w, float h, float radTopLeft, float radTopRight, float radBottomRight, float radBottomLeft);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Ellipse))]
		public static extern void Ellipse(IntPtr Ctx, float cx, float cy, float rx, float ry);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Circle))]
		public static extern void Circle(IntPtr Ctx, float cx, float cy, float r);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Fill))]
		public static extern void Fill(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Stroke))]
		public static extern void Stroke(IntPtr Ctx);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateFont))]
		public static extern int CreateFont(IntPtr Ctx, string name, string filename);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(CreateFontMem))]
		public static extern int CreateFontMem(IntPtr Ctx, string name, byte* data, int ndata, int freeData);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FindFont))]
		public static extern int FindFont(IntPtr Ctx, string name);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(AddFallbackFontId))]
		public static extern int AddFallbackFontId(IntPtr Ctx, int baseFont, int fallbackFont);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(AddFallbackFont))]
		public static extern int AddFallbackFont(IntPtr Ctx, string baseFont, string fallbackFont);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FontSize))]
		public static extern void FontSize(IntPtr Ctx, float size);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FontBlur))]
		public static extern void FontBlur(IntPtr Ctx, float blur);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextLetterSpacing))]
		public static extern void TextLetterSpacing(IntPtr Ctx, float spacing);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextLineHeight))]
		public static extern void TextLineHeight(IntPtr Ctx, float lineHeight);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextAlign))]
		public static extern void TextAlign(IntPtr Ctx, NVGAlign align);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FontFaceId))]
		public static extern void FontFaceId(IntPtr Ctx, int font);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(FontFace))]
		public static extern void FontFace(IntPtr Ctx, string font);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Text))]
		public static extern float Text(IntPtr Ctx, float x, float y, byte[] Str, byte[] end);

		//[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(Text))]
		//public static extern float Text(IntPtr Ctx, float x, float y, string Str, string end);

		public static float Text(IntPtr Ctx, float x, float y, string Str, string End) {
			return Text(Ctx, x, y, StrToUTF8(Str), StrToUTF8(End));
		}

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextBox))]
		public static extern void TextBox(IntPtr Ctx, float x, float y, float breakRowWidth, string Str, string end);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextBounds))]
		public static extern float TextBounds(IntPtr Ctx, float x, float y, string Str, string end, float* bounds);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextBoxBounds))]
		public static extern void TextBoxBounds(IntPtr Ctx, float x, float y, float breakRowWidth, string Str, string end, float* bounds);

		// TODO: NVGglyphPosition*
		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextGlyphPositions))]
		public static extern int TextGlyphPositions(IntPtr Ctx, float x, float y, string Str, string end, IntPtr positions, int maxPositions);

		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextMetrics))]
		public static extern void TextMetrics(IntPtr Ctx, float* ascender, float* descender, float* lineh);

		// TODO: NVGtextRow*
		[DllImport(LibName, CallingConvention = CConv, EntryPoint = "nvg" + nameof(TextBreakLines))]
		public static extern int TextBreakLines(IntPtr Ctx, string Str, string end, float breakRowWidth, IntPtr rows, int maxRows);
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

		public static IntPtr CreateContext(NVGParameters ParamsImpl, IntPtr? UserPtr = null, bool EdgeAntiAlias = true) {
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
			IntPtr Ctx = CreateInternal(NvgParamsHandle.AddrOfPinnedObject());
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