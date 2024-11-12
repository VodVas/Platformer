public class SoundFXSlider : VolumeSlider
{
    protected override string GetVolumeParameterName()
    {
        return AudioMixerParameterKeeper.SoundFXVolume;
    }
}