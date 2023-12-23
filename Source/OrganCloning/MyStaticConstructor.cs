using HarmonyLib;
using Verse;

namespace Cerespirin.OrganCloning
{
	[StaticConstructorOnStartup]
	static class MyStaticConstructor
	{
		static MyStaticConstructor()
		{
			Harmony harmony = new Harmony("rimworld.cerespirin.organcloning");
			harmony.PatchAll();
		}
	}
}
