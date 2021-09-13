using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HediffApplier
{
    [HarmonyPatch]
    [HarmonyPatch(typeof(SkillRecord), "LearnRateFactor")]
    class XpHarmony_Patch
    {
        static float Postfix(float __result, SkillRecord __instance, bool direct)
        {
            Pawn pawn = Traverse.Create(__instance).Field("pawn").GetValue<Pawn>();
            if (PawnChecker.MeetReq(pawn) && PawnChecker.HasHediff(pawn))
            {
                if (__instance.def.defName == "Melee" || __instance.def.defName == "Shooting")
                {                    
                    return __result * 0.5f;
                }
                if(__instance.def.defName == "Social")
                {
                    return __result * 1.5f;
                }
            }
            return __result;
        }
    }
}
