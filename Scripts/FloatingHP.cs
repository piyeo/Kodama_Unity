using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingHP : MonoBehaviour
{
    public Obstacle obstacle;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = (obstacle.hp - obstacle.damage).ToString();
    }
}
