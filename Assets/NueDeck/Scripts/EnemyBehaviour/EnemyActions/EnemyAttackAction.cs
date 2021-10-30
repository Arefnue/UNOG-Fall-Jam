using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.EnemyBehaviour.EnemyActions
{
    public class EnemyAttackAction: EnemyActionBase
    {
        public override EnemyActionType ActionType => EnemyActionType.Attack;
        
        public override void DoAction(EnemyActionParameters actionParameters)
        {
            actionParameters.targetCharacter.CharacterStats.Damage(Mathf.RoundToInt(actionParameters.value)+actionParameters.selfCharacter.CharacterStats.statusDict[StatusType.Strength].StatusValue);
            FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Attack);
            AudioManager.Instance.PlayOneShot(AudioActionType.Attack);
        }
    }
}