using System;
using System.Collections;
using NueDeck.Scripts.Managers;
using NueDeck.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NueDeck.Scripts.Utils
{
    public class SceneChanger : MonoBehaviour
    {
        
        private enum SceneType
        {
            MainMenu,
            Map,
            Combat
        }
        public void OpenMainMenuScene()
        {
            StartCoroutine(DelaySceneChange(SceneType.MainMenu));
        }

        private IEnumerator DelaySceneChange(SceneType type)
        {
            yield return StartCoroutine(UIManager.Instance.Fade(true));

            switch (type)
            {
                case SceneType.MainMenu:
                    UIManager.Instance.ChangeScene(GameManager.Instance.SceneData.mainMenuSceneIndex);
                    UIManager.Instance.SetCanvas(UIManager.Instance.combatCanvas,false,true);
                    UIManager.Instance.SetCanvas(UIManager.Instance.informationCanvas,false,true);
                    UIManager.Instance.SetCanvas(UIManager.Instance.rewardCanvas,false,true);
                    GameManager.Instance.InitGameplayData();
                    GameManager.Instance.SetInitalHand();
                    break;
                case SceneType.Map:
                    UIManager.Instance.ChangeScene(GameManager.Instance.SceneData.mapSceneIndex);
                    UIManager.Instance.SetCanvas(UIManager.Instance.combatCanvas,false,true);
                    UIManager.Instance.SetCanvas(UIManager.Instance.informationCanvas,true,false);
                    UIManager.Instance.SetCanvas(UIManager.Instance.rewardCanvas,false,true);
                    break;
                case SceneType.Combat:
                    UIManager.Instance.ChangeScene(GameManager.Instance.SceneData.combatSceneIndex);
                    UIManager.Instance.SetCanvas(UIManager.Instance.combatCanvas,false,true);
                    UIManager.Instance.SetCanvas(UIManager.Instance.informationCanvas,true,false);
                    UIManager.Instance.SetCanvas(UIManager.Instance.rewardCanvas,false,true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
           
            
        }
        public void OpenMapScene()
        {
            StartCoroutine(DelaySceneChange(SceneType.Map));
        }

        public void OpenCombatScene()
        {
            StartCoroutine(DelaySceneChange(SceneType.Combat));
        }
        
        
        public void ChangeScene(int sceneId)
        {

            if (sceneId == GameManager.Instance.SceneData.mainMenuSceneIndex)
                OpenMainMenuScene();
            else if (sceneId == GameManager.Instance.SceneData.mapSceneIndex)
                OpenMapScene();
            else if (sceneId == GameManager.Instance.SceneData.combatSceneIndex)
                OpenCombatScene();
            else
                SceneManager.LoadScene(sceneId);
        }
        
        public void ExitApp()
        {
            GameManager.Instance.OnExitApp();
            Application.Quit();
        }
        
    }
}
