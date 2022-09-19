using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public GameObject pickUpEffect;
    public Text coinText;
    int cointCount=0;
    void Start()
    {
        cointCount = PlayerPrefs.GetInt("Coin", 0);
        coinText.text = cointCount.ToString();
    }

    private void OnEnable()
    {
        Coin.onCoinCollect += CollectCoins;
    }
    void Update()
    {
        coinText.text   = cointCount.ToString();
    }
    public void CollectCoins(GameObject collided ,int coin)
    {
        if (collided.tag=="Player" )
        {

            cointCount += coin;
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Coin", cointCount);
            AudioManager.instance.PlaySound("coin");
        }
    }
       private void OnDisable()
    {
        Coin.onCoinCollect -= CollectCoins;
    }
}
