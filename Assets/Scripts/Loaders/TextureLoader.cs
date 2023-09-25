using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ContactList.Loaders
{
    public class TextureLoader : MonoBehaviour
    {
        [SerializeField] private string _url;

        public void LoadImage(Action<Texture2D> action)
        {
            StartCoroutine(LoadImageCoroutine(action));
        }

        private IEnumerator LoadImageCoroutine(Action<Texture2D> action)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(_url);

            yield return request.SendWebRequest();
            
            Debug.Log(request.result);

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                
                action(texture);
            }
            else
            {
                action(null);
            }
        }
    }
}