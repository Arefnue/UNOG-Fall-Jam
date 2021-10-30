using NueDeck.Scripts.Characters;
using NueDeck.Scripts.Data.Collection;
using NueDeck.Scripts.Enums;

namespace NueDeck.Scripts.Card
{
    public class CardActionParameters
    {
        public float value;
        public CharacterBase targetCharacter;
        public CharacterBase selfCharacter;
        public CardData cardData;
        public CardActionParameters(float value,CharacterBase target, CharacterBase self,CardData cardData)
        {
            this.value = value;
            targetCharacter = target;
            selfCharacter = self;
            this.cardData = cardData;
        }
    }
    public abstract class CardActionBase
    {
        protected CardActionBase(){}
        public abstract CardActionType ActionType { get;}
        public abstract void DoAction(CardActionParameters actionParameters);
        
    }
    
    
   
}