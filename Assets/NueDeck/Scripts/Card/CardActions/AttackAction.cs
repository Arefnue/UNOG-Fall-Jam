using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class AttackAction: CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Attack;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.Damage(Mathf.RoundToInt(actionParameters.value)+actionParameters.selfCharacter.CharacterStats.statusDict[StatusType.Strength].StatusValue);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Attack);
                AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
            }
        }
    }
}