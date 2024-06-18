using System;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{
    private const string LOGIN = "login";
    private const string PASSWORD = "password";
    private string _login;
    private string _password;
    private string _confirmPassword;

    public event Action Error;
    public event Action Succes;

    public void SetLogin(string login)
    {
        _login = login;
    }

    public void SetPassword(string password)
    {
        _password = password;
    }

    public void SetConfirmPassword(string confirmPassword)
    {
        _confirmPassword = confirmPassword;
    }

    public void SignUp()
    {
        //проверка на пустые символы
        if (string.IsNullOrEmpty(_login) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_confirmPassword))
        {
            ErrorMessage("Логин или пароль пустые");
            return;
        }

        //Пароли совпадают
        if(_password != _confirmPassword)
        {
            ErrorMessage("пароли не совпадают: ");
            return;
        }

        string url = URLLibrary.MAIN + URLLibrary.REGISTRATION;
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            {LOGIN, _login},
            {PASSWORD, _password}

        };
        Network.Instance.Post(url, data, SuccessMessage, ErrorMessage);
    }

    private void SuccessMessage(string data)
    {

        string[] result = data.Split('|');
        if (data != "ok")
        {
            ErrorMessage("ОТвет сервера  пришел вот такой: " + data);
            return;
        }

        Debug.Log("Успешная регистрация");
        Succes?.Invoke();
    }

    public void ErrorMessage(string error)
    {
        Debug.LogError(error);
        Error?.Invoke();
    }

}
