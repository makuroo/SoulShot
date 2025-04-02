using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    [Range(1, 20)]
    public float smoothFactor;

    public Vector3 offset = new Vector3(0,0,-0.3f);
    public Vector3 minValue = new Vector3(0, 0, -0.3f);
    public Vector3 maxValue = new Vector3(0, 0, -0.3f);
     void FixedUpdate()
     {
        Follow();
     }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 boundPos = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
                                        Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
                                        Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPos, smoothFactor * Time.deltaTime);

        transform.position = smoothPosition;
    }


}
