using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_TitleMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "GameScene";
    [SerializeField] UI_FadeScreen fadeScreen;
    [SerializeField] GameObject soundMenu;
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] Image timeDark;
    private bool startGame = false;

    void Start()
    {
        AudioManager.instance.playBgm = true;
        AudioManager.instance.PlayBGM(0);
        var alpha = 0f;
        if (soundMenu.activeSelf)
        {
            alpha = 0.2f;

        }
        var color = fadeScreen.GetComponent<Image>().color;
        color.a = alpha;
        fadeScreen.GetComponent<Image>().color = color;
    }

    void Update()
    {
        Dark();
        StartJudge();
    }

    public void Dark()
    {
        var alpha = 0f;
        if (soundMenu.activeSelf)
        {
            alpha = 0.5f;

        }
        var color = timeDark.color;
        color.a = alpha;
        timeDark.color = color;
    }

    public void StartJudge()
    {
        if (Input.GetMouseButtonDown(0) && !startGame && !soundMenu.activeSelf && !tutorialMenu.activeSelf)
        {
            //RaycastAll�̈����iPointerEventData�j�쐬
            PointerEventData pointData = new PointerEventData(EventSystem.current);

            //RaycastAll�̌��ʊi�[�pList
            List<RaycastResult> RayResult = new List<RaycastResult>();

            //PointerEventData�Ƀ}�E�X�̈ʒu���Z�b�g
            pointData.position = Input.mousePosition;

            //RayCast�i�X�N���[�����W�j
            EventSystem.current.RaycastAll(pointData, RayResult);

            foreach (RaycastResult result in RayResult)
            {
                if (result.gameObject != null)
                {
                    if (result.gameObject.CompareTag("NotGameStart"))
                    {
                        return;
                    }
                }
            }
            startGame = true;
            StartGame();
        }
    }

    public void OpenSoundMenu()
    {

        AudioManager.instance.PlaySFX(6);
        soundMenu.SetActive(!soundMenu.activeSelf);
    }

    public void OpenTutorialMenu()
    {
        if (soundMenu.activeSelf)
        {
            soundMenu.SetActive(!soundMenu.activeSelf);
        }
        AudioManager.instance.PlaySFX(6);
        tutorialMenu.SetActive(!tutorialMenu.activeSelf);
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySFX(7);
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }
}
