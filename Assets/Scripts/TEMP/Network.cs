using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network : MonoBehaviour
{
    //��� ������ �� �����
    //[SerializeField] private string URL;

    #region Singleton
    public static Network Instance {  get; private set; }
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void Post(string url, Dictionary<string, string> data, Action<string> success, Action<string> error = null) 
        => StartCoroutine(PostAsync(url,data,success,error));

    private IEnumerator PostAsync(string url, Dictionary<string, string> data, Action<string> success, Action<string> error = null)
    {
        #region Example with WWWForm and List<IMultipartFormSection>
        // 1)  ������� ���� ���� ��������
        WWWForm form = new WWWForm();
        form.AddField("Login", "Barsik");

        // 2) ������� ���� ����� ��������
        List<IMultipartFormSection> sections = new List<IMultipartFormSection>();
        IMultipartFormSection section = new MultipartFormDataSection("Login", "Barsik");

        sections.Add(section);

        // � ������ Post( , form ��� sections) 
        //using (UnityWebRequest www = UnityWebRequest.Post(url, sections))
        #endregion

        // ��� ��� Dispose ���� ������������ using ;
        using (UnityWebRequest www = UnityWebRequest.Post(url, data))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) error?.Invoke(www.error);
            else success?.Invoke(www.downloadHandler.text);
        }

        #region Coment
        ////�������� ���������� ��������� URL
        //UnityWebRequest www = UnityWebRequest.Get(url);

        //yield return www.SendWebRequest();

        //if (www.result != UnityWebRequest.Result.Success)
        //{
        //    error?.Invoke(www.error);
        //} else
        //{
        //    callback?.Invoke(www.downloadHandler.text);
        //}

        ////������� ��������� URL
        //www.Dispose();
        #endregion

    }


}
