using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using Verse;



namespace VanillaQuestsExpandedAncients
{
    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("PostProcessProduct")]
    public static class VanillaQuestsExpandedAncients_GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyPostfix]
        static void HandleCraftModifications(Thing product, RecipeDef recipeDef, Pawn worker)
        {
            if (worker?.genes?.HasActiveGene(InternalDefOf.VQEA_MasterfulCrafting) == true)
            {

                CompQuality compQuality = product?.TryGetComp<CompQuality>();
                if (compQuality != null)
                {
                    if (recipeDef?.workSkill == null)
                    {
                        Log.Error(recipeDef + " needs workSkill because it creates a product with a quality.");
                    }
                    if (compQuality.Quality != QualityCategory.Legendary)
                    {
                        compQuality.SetQuality(compQuality.Quality + 1, ArtGenerationContext.Colony);

                    }

                }

            }
        }
    }
}
