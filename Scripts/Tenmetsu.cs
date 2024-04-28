using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tenmetsu : MonoBehaviour
{
    // �_�ł�����Ώ�
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image img;

    // �_�Ŏ���[s]
    [SerializeField] private float _cycle = 1;

    private double _time;

    private void Update()
    {
        if(text != null)
        {
            // �����������o�߂�����
            _time += Time.deltaTime;

            // ����cycle�ŌJ��Ԃ��g�̃A���t�@�l�v�Z
            var alpha = Mathf.Cos((float)(2 * Mathf.PI * _time / _cycle)) * 0.5f + 0.5f;

            // ��������time�ɂ�����A���t�@�l�𔽉f
            var color = text.color;
            color.a = alpha;
            text.color = color;
        }
        else if(img != null)
        {
            // �����������o�߂�����
            _time += Time.deltaTime;

            // ����cycle�ŌJ��Ԃ��g�̃A���t�@�l�v�Z
            var alpha = Mathf.Cos((float)(2 * Mathf.PI * _time / _cycle)) * 0.5f + 0.5f;

            // ��������time�ɂ�����A���t�@�l�𔽉f
            var color = img.color;
            color.a = alpha;
            img.color = color;
        }

    }
}