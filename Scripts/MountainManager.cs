using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainManager : MonoBehaviour
{
    public static MountainManager instance;
    public float goal = 500;
    public float remaining = 1;
    [SerializeField] private float decreaseRateMeter;
    [SerializeField] private float decreaseRateST;
    public bool gameState = false;
    public bool gameStoped = false;
    public NewUI ui;
    public UI_Stamina staminaUI;
    private bool staminaStop = false;
    public bool achieveA;
    public bool achieveSP;
    public bool achieveB;
    public bool achieveC;
    public bool achieveD;

    /*称号
     * 登山家：
     * 1000m
     * こだま25匹集めた：
     * 森の王
     * 成功率15パーセント以内で討伐：
     * ギャンブラー
     * ノーダメージ：
     * 鉄壁
     */


    [Header("Kodama")]
    public List<KodamaController> kodamas = new List<KodamaController>();
    public int currentKodama = 0;

    [Header("Climber")]
    public float maxStamina = 100;
    public float currentStamina = 100;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Start()
    { 
        achieveA = false; 
        achieveSP = false; 
        achieveB = false; 
        achieveC = false; 
        achieveD = true; 
    }
    void Update()
    {
        CheckAchieve();
        if (remaining > 0 && gameState)
        {
            remaining += Time.deltaTime * decreaseRateMeter;
        }

        if (staminaStop)
            return;

        if(currentStamina > 0)
        {
            currentStamina -= Time.deltaTime * (decreaseRateST - Mathf.Clamp(Mathf.Log10(currentKodama), 0, decreaseRateST/1.5f) );
            staminaUI.UpdateStaminaUI();
            staminaUI.UpdateDecreaseUI();
        }

        if(currentStamina <= 0)
        {
            gameState = false;
            ClimberManager.instance.ClimberWow();
            ui.ClimberEndScreen();
        }

        //if(remaining <= 0)
        //{
        //    remaining = 0;
        //    Debug.Log("山登りカウンターがゼロになりました！");
        //}
    }

    public void PauseGame(bool _pause)
    {
        if (_pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void StopGame()
    {
        if (gameStoped)
        {
            Time.timeScale = 1;
            gameStoped = false;
            ui.StopScreen(false);
        }
        else
        {
            gameStoped = true;
            ui.StopScreen(true);
            Time.timeScale = 0;
        }
    }

    public void AddKodama(KodamaController kc)
    {
        currentKodama++;
        kodamas.Add(kc);
    }

    public void DecreaseKodama(int _index)
    {
        currentKodama--;
        kodamas.RemoveAt(_index);
    }

    public void KodamaToObstacle(GameObject _obj, GameObject _parent)
    {
        if(kodamas.Count > 0)
        {
            int random = Random.Range(0, currentKodama);
            kodamas[random].transform.SetParent(_parent.transform);
            kodamas[random].pointZone = _obj;
            kodamas[random].canMoveToObs = true;
            DecreaseKodama(random);
        }
    }

    public void StartDecrease(float _value)
    {
        StartCoroutine(DecreaseStamina(_value));
    }

    public void KilledByMonster()
    {
        AudioManager.instance.StopAllBGM();
        AudioManager.instance.StopAllSFX();
        AudioManager.instance.PlaySFX(10);
        gameState = false;
        ClimberManager.instance.ClimberWow();
        ui.MonsterEndScreen();
    }

    public IEnumerator DecreaseStamina(float _value)
    {
        AudioManager.instance.PlaySFX(11);
        staminaStop = true;
        currentStamina -= _value;
        staminaUI.UpdateStaminaUI();
        yield return new WaitForSeconds(1.2f);
        staminaUI.UpdateDecreaseUI();
        staminaStop = false;
    }

    public void CheckAchieve()
    {
        if (remaining >= 1000 && !achieveA)
            achieveA = true;
        if (remaining >= 1500 && !achieveSP)
            achieveSP = true;
        if (currentKodama >= 25 && !achieveB)
            achieveB = true;
    }
}
