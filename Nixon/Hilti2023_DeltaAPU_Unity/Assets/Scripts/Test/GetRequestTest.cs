using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRequestTest : MonoBehaviour
{
    [SerializeField] private string m_URL;

    private void Start()
    {
        this.StartCoroutine(GetRequest());
    }

    private IEnumerator GetRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(m_URL);
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
