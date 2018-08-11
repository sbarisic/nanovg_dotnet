# nanovg_dotnet

![alt text](https://raw.githubusercontent.com/sbarisic/nanovg_dotnet/master/screenshots/a.png "A")

.NET binding for nanovg using P/Invoke

Demo application window is created with GLFW.Net and uses the built in
OpenGL 3.2 NanoVG context. Custom rendering contexts can be created by implementing
a class which inherits from NanoVG.NVGParameters. Source in ``Test/Program.cs``

This binding uses System.Numerics vectors as much as possible, currently for colors and vertices,
as they mach with the ones on the C side.

This works on both x86 and x64, it should also work on platforms other
than Windows, but i do not have any way to test righ now

## TODO
* All string functions should take a byte array and include an overload which automatically converts to UTF-8
* Fill in this TODO list

## Example

```csharp
// This sets the native nanovg directory so you can ship both
// x86 and x64 versions of original nanovg library, and only
// one .NET executable
NVG.SetLibraryDirectory();

IntPtr Ctx = NVG.CreateGL3Glew(3);
// or
IntPtr Ctx = NVG.CreateContext(new CustomParameters()); // CustomParameters inherits from NanoVG.NVGParameters

// ...

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
```
