using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginManager : MonoBehaviour
{
    //InputField => ���̵�� ��й�ȣ
    //1. �α��� Ȯ���ϴ� �Լ�
    //2. id password 2�� ���� ����
    //3. PlayerPrefs.GetString("ID").PlayerPrefs.GetString("password")
    //�� InputField.text
    //== != 

    //�۱��ϱ� �Լ� ����
    //�۱��ϱ� �Ҷ� InputField ���̵�� PlayerPrefs ���̵� ���ٸ� ���� �۱�
    //�ٸ��ٸ� ����� �����ϴ� â
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

    //poiu4018�̶� �۱� ���̴ٰ� ������ money��� ������ 
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
