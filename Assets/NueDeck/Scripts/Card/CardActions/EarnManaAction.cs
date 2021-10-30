﻿using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class EarnManaAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.EarnMana;
        public override void DoAction(CardActionParameters actionParameters)
        {
            CombatManager.instance.IncreaseMana(Mathf.RoundToInt(actionParameters.value));
            FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Buff);
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}