using System;
using ContactList.FIleFields;
using ContactList.Mediators;
using UnityEngine;
using UnityEngine.UI;

namespace ContactList.UI.Windows
{
    public class ProfileWindow : Window
    {
        [SerializeField] private CardView _card;
        [SerializeField] private SaveDataMediator _saveDataMediator;
        [SerializeField] private Button _closeButton;
        
        public event Action CloseClicked;

        public event Action<Employer, bool> StatusChanged; 

        public void Init(CardView cardView)
        {
            _card.Init(cardView.Employer, cardView.IsFavorite, cardView.Avatar);
        }

        private void OnEnable()
        {
            _card.Clicked += OnCardClicked;
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnDisable()
        {
            _card.Clicked -= OnCardClicked;
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            CloseClicked?.Invoke();
        }
        
        private void OnCardClicked(CardView card)
        {
            _card.MakeFavorite(!_card.IsFavorite);
            
            _saveDataMediator.MakeCardFavorite(_card.Employer.id, _card.IsFavorite);
            
            StatusChanged?.Invoke(card.Employer, _card.IsFavorite);
        }
    }
}