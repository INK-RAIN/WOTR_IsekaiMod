﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.TrainingArc
{
    class TrainingArcSelection
    {
        public static void Add()
        {
            var OverpoweredAbilitySelection2 = Resources.GetModBlueprint<BlueprintFeatureSelection>("OverpoweredAbilitySelection2");

            var TrainingMontage = Resources.GetModBlueprint<BlueprintFeature>("TrainingMontage");
            var BodyStrengthening = Resources.GetModBlueprint<BlueprintFeature>("BodyStrengthening");
            var SpellNegationFeature = Resources.GetModBlueprint<BlueprintFeature>("SpellNegationFeature");
            var ExtremeSpeedFeature = Resources.GetModBlueprint<BlueprintFeature>("ExtremeSpeedFeature");

            // Feature
            var Icon_PerfectStrike = Resources.GetBlueprint<BlueprintFeature>("9ff65b68c09567e48af9b33848b23323").m_Icon;
            var TrainingArcSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>("TrainingArcSelection", bp => {
                bp.SetName("Training Arc");
                bp.SetDescription("At 5th, 10th and 15th level, you train yourself intensely and gain new abilities.");
                bp.m_Icon = Icon_PerfectStrike;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.m_AllFeatures = new BlueprintFeatureReference[] {
                    OverpoweredAbilitySelection2.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegationFeature.ToReference<BlueprintFeatureReference>(),
                    ExtremeSpeedFeature.ToReference<BlueprintFeatureReference>(),
                };
                bp.m_Features = new BlueprintFeatureReference[] {
                    OverpoweredAbilitySelection2.ToReference<BlueprintFeatureReference>(),
                    TrainingMontage.ToReference<BlueprintFeatureReference>(),
                    BodyStrengthening.ToReference<BlueprintFeatureReference>(),
                    SpellNegationFeature.ToReference<BlueprintFeatureReference>(),
                    ExtremeSpeedFeature.ToReference<BlueprintFeatureReference>(),
                };
            });
        }
    }
}
