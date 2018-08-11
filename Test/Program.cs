using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using Glfw3;
using NanoVG;

namespace Test {
	static class Program {
		static void Main(string[] args) {
			NVG.SetLibraryDirectory();
			Glfw.Init();

			Glfw.WindowHint(Glfw.Hint.ContextVersionMajor, 3);
			Glfw.WindowHint(Glfw.Hint.ContextVersionMinor, 2);
			Glfw.WindowHint(Glfw.Hint.OpenglForwardCompat, true);
			Glfw.WindowHint(Glfw.Hint.OpenglProfile, Glfw.OpenGLProfile.Core);

			Glfw.WindowHint(Glfw.Hint.Samples, 4);

			Glfw.Window Wnd = Glfw.CreateWindow(800, 600, "NanoVG.NET");
			Glfw.MakeContextCurrent(Wnd);
			Glfw.GetFramebufferSize(Wnd, out int FbW, out int FbH);

			IntPtr Ctx = NVG.CreateGL3Glew(3);
			Glfw.SwapInterval(0);

			int Icons = NVG.CreateFont(Ctx, "icons", "data/fonts/entypo.ttf");
			int Sans = NVG.CreateFont(Ctx, "sans", "data/fonts/Roboto-Regular.ttf");
			int SansBold = NVG.CreateFont(Ctx, "sans-bold", "data/fonts/Roboto-Bold.ttf");
			int Emoji = NVG.CreateFont(Ctx, "emoji", "data/fonts/NotoEmoji-Regular.ttf");
			//NVG.CreateFont(Ctx, "sans-bold", "data/fonts/Roboto-Bold.ttf");

			NVG.AddFallbackFontId(Ctx, Sans, Emoji);
			NVG.AddFallbackFontId(Ctx, SansBold, Emoji);

			while (!Glfw.WindowShouldClose(Wnd)) {
				NVG.BeginFrame(Ctx, 800, 600, (float)FbW / FbH);

				Demo(Ctx);

				NVG.EndFrame(Ctx);
				Glfw.SwapBuffers(Wnd);
				Glfw.PollEvents();
			}
		}

		static void Demo(IntPtr vg) {
			int x = 0;
			int y = 0;

			// Widgets
			DrawWindow(vg, "Widgets 'n Stuff", 50, 50, 300, 400);
			x = 60;
			y = 95;
			DrawSearchBox(vg, "Search 😂🔫", x, y, 280, 25);

			DrawColorWheel(vg, 300, 150, 400, 400, 1);
		}

		const int ICON_SEARCH = 0x1F50D;
		const int ICON_CIRCLED_CROSS = 0x2716;
		const int ICON_CHEVRON_RIGHT = 0xE75E;
		const int ICON_CHECK = 0x2713;
		const int ICON_LOGIN = 0xE740;
		const int ICON_TRASH = 0xE729;

		static byte[] cpToUTF8(int cp) {
			byte[] str = new byte[8];
			int n = 0;

			if (cp < 0x80)
				n = 1;
			else if (cp < 0x800)
				n = 2;
			else if (cp < 0x10000)
				n = 3;
			else if (cp < 0x200000)
				n = 4;
			else if (cp < 0x4000000)
				n = 5;
			else if (cp <= 0x7fffffff)
				n = 6;

			str[n] = 0;

			switch (n) {
				case 6:
					str[5] = (byte)(0x80 | (cp & 0x3f));
					cp = cp >> 6;
					cp |= 0x4000000;
					goto case 5;

				case 5:
					str[4] = (byte)(0x80 | (cp & 0x3f));
					cp = cp >> 6;
					cp |= 0x200000;
					goto case 4;

				case 4:
					str[3] = (byte)(0x80 | (cp & 0x3f));
					cp = cp >> 6;
					cp |= 0x10000;
					goto case 3;

				case 3:
					str[2] = (byte)(0x80 | (cp & 0x3f));
					cp = cp >> 6;
					cp |= 0x800;
					goto case 2;

				case 2:
					str[1] = (byte)(0x80 | (cp & 0x3f));
					cp = cp >> 6;
					cp |= 0xc0;
					goto case 1;

				case 1:
					str[0] = (byte)cp;
					break;
			}
			return str;
		}

