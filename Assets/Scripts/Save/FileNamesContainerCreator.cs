using ContactList.StringFields;
using UnityEngine;

namespace ContactList.Save
{
    public class FileNamesContainerCreator : MonoBehaviour
    {
        private void Awake()
        {
            Fill();
        }

        private void Fill()
        {
            FileNamesContainer.Add(typeof(CardSaveData) ,FileNames.CardSaveData);
        }
    }
}