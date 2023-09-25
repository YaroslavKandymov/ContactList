using ContactList.FIleFields;
using UnityEngine;
using UnityEngine.UI;

namespace ContactList.UI.Windows
{
    public class MainWindow : MonoBehaviour
    {
        [SerializeField] private EmployeeListWindow _employeeListWindow;
        [SerializeField] private FavoriteListWindow _favoriteListWindow;
        [SerializeField] private ProfileWindow _profileWindow;
        [SerializeField] private ContactListView _contactList;
        [SerializeField] private Button _employeeListButton;
        [SerializeField] private Button _favoriteListButton;

        private Window _previousWindow;
        
        private void OnEnable()
        {
            _employeeListButton.onClick.AddListener(OnEmployeeListButtonClicked);
            _favoriteListButton.onClick.AddListener(OnFavoriteListButtonClicked);
            
            _profileWindow.CloseClicked += OnProfileClosed;
            _contactList.CardClicked += OnCardClicked;

            _profileWindow.StatusChanged += OnCardStatusChanged;
        }

        private void OnDisable()
        {
            _employeeListButton.onClick.RemoveListener(OnEmployeeListButtonClicked);
            _favoriteListButton.onClick.RemoveListener(OnFavoriteListButtonClicked);
            
            _profileWindow.CloseClicked -= OnProfileClosed;
            _contactList.CardClicked -= OnCardClicked;
            
            _profileWindow.StatusChanged -= OnCardStatusChanged;
        }

        private void Start()
        {
            _employeeListWindow.Open();
            _favoriteListWindow.Close();
            _profileWindow.Close();

            _previousWindow = _employeeListWindow;
        }

        private void OnCardStatusChanged(Employer employer, bool value)
        {
            _contactList.MakeFavorite(employer, value);
        }

        private void OnProfileClosed()
        {
            _profileWindow.Close();
            
            _previousWindow.Open();
            _contactList.gameObject.SetActive(true);
        }

        private void OnCardClicked(CardView cardView)
        {
            _contactList.gameObject.SetActive(false);
            _profileWindow.Init(cardView);
            _profileWindow.Open();
        }

        private void OnEmployeeListButtonClicked()
        {
            _favoriteListWindow.Close();
            _employeeListWindow.Open();

            _previousWindow = _employeeListWindow;
        }
        
        private void OnFavoriteListButtonClicked()
        {
            _employeeListWindow.Close();
            _favoriteListWindow.Open();

            _previousWindow = _favoriteListWindow;
        }
    }
}