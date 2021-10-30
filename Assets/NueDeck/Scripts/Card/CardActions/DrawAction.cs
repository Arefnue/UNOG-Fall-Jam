﻿using NueDeck.Scripts.Collection;
using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class DrawAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Draw;
        public override void DoAction(CardActionParameters actionParameters)
        {
            CollectionManager.instance.DrawCards(Mathf.RoundToInt(actionParameters.value));
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}