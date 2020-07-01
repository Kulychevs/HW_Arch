internal sealed class LowerJaw : Jaws
{
    public override void RotateJaw(float rotationSpeed)
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
