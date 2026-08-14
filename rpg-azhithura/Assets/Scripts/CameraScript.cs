using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject mapPoints;

    float[] distances;

    void OnEnable()
    {
        distances = new float[mapPoints.transform.childCount];
    }

    void LateUpdate()
    {
        transform.position = getClosestMapPoint();

    }

    Vector3 getClosestMapPoint()
    {
        float lowestValue = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = Vector2.Distance(mapPoints.transform.GetChild(i).transform.position, targetObject.transform.position);
            if (distances[i] < lowestValue)
            {
                index = i;
                lowestValue = distances[i];
            }
        }
        return new Vector3(mapPoints.transform.GetChild(index).position.x, mapPoints.transform.GetChild(index).position.y, -10);
    }
}
