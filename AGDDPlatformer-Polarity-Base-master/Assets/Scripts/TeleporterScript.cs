using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGDDPlatformer {
    public class TeleporterScript : MonoBehaviour {
        [SerializeField] GameObject exit;

        private void OnTriggerEnter2D(Collider2D collision) {
            collision.transform.position = exit.transform.position + collision.transform.localScale.y * exit.transform.up;
            PlayerController pc = collision.GetComponent<PlayerController>();

            pc.velocity = -pc.velocity;
        }
    }
}