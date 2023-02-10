using UnityEngine;
using System.Collections;

public class Instantiater : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject teleportTarget;

    TestingEvents eventHolder;

    private void Awake() {
        eventHolder = GetComponent<TestingEvents>();
    }

    private void Start() {
        eventHolder.onSpacePressed += EventHolder_onSpacePressed;
        eventHolder.onWPressed += EventHolder_onWPressed;
    }

    private void EventHolder_onWPressed(Vector3 location) {
        teleportTarget.transform.position = location;
    }

    private void EventHolder_onSpacePressed() {
        GameObject obj = Instantiate(prefab, transform);
        StartCoroutine(Murder(obj));
    }

    private IEnumerator Murder(GameObject obj) {
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }
}
