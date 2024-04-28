using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUI_option : MonoBehaviour
{
    public GameObject cancelButton;

    public void CancelOption()
    {
        AudioManager.instance.PlaySFX(6);
        gameObject.SetActive(false);
    }
}
