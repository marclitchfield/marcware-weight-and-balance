using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Marcware.WB
{
	public class EnvironmentEx
	{
		[DllImport("coredll.dll", EntryPoint="SHGetSpecialFolderPath", SetLastError=false)]
		private static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, int nFolder, int fCreate);

		public static string GetSpecialFolderPath(SpecialFolder folder)
		{
			StringBuilder path = new StringBuilder(262);

			if(!SHGetSpecialFolderPath(IntPtr.Zero, path, (int)folder, 0))
			{
				throw new DirectoryNotFoundException("Special Folder Not Found: " + folder.ToString());
			}

			return path.ToString();
		}

		public enum SpecialFolder
		{
			Programs		= 0x02,       
			Personal		= 0x05,
			Favorites		= 0x06,	
			Startup			= 0x07,
			Recent			= 0x08,	
			StartMenu		= 0x0B,     
			DesktopDirectory = 0x10,
			Fonts			= 0x14,
			ApplicationData	= 0x1a,
			Windows			= 0x24,
			ProgramFiles	= 0x26,

		}
	}
}
