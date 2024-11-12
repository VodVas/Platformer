public class MasterVolumeSlider : VolumeSlider
{
    protected override string GetVolumeParameterName()
    {
        return AudioMixerParameterKeeper.MasterVolume;
    }
}