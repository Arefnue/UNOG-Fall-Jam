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
            if (!actionParameters.TargetCharacter) return;
            
            actionParameters.TargetCharacter.CharacterStats.Damage(Mathf.RoundToInt(
                actionParameters.SelfCharacter.CharacterStats.statusDict[StatusType.Poison].StatusValue * actionParameters.Value));
                
            actionParameters.SelfCharacter.CharacterStats.ClearStatus(StatusType.Poison);
            
            FxManager.Instance.PlayFx(actionParameters.TargetCharacter.transform,FxType.Attack);
            AudioManager.Instance.PlayOneShot(actionParameters.CardData.audioType);
        }
    }
}