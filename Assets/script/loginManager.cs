using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginManager : MonoBehaviour
{
    //InputField => 아이디랑 비밀번호
    //1. 로그인 확인하는 함수
    //2. id password 2개 변수 선언
    //3. PlayerPrefs.GetString("ID").PlayerPrefs.GetString("password")
    //비교 InputField.text
    //== != 

    //송금하기 함수 제작
    //송금하기 할때 InputField 아이디랑 PlayerPrefs 아이디가 같다면 돈을 송금
    //다르다면 대상이 없습니다 창
    public InputField ID_InputField;
    public InputField Password_InputField;
    public GameObject BackGround;
    public GameObject popupLoginError;
    public GameObject Loginwindow;
    public InputField RemittanceInputField;
    public int money;
    public InputField input;
    public void login()
    {
        string inputID = ID_InputField.text;
        string inputPW = Password_InputField.text;

        string savedID = PlayerPrefs.GetString(ID_InputField.text);
        string savedPW = PlayerPrefs.GetString(Password_InputField.text);

        if(inputID == savedID && inputPW == savedPW)
        {
            BackGround.SetActive(true);
            Loginwindow.SetActive(false);
        }
        else
        {
            popupLoginError.SetActive(true);
        }
    }

    //poiu4018이랑 송금 아이다가 같으면 money라는 변수에 
    public void Remittance()
    {
        Debug.Log(RemittanceInputField.text);
        if (PlayerPrefs.GetString("poiu4018") == RemittanceInputField.text)
        {
            Debug.Log("asdf");
            money = int.Parse(input.text);
            PlayerPrefs.SetInt("bankBalance",PlayerPrefs.GetInt("bankBalance") - money);
            PlayerPrefs.SetInt("cash2", GameManager.Instance.userData.cash += money);
        }
        else
        {
            popupLoginError.SetActive(true);
        }
    }
    public void Start()
    {
        Debug.Log(PlayerPrefs.GetString(ID_InputField.text));
        Debug.Log(PlayerPrefs.GetString(Password_InputField.text));
    }
}
