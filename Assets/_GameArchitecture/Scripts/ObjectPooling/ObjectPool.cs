using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
/// <summary>
/// TT- Notes on ObjectPool: 
/// object pooling- Instead of destroying and instantiating objects, a pool can be created that will grab and then return an object to a pool after use.
/// This optimizes memory allocation. object pooling is used across multiple mechanics and instances within the game.
/// Endless runner games are a good example of this utilization.
/// ObjectPool has a list of used "pooled objects" as well as objects currently residing in the pool,
/// alongside a reference to PooledObject for load in. 
/// </summary>
public class ObjectPool : MonoBehaviour
{

    public GameObject objectToPool;
    public int startSize;

    [SerializeField] private List<PooledObject> _objectPool = new List<PooledObject>();
    [SerializeField] private List<PooledObject> _usedPool = new List<PooledObject>();

    private PooledObject _tempObject;
    void Start()
    {
        
    }
    /// <summary>
    /// TT: Initialize our pool to add new objects to the pool. 
    /// </summary>
    private void Initialize()
    {
        // loop through  our start size using a for loop, adding a new object to the for loop each time. 
        for (int i = 0; i < startSize; i++)
        {
            AddNewObject(); //Add a new object to pool
        }
    }

    /// <summary>
    /// TT :  A.N.O use our tempObjects to keep track of current objects we are instantiating and 
    /// adding to our pool 
    /// 
    /// </summary>
    private void AddNewObject()
    {
        // instantiate objectToPool at the parent transform of the PooledObject G.O.  transform in Unity. 
        _tempObject = Instantiate(objectToPool, transform).GetComponent<PooledObject>();
        _tempObject.gameObject.SetActive(false);
        //grab access P.O-S.O.P  informing temppooledobject that this is the pool it belongs to 
        _tempObject.SetObjectPool(this);
        // add tempObject to list 
        _objectPool.Add(_tempObject);
        
    }
    /// <summary>
    /// TT : P.O G.P.O 
    ///  in order for other classes to use our pooled object, we will return the pooled object. 
    /// </summary>
    /// <returns></returns>

    public PooledObject GetPooledObject()
    {
        PooledObject tempObjectToReturn;
        // adding dynamism to pool via taking the count and checking if at least one, then totr equals first object
        // pool element 
        if (_objectPool.Count > 0)
        {
            tempObjectToReturn = _objectPool[0];
            // tOTR goes into uP
            _usedPool.Add(tempObjectToReturn);
            // removed tOTR at first element, so that revolving objects are consistenly at position 0.
            _objectPool.RemoveAt(0);
        }
        else
        {
            // dynamically increase the size of our object pool list. 
            AddNewObject();
            // recursion- calling a method within the method. ensuring  an exit condition (the if) 
            tempObjectToReturn = GetPooledObject();
        }

        tempObjectToReturn.gameObject.SetActive(true);
        // notes that this has been used 
        tempObjectToReturn.ResetObject();
        //return to pool 
        return tempObjectToReturn;
    }
    /// <summary>
    /// TT: D.P.O 
    /// destroys pooled object when timer runs out or at x amount of time specified 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="time"></param>
    public void DestroyPooledObject(PooledObject obj, float time = 0)
    {
        if (time == 0)
        {
            obj.Destroy();
        }
        else
        {
            obj.Destroy(time);
        }
    }

/// <summary>
/// TT: R.O
/// removes obj from used pool into end of object pool list 
/// </summary>
/// <param name="obj"></param>
    public void RestoreObject(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        _usedPool.Remove(obj);
        _objectPool.Add(obj);
    }
}
