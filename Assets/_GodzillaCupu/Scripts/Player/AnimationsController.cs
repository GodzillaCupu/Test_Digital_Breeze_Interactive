using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    public void Transitions(string _param)
    {

    }
}
