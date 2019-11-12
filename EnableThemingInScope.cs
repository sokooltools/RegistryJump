//////////////////////////////////////////////////////////////////////////////
// (c) Copyright 2006-2007  SokoolTools
//
// Description: EnableThemingInScope Class
//
// Modification Notes:
// Date		Author        	Notes
// -------- -------------- --------------------------------------------------
// 12/01/06	RSokol			Initial Development
//////////////////////////////////////////////////////////////////////////////

// http://support.microsoft.com/default.aspx?scid=kb;en-us;830033
using System.Runtime.InteropServices;
using System;
using System.Security;
using System.Security.Permissions;
using System.IO;
using System.Windows.Forms;

namespace DevTools.RegistryJump
{
	[ SuppressUnmanagedCodeSecurity ]
	internal class EnableThemingInScope : IDisposable
	{
		// Private data
		private uint  _cookie;
		private static ACTCTX _enableThemingActivationContext;
		private static IntPtr _hActCtx;
		private static bool _contextCreationSucceeded;

		public EnableThemingInScope(bool enable)
		{
			_cookie = 0;
			if (!enable || !OSFeature.Feature.IsPresent(OSFeature.Themes))
				return;
			if (!EnsureActivateContextCreated())
				return;
			if (!ActivateActCtx(_hActCtx, out _cookie))
			{
				// Be sure cookie always zero if activation failed
				_cookie = 0;
			}
		}

		~EnableThemingInScope()
		{
			Dispose(false);
		}

		void IDisposable.Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (_cookie == 0) return;
			if (DeactivateActCtx(0, _cookie))
			{
				// deactivation succeeded...
				_cookie = 0;
			}
		}

		private static bool EnsureActivateContextCreated()
		{
			lock (typeof(EnableThemingInScope))
			{
				if (_contextCreationSucceeded)
					return _contextCreationSucceeded;

				// Pull manifest from the .NET Framework install directory

				string assemblyLoc;
						
				FileIOPermission fiop = new FileIOPermission(PermissionState.None);
				fiop.AllFiles = FileIOPermissionAccess.PathDiscovery;
				fiop.Assert();
				try
				{
					assemblyLoc = typeof(object).Assembly.Location;
				}
				finally
				{ 
					CodeAccessPermission.RevertAssert();
				}

				string manifestLoc;
				string installDir;
				{
					installDir = Path.GetDirectoryName(assemblyLoc) ?? "";
					const string MANIFEST_NAME = "XPThemes.manifest";
					manifestLoc = Path.Combine(installDir, MANIFEST_NAME);
				}

				_enableThemingActivationContext = new ACTCTX
				{
					cbSize = Marshal.SizeOf(typeof(ACTCTX)),
					lpSource = manifestLoc,
					lpAssemblyDirectory = installDir,
					dwFlags = ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID
				};

				// Set the lpAssemblyDirectory to the install
				// directory to prevent Win32 Side by Side from
				// looking for comctl32 in the application
				// directory, which could cause a bogus dll to be
				// placed there and open a security hole.


				// Note this will fail gracefully if file specified
				// by manifestLoc doesn't exist.
				_hActCtx = CreateActCtx(ref _enableThemingActivationContext);
				_contextCreationSucceeded = _hActCtx != new IntPtr(-1);

				// If we return false, we'll try again on the next call into
				// EnsureActivateContextCreated(), which is fine.
				return _contextCreationSucceeded;
			}
		}

		// All the pinvoke stuff...
		[DllImport("Kernel32.dll")]
		private static extern IntPtr CreateActCtx(ref ACTCTX actctx);

		[DllImport("Kernel32.dll")]
		private static extern bool ActivateActCtx(IntPtr hActCtx, out uint lpCookie);

		[DllImport("Kernel32.dll")]
		private static extern bool DeactivateActCtx(uint dwFlags, uint lpCookie);

		private const int ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x004;
			
		private struct ACTCTX 
		{
			public int       cbSize;
			public uint      dwFlags;
			public string    lpSource;
			public ushort    wProcessorArchitecture;
			public ushort    wLangId;
			public string    lpAssemblyDirectory;
			public string    lpResourceName;
			public string    lpApplicationName;
		}
	}
}