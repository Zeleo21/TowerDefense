using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public TMP_Text moneyText;

    public void Start()
    {
        if (moneyText == null)
        {
            Debug.Log("THIS IS NOT THE WAY TO GO");
        }
    }
    void Update()
    {
        moneyText.text = PlayerStats.instance.playerMoney.ToString();
    }
}
