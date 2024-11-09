using UnityEngine;

public class DieHandler : MonoBehaviour
{
    public void Die()
    {
        Debug.Log($"{gameObject.name} умер");

        Destroy(gameObject);
    }
}