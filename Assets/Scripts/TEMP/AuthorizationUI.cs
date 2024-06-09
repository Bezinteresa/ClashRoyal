using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationUI : MonoBehaviour
{
    [SerializeField] private Authorization _authorization;
    [SerializeField] private InputField _login;
    [SerializeField] private InputField _password;
    [SerializeField] private Button _signIn;
    [SerializeField] private Button _signUp;

    private void Awake()
    {
        _login.onEndEdit.AddListener(_authorization.SetLogin);
        _password.onEndEdit.AddListener(_authorization.SetPassword);

        _signIn.onClick.AddListener(SignInClick);

        //Сделать отдельный метод вместо безымянного 
        _authorization.Error += () =>
        {
            _signIn.gameObject.SetActive(true);
            _signUp.gameObject.SetActive(true);
        };
    }

    private void SignInClick()
    {
        _signIn.gameObject.SetActive(false);
        _signUp.gameObject.SetActive(false);
        _authorization.SignIn();
    }

}
