using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLight
{
    public InLight(SunLight inl, SunLight outl) { inLight = inl; outLight = outl; }
    public SunLight inLight;
    public SunLight outLight;

};