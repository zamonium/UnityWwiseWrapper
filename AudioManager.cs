using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace STB.Client.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Action OnAudioSettingsChange;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                Debug.LogError("Audio Manager Instance already present");
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            if (AkSoundEngine.IsInitialized())
            {
                m_dBanks = new Dictionary<uint, BankData>();
                m_dBankCallback = new Dictionary<uint, Action<bool>>();
                InitAudioSettings();
            }
            else
            {
                if (m_kUI_Advice != null)
                    m_kUI_Advice.ShowAdvice(string.Empty, LocalizationStrings.WwiseNotInizialized, LocalizationStrings.ExitButton, OnExitBtnPressed);
            }
        } 

        #region Banks

        private void LoadBank(string sBankName, eBankType eType, Action<bool> kCallback)
        {
            uint iBankID = AkSoundEngine.GetIDFromString(sBankName);

            if (!m_dBanks.ContainsKey(iBankID))
            {
                BankData data = new BankData(sBankName, eType);

                m_dBanks.Add(iBankID, data);

                if(kCallback != null)
                    m_dBankCallback.Add(iBankID, kCallback);

                AkBankManager.LoadBankAsync(sBankName, WwiseBankCallback);
            }
            else
            {
#if UNITY_EDITOR || ACTIVE_LOG
                Debug.Log("The sound bank " + sBankName + " has already been loaded");
#endif
                StartCoroutine(ForcedCallToCallbackRoutine(kCallback));
            }
        }

        private void WwiseBankCallback(uint in_bankID, IntPtr in_InMemoryBankPtr, AKRESULT in_eLoadResult, uint in_memPoolId, object in_Cookie)
        {
            if (m_dBankCallback.ContainsKey(in_bankID))
            {
                m_dBankCallback[in_bankID](in_eLoadResult == AKRESULT.AK_Success);
            
                m_dBankCallback.Remove(in_bankID);
            }
            else
            {
                Debug.LogError("The sound bank wasn't present in the callback dictionary");
            }

            if (in_eLoadResult != AKRESULT.AK_Success)
            {
                m_dBanks.Remove(in_bankID);

                if(m_kUI_Advice != null)
                    m_kUI_Advice.ShowAdvice(String.Empty, LocalizationStrings.WwiseBankLoadingError, LocalizationStrings.ExitButton, OnExitBtnPressed);

                Debug.LogError("Error while loading the bank");
            }
        }
        
        private IEnumerator ForcedCallToCallbackRoutine(Action<bool> kCallback)
        {
            yield return new WaitForEndOfFrame();

            if(kCallback != null)
                kCallback(true);
        }
        
        private void UnloadBank(string sBankName)
        {
            uint iBankID = AkSoundEngine.GetIDFromString(sBankName);

            if (m_dBanks.ContainsKey(iBankID))
            {
                AkBankManager.UnloadBank(sBankName);

                m_dBanks.Remove(iBankID);
            }
#if UNITY_EDITOR
            else
            {
                Debug.Log("The sound bank " + sBankName + " wasn't loaded");
            }
#endif
        }

        public void UnloadBanksType(eBankType eType)
        {
            foreach (uint iBankID in m_dBanks.Keys.ToList())
            {
                if (m_dBanks[iBankID].BankType == eType)
                {
                    UnloadBank(m_dBanks[iBankID].BankName);
                }
            }
        }

        public void UnloadBanksTypeDelayed(eBankType eType, float fDelay)
        {
            IEnumerator kCoroutine = WaitBeforeUnload(eType, fDelay);

            StartCoroutine(kCoroutine);
        }

        private IEnumerator WaitBeforeUnload(eBankType eType, float fDelay)
        {
            yield return new WaitForSeconds(fDelay);

            UnloadBanksType(eType);
        }

        public void UnloadAllBanks()
        {
            foreach (uint iBankID in m_dBanks.Keys)
            {
                AkBankManager.UnloadBank(m_dBanks[iBankID].BankName);
            }

            m_dBanks.Clear();
        }

        #endregion
        
        public void Init(AudioComponent kAudioComponent, GameObject oTarget, Action<bool> kCallback, eBankType eType)
        {
            if (!String.IsNullOrEmpty(kAudioComponent.Bank))
                LoadBank(kAudioComponent.Bank, eType, kCallback);
            else
                Debug.LogError("Bank Name not present in the Audio Component");

            if (kAudioComponent.RTPC != eRTPC.None)
            {
                SetRTPC((uint)kAudioComponent.RTPC, 1, oTarget);
            }
        }

        public void Init(AudioComponent kAudioComponent, GameObject oTarget, eBankType eType)
        {
            Init(kAudioComponent, oTarget, InternalBankCallback, eType);
        }

        public void InternalBankCallback(bool bLoaded) { }

        public static void PlayEvent(AudioComponent kAudioComponent, GameObject oTarget)
        {
            AkSoundEngine.PostEvent(kAudioComponent.Event, oTarget);
        }

        public static void PlayUI(UIAudioComponent kUIAudioComponent)
        {
            PlayUI(kUIAudioComponent, Instance.gameObject);
        }

        public static void PlayUI(UIAudioComponent kUIAudioComponent, GameObject oTarget)
        {
            AkSoundEngine.SetSwitch(kUIAudioComponent.Group, (uint)kUIAudioComponent.AudioUI, oTarget);
            AkSoundEngine.PostEvent(kUIAudioComponent.Event, oTarget);
        }
        
        #region Hittable Element Actions

        public static void PlayHit(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.HittableElement, eCommonGroup.HittableElementGroup, eCommonAction.Hit, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayDeath(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.HittableElement, eCommonGroup.HittableElementGroup, eCommonAction.Death, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayRespawn(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.HittableElement, eCommonGroup.HittableElementGroup, eCommonAction.Respawn, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion

        #region Movable Element Actions

        public static void PlayWalk(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.MovableElement, eCommonGroup.MovableElementGroup, eCommonAction.Walk, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayRun(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.MovableElement, eCommonGroup.MovableElementGroup, eCommonAction.Run, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayStop(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.MovableElement, eCommonGroup.MovableElementGroup, eCommonAction.Stop, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }
        
        public static void PlayCharge(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.MovableElement, eCommonGroup.MovableElementGroup, eCommonAction.Charge, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion
        
        #region Base Character Active Actions

        public static void PlayActive(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.Active, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayActiveStart(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.ActiveStart, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }
        
        public static void PlayActiveEnd(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.ActiveEnd, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion

        #region Base Character Passive Actions

        public static void PlayPassive(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.Passive, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayPassiveStart(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.PassiveStart, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayPassiveEnd(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.PassiveEnd, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion

        #region Base Character Ulti Actions

        public static void PlayUlti(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.Ulti, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        public static void PlayUltiStart(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.UltiStart, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }
        
        public static void PlayUltiEnd(AudioComponent kAudio, GameObject oTarget)
        {
            SetElementSwitch(eElementType.BaseCharacter, eCommonGroup.BaseCharacterGroup, eCommonAction.UltiEnd, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion
        
        #region Custom Actions

        public static void PlayCustomElement(uint iActionValue, AudioComponent kAudio, GameObject oTarget)
        {
            AkSoundEngine.SetSwitch((uint)eElementType.Group, (uint)eElementType.Custom, oTarget);

            PlayCustom(iActionValue, kAudio, oTarget);
        }

        /// <summary>
        /// To use only if the element doesn't inherit from BaseElement, otherwise use PlayCustomElement
        /// </summary>
        public static void PlayCustom(uint iActionValue, AudioComponent kAudio, GameObject oTarget) 
        {
            AkSoundEngine.SetSwitch(kAudio.CustomGroup, iActionValue, oTarget);

            AkSoundEngine.PostEvent(kAudio.Event, oTarget);
        }

        #endregion
        
        private static void SetElementSwitch(eElementType eType, eCommonGroup eCommonGroup, eCommonAction eActionValue, GameObject oTarget)
        {
            AkSoundEngine.SetSwitch((uint)eElementType.Group, (uint)eType, oTarget);

            AkSoundEngine.SetSwitch((uint)eCommonGroup, (uint)eActionValue, oTarget);
        }

        public static void SetState(uint iStateGroup, uint iStateValue)
        {
            AkSoundEngine.SetState(iStateGroup, iStateValue);
        }

        public static void SetRTPC(uint iRTPC, float fValue, GameObject oTarget)
        {
            AkSoundEngine.SetRTPCValue(iRTPC, fValue, oTarget);
        }

        public static void StopElement(AudioComponent kAudio, GameObject oTarget, float fFadeOutSec = 0)
        {
            AkSoundEngine.ExecuteActionOnEvent(kAudio.Event, AkActionOnEventType.AkActionOnEventType_Stop, oTarget, (int)(fFadeOutSec * 1000), AkCurveInterpolation.AkCurveInterpolation_Linear);
        }

        public static void StopUIElement(UIAudioComponent kUIAudioComponent, GameObject oTarget, float fFadeOutSec = 0)
        {
            AkSoundEngine.ExecuteActionOnEvent(kUIAudioComponent.Event, AkActionOnEventType.AkActionOnEventType_Stop, oTarget, (int)(fFadeOutSec * 1000), AkCurveInterpolation.AkCurveInterpolation_Linear);
        }

        #region Audio Settings

        private void InitAudioSettings()
        {
            CurrentAudioSettings = ScriptableObject.CreateInstance(typeof(AudioSettingsData)) as AudioSettingsData;
            bool bLoadedCurrent = CurrentAudioSettings.Load(SaveNames.mk_sCurrentAudioSettings);

            if(!bLoadedCurrent)
            {
                CurrentAudioSettings.DeepCopy(m_kDefaultAudioSettings);
                CurrentAudioSettings.Save(SaveNames.mk_sCurrentAudioSettings);
                SaveLoad.Save(true);
            }

            SetSettings(CurrentAudioSettings);
        }

        public void PlayInBackground(bool bPlay)
        {
            CurrentAudioSettings.PlayInBackground = bPlay;
        }

        public void SetActive(int iIndex, bool bActive)
        {
            if(iIndex == AudioVolumeMasterIndex)
            {
                for (int i = 0; i < AudioBusLength; ++i)
                    CurrentAudioSettings.AudioControls[i].Active = bActive;

                if (OnAudioSettingsChange != null)
                    OnAudioSettingsChange();
            }
            else if(iIndex == AudioVolumeMusicIndex)
            {
                CurrentAudioSettings.AudioControls[iIndex].Active = bActive;

                for (int i = 5; i < AudioBusLength; ++i)
                    CurrentAudioSettings.AudioControls[i].Active = bActive;

                if (OnAudioSettingsChange != null)
                    OnAudioSettingsChange();
            }
            else
                CurrentAudioSettings.AudioControls[iIndex].Active = bActive;

            SetSettings(CurrentAudioSettings);
        }

        public void SetVolume(int iIndex, float fVolume)
        {
            CurrentAudioSettings.AudioControls[iIndex].Volume = fVolume;

            SetSettings(CurrentAudioSettings);
        }

        public void SaveSettings()
        {
            CurrentAudioSettings.Save(SaveNames.mk_sCurrentAudioSettings);
            SaveLoad.Save(true);

            SetSettings(CurrentAudioSettings);
        }

        public void ResetSettings()
        {
            if (!CurrentAudioSettings.Load(SaveNames.mk_sCurrentAudioSettings))
                CurrentAudioSettings.DeepCopy(m_kDefaultAudioSettings);

            SetSettings(CurrentAudioSettings);
        }

        public void SetDefaultSettings()
        {
            CurrentAudioSettings.DeepCopy(m_kDefaultAudioSettings);

            if (OnAudioSettingsChange != null)
                OnAudioSettingsChange();
        }

        private void SetSettings(AudioSettingsData kAudioSettings)
        {
            m_bPlayInBackground = CurrentAudioSettings.PlayInBackground;

            for (uint i = 0; i < AudioBusLength; ++i)
            {
                if (kAudioSettings.AudioControls[i].Active)
                    AkSoundEngine.SetRTPCValue(AudioBus[i], kAudioSettings.AudioControls[i].Volume);
                else
                    AkSoundEngine.SetRTPCValue(AudioBus[i], 0f);
            }

            if (OnAudioSettingsChange != null)
                OnAudioSettingsChange();
        }

        #endregion

        public static void ResetListenerPosition()
        {
            // Reset position of the default listener (id = 0)
            // Front -> Forward (0, 0, 1)
            // Top -> Up (0, 1, 0)
            // Position -> Audio Manager Position
            
            AkSoundEngine.SetListenerPosition(0, 0, 1, 0, 1, 0, Instance.transform.position.x, Instance.transform.position.y, Instance.transform.position.z, 0);
        }

        #region Properties

        public static AudioManager Instance { get; private set; }

        public AudioSettingsData CurrentAudioSettings { get; private set; }

        public static readonly int AudioBusLength = 7;
        public static readonly int AudioVolumeMasterIndex = 0;
        public static readonly int AudioVolumeMusicIndex = 1;
        public static readonly int[] AudioVolumeMusicSubCategoriesIndex = { 5, 6 };
        
        public bool PlayBackground { get { return m_bPlayInBackground; } }

        #endregion

        #region Variables

        private Dictionary<uint, BankData> m_dBanks;

        private Dictionary<uint, Action<bool>> m_dBankCallback;

        [SerializeField] private UI_Advice m_kUI_Advice;
        [SerializeField] private AudioSettingsData m_kDefaultAudioSettings;
        
        private static uint[] AudioBus = new uint[] { (uint)eAudioVolume.Master, (uint)eAudioVolume.Music, (uint)eAudioVolume.Ambience, (uint)eAudioVolume.SFX, (uint)eAudioVolume.UI, (uint)eAudioVolume.MusicLobby, (uint)eAudioVolume.MusicGame };
        private bool m_bPlayInBackground;

        #endregion
    }
}
