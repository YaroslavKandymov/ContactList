using ContactList.Contacts;
using ContactList.Loaders;
using ContactList.Mediators;
using ContactList.Save;
using ContactList.ScriptableObjects;
using ContactList.UI;
using UnityEngine;

namespace ContactList.Presenters
{
    public class ContactListPresenter : MonoBehaviour
    {
        [SerializeField] private ContactListView _contactListView;
        [SerializeField] private SaveDataMediator _saveDataMediator;
        [SerializeField] private ContactListData _contactListData;
        [SerializeField] private FileLoader _fileLoader;
        [SerializeField] private TextureLoader _textureLoader;

        private ContactsList _contactsList;

        private void OnDestroy()
        {
            _contactsList.CardCreated -= OnCardCreated;
        }

        private void Start()
        {
            _contactsList = new ContactsList(_contactListView, _contactListData, _fileLoader, _textureLoader);
            _contactsList.CardCreated += OnCardCreated;
            
            _contactsList.FillList(_saveDataMediator.GetCardsData());
        }

        private void OnCardCreated(CardData cardData)
        {
            _saveDataMediator.SaveNewCard(cardData);
        }
    }
}