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
    private void Update()
    {
        
    }
    public void updateStorage()
    {
        storageText.text = GameManager.instance.playerData.curStorage.ToString() + " / " + GameManager.instance.playerData.maxStorage.ToString();
    }
    public void updateMoney()
    {
        moneyText.text = GameManager.instance.playerData.curGold.ToString() + " / " + GameManager.instance.playerData.maxGold.ToString();
    }
    public void updateUI()
    {
        hpBar.fillAmount = (float)GameManager.instance.playerData.curHp / GameManager.instance.playerData.maxHp;
        fatigueBar.fillAmount = GameManager.instance.playerData.fatigue / 100f;
        hpText.text = GameManager.instance.playerData.curHp.ToString() + " / " + GameManager.instance.playerData.maxHp.ToString();
        fatigueText.text = GameManager.instance.playerData.fatigue.ToString("F1") + " / 100";
        moneySlider.value = (float)GameManager.instance.playerData.curGold / GameManager.instance.playerData.maxGold;
        storoageSlider.value = (float)GameManager.instance.playerData.curStorage / GameManager.instance.playerData.maxStorage;
        Day.text = "Day " + GameManager.instance.playerData.day.ToString();
        Time.text = (GameManager.instance.playerData.currentTime / 60f).ToString("F2") + "h";
    }
}
