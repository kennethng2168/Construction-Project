using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class VideoStreamTest : MonoBehaviour
{
    [SerializeField] private string m_URL;
    [SerializeField] private Texture m_Texture;
    private Coroutine m_RequestCoroutine;

    private void Start()
    {
        this.m_RequestCoroutine = this.StartCoroutine(GetRequest());
    }

    private void Update()
    {
    }

    private IEnumerator GetRequest()
    {
        Debug.Log("Start GetRequest");
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(m_URL);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "image/jpeg");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            request.Dispose();
        } else
        {
            this.m_Texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Debug.Log("Success");
            request.Dispose();
        }
        Debug.Log("Stop GetRequest");
    }
}
