namespace STB.Client.Audio.Internal
{
public class AK
{
    public class EVENTS
    {
        public const uint PLAY_BESTIA = 788483094U;
        public const uint PLAY_CANNON = 712207333U;
        public const uint PLAY_CAPOHIPPY = 1106213409U;
        public const uint PLAY_ENERGYGENERATOR = 64832897U;
        public const uint PLAY_GATE = 334083091U;
        public const uint PLAY_GENERATOR = 3104499145U;
        public const uint PLAY_GUNTHER = 4152091077U;
        public const uint PLAY_INFESTUS = 2503671149U;
        public const uint PLAY_MUSIC_INGAME = 962944353U;
        public const uint PLAY_MUSIC_MENU = 1699343283U;
        public const uint PLAY_MUSIC_POSTMATCH = 2107964339U;
        public const uint PLAY_NAIMA = 1152778448U;
        public const uint PLAY_ROBOTTO = 1741184965U;
        public const uint PLAY_SAMURAI = 3028710396U;
        public const uint PLAY_TECNOVICHINGA = 2857585788U;
        public const uint PLAY_UICOMMONMATCH = 605578182U;
        public const uint PLAY_UIGENERAL = 2334568968U;
        public const uint PLAY_UILOBBY = 2021984376U;
        public const uint PLAY_UIMATCH = 2158816619U;
        public const uint PLAY_UIPOSTMATCH = 2830248297U;
        public const uint START_AMBIENCE = 3626999974U;
    } // public class EVENTS

    public class STATES
    {
        public class STATE_MX_INGAME
        {
            public const uint GROUP = 1553136348U;

            public class STATE
            {
                public const uint GATE_DESTROYED = 4125600292U;
                public const uint NORMAL = 1160234136U;
            } // public class STATE
        } // public class STATE_MX_INGAME

    } // public class STATES

    public class SWITCHES
    {
        public class BASE_CHARACTER
        {
            public const uint GROUP = 3314927226U;

            public class SWITCH
            {
                public const uint ACTIVE = 58138747U;
                public const uint ACTIVE_END = 2123876509U;
                public const uint ACTIVE_START = 1240573398U;
                public const uint PASSIVE = 2595709632U;
                public const uint PASSIVE_END = 1684104902U;
                public const uint PASSIVE_START = 1145272237U;
                public const uint ULTI = 1019184271U;
                public const uint ULTI_END = 625852561U;
                public const uint ULTI_START = 2490807106U;
            } // public class SWITCH
        } // public class BASE_CHARACTER

        public class CUSTOM_BESTIA
        {
            public const uint GROUP = 2374888583U;

            public class SWITCH
            {
                public const uint ULTI_PUSH = 1421762714U;
            } // public class SWITCH
        } // public class CUSTOM_BESTIA

        public class CUSTOM_CANNON
        {
            public const uint GROUP = 1551326048U;

            public class SWITCH
            {
                public const uint CHARGE = 4285247397U;
                public const uint INTERRUPT = 3288762926U;
                public const uint SHOOT = 3038207054U;
                public const uint SHOOT_EXPLODE = 3128948000U;
            } // public class SWITCH
        } // public class CUSTOM_CANNON

        public class CUSTOM_CAPOHIPPY
        {
            public const uint GROUP = 2201044202U;

            public class SWITCH
            {
            } // public class SWITCH
        } // public class CUSTOM_CAPOHIPPY

        public class CUSTOM_ENERGY_GENERATOR
        {
            public const uint GROUP = 2337676165U;

            public class SWITCH
            {
                public const uint CHARGE = 4285247397U;
                public const uint EXTRACTION = 1479985646U;
                public const uint INTERRUPT = 3288762926U;
            } // public class SWITCH
        } // public class CUSTOM_ENERGY_GENERATOR

        public class CUSTOM_GATE
        {
            public const uint GROUP = 3223992762U;

            public class SWITCH
            {
                public const uint OFF = 930712164U;
                public const uint ON = 1651971902U;
            } // public class SWITCH
        } // public class CUSTOM_GATE

        public class CUSTOM_GENERATOR
        {
            public const uint GROUP = 3636833018U;

            public class SWITCH
            {
                public const uint BASE_DESTROYED = 79558882U;
                public const uint DESTROYED = 1359166010U;
                public const uint LOSEHP = 301302478U;
            } // public class SWITCH
        } // public class CUSTOM_GENERATOR

        public class CUSTOM_GUNTHER
        {
            public const uint GROUP = 771992650U;

            public class SWITCH
            {
                public const uint ACTIVE_HIT = 2742530041U;
                public const uint ULTI_SHIELD_APPLY = 2560927696U;
                public const uint ULTI_SHIELD_HIT = 212468635U;
            } // public class SWITCH
        } // public class CUSTOM_GUNTHER

