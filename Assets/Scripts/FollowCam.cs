using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // Ссылка на интересующий обьект
    [Header("Set In Inspetor")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;


    [Header("Set Dynamically")]
    public float camZ; // Желаемая координата Z камеры

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //Однострочная версия if не требует фигурных скобок
        if (POI == null) return;

        Vector3 destination = POI.transform.position;

        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }
}
