using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CookTest : MonoBehaviour
{
    private int remainCook = 4;
    private int FishTier = 0;
    public Image RarityUI;
    public GameObject ClickEffect;
    public Text ChanceText;
    public int upgradeRate = 25;
    public Color[] colorset = new Color[3];
    public void Start()
    {
        RarityUI.color = colorset[FishTier];
    }
    public void CookFish(){
        if(remainCook > 0) { 
            ChanceText.text = $"{4-(--remainCook)} / 4";
            Destroy(Instantiate(ClickEffect,transform.parent), 0.5f);
            if (Random.Range(0,100) <= upgradeRate){
                FishTier++;
                RarityUI.color = colorset[FishTier];
            }
        }
    }
}
