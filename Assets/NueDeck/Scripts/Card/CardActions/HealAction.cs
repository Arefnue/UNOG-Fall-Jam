using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class HealAction: CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Heal;

        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.Heal(Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Heal);
                
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.Heal(Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Heal);
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}