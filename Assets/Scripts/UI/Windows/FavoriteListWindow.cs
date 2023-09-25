using UnityEngine;

namespace ContactList.UI.Windows
{
    public class FavoriteListWindow : Window
    {
        [SerializeField] private ContactListView _contactListView;

        public override void Open()
        {
            base.Open();
            
            _contactListView.DeactivateNonFavorites(false);
        }
    }
}