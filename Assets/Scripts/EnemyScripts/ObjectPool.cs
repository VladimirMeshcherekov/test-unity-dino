using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;


    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefab)
    {
        for (int i = 0; i < _capacity; i++) 
        { 
            GameObject spawned = Instantiate(prefab[Random.Range(0, prefab.Length)], _container.transform); 
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
        
    }

    protected bool TryGetObject(out GameObject result)
    {
        int randomElement = Random.Range(0, _capacity);
        while (!_pool[randomElement].activeSelf == false)
        {
           randomElement = Random.Range(0, _capacity);
        }
       
        result = _pool[randomElement];  //(p => p.activeSelf == false);
        return result != null;  
    }
}
