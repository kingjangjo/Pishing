using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI 연결")]
    public Image hpBar;
    public Image fatigueBar;
    public Text hpText;
    public Text fatigueText;
    public Text moneyText;
    public Slider moneySlider;
    public Text storageText;
    public Slider storoageSlider;
    public Text Day;
    public Text Time;

    [Header("시계 설정")]
    public float realSecondsPerHour = 25f;
    public float startHour = 1f;
    private void Update()
    {
        updateUI();
    }
    public void updateStorage()
    {
        storoageSlider.value = (float)GameManager.instance.playerData.curStorage / GameManager.instance.playerData.maxStorage;
        storageText.text = GameManager.instance.playerData.curStorage.ToString() + " / " + GameManager.instance.playerData.maxStorage.ToString();
    }
    public void updateMoney()
    {
        moneySlider.value = (float)GameManager.instance.playerData.curGold / GameManager.instance.playerData.maxGold;
        moneyText.text = GameManager.instance.playerData.curGold.ToString() + " / " + GameManager.instance.playerData.maxGold.ToString();
    }
    public void updateUI()
    {
        hpBar.fillAmount = (float)GameManager.instance.playerData.curHp / GameManager.instance.playerData.maxHp;
        fatigueBar.fillAmount = GameManager.instance.playerData.fatigue / 100f;
        hpText.text = GameManager.instance.playerData.curHp.ToString() + " / " + GameManager.instance.playerData.maxHp.ToString() + "\n체력";
        fatigueText.text = GameManager.instance.playerData.fatigue.ToString("F1") + " / 100" + "\n피로도";
        //Day.text = "Day " + GameManager.instance.playerData.day.ToString();
        //Time.text = (GameManager.instance.playerData.currentTime / 60f).ToString("F2") + "h";
        updateTime();
    }
    public void updateTime()
    {
        float currentTime = GameManager.instance.playerData.currentTime;

        float gameMinutes = currentTime * (60f / realSecondsPerHour) + startHour * 60f;

        int totalMinutes = (int)gameMinutes % (24 * 60);
        int hour24 = totalMinutes / 60;
        int minute = totalMinutes % 60;

        int hour12 = hour24 % 12;
        if (hour12 == 0) hour12 = 12;
        string period = hour24 < 12 ? "AM" : "PM";

        Time.text = string.Format("{0:D2}:{1:D2} {2}", hour12, minute, period);
    }
}
