﻿using IsekaiMod.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.SpecialPower {

    internal class Reflect {
        private static readonly Sprite Icon_ShieldOfDawn = BlueprintTools.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d").m_Icon;

        public static void Add() {
            var Reflect = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "Reflect", bp => {
                bp.SetName(IsekaiContext, "Reflect");
                bp.SetDescription(IsekaiContext, "You deal damage to enemies equal to the damage you receive.");
                bp.m_Icon = Icon_ShieldOfDawn;
                bp.AddComponent<ReflectDamage>();
            });
            SpecialPowerSelection.AddToSelection(Reflect);
        }
    }
}