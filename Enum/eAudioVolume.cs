using STB.Client.Audio.Internal;

namespace STB.Client.Audio
{
    public enum eAudioVolume : uint
    {
        Master = AK.GAME_PARAMETERS.MASTER,
        Music = AK.GAME_PARAMETERS.MUSIC,
        SFX = AK.GAME_PARAMETERS.SFX,
        Ambience = AK.GAME_PARAMETERS.AMBIENCE,
        UI = AK.GAME_PARAMETERS.UI,
        MusicLobby = AK.GAME_PARAMETERS.MUSIC_MENU,
        MusicGame = AK.GAME_PARAMETERS.MUSIC_INGAME
    }
}