		static void DrawWindow(IntPtr Ctx, string Title, float X, float Y, float W, float H) {
			float CornerRadius = 3;
			NVGPaint ShadowPaint;
			NVGPaint HeaderPaint;
			NVG.Save(Ctx);

			// Window
			NVG.BeginPath(Ctx);
			NVG.RoundedRect(Ctx, X, Y, W, H, CornerRadius);
			NVG.FillColor(Ctx, NVG.RGBA(28, 30, 34, 192));
			NVG.Fill(Ctx);

			// Drop shadow
			ShadowPaint = NVG.BoxGradient(Ctx, X, Y + 2, W, H, CornerRadius * 2, 10, NVG.RGBA(0, 0, 0, 128), NVG.RGBA(0, 0, 0, 0));
			NVG.BeginPath(Ctx);
			NVG.Rect(Ctx, X - 10, Y - 10, W + 20, H + 30);
			NVG.RoundedRect(Ctx, X, Y, W, H, CornerRadius);
			NVG.PathWinding(Ctx, NVGSolidity.NVG_HOLE);
			NVG.FillPaint(Ctx, ShadowPaint);
			NVG.Fill(Ctx);

			// Header
			HeaderPaint = NVG.LinearGradient(Ctx, X, Y, X, Y + 15, NVG.RGBA(255, 255, 255, 8), NVG.RGBA(0, 0, 0, 16));
			NVG.BeginPath(Ctx);
			NVG.RoundedRect(Ctx, X + 1, Y + 1, W - 2, 30, CornerRadius - 1);
			NVG.FillPaint(Ctx, HeaderPaint);
			NVG.Fill(Ctx);
			NVG.BeginPath(Ctx);
			NVG.MoveTo(Ctx, X + 0.5f, Y + 0.5f + 30);
			NVG.LineTo(Ctx, X + 0.5f + W - 1, Y + 0.5f + 30);
			NVG.StrokeColor(Ctx, NVG.RGBA(0, 0, 0, 32));
			NVG.Stroke(Ctx);

			NVG.FontSize(Ctx, 18.0f);
			NVG.FontFace(Ctx, "sans-bold");
			NVG.TextAlign(Ctx, NVGAlign.NVG_ALIGN_CENTER | NVGAlign.NVG_ALIGN_MIDDLE);

			NVG.FontBlur(Ctx, 2);
			NVG.FillColor(Ctx, NVG.RGBA(0, 0, 0, 128));
			NVG.Text(Ctx, X + W / 2, Y + 16 + 1, Title, null);

			NVG.FontBlur(Ctx, 0);
			NVG.FillColor(Ctx, NVG.RGBA(220, 220, 220, 160));
			NVG.Text(Ctx, X + W / 2, Y + 16, Title, null);

			NVG.Restore(Ctx);
		}

		static void DrawSearchBox(IntPtr vg, string text, float x, float y, float w, float h) {
			NVGPaint bg;
			float cornerRadius = h / 2 - 1;

			// Edit
			bg = NVG.BoxGradient(vg, x, y + 1.5f, w, h, h / 2, 5, NVG.RGBA(0, 0, 0, 16), NVG.RGBA(0, 0, 0, 92));
			NVG.BeginPath(vg);
			NVG.RoundedRect(vg, x, y, w, h, cornerRadius);
			NVG.FillPaint(vg, bg);
			NVG.Fill(vg);

			/*	NVG.BeginPath(vg);
				NVG.RoundedRect(vg, x+0.5f,y+0.5f, w-1,h-1, cornerRadius-0.5f);
				NVG.StrokeColor(vg, NVG.RGBA(0,0,0,48));
				NVG.Stroke(vg);*/

			NVG.FontSize(vg, h * 1.3f);
			NVG.FontFace(vg, "icons");
			NVG.FillColor(vg, NVG.RGBA(255, 255, 255, 64));
			NVG.TextAlign(vg, NVGAlign.NVG_ALIGN_CENTER | NVGAlign.NVG_ALIGN_MIDDLE);
			NVG.Text(vg, x + h * 0.55f, y + h * 0.55f, cpToUTF8(ICON_SEARCH), null);

			NVG.FontSize(vg, 20.0f);
			NVG.FontFace(vg, "sans");
			NVG.FillColor(vg, NVG.RGBA(255, 255, 255, 32));

			NVG.TextAlign(vg, NVGAlign.NVG_ALIGN_LEFT | NVGAlign.NVG_ALIGN_MIDDLE);
			NVG.Text(vg, x + h * 1.05f, y + h * 0.5f, text, null);

			NVG.FontSize(vg, h * 1.3f);
			NVG.FontFace(vg, "icons");
			NVG.FillColor(vg, NVG.RGBA(255, 255, 255, 32));
			NVG.TextAlign(vg, NVGAlign.NVG_ALIGN_CENTER | NVGAlign.NVG_ALIGN_MIDDLE);
			NVG.Text(vg, x + w - h * 0.55f, y + h * 0.55f, cpToUTF8(ICON_CIRCLED_CROSS), null);
		}