        public class CUSTOM_INFESTUS
        {
            public const uint GROUP = 3207358936U;

            public class SWITCH
            {
                public const uint MUD_EXPLODE = 708071119U;
                public const uint MUD_SPAWN = 1613819821U;
                public const uint TENDRIL_DEATH = 1349305104U;
                public const uint TENDRIL_EMISSION = 2052848291U;
                public const uint TENDRIL_HIT = 450659809U;
                public const uint TENDRIL_RESPAWN = 3838780398U;
            } // public class SWITCH
        } // public class CUSTOM_INFESTUS

        public class CUSTOM_NAIMA
        {
            public const uint GROUP = 1132599127U;

            public class SWITCH
            {
                public const uint MINE_EXPLODE = 3403979510U;
                public const uint MINE_LAND = 2368118448U;
                public const uint PASSIVE_HIT = 1801106838U;
                public const uint ULTI_HIT = 40460333U;
            } // public class SWITCH
        } // public class CUSTOM_NAIMA

        public class CUSTOM_ROBOTTO
        {
            public const uint GROUP = 1816014634U;

            public class SWITCH
            {
                public const uint ACTIVE_ALTERNATIVE = 3980521999U;
                public const uint HEAL_MASTER = 901582148U;
                public const uint PROJECTILE_HIT = 2422838114U;
                public const uint PROJECTILE_SHOT = 3879818731U;
                public const uint STOP_RUN = 841243055U;
                public const uint STOP_WALK = 3140964691U;
            } // public class SWITCH
        } // public class CUSTOM_ROBOTTO

        public class CUSTOM_SAMURAI
        {
            public const uint GROUP = 489128203U;

            public class SWITCH
            {
                public const uint SPIRITS_END = 1013981515U;
                public const uint SPIRITS_USED = 2590778547U;
            } // public class SWITCH
        } // public class CUSTOM_SAMURAI

        public class CUSTOM_TECNOVICHINGA
        {
            public const uint GROUP = 2959182315U;

            public class SWITCH
            {
                public const uint ACTIVE_ALTERNATIVE_HIT = 2785355181U;
                public const uint ACTIVE_HIT = 2742530041U;
                public const uint PASSIVE_ALTERNATIVE_HIT = 3391858054U;
                public const uint PASSIVE_ALTERNATIVE_START = 3089017789U;
                public const uint PASSIVE_HIT = 1801106838U;
            } // public class SWITCH
        } // public class CUSTOM_TECNOVICHINGA

        public class ELEMENT_TYPE
        {
            public const uint GROUP = 4047470526U;

            public class SWITCH
            {
                public const uint BASE_CHARACTER = 3314927226U;
                public const uint CUSTOM = 46733444U;
                public const uint HITTABLE_ELEMENT = 1431942385U;
                public const uint MOVABLE_ELEMENT = 3235287364U;
            } // public class SWITCH
        } // public class ELEMENT_TYPE

        public class HITTABLE_ELEMENT
        {
            public const uint GROUP = 1431942385U;

            public class SWITCH
            {
                public const uint DEATH = 779278001U;
                public const uint HIT = 1116398592U;
                public const uint RESPAWN = 4279841335U;
            } // public class SWITCH
        } // public class HITTABLE_ELEMENT

        public class MOVABLE_ELEMENT
        {
            public const uint GROUP = 3235287364U;

            public class SWITCH
            {
                public const uint CHARGE = 4285247397U;
                public const uint RUN = 712161704U;
                public const uint STOP = 788884573U;
                public const uint WALK = 2108779966U;
            } // public class SWITCH
        } // public class MOVABLE_ELEMENT

        public class UI_COMMONMATCH
        {
            public const uint GROUP = 330972728U;

            public class SWITCH
            {
                public const uint SLIDER_BANDS = 2710229871U;
                public const uint SLIDER_PORTRAITS_END = 1722592465U;
                public const uint SLIDER_PORTRAITS_LOOP = 1443324212U;
                public const uint TIME_END = 2291899120U;
            } // public class SWITCH
        } // public class UI_COMMONMATCH

        public class UI_GENERAL
        {
            public const uint GROUP = 1222112018U;

            public class SWITCH
            {
                public const uint CLOSE_BUTTON = 1541040122U;
                public const uint CONFIRM_BUTTON = 3470170702U;
                public const uint EXIT_BUTTON = 477596604U;
                public const uint GENERIC_BUTTON = 45201699U;
                public const uint MATCH_FOUND = 1120202613U;
                public const uint OPTIONS_DROPDOWN = 500982403U;
                public const uint OPTIONS_TOGGLE = 861240008U;
                public const uint READY_BUTTON = 3509094665U;
                public const uint SECONDARY_TAB = 548431881U;
                public const uint SETTINGS_APPEARS = 2461984185U;
                public const uint SETTINGS_DISAPPEAR = 2708956512U;
            } // public class SWITCH
        } // public class UI_GENERAL

