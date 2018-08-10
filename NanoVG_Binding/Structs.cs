using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NVGColor = System.Numerics.Vector4;
using NVGVertex = System.Numerics.Vector4;

namespace NanoVG {
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	sealed class FuncPtrAttribute : Attribute {
		public Type DelegateType;
	}

	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate int renderCreateFunc(IntPtr uptr);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate int renderCreateTextureFunc(IntPtr uptr, int type, int w, int h, NVGImageFlags imageFlags, IntPtr data);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate int renderDeleteTextureFunc(IntPtr uptr, int image);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate int renderUpdateTextureFunc(IntPtr uptr, int image, int x, int y, int w, int h, IntPtr data);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate int renderGetTextureSizeFunc(IntPtr uptr, int image, out int w, out int h);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate void renderViewportFunc(IntPtr uptr, float width, float height, float devicePixelRatio);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate void renderCancelFunc(IntPtr uptr);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate void renderFlushFunc(IntPtr uptr);
	[UnmanagedFunctionPointer(NanoVG_Native.CConv)] delegate void renderDeleteFunc(IntPtr uptr);

	// TODO
	unsafe delegate void renderFillFunc(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, float Fringe, float* Bounds, NVGPath* Paths, int Num);
	unsafe delegate void renderStrokeFunc(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, float Fringe, float StrokeWdth, NVGPath* Paths, int Num);
	unsafe delegate void renderTrianglesFunc(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, NVGVertex* Vrts, int Num);

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	unsafe struct NVGparams {
		public IntPtr UserPtr;
		public int EdgeAntiAlias;

		[FuncPtr(DelegateType = typeof(renderCreateFunc))]
		public IntPtr renderCreate;

		[FuncPtr(DelegateType = typeof(renderCreateTextureFunc))]
		public IntPtr renderCreateTexture;
		[FuncPtr(DelegateType = typeof(renderDeleteTextureFunc))]
		public IntPtr renderDeleteTexture;
		[FuncPtr(DelegateType = typeof(renderUpdateTextureFunc))]
		public IntPtr renderUpdateTexture;
		[FuncPtr(DelegateType = typeof(renderGetTextureSizeFunc))]
		public IntPtr renderGetTextureSize;

		[FuncPtr(DelegateType = typeof(renderViewportFunc))]
		public IntPtr renderViewport;
		[FuncPtr(DelegateType = typeof(renderCancelFunc))]
		public IntPtr renderCancel;
		[FuncPtr(DelegateType = typeof(renderFlushFunc))]
		public IntPtr renderFlush;
		[FuncPtr(DelegateType = typeof(renderFillFunc))]
		public IntPtr renderFill;
		[FuncPtr(DelegateType = typeof(renderStrokeFunc))]
		public IntPtr renderStroke;
		[FuncPtr(DelegateType = typeof(renderTrianglesFunc))]
		public IntPtr renderTriangles;
		[FuncPtr(DelegateType = typeof(renderDeleteFunc))]
		public IntPtr renderDelete;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NVGCompositeOpState {
		public int SrcRGB;
		public int DstRGB;
		public int SrcAlpha;
		public int DstAlpha;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NVGScissor {
		//float xform[6];
		//float extent[2];

		public float XForm1;
		public float XForm2;
		public float XForm3;
		public float XForm4;
		public float XForm5;
		public float XForm6;

		public float Extent1;
		public float Extent2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NVGPaint {
		public float XForm1;
		public float XForm2;
		public float XForm3;
		public float XForm4;
		public float XForm5;
		public float XForm6;

		public float Extent1;
		public float Extent2;

		public float Radius;
		public float Feather;

		public NVGColor InnerColor;
		public NVGColor OuterColor;

		public int Image;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public unsafe struct NVGPath {
		public int First;
		public int Count;
		public byte Closed;
		public int NBevel;
		public NVGVertex* Fill;
		public int NFill;
		public NVGVertex* Stroke;
		public int NStroke;
		public int Winding;
		public int Convex;
	}

	public enum NVGImageFlags : int {
		NVG_IMAGE_GENERATE_MIPMAPS = 1 << 0,     // Generate mipmaps during creation of the image.
		NVG_IMAGE_REPEATX = 1 << 1,     // Repeat image in X direction.
		NVG_IMAGE_REPEATY = 1 << 2,     // Repeat image in Y direction.
		NVG_IMAGE_FLIPY = 1 << 3,       // Flips (inverses) image in Y direction when rendered.
		NVG_IMAGE_PREMULTIPLIED = 1 << 4,       // Image data has premultiplied alpha.
		NVG_IMAGE_NEAREST = 1 << 5,     // Image interpolation is Nearest instead Linear
	};

	public unsafe abstract class NVGParameters {
		public abstract int RenderCreate(IntPtr UPtr);
		public abstract int RenderCreateTexture(IntPtr UPtr, int Type, int W, int H, NVGImageFlags ImageFlags, IntPtr Data);
		public abstract int RenderDeleteTexture(IntPtr UPtr, int Image);
		public abstract int RenderUpdateTexture(IntPtr UPtr, int Image, int X, int Y, int W, int H, IntPtr Data);
		public abstract int RenderGetTextureSize(IntPtr UPtr, int Image, out int W, out int H);
		public abstract void RenderViewport(IntPtr UPtr, float W, float H, float DevPixelRatio);
		public abstract void RenderCancel(IntPtr UPtr);
		public abstract void RenderFlush(IntPtr UPtr);
		public abstract void RenderDelete(IntPtr UPtr);

		// TODO
		public virtual void RenderFill(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, float Fringe, float* Bounds, NVGPath* Paths, int Num) {
			NVGPath[] PathsArr = new NVGPath[Num];
			for (int i = 0; i < Num; i++)
				PathsArr[i] = Paths[i];

			RenderFillSafe(UPtr, *Paint, Op, *Scsr, Fringe, new float[] { Bounds[0], Bounds[1], Bounds[2], Bounds[3] }, PathsArr);
		}

		public virtual void RenderStroke(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, float Fringe, float StrokeWdth, NVGPath* Paths, int Num) {
			NVGPath[] PathsArr = new NVGPath[Num];
			for (int i = 0; i < Num; i++)
				PathsArr[i] = Paths[i];

			RenderStrokeSafe(UPtr, *Paint, Op, *Scsr, Fringe, StrokeWdth, PathsArr);
		}

		public virtual void RenderTriangles(IntPtr UPtr, NVGPaint* Paint, NVGCompositeOpState Op, NVGScissor* Scsr, NVGVertex* Vrts, int Num) {
			NVGVertex[] VrtsArr = new NVGVertex[Num];
			for (int i = 0; i < Num; i++)
				VrtsArr[i] = Vrts[i];

			RenderTrianglesSafe(UPtr, *Paint, Op, *Scsr, VrtsArr);
		}

		public abstract void RenderFillSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, float Fringe, float[] Bounds, NVGPath[] Paths);
		public abstract void RenderStrokeSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, float Fringe, float StrokeWdth, NVGPath[] Paths);
		public abstract void RenderTrianglesSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, NVGVertex[] Vrts);
	}
}
