using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    // References to each planet (excluding Pluto)
    public GameObject mercury;
    public GameObject venus;
    public GameObject earth;
    public GameObject mars;
    public GameObject jupiter;
    public GameObject saturn;
    public GameObject uranus;

    // Speeds at which each planet will revolve (relative to Earth)
    public float mercurySpeed = 83f;
    public float venusSpeed = 32.4f;
    public float earthSpeed = 20f;
    public float marsSpeed = 10.6f;
    public float jupiterSpeed = 1.6f;
    public float saturnSpeed = 0.6f;
    public float uranusSpeed = 0.22f;

    // Distances of each planet from the Sun (in relative units)
    public float mercuryDistance = 3.9f;
    public float venusDistance = 7.2f;
    public float earthDistance = 10f;
    public float marsDistance = 15.2f;
    public float jupiterDistance = 52f;
    public float saturnDistance = 95.8f;
    public float uranusDistance = 192.2f;

    void Update()
    {
        // Rotate each planet around the Sun (this object's position)

        if (mercury != null)
            OrbitPlanet(mercury, mercurySpeed, mercuryDistance);

        if (venus != null)
            OrbitPlanet(venus, venusSpeed, venusDistance);

        if (earth != null)
            OrbitPlanet(earth, earthSpeed, earthDistance);

        if (mars != null)
            OrbitPlanet(mars, marsSpeed, marsDistance);

        if (jupiter != null)
            OrbitPlanet(jupiter, jupiterSpeed, jupiterDistance);

        if (saturn != null)
            OrbitPlanet(saturn, saturnSpeed, saturnDistance);

        if (uranus != null)
            OrbitPlanet(uranus, uranusSpeed, uranusDistance);

    }

    // Helper method to orbit a planet
    void OrbitPlanet(GameObject planet, float speed, float distance)
    {
        planet.transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);

        // Maintain the planet's distance from the Sun
        Vector3 directionFromSun = (planet.transform.position - transform.position).normalized;
        planet.transform.position = transform.position + directionFromSun * distance;
    }
}
