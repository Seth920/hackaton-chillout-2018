using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events: Singleton<Events> {

    public delegate void AerialAssembled_Event(GameObject aerial);
    public AerialAssembled_Event aerialAssembled_Event;

    public delegate void AllAerialsAssembled_Event();
    public AllAerialsAssembled_Event allAerialsAssembled_Event;

}
