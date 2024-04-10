using System.Collections;
using UnityEngine;

public abstract class UnitState : ScriptableObject
{

    protected Unit _unit;
    public void Constructor(Unit unit) {
        _unit = unit;
    }

    public abstract void Init();
    public abstract void Finish();
    public abstract void Run();
    


}
