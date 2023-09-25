using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Save
{
    [Serializable]
    public class CardSaveData : SaveData
    {
        private readonly List<CardData> _cards;

        public IReadOnlyCollection<CardData> Cards => _cards;

        public CardSaveData()
        {
            _cards = new List<CardData>();
        }
        
        public CardSaveData(IEnumerable<CardData> identifiers)
        {
            _cards = new List<CardData>();

            foreach (var identifier in identifiers)
            {
                _cards.Add(identifier);
            }
        }

        public CardData? GetCardInformation(int id)
        {
            foreach (var card in _cards)
            {
                if (card.Id == id)
                {
                    return card;
                }
            }

            return null;
        }

        public void AddCard(CardData data)
        {
            if (_cards.Contains(data))
                throw new InvalidOperationException("Wrong id");

            _cards.Add(data);
        }
        
        public void RemoveCard(CardData data)
        {
            if (_cards.Contains(data) == false)
                throw new InvalidOperationException("Wrong id");
            
            _cards.Remove(data);
        }

        public void MakeFavorite(int id ,bool value)
        {
            CardData cardData = default;
            int number = 0;

            for (var index = 0; index < _cards.Count; index++)
            {
                if (_cards[index].Id == id)
                {
                    cardData = _cards[index];
                    number = index;
                }
            }

            _cards.Remove(cardData);
            _cards.Insert(number, new CardData(cardData.Id, value, cardData.Texture));
        }
    }
}