using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EXILEDModLoader
{
	// Token: 0x02000669 RID: 1641
	public class ModLoader
	{
		public static byte[] ReadFile(string path)
		{
			FileStream fileStream = File.Open(path, FileMode.Open);
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				fileStream.CopyTo(memoryStream);
				result = memoryStream.ToArray();
			}
			fileStream.Close();
			return result;
		}

		public static void LoadExiled()
		{
			if (ModLoader.loaded)
			{
				return;
			}
			ServerConsole.AddLog("Hello, yes, EXILED is loading..");
			try
			{
				ModLoader.loaded = true;
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EXILED");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				if (File.Exists(Path.Combine(text, "EXILED.dll")))
				{
					byte[] rawAssembly = ModLoader.ReadFile(Path.Combine(text, "EXILED.dll"));
					try
					{
						MethodInfo methodInfo = Assembly.Load(rawAssembly).GetTypes().SelectMany((Type p) => p.GetMethods()).FirstOrDefault((MethodInfo f) => f.Name == "EntryPointForLoader");
						if (methodInfo != null)
						{
							methodInfo.Invoke(null, null);
						}
					}
					catch (Exception arg)
					{
						ServerConsole.AddLog(string.Format("EXILED load error: {0}", arg));
					}
				}
			}
			catch (Exception ex)
			{
				ServerConsole.AddLog(ex.ToString());
			}
		}

		private static bool loaded;
	}
}

