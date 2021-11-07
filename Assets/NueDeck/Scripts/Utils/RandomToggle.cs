using NueDeck.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace NueDeck.Scripts
{
    public class RandomToggle : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;


        public void CheckToggle()
        {
            GameManager.Instance.PersistentGameplayData.IsRandomHand = toggle.isOn;
            GameManager.Instance.SetInitalHand();
        }
        
    }
}
