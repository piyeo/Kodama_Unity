using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour
{
    public GameObject nextButton;
    public Sprite[] pages;
    public Image activePage;
    public TextMeshProUGUI text;

    public int nowPage;

    public void Start()
    {
        nowPage = 0;
    }

    public void OnEnable()
    {
        text.text = "次のページ(" + (nowPage + 1) + "/" + pages.Length + ")";
        activePage.sprite = pages[nowPage];
    }
    public void NextPage()
    {
        AudioManager.instance.PlaySFX(6);
        nowPage++;
        if (nowPage == pages.Length)
        {
            nowPage = 0;
            gameObject.SetActive(false);
            return;
        }
        text.text = "次のページ(" + (nowPage + 1) + "/" + pages.Length + ")";
        activePage.sprite = pages[nowPage];
    }
}
