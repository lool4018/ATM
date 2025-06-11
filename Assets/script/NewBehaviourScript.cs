using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    private int money = 100000;
    // Start is called before the first frame update
    void Start()
    {
        string formatted = money.ToString("N0");
        moneyText.text = formatted;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
