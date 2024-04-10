
using UnityEngine;

public class Unit : MonoBehaviour
{

    //Default
    //Chase
    //Attack
    [SerializeField] private UnitState _defaultStateSO;
    [SerializeField] private UnitState _chaseStateSO;
    [SerializeField] private UnitState _attackStateSO;
     private UnitState _defaultState;
     private UnitState _chaseState;
     private UnitState _attackState;
    private UnitState _currentState;

    private void Start() {
        _defaultState = Instantiate(_defaultStateSO);
        _defaultState.Constructor(this);
        _chaseState = Instantiate(_chaseStateSO);
        _chaseState.Constructor(this);
        _attackState = Instantiate(_attackStateSO);
        _attackState.Constructor(this);

        _currentState = _defaultState;
        _chaseState.Init();
    }

    private void Update() {
        
        _currentState.Run();


    }



}
