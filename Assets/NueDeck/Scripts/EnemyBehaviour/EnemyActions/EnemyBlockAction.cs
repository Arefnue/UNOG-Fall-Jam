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
            
            var newTarget = actionParameters.TargetCharacter
                ? actionParameters.TargetCharacter
                : actionParameters.SelfCharacter;

            if (!newTarget) return;
            
            newTarget.CharacterStats.ApplyStatus(StatusType.Block,Mathf.RoundToInt(actionParameters.Value)+actionParameters.SelfCharacter.CharacterStats.StatusDict[StatusType.Dexterity].StatusValue);
            FxManager.Instance.PlayFx(newTarget.transform,FxType.Block);
            AudioManager.Instance.PlayOneShot(AudioActionType.Block);
        }
    }
}