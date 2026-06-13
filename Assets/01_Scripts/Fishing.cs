using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fishing : MonoBehaviour
{
    [Header("UI 연결")]
    [SerializeField] RectTransform bobber;
    [SerializeField] RectTransform catchZone;
    [SerializeField] float barWidth = 500f;

    [Header("설정")]
    [SerializeField] float bobberSpeed = 200f;
    [SerializeField] float zoneWidth = 120f;

    public event System.Action OnSuccess;
    public event System.Action OnFail;


    public void StartFishing() => StartCoroutine(FishingLoop());


    IEnumerator FishingLoop()
    {
        float bobX = 0f;
        float dir = 1f;
        float zoneX = Random.Range(0f, barWidth - zoneWidth);

        catchZone.sizeDelta = new Vector2(zoneWidth, catchZone.sizeDelta.y);
        catchZone.anchoredPosition = new Vector2(zoneX, 0f);

        while (true)
        {
            bobX += dir * bobberSpeed * Time.deltaTime;
            if (bobX >= barWidth) { bobX = barWidth; dir = -1f; }
            if (bobX <= 0f) { bobX = 0f; dir = 1f; }

            bobber.anchoredPosition = new Vector2(bobX, 0f);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                bool inZone = bobX >= zoneX && bobX <= zoneX + zoneWidth;
                if (inZone) OnSuccess?.Invoke();
                else OnFail?.Invoke();
                yield break;
            }

            yield return null;
        }
    }
}