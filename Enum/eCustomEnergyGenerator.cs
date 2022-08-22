using STB.Client.Audio.Internal;

namespace STB.Client.Audio
{
	public enum eCustomEnergyGenerator : uint
	{
		Charge = AK.SWITCHES.CUSTOM_ENERGY_GENERATOR.SWITCH.CHARGE,
		Extraction = AK.SWITCHES.CUSTOM_ENERGY_GENERATOR.SWITCH.EXTRACTION,
		Interrupt = AK.SWITCHES.CUSTOM_ENERGY_GENERATOR.SWITCH.INTERRUPT
	}
}
