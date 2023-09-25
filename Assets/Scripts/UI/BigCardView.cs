using ContactList.FIleFields;
using TMPro;
using UnityEngine;

namespace ContactList.UI
{
    public class BigCardView : CardView
    {
        [SerializeField] private TMP_Text _gender;

        public override void Init(Employer employer, bool isFavorite, Texture2D avatar = null)
        {
            base.Init(employer, isFavorite, avatar);

            _gender.text = employer.gender;
        }
    }
}