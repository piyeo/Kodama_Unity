using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewUI : MonoBehaviour
{
    [Header("End Screen")]
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] GameObject Mask;
    [SerializeField] GameObject Unmask;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject stopText;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject titleButton;
    [SerializeField] private GameObject achieve;
    [SerializeField] private Transform killedByStamina;
    [SerializeField] private Transform killedByMonster;
    [Space]
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject kodamaText;

    private void Awake()
    {
        fadeScreen.gameObject.SetActive(true);
    }
    void Start()
    {
        Unmask.SetActive(false);
        SwitchUI(InGameUI);
    }

    void Update()
    {
        
    }

    public void SwitchUI(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;

            if (fadeScreen == false)
                transform.GetChild(i).gameObject.SetActive(false);
        }
        if (_menu != null)
        {
            _menu.SetActive(true);
        }
        if (MountainManager.instance != null)
        {
            if (_menu == InGameUI)
                MountainManager.instance.PauseGame(false);
            else
                MountainManager.instance.PauseGame(true);
        }
    }

    private void CheckForInGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf && transform.GetChild(i).GetComponent<UI_FadeScreen>() == null)
                return;
        }

        SwitchUI(InGameUI);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void TitleScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }

    public void ClimberEndScreen()
    {
        Mask.SetActive(true);
        RectTransform rect = Unmask.GetComponent<RectTransform>();
        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, killedByStamina.transform.position);
        Unmask.SetActive(true);
        StartCoroutine(Unmask.GetComponent<UI_CircleFade>().FocusFadeOut());
        StartCoroutine(EndScreenContinue());
    }

    public void MonsterEndScreen()
    {
        Mask.SetActive(true);
        RectTransform rect = Unmask.GetComponent<RectTransform>();
        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, killedByMonster.transform.position);
        Unmask.SetActive(true);
        StartCoroutine(Unmask.GetComponent<UI_CircleFade>().FocusFadeOut());
        StartCoroutine(EndScreenContinue());
    }

    IEnumerator EndScreenContinue()
    {
        yield return new WaitForSeconds(2.5f);
        endText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        achieve.GetComponent<Achievement>().ActivateAchieve();
        achieve.SetActive(true);
        restartButton.SetActive(true);
        titleButton.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = "åãâ ÅF" + MountainManager.instance.remaining.ToString() + "m";
        scoreText.SetActive(true);
    }

    public void StopScreen(bool _stop)
    {
        AudioManager.instance.PauseAllBGM();
        AudioManager.instance.PlaySFX(6);
        stopText.SetActive(_stop);
        restartButton.SetActive(_stop);
        titleButton.SetActive(_stop);
    }
}
