using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Defective.JSON;

public class WeatherAPI : MonoBehaviour
{
    [SerializeField] private string m_APIKey = "edbbd1d7b50f468668e1e376376f730d";
    [SerializeField] private string m_URL = "http://api.openweathermap.org/data/2.5/weather";
    [SerializeField] private string m_City = "Kuala Lumpur";

    private void Start()
    {
        StartCoroutine(RequestWeatherData());
    }

    private IEnumerator RequestWeatherData()
    {
        string requestURL = this.m_URL + "?appid=" + this.m_APIKey + "&q=" + this.m_City + "&units=metric";
        UnityWebRequest request = UnityWebRequest.Get(requestURL);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            request.Dispose();
        } else
        {
            JSONObject jsonObj = new JSONObject(request.downloadHandler.text);
            Debug.Log(jsonObj["weather"]);
            request.Dispose();
        }
    }
}
