using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace NanoVG {
	public static unsafe class NanoVG_Native {
		internal const string LibName = "nanovg";
		internal const CallingConvention CConv = CallingConvention.Cdecl;

		[DllImport(LibName, CallingConvention = CConv)]
		public static extern IntPtr nvgCreateInternal(IntPtr Params);

		[DllImport(LibName, CallingConvention = CConv)]
		public static extern void nvgDeleteInternal(IntPtr ctx);
	}

	public static class NVG {
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
			IntPtr Ctx = NanoVG_Native.nvgCreateInternal(NvgParamsHandle.AddrOfPinnedObject());
			NvgParamsHandle.Free();
			return Ctx;
		}
	}
}