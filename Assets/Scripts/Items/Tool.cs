using UnityEngine;
using System.Collections;

public interface Tool {

    void triggerPull();
    void triggerRelease();
    void gripPull();
    void gripRelease();

    void touchpadPos(Vector2 touchpadPos);
}
