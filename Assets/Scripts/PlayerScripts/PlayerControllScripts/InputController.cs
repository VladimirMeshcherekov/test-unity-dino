using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject _player;
    private IControlable _controlableObject;
    private void Start()
    {
        _controlableObject = _player.GetComponent<IControlable>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IControlable");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controlableObject.Jump();
        }
        
        
    }
}
