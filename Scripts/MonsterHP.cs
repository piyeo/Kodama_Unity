using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public Obstacle obstacle;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI killRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = obstacle.hp.ToString();
        damageText.text = obstacle.damage.ToString();
        killRate.text = ((((float)obstacle.damage / obstacle.hp) * 100f) + obstacle.plusRate).ToString("F0") + "%";
    }
}
