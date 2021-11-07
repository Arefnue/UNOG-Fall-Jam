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
            
            var newTarget = actionParameters.TargetCharacter
                ? actionParameters.TargetCharacter
                : actionParameters.SelfCharacter;

            if (newTarget) return;
            
            newTarget.CharacterStats.Heal(Mathf.RoundToInt(actionParameters.SelfCharacter.CharacterStats.StatusDict[StatusType.Poison].StatusValue*actionParameters.Value));
            actionParameters.SelfCharacter.CharacterStats.ClearStatus(StatusType.Poison);
            
            FxManager.Instance.PlayFx(newTarget.transform,FxType.Heal);
            AudioManager.Instance.PlayOneShot(actionParameters.CardData.audioType);
        }
    }
}