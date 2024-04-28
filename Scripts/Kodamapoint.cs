using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kodamapoint : MonoBehaviour
{
    public bool isGenerated = false;
    [SerializeField] private GameObject kodamaPrefab;
    [SerializeField] private GameObject voicePrefab;
    private GameObject kodamaZone;
    private GameObject voiceInstance;

    void Update()
    {
        if (!MountainManager.instance.gameState)
            return;
        // �}�E�X�̍��N���b�N�����ꂽ���̏���
        if (Input.GetMouseButtonDown(0) && !isGenerated)
        {
            // �}�E�X�̈ʒu����Ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        isGenerated = true;
                        GenerateVoice();
                        break; // �������g�����������烋�[�v�𔲂���
                    }
                }
            }
        }
    }

    void GenerateVoice()
    {
        voiceInstance = Instantiate(voicePrefab, ClimberManager.instance.climber.transform.position, Quaternion.identity, ClimberManager.instance.climber.transform);
        voiceInstance.GetComponent<VoiceController>().SetPosition(gameObject);
    }

    public void GenerateKodama()
    {
        kodamaZone = GameObject.Find("kodamaZone");
        GameObject kodama = Instantiate(kodamaPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, kodamaZone.transform);
        Destroy(gameObject);
    }

    public void DestroyThis()
    {
        if (!isGenerated)
        {
            Destroy(gameObject);   
        }
    }

}
