using UnityEngine;

namespace ContactList.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new ContactListData", menuName = "StaticData/ContactListData", order = 1)]
    public class ContactListData : ScriptableObject
    {
        [SerializeField] private int _startLoadCount;

        public int StartLoadCount => _startLoadCount;
    }
}