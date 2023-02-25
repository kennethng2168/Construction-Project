using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Upload());
    }

    private IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("sender", "test");
        form.AddField("message", "hello");

        UnityWebRequest www = UnityWebRequest.Post("https://c868-58-71-199-137.ap.ngrok.io/webhooks/rest/webhook ", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        } else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