        public class UI_LOBBY
        {
            public const uint GROUP = 4293575810U;

            public class SWITCH
            {
                public const uint CANCEL_BUTTON = 3427892670U;
                public const uint CHARACTER_SELECTION = 3112424181U;
                public const uint CHARACTER_SPAWN = 572576906U;
                public const uint PEDESTALL_SELECTION = 335270178U;
                public const uint PRIMARY_TAB = 3514063397U;
            } // public class SWITCH
        } // public class UI_LOBBY

        public class UI_MATCH
        {
            public const uint GROUP = 2757049933U;

            public class SWITCH
            {
                public const uint ABILITY = 1214237073U;
                public const uint ABILITY_BUTTON = 1983404400U;
                public const uint CALLER_PHASES = 1252410663U;
                public const uint CANCEL_CLICK = 1797862502U;
                public const uint CHARACTER = 436743010U;
                public const uint DEPLOY_RESPAWN = 3608451241U;
                public const uint DONE_BUTTON = 4287607656U;
                public const uint MOVEMENT = 2129636626U;
            } // public class SWITCH
        } // public class UI_MATCH

        public class UI_POSTMATCH
        {
            public const uint GROUP = 3993141931U;

            public class SWITCH
            {
                public const uint DEFEAT = 1593864692U;
                public const uint WIN = 979765101U;
            } // public class SWITCH
        } // public class UI_POSTMATCH

    } // public class SWITCHES

    public class GAME_PARAMETERS
    {
        public const uint AMBIENCE = 85412153U;
        public const uint EPIC_SKIN_FX = 1374672411U;
        public const uint MASTER = 4056684167U;
        public const uint MUSIC = 3991942870U;
        public const uint MUSIC_INGAME = 2186578306U;
        public const uint MUSIC_MENU = 1598298728U;
        public const uint ROUND_TIME_LEFT = 3290511643U;
        public const uint SFX = 393239870U;
        public const uint UI = 1551306167U;
    } // public class GAME_PARAMETERS

    public class BANKS
    {
        public const uint INIT = 1355168291U;
        public const uint BESTIA = 2415092633U;
        public const uint CAPOHIPPY = 422040792U;
        public const uint GUNTHER = 1896602588U;
        public const uint INFESTUS = 4240259266U;
        public const uint MAP_00 = 2886052960U;
        public const uint MUSICINGAME = 1121753349U;
        public const uint MUSICMENU = 4082046343U;
        public const uint NAIMA = 3560466545U;
        public const uint POSTMATCH = 1541210382U;
        public const uint ROBOTTO = 767395484U;
        public const uint SAMURAI = 308694489U;
        public const uint TECNOVICHINGA = 2191407253U;
        public const uint UICOMMONMATCH = 1134882351U;
        public const uint UIGENERAL = 4236485561U;
        public const uint UILOBBY = 2607542257U;
        public const uint UIMATCH = 853509186U;
    } // public class BANKS

    public class BUSSES
    {
        public const uint AMBIENCE = 85412153U;
        public const uint BESTIA = 2415092633U;
        public const uint CANNON = 2393348022U;
        public const uint CAPOHIPPY = 422040792U;
        public const uint CHARACTERS = 1557941045U;
        public const uint ENVIRONMENT = 1229948536U;
        public const uint GATE = 1121922920U;
        public const uint GENERATOR = 334231652U;
        public const uint GUNTHER = 1896602588U;
        public const uint INFESTUS = 4240259266U;
        public const uint MASTER_AUDIO_BUS = 3803692087U;
        public const uint MASTER_SECONDARY_BUS = 805203703U;
        public const uint MUSIC = 3991942870U;
        public const uint MX_INGAME = 2785513802U;
        public const uint MX_MENU = 2103702368U;
        public const uint NAIMA = 3560466545U;
        public const uint ROBOTTO = 767395484U;
        public const uint SAMURAI = 308694489U;
        public const uint SFX = 393239870U;
        public const uint TECHNOVICHINGA = 212368779U;
        public const uint UI = 1551306167U;
        public const uint UI_INGAME = 2161710153U;
        public const uint UI_MENU = 2511555531U;
    } // public class BUSSES

    public class AUX_BUSSES
    {
        public const uint EPIC_SKIN_FX = 1374672411U;
        public const uint REVERB = 348963605U;
    } // public class AUX_BUSSES

}// public class AK


}
