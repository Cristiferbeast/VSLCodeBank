public class Movement2D : MonoBehavior {
    public float speed;
    public RigidBody2D body;

    void Update(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Verticle");
        body.velocity = new vector ?(h*speed, v*speed);
    }
}