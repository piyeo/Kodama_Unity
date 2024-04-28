using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public float bgmSliderValue;
    public float sfxSliderValue;

    [SerializeField] private float sfxMinimumDistance;
    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    public bool playBgm;
    private int bgmIndex;
    private bool isPause;

    private bool canPlaySFX;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            bgmSliderValue = 1; sfxSliderValue = 1;
            isPause = false;
            DontDestroyOnLoad(this.gameObject);
            instance = this;

        }
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isPause = false;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Update()
    {
        //if(!playBgm)
        //    StopAllBGM();
        //else
        //{
        //    if (!bgm[bgmIndex].isPlaying)
        //        PlayBGM(bgmIndex);
        //}

        Invoke("AllowSFX", 0.2f);

    }
    public void PlaySFX(int _sfxIndex/*, Transform _source*/)
    {
        //if (sfx[_sfxIndex].isPlaying)
        //    return;

        if (canPlaySFX == false)
            return;

        //if (_source != null && Vector2.Distance(PlayerManager.instance.player.transform.position, _source.position) > sfxMinimumDistance)
        //    return;

        if(_sfxIndex < sfx.Length)
        {
            //sfx[_sfxIndex].pitch = Random.Range(0.85f, 1.1f);
            sfx[_sfxIndex].Play();
        }
    }

    public void PlaySFXPitch(int _sfxIndex)
    {
        if (canPlaySFX == false)
            return;
        if (_sfxIndex < sfx.Length)
        {
            sfx[_sfxIndex].pitch = Random.Range(0.85f, 1.1f);
            sfx[_sfxIndex].Play();
        }
    }

    public void StopSFX(int _index) => sfx[_index].Stop();

    public void StopSFXWithTime(int _index) => StartCoroutine(DecreaseVolume(sfx[_index]));

    private IEnumerator DecreaseVolume(AudioSource _audio)
    {
        float defaultVolume = _audio.volume;

        while (_audio.volume > .1f)
        {
            _audio.volume -= _audio.volume * .2f;
            yield return new WaitForSeconds(.25f);

            if(_audio.volume <= .1f)
            {
                _audio.Stop();
                _audio.volume = defaultVolume;
                break;
            }
        }
    }

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, bgm.Length);
        PlayBGM(bgmIndex);
    }

    public void PlayBGM(int _bgmIndex)
    {
        bgmIndex = _bgmIndex;

        StopAllBGM();
        bgm[_bgmIndex].Play();
    }

    public void StopAllBGM()
    {
        for(int i = 0;i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

    public void PauseAllBGM()
    {
        if(!isPause)
        {
            for (int i = 0; i < bgm.Length; i++)
            {
                bgm[i].Pause();
            }
            isPause = true;
        }
        else
        {
            for (int i = 0; i < bgm.Length; i++)
            {
                bgm[i].UnPause();
            }
            isPause = false;
        }
    }

    public void StopAllSFX()
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].Stop();
        }
    }

    private void AllowSFX() => canPlaySFX = true;

}
