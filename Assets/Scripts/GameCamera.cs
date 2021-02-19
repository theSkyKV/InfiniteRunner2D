using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static float Border => Camera.main.orthographicSize / Camera.main.aspect;
}
