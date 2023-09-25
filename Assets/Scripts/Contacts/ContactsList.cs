using System;
using ContactList.FIleFields;
using ContactList.Loaders;
using ContactList.Save;
using ContactList.ScriptableObjects;
using ContactList.UI;
using UnityEngine;

namespace ContactList.Contacts
{
    public class ContactsList
    {
        private ContactListView _contactListView;
        private ContactListData _data;
        private FileLoader _fileLoader;
        private TextureLoader _textureLoader;
        private EmployeeData _employeeData;

        private int _currentContactNumber;

        public event Action<CardData> CardCreated;

        public ContactsList(ContactListView contactListView, ContactListData data, FileLoader fileLoader,
            TextureLoader textureLoader)
        {
            _contactListView = contactListView;
            _data = data;
            _fileLoader = fileLoader;
            _textureLoader = textureLoader;
            _employeeData = _fileLoader.GetData();
        }

        public void FillList(CardSaveData cardSaveData)
        {
            if (cardSaveData.Cards.Count <= 0)
            {
                for (int i = 0; i < _employeeData.data.Length; i++)
                {
                    _textureLoader.LoadImage(CreateNewCard);
                }
            }
            else
            {
                foreach (var card in cardSaveData.Cards)
                {
                    if (card.Texture != null)
                    {
                        Texture2D texture = new Texture2D(1, 1);
                        
                        texture.LoadImage(card.Texture);
                        _contactListView.CreateContact(_fileLoader.GetEmployer(card.Id), card.IsFavorite,
                            texture);
                    }
                    else
                    {
                        _contactListView.CreateContact(_fileLoader.GetEmployer(card.Id), card.IsFavorite);
                    }
                }
            }
        }

        private void CreateNewCard(Texture2D texture)
        {
            _contactListView.CreateContact(_employeeData.data[_currentContactNumber], false, texture);

            byte[] bytes = null;
            
            if (texture != null)
            {
                bytes = texture.EncodeToPNG();
            }

            var card = new CardData(_employeeData.data[_currentContactNumber].id, false, bytes);
            CardCreated?.Invoke(card);

            _currentContactNumber++;
        }
    }
}