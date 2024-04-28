using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour
{
    private Vector3 targetPosition;
    private GameObject kodamaPoint;
    [SerializeField] private Sprite[] renderers;

    void Awake()
    {
        int random = Random.Range(0, renderers.Length);
        GetComponent<SpriteRenderer>().sprite = renderers[random];
        AudioManager.instance.PlaySFX(random+1);
    }
    void Update()
    {
        if (kodamaPoint != null)
        {
            if (gameObject.transform.position != targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 30.0f * Time.deltaTime);
            else if (gameObject.transform.position == targetPosition)
            {
                kodamaPoint.GetComponent<Kodamapoint>().GenerateKodama();
                Destroy(gameObject);
            }
        }
    }

    public void SetPosition(GameObject _kodamaPoint)
    {
        kodamaPoint = _kodamaPoint;
        targetPosition = _kodamaPoint.transform.position;
    }
}
