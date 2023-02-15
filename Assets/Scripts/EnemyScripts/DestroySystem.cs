using UnityEngine;

public class DestroySystem : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
       col.gameObject.transform.parent.gameObject.SetActive(false);
   }
}
