using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class IncreaseMaxHealthAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.IncreaseMaxHealth;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.IncreaseMaxHealth(Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Heal);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Buff);
               
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.IncreaseMaxHealth(Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Heal);
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Buff);
                
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}