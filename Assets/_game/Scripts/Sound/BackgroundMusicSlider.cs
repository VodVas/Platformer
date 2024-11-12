public class BackgroundMusicSlider : VolumeSlider
{
    protected override string GetVolumeParameterName()
    {
        return AudioMixerParameterKeeper.BackgroundMusicVolume;
    }
}