using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject followerPrefab; // Prefab of the small copy
    public int maxFollowers = 5; // Maximum number of small copies
    public float spacing = 1.0f; // Spacing between followers
    public float followSpeed = 5.0f; // Speed at which followers move toward the main object

    private Transform mainObject;
    private GameObject[] followers;

    void Start()
    {
        mainObject = transform; // Assuming the script is attached to the main object

        // Initialize followers array
        followers = new GameObject[maxFollowers];
    }

    void Update()
    {
        // Spawn a new follower if there's room
        if (Input.GetKeyDown(KeyCode.Space) && followers.Length < maxFollowers)
        {
            GameObject newFollower = Instantiate(followerPrefab, transform.position, Quaternion.identity);
            ArrayUtility.Add(ref followers, newFollower);
        }

        // Move each follower toward the main object
        for (int i = 0; i < followers.Length; i++)
        {
            if (followers[i] != null)
            {
                Vector3 targetPosition = mainObject.position - new Vector3(0, spacing * (i + 1), 0);
                followers[i].transform.position = Vector3.MoveTowards(followers[i].transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }

        // Update the position of the main object
        Vector3 newPosition = mainObject.position;

        // Apply additional movement to mimic the main object's velocity
        float additionalMovement = 0.1f; // Adjust this value based on your preference
        newPosition.x += mainObject.GetComponent<Rigidbody2D>().velocity.x * additionalMovement;

        // Update the position of the followers
        for (int i = 0; i < followers.Length; i++)
        {
            if (followers[i] != null)
            {
                Vector3 targetPosition = newPosition - new Vector3(0, spacing * (i + 1), 0);
                followers[i].transform.position = Vector3.MoveTowards(followers[i].transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}

