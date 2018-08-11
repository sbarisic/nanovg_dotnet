#include <nanovg.h>
//#include <nanovg_gl.h>

#define NANOVG_DOTNET_COMPILE_GL3

#ifdef NANOVG_DOTNET_COMPILE_GL3
#pragma comment(lib, "opengl32.lib")
#pragma comment(lib, "glew32.lib")
//#pragma comment(lib, "glfw3dll.lib")
#include <GL/glew.h>

#define NANOVG_GL3_IMPLEMENTATION
#include <nanovg_gl_utils.h>
#include <nanovg_gl.h>

__declspec(dllexport) NVGcontext* nvgCreateGL3Glew(int flags) {
	if (glewInit() != GLEW_OK)
		return NULL;

	return nvgCreateGL3(flags);
}
#endif
