using UnityEngine;
using System.Collections;

public class SimpleFishing : MonoBehaviour
{
    [Header("UI 연결")]
    public RectTransform bobber;
    public RectTransform catchZone;
    public float barWidth = 500f;

    public float rangeMin = 0.1f;
    public float rangeMax = 0.9f;

    public float period = 2.5f;

    public float zoneMinWidth = 80f;
    public float zoneMaxWidth = 140f;

    public event System.Action OnSuccess;
    public event System.Action OnFail;

    public void StartFishing() => StartCoroutine(FishingLoop());

    IEnumerator FishingLoop()
    {
        float rangeStartPx = rangeMin * barWidth;
        float rangeEndPx = rangeMax * barWidth;
        float rangePx = rangeEndPx - rangeStartPx;

        float zoneW = Random.Range(zoneMinWidth, zoneMaxWidth);
        float zoneX = rangeStartPx + Random.Range(0f, rangePx - zoneW);

        catchZone.sizeDelta = new Vector2(zoneW, catchZone.sizeDelta.y);
        catchZone.anchoredPosition = new Vector2(zoneX, 0f);

        float t = 0f;

        while (true)
        {
            t += Time.deltaTime / period;

            float norm = (1f - Mathf.Cos(t * Mathf.PI * 2f)) * 0.5f;
            float bobX = Mathf.Lerp(rangeStartPx, rangeEndPx, norm);

            bobber.anchoredPosition = new Vector2(bobX, 0f);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                bool inZone = bobX >= zoneX && bobX <= zoneX + zoneW;
                if (inZone) { OnSuccess?.Invoke(); Debug.Log("Success"); }
                else { OnFail?.Invoke(); Debug.Log("Fail"); }
                this.gameObject.SetActive(false);
                yield break;
            }

            yield return null;
        }
    }
}