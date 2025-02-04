﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using UnityEngine;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.OverpoweredAbility {

    internal class PerfectRoll {
        private static readonly Sprite Icon_TrickFate = BlueprintTools.GetBlueprint<BlueprintAbility>("6e109d21da9e1c44fb772a9eca2cafdd").m_Icon;

        public static void Add() {
            var PerfectRollBuff = ThingsNotHandledByTTTCore.CreateBuff("PerfectRollBuff", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Perfect Roll");
                bp.SetDescription(IsekaiContext, "This character always {g|Encyclopedia:Dice}rolls{/g} 20 on all d20 rolls.");
                bp.m_Icon = Icon_TrickFate;
                bp.AddComponent<ModifyD20>(c => {
                    c.Rule = RuleType.All;
                    c.Replace = true;
                    c.RollResult = 20;
                });
                bp.Stacking = StackingType.Replace;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.StayOnDeath;
            });
            var PerfectRollAbility = ThingsNotHandledByTTTCore.CreateActivatableAbility("PerfectRollAbility", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Perfect Roll");
                bp.SetDescription(IsekaiContext, "You always {g|Encyclopedia:Dice}roll{/g} a 20 on all d20 rolls.");
                bp.m_Icon = Icon_TrickFate;
                bp.m_Buff = PerfectRollBuff.ToReference<BlueprintBuffReference>();
            });
            var PerfectRollFeature = Helpers.CreateBlueprint<BlueprintFeature>(IsekaiContext, "PerfectRollFeature", bp => {
                bp.SetName(IsekaiContext, "Overpowered Ability — Perfect Roll");
                bp.SetDescription(IsekaiContext, "You always {g|Encyclopedia:Dice}roll{/g} a 20 on all d20 rolls.");
                bp.m_Icon = Icon_TrickFate;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { PerfectRollAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });

            OverpoweredAbilitySelection.AddToSelection(PerfectRollFeature);
        }
    }
}