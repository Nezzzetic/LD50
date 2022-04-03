using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float Speed => _getSpeed();
    public float DefaultSpeed;
    public float SlowSpeed;
    public OneDirectionMovement Movement;
    public InputController InputController;
    public int IntersecCount;
    public List<Moveable> Intersec;
    public bool Slow=>Intersec.Count > 0;
    // Start is called before the first frame update
    void Start()
    {
        _updateSpeed();
    }

    // Update is called once per frame

    void _updateSpeed()
    {
        Movement.Speed = _getSpeed();
    }
    
    float _getSpeed()
    {
        if (Intersec.Count > 0) return SlowSpeed;
        return DefaultSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        var mov = other.GetComponent<Moveable>();
        if (mov != null) _consumeObjectStart(mov);
        
    }
    void OnTriggerExit(Collider other)
    {
        var mov = other.GetComponent<Moveable>();
        if (mov != null && Intersec.Contains(mov)) _consumeObjectEnd(mov);
    }

    void _consumeObjectStart(Moveable obj)
    {
        InputController.DropObj();
        Intersec.Add(obj);
        obj.OnLavaAction();
        _updateSpeed();
    }
    
    void _consumeObjectEnd(Moveable obj)
    {
        Intersec.Remove(obj);
        obj.OnLavaFinishAction();
        _updateSpeed();
    }
}
