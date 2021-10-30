using NueDeck.Scripts.Enums;
using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.EnemyBehaviour.EnemyActions
{
    public class EnemyPoisonAction : EnemyActionBase
    {
        public override EnemyActionType ActionType => EnemyActionType.Poison;
        public override void DoAction(EnemyActionParameters actionParameters)
        {
            if (actionParameters.targetCharacter)
            {
                actionParameters.targetCharacter.CharacterStats.ApplyStatus(StatusType.Poison,Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.targetCharacter.transform,FxType.Poison);
            }
            else
            {
                actionParameters.selfCharacter.CharacterStats.ApplyStatus(StatusType.Poison,Mathf.RoundToInt(actionParameters.value));
                FxManager.Instance.PlayFx(actionParameters.selfCharacter.transform,FxType.Poison);
            }
            AudioManager.Instance.PlayOneShot(AudioActionType.Poison);
        }
    }
}