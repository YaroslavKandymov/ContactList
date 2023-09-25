using System;
using System.Collections.Generic;
using ContactList.FIleFields;
using UnityEngine;

namespace ContactList.UI
{
    public class ContactListView : MonoBehaviour
    {
        [SerializeField] private CardsFactory _cardsFactory;
        [SerializeField] private Transform _parent;

        private readonly List<CardView> _cards = new ();

        public event Action<CardView> CardClicked;

        private void OnDestroy()
        {
            foreach (var card in _cards)
            {
                card.Clicked -= OnCardClicked;
            }
        }

        public void CreateContact(Employer employer, bool isFavorite, Texture2D avatar)
        {
            var card = _cardsFactory.CreateCard(_parent);
            
            card.Init(employer, isFavorite, avatar);
            
            _cards.Add(card);

            card.SetActiveBackground(_cards.Count % 2 != 0);
            
            card.Clicked += OnCardClicked;
        }

        public void DeactivateNonFavorites(bool value)
        {
            foreach (var card in _cards)
            {
                if (card.IsFavorite == false)
                {
                    card.gameObject.SetActive(value);
                }
            }

            int activeCount = 0;
            
            foreach (var card in _cards)
            {
                if (card.gameObject.activeSelf)
                {
                    card.SetActiveBackground(activeCount % 2 == 0);

                    activeCount++;
                }
            }
        }

        public void MakeFavorite(Employer employer, bool value)
        {
            foreach (var cardView in _cards)
            {
                if (cardView.Employer.id == employer.id)
                {
                    cardView.MakeFavorite(value);
                }
            }
        }

        private void OnCardClicked(CardView card)
        {
            CardClicked?.Invoke(card);
        }
    }
}