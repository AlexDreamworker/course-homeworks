namespace Homework1.Task4
{
    public interface IReadOnlyBall
    {
        Ball IReadOnlyBall { get; }
        ColorType ColorType { get; }
        bool IsActive { get; }
    }
}