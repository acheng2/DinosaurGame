using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStats : MonoBehaviour {

    public static Dictionary<String, float> stats = new Dictionary<string, float>() {
        {"fatBirdDuckColliderOffsetX", -0.006280363f},
        {"fatBirdDuckColliderOffsetY", -0.03977588f},
        {"fatBirdDuckColliderSizeX", 0.3581308f},
        {"fatBirdDuckColliderSizeY", 0.3292703f},
        {"fatBirdRunColliderOffsetX", -0.004901543f},
        {"fatBirdRunColliderOffsetY", 0.006059974f},
        {"fatBirdRunColliderSizeX", 0.3144052f},
        {"fatBirdRunColliderSizeY", 0.4139446f},

        {"duckDuckColliderOffsetX", 0f},
        {"duckDuckColliderOffsetY", -0.05544222f},
        {"duckDuckColliderSizeX", 0.36f},
        {"duckDuckColliderSizeY", .22f},
        {"duckRunColliderOffsetX", 0f},
        {"duckRunColliderOffsetY", 0.01354327f},
        {"duckRunColliderSizeX", 0.36f},
        {"duckRunColliderSizeY", 0.3206607f}
    };

}
