using ContactList.Save;
using UnityEngine;

namespace ContactList.Mediators
{
    public class SaveDataMediator : MonoBehaviour
    {
        private CardSaveData _cardSaveData;

        public CardSaveData GetCardsData()
        {
            if (_cardSaveData == null)
            {
                _cardSaveData = SaveSystem.LoadData<CardSaveData>();

                if (_cardSaveData == null)
                {
                    _cardSaveData = new CardSaveData();
                    
                    SaveSystem.SaveData(_cardSaveData);
                }
            }

            return _cardSaveData;
        }

        public void SaveNewCard(CardData cardData)
        {
            if (_cardSaveData == null)
            {
                GetCardsData();
            }
            
            _cardSaveData.AddCard(cardData);
            
            SaveSystem.SaveData(_cardSaveData);
        }

        public void MakeCardFavorite(int id, bool value)
        {
            _cardSaveData.MakeFavorite(id, value);

            SaveSystem.SaveData(_cardSaveData);
        }
    }
}