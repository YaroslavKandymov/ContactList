using System;
using ContactList.FIleFields;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ContactList.UI
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _starIcon;
        [SerializeField] private Image _background;
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _contacts;
        [SerializeField] private TMP_Text _ipAddress;
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _enabledStar;
        [SerializeField] private Sprite _disabledStar;

        public Employer Employer{ get; private set; }
        public bool IsFavorite { get; private set; }
        public Texture2D Avatar { get; private set; }

        public event Action<CardView> Clicked;

        public virtual void Init(Employer employer, bool isFavorite, Texture2D avatar = null)
        {
            _name.text = $"{employer.first_name} {employer.last_name}";
            _contacts.text = $"{employer.email}";
            _ipAddress.text = $"{employer.ip_address}";
            Employer = employer;
            IsFavorite = isFavorite;
            Avatar = avatar;

            MakeFavorite(IsFavorite);

            if (avatar != null)
            {
                var sprite = Sprite.Create( avatar, new Rect(0.0f, 0.0f, avatar.width, avatar.height), new Vector2(0.5f, 0.5f), 100.0f);
                
                _avatar.sprite = sprite;
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        public void MakeFavorite(bool value)
        {
            IsFavorite = value;
            
            _starIcon.sprite = IsFavorite ? _enabledStar : _disabledStar;
        }

        public void SetActiveBackground(bool value)
        {
            _background.color =
                value
                    ? new Color(_background.color.r, _background.color.g, _background.color.b, 1)
                    : new Color(_background.color.r, _background.color.g, _background.color.b, 0);
        }

        private void OnButtonClicked()
        {
            Clicked?.Invoke(this);
        }
    }
}