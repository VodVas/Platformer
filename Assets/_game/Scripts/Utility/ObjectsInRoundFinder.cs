using UnityEngine;

public class ObjectsInRoundFinder : MonoBehaviour
{
    public T FindNearestObject<T>(float radius) where T : Component
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        T nearestObject = null;

        float minDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            T obj = collider.GetComponent<T>();

            if (obj != null)
            {
                float distance = Vector2.Distance(transform.position, obj.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = obj;
                }
            }
        }

        return nearestObject;
    }
}