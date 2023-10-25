using UnityEngine;

public class Collectible : MonoBehaviour
{
   public virtual void Collect(GameObject collector)
    {
        Destroy(gameObject);
    }
}
