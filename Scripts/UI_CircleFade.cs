using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CircleFade : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FocusFadeOut()
    {
        yield return new WaitForSeconds(0.45f);
        anim.SetFloat("MoveSpeed", 0);
        yield return new WaitForSeconds(1.5f);
        anim.SetFloat("MoveSpeed", 1);
    }

}
