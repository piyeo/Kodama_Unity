using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewUI_InGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentRemaining;
    [SerializeField] private TextMeshProUGUI currentKodama;
    [SerializeField] private Image yahooCooldownImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRemainingUI();
        CheckCooldownOf(Yahoo.instance.cooldown);
    }

    private void UpdateRemainingUI()
    {
        currentRemaining.text =((int)MountainManager.instance.remaining).ToString() + "m";
        currentKodama.text =MountainManager.instance.currentKodama.ToString() + "•C";
    }

    public void SetCooldownOf()
    {
        if (yahooCooldownImage.fillAmount <= 0)
            yahooCooldownImage.fillAmount = 1;
    }

    private void CheckCooldownOf(float _cooldown)
    {
        if (yahooCooldownImage.fillAmount > 0)
            yahooCooldownImage.fillAmount -= 1 / _cooldown * Time.deltaTime;
    }
}
