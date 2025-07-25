using System;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsController : MonoBehaviour
{
    [SerializeField] private AnimationsData data;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationsName previousAnimations;
    [SerializeField] private AnimationsName currentAnimations;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (data == null)
        {
            Debug.LogWarning($"Animations Data is Empty => {data}");
            return;
        }
    }

    public void PlayAnimations(string _animation) => animator.Play(FindAnimations(_animation, data));

    string FindAnimations(string _targetName, AnimationsData _data)
    {
        previousAnimations = currentAnimations;

        AnimationsName nextAnimations = _data._name.Find(x => x.ID == _targetName);

        currentAnimations = nextAnimations;
        return currentAnimations.AnimatorName;
    }
}
