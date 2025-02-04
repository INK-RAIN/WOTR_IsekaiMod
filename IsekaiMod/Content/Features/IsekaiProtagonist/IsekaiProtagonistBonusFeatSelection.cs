﻿using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist {

    internal class IsekaiProtagonistBonusFeatSelection {
        private static readonly BlueprintFeatureSelection BasicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");

        public static void Add() {
            var IsekaiProtagonistBonusFeatSelection = Helpers.CreateBlueprint<BlueprintFeatureSelection>(IsekaiContext, "IsekaiProtagonistBonusFeatSelection", bp => {
                bp.SetName(IsekaiContext, "Bonus Feat");
                bp.SetDescription(IsekaiContext, "At 1st level, and at every even level thereafter, you gain a bonus {g|Encyclopedia:Feat}feat{/g} in addition to those gained from normal advancement.");
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.Group = FeatureGroup.Feat;
                bp.Group2 = FeatureGroup.TricksterFeat;
                bp.m_AllFeatures = BasicFeatSelection.m_AllFeatures;
            });
            PatchExceptionalFeatSelection(IsekaiProtagonistBonusFeatSelection);
        }

        private static void PatchExceptionalFeatSelection(BlueprintFeatureSelection blueprintFeatureSelection) {
            var ExceptionalFeatSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatSelection");
            var ExceptionalFeatBonusSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(IsekaiContext, "ExceptionalFeatBonusSelection");
            if (ExceptionalFeatSelection != null && ExceptionalFeatBonusSelection != null) {
                blueprintFeatureSelection.m_AllFeatures = ThingsNotHandledByTTTCore.AddToFirst<BlueprintFeatureReference>(blueprintFeatureSelection.m_AllFeatures
                    .RemoveFromArray(ExceptionalFeatSelection.ToReference<BlueprintFeatureReference>()), ExceptionalFeatBonusSelection.ToReference<BlueprintFeatureReference>());
            }
        }
    }
}