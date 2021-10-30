using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.EnemyBehaviour.EnemyActions
{
    public class EnemyBlockAction : EnemyActionBase
    {
        public override EnemyActionType ActionType => EnemyActionType.Block;
        
        public override void DoAction(EnemyActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value)+actionParameters.targetCharacter.CharacterStats.statusDict[StatusType.Dexterity].StatusValue);
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Block);
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.value)+actionParameters.selfCharacter.CharacterStats.statusDict[StatusType.Dexterity].StatusValue);
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Block);
            }
            AudioManager.Instance.PlayOneShot(AudioActionType.Block);
        }
    }
}