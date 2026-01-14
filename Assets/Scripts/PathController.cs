using UnityEngine;

public class PathController : MonoBehaviour
{
    public GameObject[] WayPoint;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < WayPoint.Length; i++)
        {
            if (i < WayPoint.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(WayPoint[i].transform.position, WayPoint[i+1].transform.position);
            }
        }
    }
    public Vector3 GetPosition(int index)
    {
        return WayPoint[index].transform.position;
    }
}
