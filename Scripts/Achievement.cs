using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public GameObject AchieveA; //ìoéRâ∆
    public GameObject AchieveB; //êXÇÃâ§
    public GameObject AchieveC; //ÉMÉÉÉìÉuÉâÅ[
    public GameObject AchieveD; //éÁåÏé“

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateAchieve()
    {
        if(MountainManager.instance.achieveA)
        {
            AchieveA.transform.Find("NoAchieveName").gameObject.SetActive(false);
            AchieveA.transform.Find("NoAchieveDescription").gameObject.SetActive(false);
            if (MountainManager.instance.achieveSP)
            {
                AchieveA.transform.Find("AchieveNameSP").gameObject.SetActive(true);
                AchieveA.transform.Find("AchieveIconSP").gameObject.SetActive(true);
                AchieveA.transform.Find("AchieveDescriptionSP").gameObject.SetActive(true);
            }
            else
            {
                AchieveA.transform.Find("AchieveName").gameObject.SetActive(true);
                AchieveA.transform.Find("AchieveIcon").gameObject.SetActive(true);
                AchieveA.transform.Find("AchieveDescription").gameObject.SetActive(true);
            }

        }
        if (MountainManager.instance.achieveB)
        {
            AchieveB.transform.Find("NoAchieveName").gameObject.SetActive(false);
            AchieveB.transform.Find("NoAchieveDescription").gameObject.SetActive(false);
            AchieveB.transform.Find("AchieveName").gameObject.SetActive(true);
            AchieveB.transform.Find("AchieveIcon").gameObject.SetActive(true);
            AchieveB.transform.Find("AchieveDescription").gameObject.SetActive(true);
        }
        if (MountainManager.instance.achieveC)
        {
            AchieveC.transform.Find("NoAchieveName").gameObject.SetActive(false);
            AchieveC.transform.Find("NoAchieveDescription").gameObject.SetActive(false);
            AchieveC.transform.Find("AchieveName").gameObject.SetActive(true);
            AchieveC.transform.Find("AchieveIcon").gameObject.SetActive(true);
            AchieveC.transform.Find("AchieveDescription").gameObject.SetActive(true);
        }
        if (MountainManager.instance.achieveD)
        {
            AchieveD.transform.Find("NoAchieveName").gameObject.SetActive(false);
            AchieveD.transform.Find("NoAchieveDescription").gameObject.SetActive(false);
            AchieveD.transform.Find("AchieveName").gameObject.SetActive(true);
            AchieveD.transform.Find("AchieveIcon").gameObject.SetActive(true);
            AchieveD.transform.Find("AchieveDescription").gameObject.SetActive(true);
        }
    }
}
