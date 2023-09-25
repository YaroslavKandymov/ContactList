using UnityEngine;

namespace ContactList.UI
{
    public class CardsFactory : MonoBehaviour
    {
        [SerializeField] private CardView _template;

        public CardView CreateCard(Transform parent)
        {
            return Instantiate(_template, parent);
        }
    }
}