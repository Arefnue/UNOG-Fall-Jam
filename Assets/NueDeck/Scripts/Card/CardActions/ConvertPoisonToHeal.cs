using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class ConvertPoisonToHeal : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.ConvertPoisonToHeal;
        
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.Heal(actionParameters.targetCharacter.CharacterStats.statusDict[StatusType.Poison].StatusValue*Mathf.RoundToInt(actionParameters.value));
                actionParameters.targetCharacter.CharacterStats.ClearStatus(StatusType.Poison);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Heal);
                
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.Heal(actionParameters.selfCharacter.CharacterStats.statusDict[StatusType.Poison].StatusValue*Mathf.RoundToInt(actionParameters.value));
                actionParameters.selfCharacter.CharacterStats.ClearStatus(StatusType.Poison);
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Heal);
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}