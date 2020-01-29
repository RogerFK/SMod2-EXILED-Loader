using Smod2;
using Smod2.Attributes;

namespace EXILEDModLoader
{
	[PluginDetails(
		author = "RogerFK",
		name = "SMod2-EXILED",
		description = "A simple plugin to load EXILED plugins.",
		id = "rogerfk.exiled",
		configPrefix = "exiled",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 7,
		SmodRevision = 0
		)]
	public class EXILEDPlugin : Plugin
	{
		public override void OnDisable()
		{
			// Not implemented.
		}

		public override void OnEnable()
		{
			// Not implemented.
		}

		public override void Register()
		{
			ModLoader.LoadExiled();
		}
	}
}
