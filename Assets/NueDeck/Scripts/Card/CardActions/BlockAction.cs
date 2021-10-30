using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Card.CardActions
{
    public class BlockAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Block;
        public override void DoAction(CardActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter != null)
            {
                actionParameters.targetCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value)+actionParameters.targetCharacter.CharacterStats.statusDict[StatusType.Dexterity].StatusValue);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Block);
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value)+actionParameters.selfCharacter.CharacterStats.statusDict[StatusType.Dexterity].StatusValue);
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Block);
            }
            AudioManager.Instance.PlayOneShot(actionParameters.cardData.audioType);
        }
    }
}