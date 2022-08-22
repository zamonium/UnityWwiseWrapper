using UnityEngine;
using UnityEngine.EventSystems;

namespace STB.Client.Audio
{
    public class AudioClickAction : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.PlayUI(m_kAudioComponent);
        }

        [SerializeField] private UIAudioComponent m_kAudioComponent;
    }
}

