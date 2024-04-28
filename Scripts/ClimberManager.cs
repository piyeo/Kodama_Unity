using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberManager : MonoBehaviour
{
    public static ClimberManager instance;
    public GameObject climber;
    [SerializeField] private Animator anim;
    public GameObject audioInstance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        if (AudioManager.instance == null)
            Instantiate(audioInstance);
        AudioManager.instance.playBgm = true;
        AudioManager.instance.PlayBGM(1);
    }

    void Update()
    {
    }

    public void ClimberWow() => anim.SetTrigger("Wow");

    public IEnumerator ClimberYahoo()
    {
        anim.SetBool("Yahoo", true);
        yield return new WaitForSeconds(1f);

        anim.SetBool("Yahoo", false);
    }
}
