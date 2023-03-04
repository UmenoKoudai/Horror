using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : SingletonMonoBehaviour<AudioController>
{
    [Header("0:Walk")]
    [Header("1:Run")]
    [Header("2:Door")]
    [Header("3:Shoot")]
    [Header("4:Reload")]
    [Header("5:EnemyVoice1")]
    [Header("6:EnemyVoice2")]
    [Header("7:EnemyVoice3")]
    [Header("8:EnemyVoice4")]
    [Header("9:EnemyDown")]
    [Header("10:GameOver")]
    [Header("11:ItemGet")]
    //再生したいAudioClipの配列
    [SerializeField] AudioClip[] _seClips;
    AudioSource _audio;
    float _timer;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    //Audioclipを再生するための関数
    public void SePlay(SelectClip clip, float intarval)
    {
        _timer += Time.deltaTime;
        //enumをintに変換する
        int index = (int)clip;
        if (_timer > intarval)
        {
            //intに変換した要素のAudioClipを再生する
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
    EnemyVoice1,
    EnemyVoice2,
    EnemyVoice3,
    EnemyVoice4,
    EnemyDown,
    GameOver,
    ItemGet,
}