		static void DrawColorWheel(IntPtr vg, float x, float y, float w, float h, float t) {
			int i;
			float r0, r1, ax, ay, bx, by, cx, cy, aeps, r;
			float hue = (float)Math.Sin(t * 0.12f);
			NVGPaint paint;

			NVG.Save(vg);

			/*	NVG.BeginPath(vg);
				NVG.Rect(vg, x,y,w,h);
				NVG.FillColor(vg, NVG.RGBA(255,0,0,128));
				NVG.Fill(vg);*/

			cx = x + w * 0.5f;
			cy = y + h * 0.5f;
			r1 = (w < h ? w : h) * 0.5f - 5.0f;
			r0 = r1 - 20.0f;
			aeps = 0.5f / r1;   // half a pixel arc length in radians (2pi cancels out).

			for (i = 0; i < 6; i++) {
				float a0 = (float)i / 6.0f * (float)Math.PI * 2.0f - aeps;
				float a1 = (float)(i + 1.0f) / 6.0f * (float)Math.PI * 2.0f + aeps;
				NVG.BeginPath(vg);
				NVG.Arc(vg, cx, cy, r0, a0, a1, NVGWinding.NVG_CW);
				NVG.Arc(vg, cx, cy, r1, a1, a0, NVGWinding.NVG_CCW);
				NVG.ClosePath(vg);
				ax = cx + (float)Math.Cos(a0) * (r0 + r1) * 0.5f;
				ay = cy + (float)Math.Sin(a0) * (r0 + r1) * 0.5f;
				bx = cx + (float)Math.Cos(a1) * (r0 + r1) * 0.5f;
				by = cy + (float)Math.Sin(a1) * (r0 + r1) * 0.5f;
				paint = NVG.LinearGradient(vg, ax, ay, bx, by, NVG.HSLA(a0 / ((float)Math.PI * 2), 1.0f, 0.55f, 255), NVG.HSLA(a1 / ((float)Math.PI * 2), 1.0f, 0.55f, 255));
				NVG.FillPaint(vg, paint);
				NVG.Fill(vg);
			}

			NVG.BeginPath(vg);
			NVG.Circle(vg, cx, cy, r0 - 0.5f);
			NVG.Circle(vg, cx, cy, r1 + 0.5f);
			NVG.StrokeColor(vg, NVG.RGBA(0, 0, 0, 64));
			NVG.StrokeWidth(vg, 1.0f);
			NVG.Stroke(vg);

			// Selector
			NVG.Save(vg);
			NVG.Translate(vg, cx, cy);
			NVG.Rotate(vg, hue * (float)Math.PI * 2);

			// Marker on
			NVG.StrokeWidth(vg, 2.0f);
			NVG.BeginPath(vg);
			NVG.Rect(vg, r0 - 1, -3, r1 - r0 + 2, 6);
			NVG.StrokeColor(vg, NVG.RGBA(255, 255, 255, 192));
			NVG.Stroke(vg);

			paint = NVG.BoxGradient(vg, r0 - 3, -5, r1 - r0 + 6, 10, 2, 4, NVG.RGBA(0, 0, 0, 128), NVG.RGBA(0, 0, 0, 0));
			NVG.BeginPath(vg);
			NVG.Rect(vg, r0 - 2 - 10, -4 - 10, r1 - r0 + 4 + 20, 8 + 20);
			NVG.Rect(vg, r0 - 2, -4, r1 - r0 + 4, 8);
			NVG.PathWinding(vg, NVGSolidity.NVG_HOLE);
			NVG.FillPaint(vg, paint);
			NVG.Fill(vg);

			// Center triangle
			r = r0 - 6;
			ax = (float)Math.Cos(120.0f / 180.0f * (float)Math.PI) * r;
			ay = (float)Math.Sin(120.0f / 180.0f * (float)Math.PI) * r;
			bx = (float)Math.Cos(-120.0f / 180.0f * (float)Math.PI) * r;
			by = (float)Math.Sin(-120.0f / 180.0f * (float)Math.PI) * r;
			NVG.BeginPath(vg);
			NVG.MoveTo(vg, r, 0);
			NVG.LineTo(vg, ax, ay);
			NVG.LineTo(vg, bx, by);
			NVG.ClosePath(vg);
			paint = NVG.LinearGradient(vg, r, 0, ax, ay, NVG.HSLA(hue, 1.0f, 0.5f, 255), NVG.RGBA(255, 255, 255, 255));
			NVG.FillPaint(vg, paint);
			NVG.Fill(vg);
			paint = NVG.LinearGradient(vg, (r + ax) * 0.5f, (0 + ay) * 0.5f, bx, by, NVG.RGBA(0, 0, 0, 0), NVG.RGBA(0, 0, 0, 255));
			NVG.FillPaint(vg, paint);
			NVG.Fill(vg);
			NVG.StrokeColor(vg, NVG.RGBA(0, 0, 0, 64));
			NVG.Stroke(vg);

			// Select circle on triangle
			ax = (float)Math.Cos(120.0f / 180.0f * (float)Math.PI) * r * 0.3f;
			ay = (float)Math.Sin(120.0f / 180.0f * (float)Math.PI) * r * 0.4f;
			NVG.StrokeWidth(vg, 2.0f);
			NVG.BeginPath(vg);
			NVG.Circle(vg, ax, ay, 5);
			NVG.StrokeColor(vg, NVG.RGBA(255, 255, 255, 192));
			NVG.Stroke(vg);

			paint = NVG.RadialGradient(vg, ax, ay, 7, 9, NVG.RGBA(0, 0, 0, 64), NVG.RGBA(0, 0, 0, 0));
			NVG.BeginPath(vg);
			NVG.Rect(vg, ax - 20, ay - 20, 40, 40);
			NVG.Circle(vg, ax, ay, 7);
			NVG.PathWinding(vg, NVGSolidity.NVG_HOLE);
			NVG.FillPaint(vg, paint);
			NVG.Fill(vg);

			NVG.Restore(vg);

			NVG.Restore(vg);
		}
	}
}
