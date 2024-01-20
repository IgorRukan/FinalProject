using UnityEngine;

public class UI : MonoBehaviour
{
    public void EnableAndDisable(GameObject go)
    {
        bool state;
        state = !go.activeSelf;
        go.gameObject.SetActive(state);
    }
}
