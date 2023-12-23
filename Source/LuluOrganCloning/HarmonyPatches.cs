using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

#pragma warning disable IDE1006 // Naming Styles

namespace LoonyLadle.OrganCloning
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("rimworld.loonyladle.organcloning");

            MethodInfo method1 = AccessTools.Method(typeof(PawnUtility), "TrySpawnHatchedOrBornPawn");
            HarmonyMethod patch1 = new HarmonyMethod(typeof(HarmonyPatches), nameof(AddClonedOrgans));
            harmony.Patch(method1, null, patch1);
        }
        
        public static void AddClonedOrgans(Pawn pawn, Thing motherOrEgg)
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
