using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class ConvertPoisonToDamage : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.ConvertPoisonToDamage;
        
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.Damage(actionParameters.targetCharacter.CharacterStats.statusDict[StatusType.Poison].StatusValue*Mathf.RoundToInt(actionParameters.value));
                actionParameters.targetCharacter.CharacterStats.ClearStatus(StatusType.Poison);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Heal);
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}