using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class IncreaseStrengthAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.IncreaseStrength;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.ApplyStatus(StatusType.Strength,Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Str);
               
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.ApplyStatus(StatusType.Strength,Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Str);
              
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}