using System;
using UnityEngine;

public class TestingEvents : MonoBehaviour {
    public event SpacePressedHandler onSpacePressed;
    public event WPressedHandler onWPressed;
    public delegate void SpacePressedHandler();
    public delegate void WPressedHandler(Vector3 location);

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            onSpacePressed?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            onWPressed?.Invoke(new(0, 0, -5));
        }
    }
}
