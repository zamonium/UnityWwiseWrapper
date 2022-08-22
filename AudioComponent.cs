using UnityEngine;

namespace STB.Client.Audio
{
    public partial class AudioComponent : MonoBehaviour
    {
        #region Properties

        public string Bank { get { return m_sBankName; } }
        public uint Event { get { return (uint)m_iEventID; } }
        public uint CustomGroup { get { return (uint)m_iGroupID; } }
        public eRTPC RTPC { get { return m_bRTPC; } }

        #endregion

        #region Variables

        [SerializeField, HideInInspector] private string m_sBankName = "";
        [SerializeField, HideInInspector] private int m_iEventID = 0;
        [SerializeField, HideInInspector] private int m_iGroupID = 0;
        [SerializeField] private eRTPC m_bRTPC;

        #endregion
    }

    #region UNITY_EDITOR
#if UNITY_EDITOR
    public partial class AudioComponent : MonoBehaviour
    {
        [HideInInspector] public byte[] m_aBankGuid = new byte[16];
        [HideInInspector] public byte[] m_aEventGuid = new byte[16];

        [HideInInspector] public byte[] m_aGroupGuid = new byte[16];
        [HideInInspector] public byte[] m_aValueGuid = new byte[16];
    }
#endif
    #endregion
}
