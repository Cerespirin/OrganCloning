﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace Cerespirin.OrganCloning
{
	[StaticConstructorOnStartup]
	static class HarmonyPatches
	{
		static HarmonyPatches()
		{
			Harmony harmony = new Harmony("rimworld.cerespirin.organcloning");
			harmony.PatchAll();
		}
	}

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
					Hediff hediff = HediffMaker.MakeHediff(MyDefOf.LuluOrganCloning_ClonedOrgan, pawn, part);
					pawn.health.AddHediff(hediff);
				}
			}
		}
	}
}
