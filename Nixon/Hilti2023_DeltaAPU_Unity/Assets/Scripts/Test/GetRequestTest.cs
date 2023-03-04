using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRequestTest : MonoBehaviour
{
    [SerializeField] private string URL;
    private Coroutine m_RequestCoroutine;

    private void Start()
    {
        this.m_RequestCoroutine = StartCoroutine(GetRequest());
    }

    private IEnumerator GetRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
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
