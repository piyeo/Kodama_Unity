using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Yahoo : MonoBehaviour
{
    [SerializeField] private GameObject yahooPrefab;
    private GameObject nowYahoo;
    public static Yahoo instance;
    public float cooldown = 10;
    public float cooldownTimer;
    public NewUI_InGame inGameUI;
    private bool isMoving = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        inGameUI.SetCooldownOf();
        cooldownTimer = cooldown;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Z)) && MountainManager.instance.gameState)
        {
            CanUseYahoo();
        }

        if(isMoving && nowYahoo != null)
        {
            Vector3 movement = new Vector3(1.0f, 0.4f, 0.0f).normalized * 30.0f * Time.deltaTime;
            nowYahoo.transform.Translate(movement);
        }
    }

    public bool CanUseYahoo()
    {
        if (cooldownTimer < 0)
        {
            inGameUI.SetCooldownOf();
            UseYahoo();
            cooldownTimer = cooldown;
            return true;
        }
        return false;
    }

    public void UseYahoo()
    {
        AudioManager.instance.PlaySFX(0);
        MonsterDamage();
        GameObject[] treeObjects = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject treeObject in treeObjects)
        {
            // Treeスクリプトコンポーネントを取得
            Tree treeScript = treeObject.GetComponent<Tree>();

            // Treeスクリプトが存在し、Kodama関数を持っている場合に実行
            if (treeScript != null)
            {
                float random = Random.Range(0, 1f);
                if (random > 0.5f)
                    treeScript.pointSummon();
            }
        }

        //DestroyAll();
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // すべてのGameObjectについてKodamaコンポーネントがアタッチされているかチェックします
        foreach (GameObject obj in allObjects)
        {
            Kodamapoint kodamaPoint = obj.GetComponent<Kodamapoint>();
            if (kodamaPoint != null && !kodamaPoint.isGenerated)
            {
                // Kodamaコンポーネントがアタッチされている場合、Generate関数を呼び出します
                kodamaPoint.GenerateKodama();
            }
        }

        StartCoroutine(ClimberManager.instance.ClimberYahoo());
        StartCoroutine(RemoveYahoo());
    }

    public void DestroyAll()
    {
        GameObject[] voices = GameObject.FindGameObjectsWithTag("Voice");
        foreach (GameObject obj in voices)
        {
            Destroy(obj);
        }
        GameObject[] floatings = GameObject.FindGameObjectsWithTag("Floating");
        foreach (GameObject obj in floatings)
        {
            Destroy(obj);
        }
    }

    public IEnumerator RemoveYahoo()
    {
        yield return new WaitForSeconds(.2f);
        nowYahoo = Instantiate(yahooPrefab, ClimberManager.instance.transform.position, Quaternion.identity, ClimberManager.instance.transform);
        isMoving = true;
        yield return new WaitForSeconds(3f);
        isMoving = false;
        if(nowYahoo != null)
            Destroy(nowYahoo);
    }

    public void MonsterDamage()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject obj in monsters)
        {
            AudioManager.instance.PlaySFX(11);
            obj.GetComponent<Monster>().RateUp();
        }
    }
}
