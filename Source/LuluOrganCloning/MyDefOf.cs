using RimWorld;
using Verse;

namespace Cerespirin.OrganCloning
{
	[DefOf]
	public static class MyDefOf
	{
		static MyDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));

		public static HediffDef OrganCloning_ClonedOrgan;
	}
}
