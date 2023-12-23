using HarmonyLib;
using RimWorld;
using Verse;

namespace Cerespirin.OrganCloning
{
	[HarmonyPatch(typeof(PawnUtility), nameof(PawnUtility.TrySpawnHatchedOrBornPawn))]
	public static class HarmonyPatch_PawnUtility_TrySpawnHatchedOrBornPawn
	{
		public static void Postfix(Pawn pawn, Thing motherOrEgg)
		{
			if (motherOrEgg is Pawn mother)
			{
				HediffComp_OrganProps organProps = mother.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Pregnant).TryGetComp<HediffComp_OrganProps>();

				foreach (BodyPartRecord part in organProps.organsToClone)
				{
					Hediff hediff = HediffMaker.MakeHediff(MyDefOf.OrganCloning_ClonedOrgan, pawn, part);
					pawn.health.AddHediff(hediff);
				}
			}
		}
	}
}
