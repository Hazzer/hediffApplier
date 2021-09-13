using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace HediffApplier
{
    [StaticConstructorOnStartup]
    internal class Main
    {
        static Main()
        {
            try
            {
                var harmony = new Harmony("Harmony_FemaleHediff");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Log.Error($"Error during startup:\n{e}");
            }

        }
    }
}
