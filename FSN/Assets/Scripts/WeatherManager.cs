using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    public float cloudValue { get; private set; }

	public void Startup () {
        Debug.Log("Weather manager starting...");
        _network = new NetworkService();
        //StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));
        //StartCoroutine(_network.GetWeatherJSON(OnJSONDataLoaded));
        status = ManagerStatus.Started;
	}
    public void OnXMLDataLoaded(string data) {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;
        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["Value"].Value;
        cloudValue = XmlConvert.ToInt32(value) / 100f;
        Debug.Log("Value: " + cloudValue);
        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
        status = ManagerStatus.Started;
    }
    public void OnJSONDataLoaded(string data) {
        //Dictionary<string, object> dict;
       // dict = (Dictionary<string, object>)Json.Deserialize(data);
        //Dictionary<string, object> clouds = (Dictionary<string, object>)dict["clouds"];
        //cloudValue = XmlConvert.ToInt32(clouds["all"]) / 100f;
    }
    public void LogWeather(string name) {
        StartCoroutine(_network.LogWeather(name, cloudValue, OnLogged));
    }
    private void OnLogged(string response) {
        Debug.Log(response);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
