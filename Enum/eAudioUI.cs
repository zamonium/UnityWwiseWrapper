using STB.Client.Audio.Internal;

namespace STB.Client.Audio
{
	public enum eAudioUI : int
	{
		SliderBands = unchecked((int) AK.SWITCHES.UI_COMMONMATCH.SWITCH.SLIDER_BANDS),
		SliderPortraitsEnd = unchecked((int) AK.SWITCHES.UI_COMMONMATCH.SWITCH.SLIDER_PORTRAITS_END),
		SliderPortraitsLoop = unchecked((int) AK.SWITCHES.UI_COMMONMATCH.SWITCH.SLIDER_PORTRAITS_LOOP),
		TimeEnd = unchecked((int) AK.SWITCHES.UI_COMMONMATCH.SWITCH.TIME_END),
		CloseButton = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.CLOSE_BUTTON),
		ConfirmButton = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.CONFIRM_BUTTON),
		ExitButton = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.EXIT_BUTTON),
		GenericButton = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.GENERIC_BUTTON),
		MatchFound = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.MATCH_FOUND),
		OptionsDropdown = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.OPTIONS_DROPDOWN),
		OptionsToggle = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.OPTIONS_TOGGLE),
		ReadyButton = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.READY_BUTTON),
		SecondaryTab = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.SECONDARY_TAB),
		SettingsAppears = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.SETTINGS_APPEARS),
		SettingsDisappear = unchecked((int) AK.SWITCHES.UI_GENERAL.SWITCH.SETTINGS_DISAPPEAR),
		CancelButton = unchecked((int) AK.SWITCHES.UI_LOBBY.SWITCH.CANCEL_BUTTON),
		CharacterSelection = unchecked((int) AK.SWITCHES.UI_LOBBY.SWITCH.CHARACTER_SELECTION),
		CharacterSpawn = unchecked((int) AK.SWITCHES.UI_LOBBY.SWITCH.CHARACTER_SPAWN),
		PedestallSelection = unchecked((int) AK.SWITCHES.UI_LOBBY.SWITCH.PEDESTALL_SELECTION),
		PrimaryTab = unchecked((int) AK.SWITCHES.UI_LOBBY.SWITCH.PRIMARY_TAB),
		Ability = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.ABILITY),
		AbilityButton = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.ABILITY_BUTTON),
		CallerPhases = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.CALLER_PHASES),
		CancelClick = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.CANCEL_CLICK),
		Character = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.CHARACTER),
		DeployRespawn = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.DEPLOY_RESPAWN),
		DoneButton = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.DONE_BUTTON),
		Movement = unchecked((int) AK.SWITCHES.UI_MATCH.SWITCH.MOVEMENT),
		Defeat = unchecked((int) AK.SWITCHES.UI_POSTMATCH.SWITCH.DEFEAT),
		Win = unchecked((int) AK.SWITCHES.UI_POSTMATCH.SWITCH.WIN)
	}
}
