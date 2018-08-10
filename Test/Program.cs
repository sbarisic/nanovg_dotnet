using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using NanoVG;

namespace Test {
	class Params : NVGParameters {
		public override void RenderCancel(IntPtr UPtr) {
		}

		public override int RenderCreate(IntPtr UPtr) {
			return 1;
		}

		public override int RenderCreateTexture(IntPtr UPtr, int Type, int W, int H, NVGImageFlags ImageFlags, IntPtr Data) {
			return 1;
		}

		public override void RenderDelete(IntPtr UPtr) {
		}

		public override void RenderFlush(IntPtr UPtr) {
		}

		public override int RenderDeleteTexture(IntPtr UPtr, int Image) {
			return 0;
		}

		public override int RenderGetTextureSize(IntPtr UPtr, int Image, out int W, out int H) {
			W = H = 0;
			return 0;
		}

		public override int RenderUpdateTexture(IntPtr UPtr, int Image, int X, int Y, int W, int H, IntPtr Data) {
			return 0;
		}

		public override void RenderViewport(IntPtr UPtr, float W, float H, float DevPixelRatio) {
		}

		public override void RenderFillSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, float Fringe, float[] Bounds, NVGPath[] Paths) {
		}

		public override void RenderStrokeSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, float Fringe, float StrokeWdth, NVGPath[] Paths) {
		}

		public override void RenderTrianglesSafe(IntPtr UPtr, NVGPaint Paint, NVGCompositeOpState Op, NVGScissor Scsr, Vector4[] Vrts) {
		}
	}

	static class Program {
		static void Main(string[] args) {
			NVG.SetLibraryDirectory();
			IntPtr Ctx = NVG.CreateContext(new Params());

			Console.WriteLine("Done!");
			Console.ReadLine();
		}
	}
}
