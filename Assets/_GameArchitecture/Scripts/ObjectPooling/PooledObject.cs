using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// TT: notes on Pooled Object: 
/// Contains info about the object and how it can be used. The context for utilization is to destroy our object, then restore and intialize it. 
/// When we shoot the bullet we spawn it as a P.O and after X seconds, we restore the object back to the pool.
/// PooledObject represents each object and ObjectPooled has a list of pooled objects being used, as well as objects that are still within the pool. OP tracks PO.
/// </summary>
public class PooledObject : MonoBehaviour
{
    [SerializeField] private UnityEvent _onReset;


    private bool _setToDestroy = false;
    private float _timeToDestroy = 0;
    private float _timer;

    ObjectPool _associatedPool;

    /// <summary>
    /// TT: S.P.O  for O.P.
    /// </summary>
    /// <param name="pool"></param>
    public void SetObjectPool(ObjectPool pool)
    {
        _associatedPool = pool;
        _timer = 0;
        _timeToDestroy = 0;
        _setToDestroy = false;
    }
    /// <summary>
    /// TT: Update if sTD is true, the timer checks if tTD is lesser than current value, sTD false and timer resets to O. 
    /// </summary>
    void Update()
    {
        if (_setToDestroy)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToDestroy)
            {
                _setToDestroy = false;
                _timer = 0;
                Destroy();
            }
        }
    }
    /// <summary>
    /// TT: Destroy - deactivates object using destroy
    /// </summary>
    public void Destroy()
    {
        if (_associatedPool != null)
        {
            //ObjectPool should restore this pooled object. 
            _associatedPool.RestoreObject(this);
        }
    }
    /// <summary>
    /// TT: Destroy(floattime)- method overload of Destroy that takes in ft , sets sTD to true, and tTD as the current time value. 
    /// </summary>
    /// <param name="time"></param>
    public void Destroy(float time)
    {
        _setToDestroy = true;
        _timeToDestroy = time;
    }
    /// <summary>
    /// TT: ResetObject - gets object back into pool using an event. 
    /// </summary>
    public void ResetObject()
    {
        // adds null to ensure if onReset is null so as to not invoke. ? best used for events.
        _onReset?.Invoke();
    }
}
