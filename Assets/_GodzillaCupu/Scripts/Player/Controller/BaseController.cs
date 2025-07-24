using UnityEngine;

public interface BaseController
{
    StateManager StateManager { get; set; }
    Rigidbody2D Rigidbody { get; set; }
    AnimationsController Animation { get; set; }
}
