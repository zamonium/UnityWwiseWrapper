using UnityEngine;
using STB.Client.Audio.Internal;

namespace STB.Client.Audio
{
    public partial class UIAudioComponent : MonoBehaviour
    {
        private void Awake()
        {
            switch ((uint)m_iEventID)
            {
                case AK.EVENTS.PLAY_UIGENERAL:
                    m_iGroup = AK.SWITCHES.UI_GENERAL.GROUP;
                    break;
                case AK.EVENTS.PLAY_UILOBBY:
                    m_iGroup = AK.SWITCHES.UI_LOBBY.GROUP;
                    break;
                case AK.EVENTS.PLAY_UIMATCH:
                    m_iGroup = AK.SWITCHES.UI_MATCH.GROUP;
                    break;
                case AK.EVENTS.PLAY_UIPOSTMATCH:
                    m_iGroup = AK.SWITCHES.UI_POSTMATCH.GROUP;
                    break;
                case AK.EVENTS.PLAY_UICOMMONMATCH:
                    m_iGroup = AK.SWITCHES.UI_COMMONMATCH.GROUP;
                    break;
            }
        }

        #region Properties

        public eAudioUI AudioUI { get { return m_eAudioUI; } }
        public uint Event { get { return (uint)m_iEventID; } }
        public uint Group { get { return m_iGroup; } }

        #endregion

        #region Variables

        [SerializeField] private eAudioUI m_eAudioUI;
        [SerializeField, HideInInspector] private int m_iEventID = 0;
        private uint m_iGroup = 0;

        #endregion
    }

    #region UNITY_EDITOR
#if UNITY_EDITOR
    public partial class UIAudioComponent : MonoBehaviour
    {
        [HideInInspector] public byte[] m_aEventGuid = new byte[16];
    }
#endif
    #endregion
}
