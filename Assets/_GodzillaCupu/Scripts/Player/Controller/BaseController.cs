using UnityEngine;

public interface IController
{
    StateManager StateManager { get; set; }
    Rigidbody2D Rigidbody { get; set; }
    AnimationsController Animation { get; set; }
}
