using System.Collections;
using TMPro;
using UnityEngine;

public class WaveView : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
        transform.localScale = Vector3.zero;
    }

    public void SetWave(string waveName)
    {
        _text.text = waveName;
        gameObject.SetActive(true);
        StartCoroutine(ShowWaveName());
    }

    private IEnumerator ShowWaveName()
    {
        yield return new WaitForSeconds(1.5f);

        var progress = 0f;
        while(progress <= 0.99f)
        {
            progress = Mathf.Lerp(progress, 1, 0.1f);
            transform.localScale = Vector3.one * progress;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while(progress >= 0.05)
        {
            progress = Mathf.Lerp(progress, 0, 0.1f);
            transform.localScale = Vector3.one * progress;
            yield return null;
        }
        gameObject.SetActive(false);
        StopCoroutine(ShowWaveName());
    }
}
