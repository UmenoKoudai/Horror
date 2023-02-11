using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : SingletonMonoBehaviour<AudioController>
{
    [Header("0:Walk")]
    [Header("1:Run")]
    [Header("2:Door")]
    [Header("3:Shoot")]
    [Header("4:Reload")]
    [SerializeField] AudioClip[] _seClips;
    AudioSource _audio;
    float _timer;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SePlay(SelectClip clip, float intarval)
    {
        _timer += Time.deltaTime;
        int index = (int)clip;
        if (_timer > intarval)
        {
            _audio.PlayOneShot(_seClips[index]);
            _timer = 0f;
        }
    }
}
public enum SelectClip
{
    Walk,
    Run,
    Door,
    Shoot,
    Reload,
}
