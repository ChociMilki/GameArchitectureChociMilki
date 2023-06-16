using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///Loot box = builder 
/// </summary>
public class Builder : MonoBehaviour
{
    [Header("Loot Box Properties")]
    [SerializeField] private GameObject _loot;
    [SerializeField] private Transform _placementPoint; 

    public void Build()
    {
        Instantiate(_loot,  _placementPoint.position, _placementPoint.rotation);
        Destroy(gameObject); 

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
