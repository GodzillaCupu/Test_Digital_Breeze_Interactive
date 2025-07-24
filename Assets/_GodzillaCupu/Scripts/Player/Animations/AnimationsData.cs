using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationsData", menuName = "Scriptable Objects/AnimationsData")]
public class AnimationsData : ScriptableObject
{
    public List<AnimationsName> _name;
}

[Serializable]
public class AnimationsName
{
    public string ID;
    public string AnimatorName;
}
