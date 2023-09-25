using ContactList.Extensions;
using UnityEngine;

namespace ContactList.UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public virtual void Open()
        {
            _canvasGroup.Open();
        }

        public virtual void Close()
        {
            _canvasGroup.Close();
        }
    }
}