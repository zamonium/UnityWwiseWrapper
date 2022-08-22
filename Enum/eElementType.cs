using STB.Client.Audio.Internal;

namespace STB.Client.Audio
{
    public enum eElementType : uint
    {
        Group = AK.SWITCHES.ELEMENT_TYPE.GROUP,

        HittableElement = AK.SWITCHES.ELEMENT_TYPE.SWITCH.HITTABLE_ELEMENT,
        MovableElement = AK.SWITCHES.ELEMENT_TYPE.SWITCH.MOVABLE_ELEMENT,
        BaseCharacter = AK.SWITCHES.ELEMENT_TYPE.SWITCH.BASE_CHARACTER,
        Custom = AK.SWITCHES.ELEMENT_TYPE.SWITCH.CUSTOM
    }
}