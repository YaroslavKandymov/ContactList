using UnityEngine;

namespace ContactList.UI.Windows
{
    public class EmployeeListWindow : Window
    {
        [SerializeField] private ContactListView _contactListView;
        
        public override void Open()
        {
            base.Open();
            
            _contactListView.DeactivateNonFavorites(true);
        }
    }
}