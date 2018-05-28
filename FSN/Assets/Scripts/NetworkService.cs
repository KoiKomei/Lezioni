using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkService {
    private const string webImage="http://i.4cdn.org/vg/1527127764597.jpg";
    private const string xmlApi ="http://api.openweathermap.org/data/2.5/weather?q=cosenza,it&mode=xml&appid=e17b870eb05c8c85896ff6ca22e9d10d";
    private const string localApi = "";
    public IEnumerator GetWeatherXML(Action<string> callback) {
        return CallAPI(xmlApi, null, callback);
    }

    public IEnumerator LogWeather(string name, float cloudvalue, Action<string> callback) {
        Hashtable args = new Hashtable();
        args.Add("message", name);
        args.Add("cloud_value", cloudvalue);
        args.Add("timestamp", DateTime.UtcNow);
        return CallAPI(localApi, args, callback);
    }
    public IEnumerator DownloadImage(Action<Texture2D> callback) {
        WWW www = new WWW(webImage);
        yield return www;
        callback(www.texture);
    }


    private IEnumerator CallAPI(string url, Hashtable args, Action<string> callback) {
        WWW www;
        if (args == null)
        {
            www = new WWW(url);
        }
        else {
            WWWForm form = new WWWForm();
            foreach (DictionaryEntry arg in args) {
                form.AddField(arg.Key.ToString(), arg.Value.ToString());
            }
            www = new WWW(url, form);
        }
        yield return www;
        if (!IsResponseValid(www)) {
            yield break;
        }
        callback(www.text);
    }


    private bool IsResponseValid(WWW www)
    {
        if (www.error != null) {
            Debug.Log("bad connection");
            return false;
        }
        else {
            if (string.IsNullOrEmpty(www.text)){
                Debug.Log("bad data");
                return false;
            }
            else {
                return true;
            }
        }
    }




}

