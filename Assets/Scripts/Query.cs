using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using System.IO;
using AsImpL;
using Siccity.GLTFUtility;
using System.Globalization;
using UnityEngine.Video;

public class Query : MonoBehaviour
{
    [SerializeField]
    GameObject echoPreFab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject echo = GameObject.Find("echoAR");
        if (echo)
        {
            Vector3 pos = echo.transform.position;
            Destroy(echo);
            echo = Instantiate(echoPreFab, pos, Quaternion.identity);
        }
        else
        {
            echo = Instantiate(echoPreFab, Vector3.zero, Quaternion.identity);
        }

        echo.GetComponent<echoAR>().company = "GOOGLE";

        echo.GetComponent<echoAR>().Init();
    }

    //IEnumerator GetQuery()
    //{
    //    Debug.Log("hello from query");
    //    string data = "&data=company";
    //    string value = "&value=GOOGLE";
    //    string fetch = url + key + data + value;
    //    UnityWebRequest query = UnityWebRequest.Get(fetch);
    //    yield return query.SendWebRequest();

    //    if (query.isNetworkError || query.isHttpError)
    //    {
    //        Debug.Log(query.result);
    //        Debug.LogError(query.error);
    //        yield break;
    //    }
    //    else
    //    {
    //        JSONNode queryJson = JSON.Parse(query.downloadHandler.text);
    //        print(queryJson.ToString());
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
