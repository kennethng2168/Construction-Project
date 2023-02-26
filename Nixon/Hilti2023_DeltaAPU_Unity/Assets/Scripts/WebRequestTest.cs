using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestTest : MonoBehaviour
{
    [SerializeField] private string URL;

    private void Start()
    {
        StartCoroutine(Upload());
    }

    private IEnumerator Upload()
    {
        string data = "{ \"sender\":\"test\", \"message\":\"hey\" }";

        // UnityWebRequest request = UnityWebRequest.PostWwwForm(URL, data);
        UnityWebRequest request = new UnityWebRequest(URL, "POST");

        request.uploadHandler = new UploadHandlerRaw(new System.Text.UTF8Encoding().GetBytes(data));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            request.Dispose();
        } else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }
}
