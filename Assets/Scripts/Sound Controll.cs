using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting; // using ConvertTo()

public class SoundControl : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource[] sfxSources;
    public Slider music, sfx;
    public Text musicText, sfxText;

    // Toggle Background sound control
    public void toggleMusic(float val)
    {   
        musicSource.volume = music.value += val;
        float value = 100 * music.value;
       musicText.text = value.ConvertTo(typeof(int)) + "%";
    }

    // Toggle SFX sound control
    public void toggleSFX(float val)
    {
        sfxSources[0].volume = sfx.value += val;
        sfxSources[1].volume = sfx.value += val;
        sfxSources[2].volume = sfx.value += val;
        float value = 100 * sfx.value;
       sfxText.text = value.ConvertTo(typeof(int)) + "%";
    }
}
