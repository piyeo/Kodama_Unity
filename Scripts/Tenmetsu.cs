using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tenmetsu : MonoBehaviour
{
    // 点滅させる対象
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image img;

    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;

    private double _time;

    private void Update()
    {
        if(text != null)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;

            // 周期cycleで繰り返す波のアルファ値計算
            var alpha = Mathf.Cos((float)(2 * Mathf.PI * _time / _cycle)) * 0.5f + 0.5f;

            // 内部時刻timeにおけるアルファ値を反映
            var color = text.color;
            color.a = alpha;
            text.color = color;
        }
        else if(img != null)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;

            // 周期cycleで繰り返す波のアルファ値計算
            var alpha = Mathf.Cos((float)(2 * Mathf.PI * _time / _cycle)) * 0.5f + 0.5f;

            // 内部時刻timeにおけるアルファ値を反映
            var color = img.color;
            color.a = alpha;
            img.color = color;
        }

    }
}