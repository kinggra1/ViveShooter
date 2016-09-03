using UnityEngine;
using System.Collections;

public interface Destructible {

    void destroy();
    void hit(float damage);
    void knockBack(Vector3 direction, float force);
}
